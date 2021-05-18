var aid = null;
var aob = null;

function OnUpdatePromotionBegin(xhr)
{
    var textId = $('#input-promotion-id');
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

    var id = textId.val().trim();

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

function OnUpdatePromotionSuccess(data, status, xhr)
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

function OnUpdatePromotionFailure(xhr, status, error)
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

function DeletePromotion()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Promotion/Delete/' + aid;

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
                window.location.href = "/Promotion";
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

function loadPromotion()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Promotion/View/' + aid;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var promotionJson = returnedData;

            var textId = $('#input-promotion-id');
            var dropdownType = $('#input-promotion-type');
            var textCode = $('#input-promotion-code');
            var textValue = $('#input-promotion-value');
            var textDescription = $('#input-promotion-description');
            var textValidFrom = $('#input-promotion-valid-from');
            var textValidTo = $('#input-promotion-valid-to');
            var textUsageLimit = $('#input-promotion-usage-limit');
            var textUserUsageLimit = $('#input-promotion-user-usage-limit');

            var id = promotionJson['Id'];
            textId.val(id);

            var type = promotionJson['Type'];
            dropdownType.val(type);

            var code = promotionJson['Code'];
            textCode.val(code);

            var value = promotionJson['Value'];
            textValue.val(value);

            var description = promotionJson['Description'];
            textDescription.val(description);

            var validFromDate = promotionJson['ValidFromDate'];
            var validToDate = promotionJson['ValidToDate'];
            var validFrom = moment.utc(validFromDate, 'MM/DD/YYYY HH:mm').local();
            var validTo = moment.utc(validToDate, 'MM/DD/YYYY HH:mm').local();

            textValidFrom.val(validFrom.format('MM/DD/YYYY HH:mm:ss'));
            textValidTo.val(validTo.format('MM/DD/YYYY HH:mm:ss'));

            var usageLimit = promotionJson['UsageLimit'];
            textUsageLimit.val(usageLimit);

            var userUsageLimit = promotionJson['PerUserUsageLimit'];
            textUserUsageLimit.val(userUsageLimit);

            aob = promotionJson;

            progressPanel.hide();
            contentPanel.show();

            textCode.focus();
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

    var buttonDelete = $('#button-promotion-delete-submit');
    if (buttonDelete !== null)
        buttonDelete.click(DeletePromotion);

    loadPromotion();
}

$(document).ready(documentReady);