function OnCreateExtraBegin(xhr)
{
    var textEName = $('#input-extra-ename');
    var textHName = $('#input-extra-hname');
    var textPrice = $('#input-extra-price');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    //var id = textId.val().trim();

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

function OnCreateExtraSuccess(data, status, xhr)
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

function OnCreateExtraFailure(xhr, status, error)
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