@Code
    ViewData("Title") = "View Car Type"
    ViewData("Selection") = "Categorize"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ViewCarType.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Car Type</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("CarType/Update", "Service", New AjaxOptions() With {.HttpMethod = "POST", .OnBegin = "OnUpdateCarTypeBegin", .OnSuccess = "OnUpdateCarTypeSuccess", .OnFailure = "OnUpdateCarTypeFailure"})
                        @<input type="hidden" name="input-car-type-id" id="input-car-type-id" class="form-control" />
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-car-type-hname">Name</label>
                                        @Html.TextBox("input-car-type-hname", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-car-type-ename">Name (English)</label>
                                        @Html.TextBox("input-car-type-ename", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-car-type-update-submit" class="btn btn-danger btn-round" type="submit" value="Update Car Type" />
                            <input id="button-car-type-delete-submit" class="btn btn-danger btn-round" type="button" value="Delete Car Type" />
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