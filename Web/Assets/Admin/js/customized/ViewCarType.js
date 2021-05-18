var aid = null;
var aob = null;

function OnUpdateCarTypeBegin(xhr)
{
    var textId = $('#input-car-type-id');
    var textHName = $('#input-car-type-hname');
    var textEName = $('#input-car-type-ename');

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

function OnUpdateCarTypeSuccess(data, status, xhr)
{
    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/CarType";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnUpdateCarTypeFailure(xhr, status, error)
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid Car Type Details");
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

function DeleteCarType()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/CarType/Delete/' + aid;

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
                window.location.href = "/CarType";
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

function loadCarType()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/CarType/View/' + aid;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var cityJson = returnedData;

            var textId = $('#input-car-type-id');
            var textHName = $('#input-car-type-hname');
            var textEName = $('#input-car-type-ename');

            var id = cityJson['Id'];
            textId.val(id);

            var code = cityJson['HName'];
            textHName.val(code);

            var value = cityJson['EName'];
            textEName.val(value);

            aob = cityJson;

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

    var buttonDelete = $('#button-car-type-delete-submit');
    if (buttonDelete !== null)
        buttonDelete.click(DeleteCarType);

    loadCarType();
}

$(document).ready(documentReady);