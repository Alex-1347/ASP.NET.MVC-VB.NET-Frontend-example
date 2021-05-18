function OnCreatePromotionBegin(xhr)
{
    var dropdownType = $('#input-promotion-type');
    var textCode = $('#input-promotion-code');
    var textValue = $('#input-promotion-value');
    var textDescription = $('#input-promotion-description');
    var textValidFrom = $('#input-promotion-valid-from');
    var textValidTo = $('#input-promotion-valid-to');
    var textUsageLimit = $('#input-promotion-usage-limit');
    var textUserUsageLimit = $('#input-promotion-user-usage-limit');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    var type = dropdownType.val();
    if (type == -1)
    {
        labelStatusMessage.text("Please select Type");
        return false;
    }

    var code = textCode.val().trim();
    if (code === null || code.length <= 0)
    {
        labelStatusMessage.text("Please enter Code");
        return false;
    }

    var value = textValue.val().trim();
    if (value === null || value.length <= 0)
    {
        labelStatusMessage.text("Please enter Value");
        return false;
    }

    var description = textDescription.val().trim();
    if (description === null || description.length <= 0)
    {
        labelStatusMessage.text("Please enter Description");
        return false;
    }

    var validFrom = textValidFrom.val().trim();
    if (validFrom === null || validFrom.length <= 0)
    {
        labelStatusMessage.text("Please enter Valid From Date");
        return false;
    }

    var validTo = textValidTo.val().trim();
    if (validTo === null || validTo.length <= 0)
    {
        labelStatusMessage.text("Please enter Valid To Date");
        return false;
    }

    var usageLimit = textUsageLimit.val().trim();
    if (usageLimit === null || usageLimit === 0)
    {
        labelStatusMessage.text("Please enter Usage Limit");
        return false;
    }

    var userUsageLimit = textUserUsageLimit.val().trim();
    if (userUsageLimit === null || userUsageLimit === 0)
    {
        labelStatusMessage.text("Please enter Per User Usage Limit");
        return false;
    }

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();
    return true;
}

function OnCreatePromotionSuccess(data, status, xhr)
{
    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/Promotion";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnCreatePromotionFailure(xhr, status, error)
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid Promotion Details");
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
    $('#input-promotion-valid-from').datetimepicker({debug:true,format:'MM/DD/YYYY HH:mm'});
    $('#input-promotion-valid-to').datetimepicker({ debug: true, format: 'MM/DD/YYYY HH:mm' });
}

$(document).ready(documentReady);