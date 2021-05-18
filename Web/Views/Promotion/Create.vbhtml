@Code
    ViewData("Title") = "Create Promotion"
    ViewData("Selection") = "Rates"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/CreatePromotion.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Promotion</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("Promotion/Create", "Service", New AjaxOptions() With {.HttpMethod = "POST", .OnBegin = "OnCreatePromotionBegin", .OnSuccess = "OnCreatePromotionSuccess", .OnFailure = "OnCreatePromotionFailure"})
                        @<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-type">@Resources.Promotion.Create.Type</label>
                                        <select class="form-control" id="input-promotion-type" name="input-promotion-type">
                                            <option value="-1" selected="selected">Select Type</option>
                                            <option value="1">Percentage Discount</option>
                                            <option value="2">Flat Discount</option>
                                            <option value="3">Free Ride</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-code">@Resources.Promotion.Create.Code</label>
                                        @Html.TextBox("input-promotion-code", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-value">@Resources.Promotion.Create.Value</label>
                                        @Html.TextBox("input-promotion-value", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-description">@Resources.Promotion.Create.Description</label>
                                        @Html.TextBox("input-promotion-description", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-valid-from">@Resources.Promotion.Create.ValidFrom</label>
                                        @Html.TextBox("input-promotion-valid-from", Nothing, New With {.class = "form-control datetimepicker"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-valid-to">@Resources.Promotion.Create.ValidTo</label>
                                        @Html.TextBox("input-promotion-valid-to", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-usage-limit">@Resources.Promotion.Create.RestrictionOfUse</label>
                                        @Html.TextBox("input-promotion-usage-limit", Nothing, New With {.class = "form-control", .type = "number"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-user-usage-limit">@Resources.Promotion.Create.LimitUsage</label>
                                        @Html.TextBox("input-promotion-user-usage-limit", Nothing, New With {.class = "form-control", .type = "number"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-promotion-create-submit" class="btn btn-danger btn-round" type="submit" value=@Resources.Promotion.Create.CreationBenefits />
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