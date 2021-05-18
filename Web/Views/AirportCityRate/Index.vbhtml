@modeltype Model.ViewAirCityRates

@Code 
    ViewData("Title") = "Airport-City Rates"
    ViewData("Selection") = "Rates"
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
                        Airport City Rate
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "AirportCityRate")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>View</th>
                                    <th>Delete</th>
                                    <th>Day/Nigth</th>
                                    <th>Rate</th>
                                    <th>DiscountRate</th>
                                    <th>Airport</th>
                                    <th>City</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-countries">
                                @If Model.DataListT.AirCityRates IsNot Nothing Then
                                    @For I As Integer = 0 To Model.DataListT.AirCityRates.Count - 1
                                        @<tr>
                                            <td>@Html.ActionLink("View", "View", New With {.id = Model.DataListT.AirCityRates(I).Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Html.ActionLink("DeleteRate", "DeleteRate", New With {.id = Model.DataListT.AirCityRates(I).Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@IIf(Model.DataListT.AirCityRates(I).Type = 1, "Day", "Night")</td>
                                            <td>@Model.DataListT.AirCityRates(I).Rate</td>
                                            <td>@Model.DataListT.AirCityRates(I).DiscountRate</td>
                                            <td>@Html.ActionLink(If(Model.DataListT.AirCityRates(I).Airports_EName, "Deleted"), "View", "Airport", New With {.id = Model.DataListT.AirCityRates(I).FromAirportId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Html.ActionLink(If(Model.DataListT.AirCityRates(I).Cities_EName, "Deleted"), "ViewCity", "City", New With {.id = Model.DataListT.AirCityRates(I).ToCityId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
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