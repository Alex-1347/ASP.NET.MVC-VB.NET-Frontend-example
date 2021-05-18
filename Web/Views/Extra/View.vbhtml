@Code
    ViewData("Title") = "View Extra"
    ViewData("Selection") = "Rates"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ViewExtra.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Extra</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("Extra/Update", "Service", New AjaxOptions() With {.HttpMethod = "PUT", .OnBegin = "OnUpdateExtraBegin", .OnSuccess = "OnUpdateExtraSuccess", .OnFailure = "OnUpdateExtraFailure"})
                        @<input type="hidden" name="input-extra-id" id="input-extra-id" class="form-control" />
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-extra-hname">Name</label>
                                        @Html.TextBox("input-extra-hname", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-extra-ename">Name (English)</label>
                                        @Html.TextBox("input-extra-ename", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-feature-price">Price</label>
                                        @Html.TextBox("input-extra-price", Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-extra-update-submit" class="btn btn-danger btn-round" type="submit" value="Update Extra" />
                            <input id="button-extra-delete-submit" class="btn btn-danger btn-round" type="button" value="Delete Extra" />
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