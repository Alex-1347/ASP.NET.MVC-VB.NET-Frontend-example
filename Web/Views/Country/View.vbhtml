@modeltype List(Of Contract.CityCountry)
@Code       
    ViewData("Title") = "View Country"
    ViewData("Selection") = "Location"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ViewCountry.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Country</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("Country/Update", "Service", New AjaxOptions() With {.HttpMethod = "POST", .OnBegin = "OnUpdateCountryBegin", .OnSuccess = "OnUpdateCountrySuccess", .OnFailure = "OnUpdateCountryFailure"})
                        @<input type="hidden" name="input-country-id" id="input-country-id" class="form-control" />
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-country-hname">Name</label>
                                        @Html.TextBox("input-country-hname", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-country-ename">Name (English)</label>
                                        @Html.TextBox("input-country-ename", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-country-code">Country Code</label>
                                        @Html.TextBox("input-country-code", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-country-phone-code">Phone Code</label>
                                        @Html.TextBox("input-country-phone-code", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @*@Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-country-update-submit" class="btn btn-danger btn-round" type="submit" value="Update Country" />
                            <input id="button-country-delete-submit" class="btn btn-default btn-round" type="button" value="Delete Country" disabled />
                        </div>*@
                    End Using
                </div>
            </div>
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Cities</h4>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                          <Table class="table">
                            <tbody id="table-body-cities">
                                @If Model IsNot Nothing Then
                                    @For I As Integer = 0 To (Model.Count - 1) \ 4 + 4 Step 4
                                        @<tr>
                                             <td>
                                                 @If I <= Model.Count - 1 Then
                                                     @Html.ActionLink(Model(I).Cities_EName, "ViewCity", "City", New With {.id = Model(I).Cities_Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})
                                                 End If
                                             </td>
                                             <td>
                                                 @If I <= Model.Count - 2 Then
                                                     @Html.ActionLink(Model(I + 1).Cities_EName, "ViewCity", "City", New With {.id = Model(I + 1).Cities_Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})
                                                 End If
                                             </td>
                                             <td>
                                                 @If I <= Model.Count - 3 Then
                                                     @Html.ActionLink(Model(I + 2).Cities_EName, "ViewCity", "City", New With {.id = Model(I + 2).Cities_Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})
                                                 End If
                                             </td>
                                             <td>
                                                 @If I <= Model.Count - 4 Then
                                                     @Html.ActionLink(Model(I + 3).Cities_EName, "ViewCity", "City", New With {.id = Model(I + 3).Cities_Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})
                                                 End If
                                             </td> 
                                        </tr>
                                    Next
                                End If
                            </tbody>
                         </Table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div Class="row" id="progress-panel" style="display: none;">
        <div Class="es-spinner-ring"></div>
    </div>
</div>