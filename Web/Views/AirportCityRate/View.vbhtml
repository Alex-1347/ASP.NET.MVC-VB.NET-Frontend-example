@modeltype Contract.AirportCityRate2
@Code       
    ViewData("Title") = "View Airport-City Rate"
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
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Airport-City Rate</h4>
                </div>
                <div class="card-body">
                    @Using Html.BeginForm("Update", "AirportCityRate", FormMethod.Post, New With {.OnClick = "ShowWaitGif"})
                        @<input type="hidden" name="input-airport-city-rate-id" id="input-airport-city-rate-id" class="form-control" />
                        @<div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-from-city">From Airport</label>
                                        @Html.TextBoxFor(Function(model) model.Airports_EName, New With {.Class = "form-control", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-to-city">To City</label>
                                        @Html.TextBoxFor(Function(model) model.Cities_EName, New With {.class = "form-control", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-type">Type (Day/Night) (1/2)</label>
                                        @Html.TextBoxFor(Function(model) model.[Type], New With {.class = "form-control", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                        </div>

                       @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-rate">Govt. Rate</label>
                                        @Html.TextBoxFor(Function(model) model.Rate, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-discount-rate">Discount Rate</label>
                                        @Html.TextBoxFor(Function(model) model.DiscountRate, Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.HiddenFor(Function(model) model.Id)
                        @Html.HiddenFor(Function(model) model.ToCityId)
                        @Html.HiddenFor(Function(model) model.FromAirportId)
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input name="submitbutton" id="button-airport-city-rate-update-submit" class="btn btn-danger btn-round" type="submit" value="Update Rate" />
                            <input name="submitbutton" id="button-airport-city-rate-delete-submit" class="btn btn-danger btn-round" type="button" value="Delete Rate" />
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