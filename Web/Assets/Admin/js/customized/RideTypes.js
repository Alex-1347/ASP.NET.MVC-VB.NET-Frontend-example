function loadRideTypes()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var tableBodyRideTypes = $('#table-body-ride-types');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/RideType';

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

            var rideTypesJson = returnedData;

            for (var rideTypeIndex in rideTypesJson)
            {
                var rideTypeJson = rideTypesJson[rideTypeIndex];
                var rideTypeId = rideTypeJson['Id'];
                var rideTypeEName = rideTypeJson['EName'];
                var rideTypeHName = rideTypeJson['HName'];

                htmlString += '<tr><td>' + rideTypeHName + '</td><td>' + rideTypeEName + '</td><td><a href="RideType/View/' + rideTypeId + '" class="text-danger"><u>View</u></a></td></tr>';
            }
            tableBodyRideTypes.html(htmlString);

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
    loadRideTypes();
}

$(document).ready(documentReady);