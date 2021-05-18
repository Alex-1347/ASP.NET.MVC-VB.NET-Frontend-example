function OnAuthenticationBegin(xhr)
{
    var textUsername = $('#input-username');
    var textPassword = $('#input-password');
    var buttonAuthenticationSubmit = $('#button-authentication-submit');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    var username = textUsername.val().trim();
    var password = textPassword.val().trim();

    if (username.length <= 0)
    {
        labelStatusMessage.text("Please enter Username");
        return false;
    }

    if (password.length <= 0)
    {
        labelStatusMessage.text("Please enter Password");
        return false;
    }

    buttonAuthenticationSubmit.prop('disabled', true);
    buttonAuthenticationSubmit.val("Logging in..");
    return true;
}

function OnAuthenticationSuccess(data, status, xhr)
{
    //var textUsername = $('#input-username');
    //var textPassword = $('#input-password');

    var labelStatusMessage = $('#status-message');

    //textPassword.empty();

    if (xhr.status == 200 && data === "TRUE")
    {
        labelStatusMessage.text("Successfully logged in!");
        window.location = "Dashboard";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnAuthenticationFailure(xhr, status, error)
{
    //var textEmployeeId = $('#input-employee-id');
    //var textPassword = $('#input-password');
    var buttonAuthenticationSubmit = $('#button-authentication-submit');

    var labelStatusMessage = $('#status-message');

    buttonAuthenticationSubmit.prop('disabled', false);
    buttonAuthenticationSubmit.val("Login");

    //textPassword.empty();

    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Enter username and password");
            break;

        case 403:
            labelStatusMessage.text("Incorrect username or password !");
            break;

        case 500:
        default:
            labelStatusMessage.text("A temporary error occurred");
            break;
    }
}