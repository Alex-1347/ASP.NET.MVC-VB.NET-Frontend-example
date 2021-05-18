@modeltype Contract.CityCountry
@Code
    ViewData("Title") = "View City"
    ViewData("Selection") = "Location"
    Dim Location As Model.ViewLocation = ViewData("Location")
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    @*<script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ViewCity.js")"></script>*@
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">City</h4> 
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="has-danger">
                                    <Label Class="bmd-label-floating">@Html.DisplayNameFor(Function(model) model.Cities_EName)</Label><br />
                                    @Html.DisplayFor(Function(model) model.Cities_EName)
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="has-danger">
                                    <Label Class="bmd-label-floating">@Html.DisplayNameFor(Function(model) model.Cities_HName)</Label><br />
                                    @Html.DisplayFor(Function(model) model.Cities_HName)
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="has-danger">
                                    <Label Class="bmd-label-floating">@Html.DisplayNameFor(Function(model) model.Countries_PhoneCode)</Label><br />
                                    @Html.DisplayFor(Function(model) model.Countries_PhoneCode)
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="has-danger">
                                    <Label Class="bmd-label-floating">@Html.DisplayNameFor(Function(model) model.Countries_EName)</Label><br />
                                    @Html.DisplayFor(Function(model) model.Countries_EName)
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Locations</h4>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <Table class="table">
                                <thead class="text-danger">
                                    <tr>
                                        <th>View</th>
                                        <th>GPlaceId</th>
                                        <th>Latitude</th>
                                        <th>Longitude</th>
                                    </tr>
                                </thead>
                                <tbody id="table-body-cities">
                                    @If Location.DataListT.Locations IsNot Nothing Then
                                        @For I As Integer = 0 To Location.DataListT.Locations.Count - 1
                                            @<tr>
                                                <td>
                                                    @Html.ActionLink(Location.DataListT.Locations(I).Address, "ViewOneLocation", "Location", New With {.id = Location.DataListT.Locations(I).ID},
New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})
                                                </td>
                                                <td>
                                                    @Location.DataListT.Locations(I).GPlaceId
                                                </td>
                                                <td>
                                                    @Location.DataListT.Locations(I).Latitude
                                                </td>
                                                <td>
                                                    @Location.DataListT.Locations(I).Longitude
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