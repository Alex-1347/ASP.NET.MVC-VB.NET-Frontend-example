@Code
    ViewData("Title") = "Inter-City Rates"
    ViewData("Selection") = "Rates"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/InterCityRates.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Inter-City Rates
                    </h4>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="has-danger">
                                    <label class="bmd-label-floating" for="input-from-city">From City</label>
                                    <select class="form-control" id="input-from-city" name="input-from-city">
                                        <option value="-1" selected="selected">Select From City</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="has-danger">
                                    <label class="bmd-label-floating" for="input-to-city">To City</label>
                                    <select class="form-control" id="input-to-city" name="input-to-city">
                                        <option value="-1" selected="selected">Select To City</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                        <label id="status-message" class="label" style="color: tomato;"></label>
                    </div>
                    <div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                        <input id="button-get-inter-city-rate" class="btn btn-danger btn-round" type="button" value="Search" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-8" id="existing-rate-panel" style="display: none;">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Inter-City Rates
                        @*<div class="pull-left">
                            <a href="@Url.Action("Create", "InterCityRate")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>*@
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>Type</th>
                                    <th>Govt. Rate</th>
                                    <th>Discounted Rate</th>
                                    <th>View</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-inter-city-rates"></tbody>
                        </Table>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-8" id="non-existing-rate-panel" style="display: none;">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Add Rate</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("InterCityRate/Create", "Service", New AjaxOptions() With {.HttpMethod = "POST", .OnBegin = "OnCreateInterCityRateBegin", .OnSuccess = "OnCreateInterCityRateSuccess", .OnFailure = "OnCreateInterCityRateFailure"})
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-from-city">From City</label>
                                        <select class="form-control" id="input-inter-city-rate-from-city" name="input-inter-city-rate-from-city" style="pointer-events:none;" tabindex="-1" readonly>
                                            <option value="-1" selected="selected">Select From City</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-to-city">To City</label>
                                        <select class="form-control" id="input-inter-city-rate-to-city" name="input-inter-city-rate-to-city" style="pointer-events:none;" tabindex="-1" readonly>
                                            <option value="-1" selected="selected">Select To City</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-day-rate">Day Govt. Rate</label>
                                        @Html.TextBox("input-inter-city-rate-day-rate", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-day-discount-rate">Day Discount Rate</label>
                                        @Html.TextBox("input-inter-city-rate-day-discount-rate", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-night-rate">Night Govt. Rate</label>
                                        @Html.TextBox("input-inter-city-rate-night-rate", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-inter-city-rate-night-discount-rate">Night Discount Rate</label>
                                        @Html.TextBox("input-inter-city-rate-night-discount-rate", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message-create" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-inter-city-rate-create-submit" class="btn btn-danger btn-round" type="submit" value="Add Rate" />
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