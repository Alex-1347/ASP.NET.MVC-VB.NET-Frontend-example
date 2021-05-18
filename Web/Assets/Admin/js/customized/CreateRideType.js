function OnCreateRideTypeBegin(xhr)
{
    var textHName = $('#input-ride-type-hname');
    var textEName = $('#input-ride-type-ename');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    var HName = textHName.val().trim();
    if (HName === null || HName.length <= 0)
    {
        labelStatusMessage.text("Please enter Name in Hebrew");
        return false;
    }

    var EName = textEName.val().trim();
    if (EName === null || EName.length <= 0)
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

function OnCreateRideTypeSuccess(data, status, xhr)
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

function OnCreateRideTypeFailure(xhr, status, error)
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

function documentReady()
{
}

$(document).ready(documentReady);