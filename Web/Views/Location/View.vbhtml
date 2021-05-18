@ModelType Contract.Location
@Code
    ViewData("Title") = "Location"
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
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Update Location</h4>
                </div>
                <div class="card-body">
                    @Using (Html.BeginForm("Update", "Location", Nothing, FormMethod.Post, New With {.OnSubmit = "ShowWaitGif(event)"}))

                        @<div class="form-horizontal">
                            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.Address, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                <div class="col-md-10">
                                    @Html.EditorFor(Function(model) model.Address, New With {.htmlAttributes = New With {.class = "form-control"}})
                                    @Html.ValidationMessageFor(Function(model) model.Address, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.City, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                <div class="col-md-10">
                                    @Html.EditorFor(Function(model) model.City, New With {.htmlAttributes = New With {.class = "form-control"}})
                                    @Html.ValidationMessageFor(Function(model) model.City, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.Latitude, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                <div class="col-md-10">
                                    @Html.EditorFor(Function(model) model.Latitude, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "22.318587"}})
                                    @Html.ValidationMessageFor(Function(model) model.Latitude, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.Longitude, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                <div class="col-md-10">
                                    @Html.EditorFor(Function(model) model.Longitude, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "73.170802"}})
                                    @Html.ValidationMessageFor(Function(model) model.Longitude, "", New With {.class = "text-danger"})
                                </div>
                            </div>

                            <div class="form-group">
                                @Html.LabelFor(Function(model) model.GPlaceId, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                <div class="col-md-10">
                                    @Html.EditorFor(Function(model) model.GPlaceId, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "ChIJETj1hbfIXzkRd0M7CE_ImL8"}})
                                    @Html.ValidationMessageFor(Function(model) model.GPlaceId, "", New With {.class = "text-danger"})
                                </div>
                            </div>
                            @Html.AntiForgeryToken()
                            <div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                                <label id="status-message" class="label" style="color: tomato;"></label>
                            </div>
                            <div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                                <input id="button-create-ride-type-submit" class="btn btn-danger btn-round" type="submit" value="Update Location" />
                            </div>
                        </div>
                    End Using
                </div>
            </div>
        </div>
        <div Class="row" id="progress-panel" style="display: none;">
            <div Class="es-spinner-ring"></div>
        </div>
    </div>
</div>

