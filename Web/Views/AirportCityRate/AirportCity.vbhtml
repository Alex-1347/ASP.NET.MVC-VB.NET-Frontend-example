@modeltype Contract.AirportCityRate2

@Code
    ViewData("Selection") = "Rates"
    Dim CityDatas As List(Of SelectListItem) = ViewData("Cities")
    Dim AirportDatas As List(Of SelectListItem) = ViewData("Airports")
End Code

<div class="row">
    <div class="col-md-6">
        <div class="form-group">
            <div class="has-danger">
                <label class="bmd-label-floating" for="input-airport-city-rate-from-city">From Airport</label>
                @Html.DropDownList("AirportDatas", AirportDatas, New With {.Class = "form-control"})
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div class="form-group">
            <div class="has-danger">
                <label class="bmd-label-floating" for="input-airport-city-rate-to-city">To City</label>
                @Html.DropDownList("CityDatas", CityDatas, New With {.class = "form-control"})
            </div>
        </div>
    </div>
</div>