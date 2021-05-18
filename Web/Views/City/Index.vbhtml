@ModelType Model.ViewCity
@Code
    ViewData("Title") = "Cities"
    ViewData("Selection") = "Location"
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
                    <h4 class="card-title">
                        Cities
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "City")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>View</th>
                                    <th>Name</th>
                                    <th>Name (Hebrew)</th>
                                    <th>Country</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-cities">
                                @If Model.DataListT IsNot Nothing Then
                                    @For I As Integer = 0 To Model.DataListT.Cities.Count - 1
                                        @<tr>
                                            <td>@Html.ActionLink("View", "ViewCity", "City", New With {.id = Model.DataListT.Cities(I).Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.Cities(I).EName</td>
                                            <td>@Model.DataListT.Cities(I).HName</td>
                                            <td>@Html.ActionLink(Model.DataListT.Cities(I).Country, "View", "Country", New With {.id = Model.DataListT.Cities(I).ToCountry}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                        </tr>
                                    Next
                                End If
                            </tbody>
                        </Table>
                    </div>
                    @Html.Partial("Pager", Model)
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="progress-panel" style="display: none;">
        <div class="es-spinner-ring"></div>
    </div>
</div>