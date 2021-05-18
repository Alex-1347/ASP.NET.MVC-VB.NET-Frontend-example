function OnCreateCountryBegin(xhr)
{
    var textHName = $('#input-country-hname');
    var textEName = $('#input-country-ename');
    var textCode = $('#input-country-code');
    var textPhoneCode = $('#input-country-phone-code');

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

    var code = textCode.val().trim();
    if (code === null || code.length <= 0)
    {
        labelStatusMessage.text("Please enter Country Code");
        return false;
    }

    var phoneCode = textPhoneCode.val().trim();
    if (phoneCode === null || phoneCode.length <= 0)
    {
        labelStatusMessage.text("Please enter Phone Code");
        return false;
    }

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();
    return true;
}

function OnCreateCountrySuccess(data, status, xhr)
{
    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/Country";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnCreateCountryFailure(xhr, status, error)
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid Country details");
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