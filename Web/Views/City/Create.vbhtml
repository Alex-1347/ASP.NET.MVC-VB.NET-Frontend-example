@modelType Contract.Cities
@Code       
    ViewData("Title") = "Create City"
    ViewData("Selection") = "Location"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-4">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">City</h4>
                </div>
                <div class="card-body">
                    @Using Html.BeginForm("Create", "City", New AjaxOptions() With {.HttpMethod = "POST", .OnBegin = "ShowWaitGif"})
                            @<div Class="col-md-12">
                                <div Class="form-group">
 
                                        <Label Class="bmd-label-floating" for="input-city-ename">Name</label>
                                        @Html.TextBoxFor(Function(model) model.City, Nothing, New With {.class = "form-control"})
 
                                </div>
                            </div>

                           @<div class="col-md-12">
                                <div class="form-group">
 
                                        <label class="bmd-label-floating" for="input-city-hname">Country</label>
                                        @Html.DropDownListFor(Function(model) model.CityID, DirectCast(ViewData("CountryList"), List(Of SelectListItem)), New With {.class = "form-control"})
 
                                </div>
                            </div>
                        @Html.AntiForgeryToken()

                       @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-city-create-submit" class="btn btn-danger btn-round" type="submit" value="Create City" />
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