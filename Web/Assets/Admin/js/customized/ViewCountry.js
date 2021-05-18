var cid = null;
var cob = null;

function OnUpdateCountryBegin(xhr)
{
    var textId = $('#input-country-id');
    var textHName = $('#input-country-hname');
    var textEName = $('#input-country-ename');
    var textCode = $('#input-country-code');
    var textPhoneCode = $('#input-country-phone-code');

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

    var code = textCode.val().trim();
    if (code === null || code.length <= 0)
    {
        labelStatusMessage.text("Please enter Code");
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

function OnUpdateCountrySuccess(data, status, xhr)
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

function OnUpdateCountryFailure(xhr, status, error)
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
            window.location.href = "/Country";
            break;

        case 500:
        default:
            labelStatusMessage.text("A temporary error occured");
            break;
    }
}

function DeleteCountry()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Country/Delete/' + cid;

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
                window.location.href = "/Country";
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

function loadCountry()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Country/View/' + cid;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var countryJson = returnedData;

            var textId = $('#input-country-id');
            var textHName = $('#input-country-hname');
            var textEName = $('#input-country-ename');
            var textCode = $('#input-country-code');
            var textPhoneCode = $('#input-country-phone-code');

            var id = countryJson['Id'];
            textId.val(id);

            var code = countryJson['HName'];
            textHName.val(code);

            var value = countryJson['EName'];
            textEName.val(value);

            var code = countryJson['Code'];
            textCode.val(code);

            var phoneCode = countryJson['PhoneCode'];
            textPhoneCode.val(phoneCode);

            cob = countryJson;

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
    cid = lastSegment;

    var buttonDelete = $('#button-country-delete-submit');
  /*  if (buttonDelete !== null)
        buttonDelete.click(DeleteCountry); */

    loadCountry();
}

$(document).ready(documentReady);