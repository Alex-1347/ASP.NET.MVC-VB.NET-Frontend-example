@modeltype Model.ViewDocumentFile

@Code 
    ViewData("Title") = "ViewDocuments"
    ViewData("Selection") = "DriverRegistration"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Document</h4>
                </div>
                <div class="card-body">
                    @Using Html.BeginForm("DocumentUpdate", "Driver", New With {.DriverId = Model.DriverId, .DocId = Model.Id}, FormMethod.Post, New With {.onsubmit = "ShowWaitGif(event)"})
                    @<div class="row">
                        <div Class="table-responsive">
                            <Table Class="table">
                                <thead Class="text-danger">
                                    <tr>
                                        <th>@Resources.Driver.View.Type</th>
                                        <th>@Resources.Driver.View.Identifier</th>
                                        <th>@Resources.Driver.View.ValidFrom</th>
                                        <th>@Resources.Driver.View.ValidTo</th>
                                        <th>@Resources.Driver.View.Validation</th>
                                    </tr>
                                </thead>
                                <tbody id="table-body-documents">
                                    <tr>
                                        <td>@Model.TypeStr</td>
                                        <td>@Model.Identifier</td>
                                        <td>@Model.ValidFrom</td>
                                        <td>@Model.ValidTo</td>
                                        <td>@Model.Verified</td>
                                    </tr>
                                </tbody>
                            </Table>
                        </div>
                    </div>

                    @<div class="row">
                        @code
                            Dim ImgSrc As String = $"data:image/jpg;base64,{Model.EncodedDocument}"
                        End Code
                        <img src="@ImgSrc" class="img" id="driver-document" style="overflow:hidden;box-shadow: 0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);" />
                    </div>
                     @Html.AntiForgeryToken()

                    @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                        <input id="button-set-document-valid" class="btn btn-danger btn-round" type="submit" name="submitButton" value="Set document valid" />
                        <input id="button-set-document-delete" class="btn btn-danger btn-round" type="submit" name="submitButton" value="Delete document" />
                    </div>
                            End Using
                </div>
            </div>
        </div>

    </div>
    <div class="row" id="progress-panel" style="display: none;">
        <div class="es-spinner-ring"></div>
    </div>
</div>