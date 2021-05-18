var aid = null;
var aob = null;

function OnUpdateAirportBegin(xhr)
{
    var textId = $('#input-airport-id');
    var textHName = $('#input-airport-hname');
    var textEName = $('#input-airport-ename');
    var textGPlaceId = $('#input-airport-gplaceid');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    var id = textId.val().trim();

    var hname = textHName.val().trim();
    if (hname === null || hname.length <= 0)
    {
        labelStatusMessage.text("Please enter Name in Hebrew");
        return false;
    }

    var ename = textEName.val().trim();
    if (ename === null || ename.length <= 0)
    {
        labelStatusMessage.text("Please enter Name in English");
        return false;
    }

    var gplaceid = textGPlaceId.val().trim();
    if (gplaceid === null || gplaceid.length <= 0)
    {
        labelStatusMessage.text("Please enter Google Place Id");
        return false;
    }

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();
    return true;
}

function OnUpdateAirportSuccess(data, status, xhr)
{
    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/Airport";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnUpdateAirportFailure(xhr, status, error)
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid Airport Details");
            break;

        case 403:
            window.location.href = "/Airport";
            break;

        case 500:
        default:
            labelStatusMessage.text("A temporary error occured");
            break;
    }
}

function DeleteAirport()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Airport/Delete/' + aid;

    $.ajax({
        url: serviceUrl,
        type: 'DELETE',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data, status, xhr)
        {
            var labelStatusMessage = $('#status-message');
            labelStatusMessage.empty();

            if (xhr.status === 200)
            {
                window.location.href = "/Airport";
            }
            else
            {
                labelStatusMessage.text("A temporary error occured");
            }
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

function loadAirport()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Airport/View/' + aid;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var airportJson = returnedData;

            var textId = $('#input-airport-id');
            var textHName = $('#input-airport-hname');
            var textEName = $('#input-airport-ename');
            var textGPlaceId = $('#input-airport-gplaceid');

            var id = airportJson['Id'];
            textId.val(id);

            var code = airportJson['HName'];
            textHName.val(code);

            var value = airportJson['EName'];
            textEName.val(value);

            var gplaceid = airportJson['GPlaceId'];
            textGPlaceId.val(gplaceid);

            aob = airportJson;

            progressPanel.hide();
            contentPanel.show();

            textHName.focus();
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
    var parts = window.location.href.split('/');
    var lastSegment = parts.pop() || parts.pop();
    aid = lastSegment;

    var buttonDelete = $('#button-airport-delete-submit');
    if (buttonDelete !== null)
        buttonDelete.click(DeleteAirport);

    loadAirport();
}

$(document).ready(documentReady);