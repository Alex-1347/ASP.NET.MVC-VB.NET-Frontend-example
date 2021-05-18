var ucount = 20;
var ukeyword = null;
var ucurrentPage = 1;
var utotalPages = 0;
var utotalCount = 0;

function loadUsers()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var tableBodyUsers = $('#table-body-users');
    var pagingCount = $('#page-count');
    var buttonUserCount = $('#button-user-count');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/User?Offset=' + (ucurrentPage - 1) * ucount + '&Count=' + ucount;

    if (ukeyword !== null && ukeyword.length > 0)
    {
        serviceUrl = serviceUrl + '&Keyword=' + ukeyword;
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

            var pagingUsersJson = returnedData;

            var poffset = pagingUsersJson['Offset'];
            var pcount = pagingUsersJson['Count'];
            var ptcount = pagingUsersJson['TotalCount'];

            utotalCount = ptcount;

            var numberOfPages = parseFloat(ptcount / pcount);
            utotalPages = Math.ceil(numberOfPages);

            var currentPage = (poffset + pcount) / pcount;
            ucurrentPage = currentPage;

            pagingCount.html("Page " + ucurrentPage + " / " + utotalPages);

            var usersJson = pagingUsersJson['Users'];

            for (var userIndex in usersJson)
            {
                var userJson = usersJson[userIndex];
                var userId = userJson['Id'];

                var name = userJson['Name'];
                var email = userJson['Email'];
                var phone = userJson['PhoneNumber'];

                var status = userJson['Status'];
                var statusDesc = "";
                switch (status)
                {
                    case 1:
                        statusDesc = "Active";
                        break;

                    case 2:
                        statusDesc = "Suspended";
                        break;

                    default:
                }

                htmlString += '<tr><td><a href="User/View/' + userId + '" class="text-danger"><u>View</u></a></td><td>' + name + '</td><td>' + email + '</td><td>' + phone + '</td><td>' + statusDesc + '</td>'+
				'<td><a href="Trip/ViewUserTrips/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="Message/ViewUserMessages/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="Review/ViewUserReviews/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'<td><a href="Payment/ViewUserPayments/' + userId + '" class="text-danger" ><u>View</u></a></td>'+
				'</tr>';
            }
            tableBodyUsers.html(htmlString);
            //buttonUserCount.html( @Resources.Assets.Admin.js.customized.Users.TotalUsers + ": " + utotalCount);
            buttonUserCount.html( "Total users : " + utotalCount);

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
    if (ucurrentPage === 1)
    {
        return;
    }
    
    ucurrentPage = 1;
    loadUsers();
}

function loadPreviousPage()
{
    if (ucurrentPage === 1)
    {
        return;
    }

    ucurrentPage = 1;
    loadUsers();
}

function loadNextPage()
{
    if (ucurrentPage >= utotalPages)
    {
        return;
    }

    ucurrentPage = ucurrentPage + 1;
    loadUsers();
}

function loadLastPage()
{
    if (ucurrentPage >= utotalPages)
    {
        return;
    }

    ucurrentPage = utotalPages;
    loadUsers();
}

function searchDrivers()
{
    var keyword = $('#input-user-keyword').val().trim();
    if (keyword !== null && keyword.length > 0)
    {
        ukeyword = keyword;
        ucurrentPage = 1;
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

    var buttonSearch = $('#button-user-search');
    buttonSearch.click(searchDrivers);

    loadUsers();
}

$(document).ready(documentReady);