var icrSelectedFromCityId = null;
var icrCitiesOb = null;

var icrCreateSelectedFromCityId = null;

function loadFromCities()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var dropdownFromCities = $('#input-from-city');
    var dropdownCreateFromCities = $('#input-inter-city-rate-from-city');
    var dropdownCreateToCities = $('#input-inter-city-rate-to-city');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/City';

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var htmlString = '<option value="-1" selected="selected">Select From City</option>';

            var citiesJson = returnedData;

            for (var cityIndex in citiesJson)
            {
                var cityJson = citiesJson[cityIndex];
                var cityId = cityJson['Id'];
                //var cityEName = cityJson['EName'];
                var cityHName = cityJson['HName'];

                htmlString += '<option value="' + cityId + '">' + cityHName + '</option>';
            }
            dropdownFromCities.html(htmlString);
            dropdownCreateFromCities.html(htmlString);
            dropdownCreateToCities.html(htmlString);

            icrCitiesOb = citiesJson;

            progressPanel.hide();
            contentPanel.show();
        },
        error: function (jqXHR, textStatus, errorThrown)
        {
            progressPanel.hide();
            contentPanel.show();
            switch (jqXHR.status)
            {
                case 403:
                    window.location.href = "/";
                    break;

                default:
                    $.notify({ message: jqXHR.responseJSON }, { type: 'danger', timer: 2000 });
                    break;
            }
        }
    });
}

function loadToCities()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var dropdownToCities = $('#input-to-city');

    contentPanel.hide();
    progressPanel.show();

    var htmlString = '<option value="-1" selected="selected">Select To City</option>';

    var citiesJson = icrCitiesOb;

    for (var cityIndex in citiesJson)
    {
        var cityJson = citiesJson[cityIndex];
        var cityId = cityJson['Id'];
        //var cityEName = cityJson['EName'];
        var cityHName = cityJson['HName'];

        if (cityId !== icrSelectedFromCityId)
            htmlString += '<option value="' + cityId + '">' + cityHName + '</option>';
    }
    dropdownToCities.html(htmlString);

    progressPanel.hide();
    contentPanel.show();
}

function loadCreateToCities()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var dropdownCreateToCities = $('#input-inter-city-rate-to-city');

    contentPanel.hide();
    progressPanel.show();

    var htmlString = '<option value="-1" selected="selected">Select To City</option>';

    var citiesJson = icrCitiesOb;

    for (var cityIndex in citiesJson)
    {
        var cityJson = citiesJson[cityIndex];
        var cityId = cityJson['Id'];
        //var cityEName = cityJson['EName'];
        var cityHName = cityJson['HName'];

        if (cityId !== icrCreateSelectedFromCityId)
            htmlString += '<option value="' + cityId + '">' + cityHName + '</option>';
    }
    dropdownCreateToCities.html(htmlString);

    progressPanel.hide();
    contentPanel.show();
}

function fromCityChanged()
{
    var selectedCity = $(this).find("option:selected");
    icrSelectedFromCityId = selectedCity.val();
    loadToCities();
}

function createFromCityChanged()
{
    var selectedCity = $(this).find("option:selected");
    icrCreateSelectedFromCityId = selectedCity.val();
    loadCreateToCities();
}

function getInterCityRates()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    var panelExistingRate = $('#existing-rate-panel');
    var panelNonExistingRate = $('#non-existing-rate-panel');

    var tableBodyInterCityRates = $('#table-body-inter-city-rates');

    var selectedFromCity = $('#input-from-city').find("option:selected");
    var selectedFromCityId = selectedFromCity.val();

    if (selectedFromCityId == -1)
    {
        return;
    }

    var selectedToCity = $('#input-to-city').find("option:selected");
    var selectedToCityId = selectedToCity.val();

    if (selectedToCityId == -1)
    {
        return;
    }

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/InterCityRate/' + selectedFromCityId + '/' + selectedToCityId;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var htmlString = "";

            var interCityRatesJson = returnedData;

            if (interCityRatesJson !== null && interCityRatesJson !== undefined)
            {
                panelExistingRate.show();
                panelNonExistingRate.hide();

                for (var interCityRateIndex in interCityRatesJson)
                {
                    var interCityRateJson = interCityRatesJson[interCityRateIndex];
                    var interCityRateId = interCityRateJson['Id'];
                    var interCityRateType = interCityRateJson['Type'];
                    var interCityRateRate = interCityRateJson['Rate'];
                    var interCityRateDiscountedRate = interCityRateJson['DiscountRate'];

                    if (interCityRateType == 1)
                    {
                        interCityRateType = 'Day';
                    }
                    else if (interCityRateType == 2)
                    {
                        interCityRateType = 'Night';
                    }

                    htmlString += '<tr><td>' + interCityRateType + '</td><td>' + interCityRateRate + '</td><td>' + (interCityRateDiscountedRate !== null ? interCityRateDiscountedRate : 'N/A') + '</td><td><a href="InterCityRate/View/' + interCityRateId + '" class="text-danger"><u>View</u></a></td></tr>';
                }
                tableBodyInterCityRates.html(htmlString);
            }
            else
            {
                panelExistingRate.hide();
                panelNonExistingRate.show();

                $('#input-inter-city-rate-from-city').val(selectedFromCityId);
                $('#input-inter-city-rate-to-city').val(selectedToCityId);
            }

            progressPanel.hide();
            contentPanel.show();
        },
        error: function (jqXHR, textStatus, errorThrown)
        {
            progressPanel.hide();
            contentPanel.show();
            switch (jqXHR.status)
            {
                case 204:
                    {
                        panelExistingRate.hide();
                        panelNonExistingRate.show();

                        $('#input-inter-city-rate-from-city').val(selectedFromCityId);
                        $('#input-inter-city-rate-to-city').val(selectedToCityId);
                    }
                    break;

                case 403:
                    window.location.href = "/";
                    break;

                default:
                    $.notify({ message: jqXHR.responseJSON }, { type: 'danger', timer: 2000 });
                    break;
            }
        }
    });
}

function OnCreateInterCityRateBegin(xhr)
{
    var selectedFromCity = $('#input-inter-city-rate-from-city').find("option:selected");
    var selectedFromCityId = selectedFromCity.val();
    if (selectedFromCityId == -1)
    {
        return false;
    }

    var selectedToCity = $('#input-inter-city-rate-to-city').find("option:selected");
    var selectedToCityId = selectedToCity.val();
    if (selectedToCityId == -1)
    {
        return false;
    }

    var textICDayRate = $('#input-inter-city-rate-day-rate');
    var icDayRate = textICDayRate.val().trim();
    if (icDayRate === null || icDayRate === 0)
    {
        labelStatusMessage.text("Please enter Day Rate");
        return false;
    }

    var textICNightRate = $('#input-inter-city-rate-night-rate');
    var icNightRate = textICNightRate.val().trim();
    if (icNightRate === null || icNightRate === 0)
    {
        labelStatusMessage.text("Please enter Night Rate");
        return false;
    }

    var labelStatusMessage = $('#status-message-create');
    labelStatusMessage.empty();

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    //$('#input-inter-city-rate-from-city').removeAttr('disabled');
    //$('#input-inter-city-rate-to-city').removeAttr('disabled');
    return true;
}

function OnCreateInterCityRateSuccess(data, status, xhr)
{
    //$('#input-inter-city-rate-from-city').attr('disabled', 'disabled');
    //$('#input-inter-city-rate-to-city').attr('disabled', 'disabled');

    var labelStatusMessage = $('#status-message-create');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/InterCityRate";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnCreateInterCityRateFailure(xhr, status, error)
{
    //$('#input-inter-city-rate-from-city').attr('disabled', 'disabled');
    //$('#input-inter-city-rate-to-city').attr('disabled', 'disabled');

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message-create');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid Inter-City Rate Details");
            break;

        case 403:
            window.location.href = "/";
            break;

        case 500:
        default:
            labelStatusMessage.text("A temporary error occured");
            break;
    }
}

function documentReady()
{
    var buttonGetInterCityRates = $('#button-get-inter-city-rate');
    if (buttonGetInterCityRates !== null)
        buttonGetInterCityRates.click(getInterCityRates);

    var dropdownFromCities = $('#input-from-city');
    if (dropdownFromCities !== null)
        dropdownFromCities.change(fromCityChanged);

    var dropdownCreateFromCities = $('#input-inter-city-rate-from-city');
    if (dropdownCreateFromCities !== null)
        dropdownCreateFromCities.change(createFromCityChanged);

    loadFromCities();
}

$(document).ready(documentReady);