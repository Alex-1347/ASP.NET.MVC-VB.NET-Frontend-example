function loadExtras()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var tableBodyExtras = $('#table-body-extras');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Extra';

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

            var extrasJson = returnedData;

            for (var extraIndex in extrasJson)
            {
                var extraJson = extrasJson[extraIndex];
                var extraId = extraJson['Id'];
                var extraHName = extraJson['HName'];
                var extraEName = extraJson['EName'];
                var extraPrice = extraJson['Price'];

                htmlString += '<tr><td>' + extraHName + '</td><td>' + extraEName + '</td><td>₪ ' + extraPrice + '</td><td><a href="Extra/View/' + extraId + '" class="text-danger"><u>View</u></a></td></tr>';
            }
            tableBodyExtras.html(htmlString);

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
    loadExtras();
}

$(document).ready(documentReady);