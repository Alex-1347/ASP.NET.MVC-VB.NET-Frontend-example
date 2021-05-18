@Code
    ViewData("Title") = "View Promotion"
    ViewData("Selection") = "Rates"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ViewPromotion.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Promotion</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("Promotion/Update", "Service", New AjaxOptions() With {.HttpMethod = "PUT", .OnBegin = "OnUpdatePromotionBegin", .OnSuccess = "OnUpdatePromotionSuccess", .OnFailure = "OnUpdatePromotionFailure"})
                        @<input type="hidden" name="input-promotion-id" id="input-promotion-id" Class="form-control" />
                        @<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-type">@Resources.Promotion.View.Type</label>
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
                                        <label class="bmd-label-floating" for="input-promotion-code">Code</label>
                                        @Html.TextBox("input-promotion-code", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-value">Value</label>
                                        @Html.TextBox("input-promotion-value", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-description">Description</label>
                                        @Html.TextBox("input-promotion-description", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-valid-from">Valid From</label>
                                        @Html.TextBox("input-promotion-valid-from", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-valid-to">Valid To</label>
                                        @Html.TextBox("input-promotion-valid-to", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-usage-limit">Usage Limit</label>
                                        @Html.TextBox("input-promotion-usage-limit", Nothing, New With {.class = "form-control", .type = "number"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-promotion-user-usage-limit">Per User Usage Limit</label>
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
                            <input id="button-promotion-update-submit" class="btn btn-danger btn-round" type="submit" value=@Resources.Promotion.View.UpdateBenefit />
                            <input id="button-promotion-delete-submit" class="btn btn-danger btn-round" type="button" value=@Resources.Promotion.View.DeleteBenefit />
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