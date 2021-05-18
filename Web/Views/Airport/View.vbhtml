@Code
    ViewData("Title") = "View Airport"
    ViewData("Selection") = "Location"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ViewAirport.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Airport</h4>
                </div>
                <div class="card-body">
                    @Using Ajax.BeginForm("Airport/Update", "Service", New AjaxOptions() With {.HttpMethod = "POST", .OnBegin = "OnUpdateAirportBegin", .OnSuccess = "OnUpdateAirportSuccess", .OnFailure = "OnUpdateAirportFailure"})
                        @<input type="hidden" name="input-airport-id" id="input-airport-id" class="form-control" />
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-hname">Name</label>
                                        @Html.TextBox("input-airport-hname", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-ename">Name (English)</label>
                                        @Html.TextBox("input-airport-ename", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-gplaceid">Google Place Id</label>
                                        @Html.TextBox("input-airport-gplaceid", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-airport-update-submit" class="btn btn-danger btn-round" type="submit" value="Update Airport" />
                            <input id="button-airport-delete-submit" class="btn btn-danger btn-round" type="button" value="Delete Airport" />
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