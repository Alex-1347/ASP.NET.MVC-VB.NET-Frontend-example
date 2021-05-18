var dkeyword = null;
var dcount = 20;
var dcurrentPage = 1;
var dtotalPages = 0;
var dtotalCount = 0;

function loadUsers()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var tableBodyDrivers = $('#table-body-drivers');
    var pagingCount = $('#page-count');
    var buttonDriverCount = $('#button-driver-count');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Driver?Offset=' + (dcurrentPage - 1) * dcount + '&Count=' + dcount;

    if (dkeyword !== null && dkeyword.length > 0)
    {
        serviceUrl = serviceUrl + '&Keyword=' + dkeyword;
    }

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            var htmlString = "";

            var pagingDriversJson = returnedData;

            var poffset = pagingDriversJson['Offset'];
            var pcount = pagingDriversJson['Count'];
            var ptcount = pagingDriversJson['TotalCount'];

            dtotalCount = ptcount;

            var numberOfPages = parseFloat(ptcount / pcount);
            dtotalPages = Math.ceil(numberOfPages);

            var currentPage = (poffset + pcount) / pcount;
            dcurrentPage = currentPage;

            pagingCount.html("Page " + dcurrentPage + " / " + dtotalPages);

            var driversJson = pagingDriversJson['Drivers'];

            for (var driverIndex in driversJson)
            {
                var driverJson = driversJson[driverIndex];
                var userId = driverJson['Id'];

                var firstName = driverJson['Name'];
                var lastName = driverJson['LastName'];
                var status = driverJson['Status'];
                var onboardingstatus = driverJson['OnboardingStatus'];
                var email = driverJson['Email'];
                var phonenumber = driverJson['PhoneNumber'];
                var statustxt;

                if (status == 1) { statustxt = "Pending Contact Verification" }
                else if (status == 2) { statustxt = "Pending Document Verification" }
                else if(status == 3) { statustxt = "Active" }
                else if(status == 4) { statustxt = "Active | Pending Document Update Verification" }
                else if(status == 5) { statustxt = "Suspended" }


                htmlString += '<tr><td><a href="Driver/View/' + userId + '" class="text-danger" ><u>View</u></a></td><td>' + firstName + '</td><td>' + email + '</td><td>' + phonenumber + '</td><td>' + statustxt + '</td><td>' + onboardingstatus + '</td>'+
				'<td><a href="Location/ViewDevicesLocation/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="/Driver/ViewNotification/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="Bids/View/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="Ride/View/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="Message/View/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="Review/View/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="Payment/View/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'</tr>';
            }
            tableBodyDrivers.html(htmlString);
            buttonDriverCount.html("Drivers total:" + dtotalCount);

            progressPanel.hide();
            contentPanel.show();
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

function loadFirstPage()
{
    if (dcurrentPage === 1)
    {
        return;
    }
    
    dcurrentPage = 1;
    loadUsers();
}

function loadPreviousPage()
{
    if (dcurrentPage === 1)
    {
        return;
    }

    dcurrentPage = 1;
    loadUsers();
}

function loadNextPage()
{
    if (dcurrentPage >= dtotalPages)
    {
        return;
    }

    dcurrentPage = dcurrentPage + 1;
    loadUsers();
}

function loadLastPage()
{
    if (dcurrentPage >= dtotalPages)
    {
        return;
    }

    dcurrentPage = dtotalPages;
    loadUsers();
}

function searchDrivers()
{
    var keyword = $('#input-driver-keyword').val().trim();
    if (keyword !== null && keyword.length > 0)
    {
        dkeyword = keyword;
        dcurrentPage = 1;
        loadUsers();
    }
}

function documentReady()
{
    var pageFirst = $('#page-first');
    var pagePrevious = $('#page-previous');
    var pageNext = $('#page-next');
    var pageLast = $('#page-last');

    pageFirst.click(loadFirstPage);
    pagePrevious.click(loadPreviousPage);
    pageNext.click(loadNextPage);
    pageLast.click(loadLastPage);

    var buttonSearch = $('#button-driver-search');
    buttonSearch.click(searchDrivers);

    loadUsers();
}

function ShowWaitGif(e) {
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    contentPanel.hide();
    progressPanel.show();

    return true;
}

$(document).ready(documentReady);