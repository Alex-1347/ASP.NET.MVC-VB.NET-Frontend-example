var icrid = null;
var icrob = null;

function OnUpdateInterCityRateBegin(xhr)
{
    var textId = $('#input-inter-city-rate-id');
    var textRate = $('#input-inter-city-rate-rate');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    var id = textId.val().trim();

    var rate = textRate.val().trim();
    if (rate === null || rate === 0)
    {
        labelStatusMessage.text("Please enter Rate");
        return false;
    }

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();
    return true;
}

function OnUpdateInterCityRateSuccess(data, status, xhr)
{
    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/InterCityRate";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnUpdateInterCityRateFailure(xhr, status, error)
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid Inter-City Rate Details");
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

function DeleteInterCityRate()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/InterCityRate/Delete/' + icrid;

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
                window.location.href = "/InterCityRate";
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

function loadInterCityRate()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/InterCityRate/View/' + icrid;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var interCityRateJson = returnedData;

            var textId = $('#input-inter-city-rate-id');
            var textFromCity = $('#input-inter-city-rate-from-city');
            var textToCity = $('#input-inter-city-rate-to-city');
            var textType = $('#input-inter-city-rate-type');
            var textRate = $('#input-inter-city-rate-rate');
            var textDiscountRate = $('#input-inter-city-rate-discount-rate');

            var interCityRateId = interCityRateJson['Id'];
            var interCityRateFrom = interCityRateJson['FromCity']['HName'];
            var interCityRateTo = interCityRateJson['ToCity']['HName'];
            var interCityRateType = interCityRateJson['Type'];
            var interCityRateRate = interCityRateJson['Rate'];
            var interCityRateDiscountedRate = interCityRateJson['DiscountRate'];

            if (interCityRateType == 1)
            {
                interCityRateType = 'Day';
            }
            else if (interCityRateType == 2)
            {
                interCityRateType = 'Night';
            }

            textId.val(interCityRateId);
            textFromCity.val(interCityRateFrom);
            textToCity.val(interCityRateTo);
            textType.val(interCityRateType);
            textRate.val(interCityRateRate);
            textDiscountRate.val(interCityRateDiscountedRate);

            icrob = interCityRateJson;

            progressPanel.hide();
            contentPanel.show();

            textRate.focus();
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
    icrid = lastSegment;

    var buttonDelete = $('#button-inter-city-rate-delete-submit');
    if (buttonDelete !== null)
        buttonDelete.click(DeleteInterCityRate);

    loadInterCityRate();
}

$(document).ready(documentReady);