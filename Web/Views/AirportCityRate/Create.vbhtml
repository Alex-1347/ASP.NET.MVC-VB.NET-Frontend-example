@modeltype Contract.AirportCityRate2
@Code
    ViewData("Title") = "View Airport-City Rate"
    ViewData("Selection") = "Rates"
    Dim TypeList As New List(Of SelectListItem)
    Dim N = New SelectListItem()
    N.Text = "Day"
    N.Value = 1
    TypeList.Add(N)
    N = New SelectListItem()
    N.Text = "Night"
    N.Value = 2
    TypeList.Add(N)
    Dim ContryDatas As List(Of SelectListItem) = ViewData("CountryList")
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
    @*<script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowHelp.js")"></script>*@
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">New Airport-City Rate</h4>
                </div>
                <div class="card-body">
                    @Using Html.BeginForm("Create", "AirportCityRate", FormMethod.Post, New With {.onlick = "ShowWaitGif"})
                        @<input type="hidden" name="input-airport-city-rate-id" id="input-airport-city-rate-id" class="form-control" />
                        @<div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-from-city">Firstly select country</label>
                                        @Html.DropDownList("Country", ContryDatas, New With {.Class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<hr />
                        @<div id="PlaceToPartial">
                    
                        </div>
                        @*@<div class="row">
            <div class="col-md-2">
                <a id="AirHelp" class="btn btn-link btn-danger" href="@Url.Action("AirHelp")" target="_blank">all</a>
            </div>
            <div class="col-md-2">
                <a id="CityIDcheckLink" class="btn btn-link btn-danger" href="@Url.Action("CheckCityID")">check</a>
            </div>
            <div class="col-md-4 align-self-center" id="CheckCity">
            </div>*@
                        @*<div class="col-md-2">
                <a id="AirHelp" class="btn btn-link btn-danger" href="@Url.Action("CityHelp")" target="_blank">all</a>

            </div>
            <div class="col-md-2">
                <a id="AirIDcheckLink" class="btn btn-link btn-danger" href="@Url.Action("CheckAirID")">check</a>

            </div>
            <div class="col-md-6 align-self-center" id="CheckAir">
            </div>
                                                </div>*@
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-rate">Govt. Rate</label>
                                        @Html.TextBoxFor(Function(model) model.Rate, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-discount-rate">Discount Rate</label>
                                        @Html.TextBoxFor(Function(model) model.DiscountRate, Nothing, New With {.class = "form-control", .type = "number", .step = "0.01"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-airport-city-rate-type">Day/Night</label>
                                        @Html.DropDownListFor(Function(model) model.[Type], TypeList, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.HiddenFor(Function(model) model.Id)
                        @Html.HiddenFor(Function(model) model.ToCityId)
                        @Html.HiddenFor(Function(model) model.FromAirportId)
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-airport-city-rate-update-submit" class="btn btn-danger btn-round" type="submit" value="Create Rate" />
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

@Scripts.Render("~/Scripts/jquery-3.4.1.js")

<script type="text/javascript">
$(function() {
    /*
    AjaxRequest("#AirIDcheckLink","#Airports_EName","#CheckAir");
    AjaxRequest("#CityIDcheckLink","#Cities_EName","#CheckCity");
    */
    $("#Country").change(function(){
        var id=$("#Country").val();
        $("#PlaceToPartial").load('@Url.Content("/AirportCityRate/AirportCity/")' + id);
    });


});
</script>