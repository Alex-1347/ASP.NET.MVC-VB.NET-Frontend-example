﻿@Code
    ViewData("Title") = "Create Extra"
    ViewData("Selection") = "Rates"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/CreateExtra.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Create Extra</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("Extra/Create", "Service", New AjaxOptions() With {.HttpMethod = "POST", .OnBegin = "OnCreateExtraBegin", .OnSuccess = "OnCreateExtraSuccess", .OnFailure = "OnCreateExtraFailure"})
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
                            <input id="button-create-extra-submit" class="btn btn-danger btn-round" type="submit" value="Create Extra" />
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