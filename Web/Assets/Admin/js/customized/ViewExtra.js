var eid = null;
var eob = null;

function OnUpdateExtraBegin(xhr)
{
    var textId = $('#input-extra-id');
    var textEName = $('#input-extra-ename');
    var textHName = $('#input-extra-hname');
    var textPrice = $('#input-extra-price');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    var id = textId.val().trim();

    var ename = textEName.val().trim();
    if (ename === null || ename.length <= 0)
    {
        labelStatusMessage.text("Please enter Name in English");
        return false;
    }

    var hname = textHName.val().trim();
    if (hname === null || hname.length <= 0)
    {
        labelStatusMessage.text("Please enter Name in Hebrew");
        return false;
    }

    var price = textPrice.val().trim();
    if (price === null || price.length <= 0)
    {
        labelStatusMessage.text("Please enter Price");
        return false;
    }

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();
    return true;
}

function OnUpdateExtraSuccess(data, status, xhr)
{
    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/Extra";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnUpdateExtraFailure(xhr, status, error)
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid Extra details");
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

function DeleteExtra()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Extra/Delete/' + eid;

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
                window.location.href = "/Extra";
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

function loadExtra()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Extra/View/' + eid;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var extraJson = returnedData;

            var textId = $('#input-extra-id');
            var textEName = $('#input-extra-ename');
            var textHName = $('#input-extra-hname');
            var textPrice = $('#input-extra-price');

            var id = extraJson['Id'];
            textId.val(id);

            var ename = extraJson['EName'];
            textEName.val(ename);

            var hname = extraJson['HName'];
            textHName.val(hname);

            var price = extraJson['Price'];
            textPrice.val(price);

            eob = extraJson;

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
    eid = lastSegment;

    var buttonDelete = $('#button-extra-delete-submit');
    if (buttonDelete !== null)
        buttonDelete.click(DeleteExtra);

    loadExtra();
}

$(document).ready(documentReady);