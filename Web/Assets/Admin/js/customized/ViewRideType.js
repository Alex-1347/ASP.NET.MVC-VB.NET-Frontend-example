var rtid = null;
var rtob = null;

function OnUpdateRideTypeBegin(xhr)
{
    var textId = $('#input-ride-type-id');
    var textHName = $('#input-ride-type-hname');
    var textEName = $('#input-ride-type-ename');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    var id = textId.val().trim();

    var code = textHName.val().trim();
    if (code === null || code.length <= 0)
    {
        labelStatusMessage.text("Please enter Name in Hebrew");
        return false;
    }

    var value = textEName.val().trim();
    if (value === null || value.length <= 0)
    {
        labelStatusMessage.text("Please enter Name in English");
        return false;
    }

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();
    return true;
}

function OnUpdateRideTypeSuccess(data, status, xhr)
{
    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/RideType";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnUpdateRideTypeFailure(xhr, status, error)
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid Ride Type details");
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

function DeleteRideType()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/RideType/Delete/' + rtid;

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
                window.location.href = "/RideType";
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

function loadRideType()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/RideType/View/' + rtid;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var rideTypeJson = returnedData;

            var textId = $('#input-ride-type-id');
            var textHName = $('#input-ride-type-hname');
            var textEName = $('#input-ride-type-ename');

            var id = rideTypeJson['Id'];
            textId.val(id);

            var code = rideTypeJson['HName'];
            textHName.val(code);

            var value = rideTypeJson['EName'];
            textEName.val(value);

            rtob = rideTypeJson;

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
    rtid = lastSegment;

    var buttonDelete = $('#button-ride-type-delete-submit');
    if (buttonDelete !== null)
        buttonDelete.click(DeleteRideType);

    loadRideType();
}

$(document).ready(documentReady);