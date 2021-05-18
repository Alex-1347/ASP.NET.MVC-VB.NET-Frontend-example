var did = null;
var dob = null;

function OnUpdateUserBegin(xhr)
{
    //var textEmployeeId = $('#input-employee-id');
    //var dropdownProject = $('#input-employee-project-id');
    //var dropdownDesignation = $('#input-employee-designation-id');
    //var dropdownDepartment = $('#input-employee-department-id');
    //var dropdownRole = $('#input-employee-role-id');
    //var dropdownGender = $('#input-employee-gender');
    ////var dropdownTitle = $('#input-employee-title');
    //var dropdownLocation = $('#input-employee-location-id');
    //var textFirstName = $('#input-employee-first-name');
    //var textMiddleName = $('#input-employee-middle-name');
    //var textLastName = $('#input-employee-last-name');
    //var textBirthDate = $('#input-employee-birth-date');
    //var textHireDate = $('#input-employee-hire-date');
    //var textPhone = $('#input-employee-phone');

    var textId = $('#input-user-id');
    var textName = $('#input-user-name');
    var textFirstName = $('#input-user-first-name');
    var textLastName = $('#input-user-last-name');
    var textEmail = $('#input-user-email');
    var textPhone = $('#input-user-phone');
    var dropdownStatus = $('#input-user-status');

    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    var id = textId.val().trim();
    //if (id === null || id.length <= 0)
    //{
    //    labelStatusMessage.text("Please enter Employee Id");
    //    return false;
    //}

    //if (employeeId.length !== 6)
    //{
    //    labelStatusMessage.text("Please enter valid Employee Id");
    //    return false;
    //}

    //var projectId = dropdownProject.val();
    //if (projectId === null || projectId === "-1")
    //{
    //    labelStatusMessage.text("Please select a Project");
    //    return false;
    //}

    //var designationId = dropdownDesignation.val();
    //if (designationId === null || designationId === "-1")
    //{
    //    labelStatusMessage.text("Please select a Designation");
    //    return false;
    //}

    //var departmentId = dropdownDepartment.val();
    //if (departmentId === null || departmentId === "-1")
    //{
    //    labelStatusMessage.text("Please select a Department");
    //    return false;
    //}

    //var roleId = dropdownRole.val();
    //if (roleId === null || roleId === "-1")
    //{
    //    labelStatusMessage.text("Please select a Role");
    //    return false;
    //}

    //var locationId = dropdownLocation.val();
    //if (locationId === null || locationId === "-1")
    //{
    //    labelStatusMessage.text("Please select a Location");
    //    return false;
    //}

    //var gender = dropdownGender.val();
    //if (gender === null || gender === "-1")
    //{
    //    labelStatusMessage.text("Please select a Gender");
    //    return false;
    //}

    //var title = dropdownTitle.val();
    //if (title === null || title === "-1")
    //{
    //    labelStatusMessage.text("Please select a Title");
    //    return false;
    //}

   // var firstName = textName.val().trim();
    if (textFirstName === null || textFirstName.length <= 0)
    {
        labelStatusMessage.text("Please enter FirstName");
        return false;
    }

    //if (textLastName === null || textLastName.length <= 0) {
    //    labelStatusMessage.text("Please enter LastName");
    //    return false;
    //}


    var email = textEmail.val().trim();
    if (email === null || email.length <= 0)
    {
        labelStatusMessage.text("Please enter Email");
        return false;
    }

    var emailRegex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!emailRegex.test(email))
    {
        labelStatusMessage.text("Please enter valid Email");
        return false;
    }

    var phone = textPhone.val().trim();
    if (phone === null || phone.length <= 0)
    {
        labelStatusMessage.text("Please enter Phone");
        return false;
    }

    //if (phone.indexOf("+972") !== 0)
    //{
    //    labelStatusMessage.text("Please enter valid Phone");
    //    return false;
    //}

    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();
    return true;
}

function OnUpdateUserSuccess(data, status, xhr)
{
    var labelStatusMessage = $('#status-message');
    labelStatusMessage.empty();

    if (xhr.status === 200)
    {
        window.location.href = "/User";
    }
    else
    {
        labelStatusMessage.text("A temporary error occured");
    }
}

function OnUpdateUserFailure(xhr, status, error)
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.show();
    progressPanel.hide();

    var labelStatusMessage = $('#status-message');
    switch (xhr.status)
    {
        case 400:
            labelStatusMessage.text("Missing or invalid User Details");
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

function DeleteUser()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/User/Delete/' + did;

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
                window.location.href = "/User";
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

function loadUser()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/User/View/' + did;

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var userJson = returnedData;

            var textId = $('#input-user-id');
            var imageUser = $('#input-user-profile-image');
            var textFirstName = $('#input-user-first-name');
            var textLastName = $('#input-user-last-name');
            var textName = $('#input-user-name');
            var textEmail = $('#input-user-email');
            var textPhone = $('#input-user-phone');
            var dropdownStatus = $('#input-user-status');

            var id = userJson['Id'];
            textId.val(id);

            //var name = userJson['Name'];
            //textName.val(name);

            var Fname = userJson['Name'];
            textFirstName.val(Fname);

            //var Lname = userJson['LastName'];
            //textLastName.val(Lname);

            var status = userJson['Status'];
            dropdownStatus.val(status);

            var email = userJson['Email'];
            textEmail.val(email);

            var phone = userJson['PhoneNumber'];
            textPhone.val(phone);
            imageUser.attr("src", "/Service/User/" + id + "/Image/Thumbnail");

            dob = userJson;

            progressPanel.hide();
            contentPanel.show();

            textName.focus();
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
    did = lastSegment;

    var buttonDelete = $('#button-user-delete-submit');
    if (buttonDelete !== null)
        buttonDelete.click(DeleteUser);

    loadUser();
}

$(document).ready(documentReady);