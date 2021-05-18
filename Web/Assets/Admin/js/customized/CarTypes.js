function loadCarTypes()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var tableBodyCarTypes = $('#table-body-car-types');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/CarType';

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

            var carTypesJson = returnedData;

            for (var carTypeIndex in carTypesJson)
            {
                var carTypeJson = carTypesJson[carTypeIndex];
                var carTypeId = carTypeJson['Id'];
                var carTypeEName = carTypeJson['EName'];
                var carTypeHName = carTypeJson['HName'];

                htmlString += '<tr><td>' + carTypeHName + '</td><td>' + carTypeEName + '</td><td><a href="CarType/View/' + carTypeId + '" class="text-danger"><u>View</u></a></td></tr>';
            }
            tableBodyCarTypes.html(htmlString);

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
    loadCarTypes();
}

$(document).ready(documentReady);