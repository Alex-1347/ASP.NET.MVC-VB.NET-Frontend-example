@ModelType Model.ViewLocation
@Code
    ViewData("Title") = "Location"
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
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Location
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "Location")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>View</th>
                                    <th>ID</th>
                                    <th>GPlaceId</th>
                                    <th>Latitude</th>
                                    <th>Longitude</th>
                                    <th>City</th>
                                    <th>Address</th>
                                    <th>CrDate</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-countries">
                                @If Model.DataListT IsNot Nothing Then
                                    @For I As Integer = 0 To Model.DataListT.Locations.Count - 1
                                        @<tr>
                                            <td>@Html.ActionLink("View", "ViewOneLocation", New With {.id = Model.DataListT.Locations(I).ID}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.Locations(I).ID</td>
                                            <td>@Model.DataListT.Locations(I).GPlaceId</td>
                                            <td>@Model.DataListT.Locations(I).Latitude</td>
                                            <td>@Model.DataListT.Locations(I).Longitude</td>
                                            <td>@Html.ActionLink(Model.DataListT.Locations(I).City, "ViewCity", "City", New With {.id = Model.DataListT.Locations(I).ToCity}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.Locations(I).Address</td>
                                            <td>@Model.DataListT.Locations(I).InsertedDateStr</td>

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
    <div Class="row" id="progress-panel" style="display: none;">
        <div Class="es-spinner-ring"></div>
    </div>
</div>
