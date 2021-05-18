@ModelType Model.ViewTrips
@Code
    ViewData("Title") = "Trip"
    ViewData("Selection") = "List"
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
                        Trip
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "Trip")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>View</th>
                                    <th>Created</th>
                                    <th>User</th>
                                    <th>Type</th>
                                    <th>RideType</th>
                                    <th>From</th>
                                    <th>To</th>
                                    <th>DepartureTime</th>
                                    <th>Sheduled</th>
                                    <th>BidEnabled</th>
                                    <th>FireType</th>
                                    <th>Fire</th>
                                    <th>Status</th>
                                    <th>PaymentMethod</th>
                                    <th>PaymentStatus</th>
                                    <th>Promotion</th>
                                    <th>Accept</th>
                                    <th>Note</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-countries">
                                @If Model.DataListT IsNot Nothing Then
                                    @For I As Integer = 0 To Model.DataListT.TripLocation.Count - 1
                                        @<tr>
                                            <td>@Html.ActionLink("View", "ViewOneTrip", New With {.id = Model.DataListT.TripLocation(I).Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.TripLocation(I).InsertDate</td>
                                            <td>@Html.ActionLink("User", "View", "User", New With {.id = Model.DataListT.TripLocation(I).UserId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.TripLocation(I).TypeStr </td>
                                            <td>
                                                @If String.IsNullOrEmpty(Model.DataListT.TripLocation(I).PaymentMethodId.ToString) Then
                                                    @Html.Raw("Undefined")
                                                Else
                                                    @Html.ActionLink("RideType", "View", "RideType", New With {.id = Model.DataListT.TripLocation(I).RideTypeId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})
                                                End If
                                            </td>
                                            <td>@Html.ActionLink(Model.DataListT.TripLocation(I).DepartureLocation_City, "ViewOneLocation", "Location", New With {.id = Model.DataListT.TripLocation(I).DepartureLocationId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Html.ActionLink(Model.DataListT.TripLocation(I).DestinationLocation_City, "ViewOneLocation", "Location", New With {.id = Model.DataListT.TripLocation(I).DestinationLocationId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.TripLocation(I).DepartureTime</td>
                                            <td>@Model.DataListT.TripLocation(I).Scheduled</td>
                                            <td>@Model.DataListT.TripLocation(I).BidEnabled</td>
                                            <td>@Model.DataListT.TripLocation(I).FareTypeStr </td>
                                            <td>@Html.ActionLink("Fire", "View", "Fire", New With {.id = Model.DataListT.TripLocation(I).FareId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.TripLocation(I).StatusStr</td>
                                            <td>
                                                @If String.IsNullOrEmpty(Model.DataListT.TripLocation(I).PaymentMethodId.ToString) Then
                                                    @Html.Raw("Undefined")
                                                Else
                                                    @Html.ActionLink("PaymentMethod", "View", "PaymentMethod", New With {.id = Model.DataListT.TripLocation(I).PromotionId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})
                                                End If
                                            </td>
                                            <td>@Model.DataListT.TripLocation(I).PaymentStatusStr</td>
                                            <td>
                                                @If String.IsNullOrEmpty(Model.DataListT.TripLocation(I).PromotionId.ToString) Then
                                                    @Html.Raw("No")
                                                Else
                                                    @Html.ActionLink("Promotion", "View", "Promotion", New With {.id = Model.DataListT.TripLocation(I).PromotionId}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})
                                                End If
                                            </td>
                                            <td>@IIf(String.IsNullOrEmpty(Model.DataListT.TripLocation(I).DriverId.ToString), "False", "True")</td>
                                            <td>@Model.DataListT.TripLocation(I).Note</td>
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
