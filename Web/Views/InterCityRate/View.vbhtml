@Code
    ViewData("Title") = "View Inter-City Rate"
    ViewData("Selection") = "Rates"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ViewInterCityRate.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">@Resources.InterCityRate.View.Bonus</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("InterCityRate/Update", "Service", New AjaxOptions() With {.HttpMethod = "POST", .OnBegin = "OnUpdateInterCityRateBegin", .OnSuccess = "OnUpdateInterCityRateSuccess", .OnFailure = "OnUpdateInterCityRateFailure"})
                        @<input type="hidden" name="input-inter-city-rate-id" id="input-inter-city-rate-id" class="form-control" />
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-from-city">From City</label>
                                        @Html.TextBox("input-inter-city-rate-from-city", Nothing, New With {.class = "form-control", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-to-city">To City</label>
                                        @Html.TextBox("input-inter-city-rate-to-city", Nothing, New With {.class = "form-control", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-type">Type</label>
                                        @Html.TextBox("input-inter-city-rate-type", Nothing, New With {.class = "form-control", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-rate">Govt. Rate</label>
                                        @Html.TextBox("input-inter-city-rate-rate", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-discount-rate">Discount Rate</label>
                                        @Html.TextBox("input-inter-city-rate-discount-rate", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-inter-city-rate-update-submit" class="btn btn-danger btn-round" type="submit" value="Update Rate" />
                            <input id="button-inter-city-rate-delete-submit" class="btn btn-danger btn-round" type="button" value="Delete Rate" />
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