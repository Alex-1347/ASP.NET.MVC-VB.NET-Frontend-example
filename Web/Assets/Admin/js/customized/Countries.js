function loadCountries()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var tableBodyCountries = $('#table-body-countries');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Country';

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

            var countriesJson = returnedData;

            for (var countryIndex in countriesJson)
            {
                var countryJson = countriesJson[countryIndex];
                var countryId = countryJson['Id'];
                var countryEName = countryJson['EName'];
                var countryHName = countryJson['HName'];
                var countryCode = countryJson['Code'];
                var countryPhoneCode = countryJson['PhoneCode'];

                htmlString += '<tr><td>' + countryHName + '</td><td>' + countryEName + '</td><td>' + countryCode + '</td><td>' + countryPhoneCode + '</td><td><a href="Country/View/' + countryId + '" class="text-danger"><u>View</u></a></td></tr>';
            }
            tableBodyCountries.html(htmlString);

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

function documentReady()
{
    loadCountries();
}

$(document).ready(documentReady);