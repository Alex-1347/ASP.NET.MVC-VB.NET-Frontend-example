function loadPromotions()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');
    var tableBodyPromotions = $('#table-body-promotions');

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Promotion';

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

            var promotionsJson = returnedData;

            for (var promotionIndex in promotionsJson)
            {
                var promotionJson = promotionsJson[promotionIndex];
                var promotionId = promotionJson['Id'];
                var promotionType = promotionJson['Type'];
                var promotionCode = promotionJson['Code'];
                var promotionValue = promotionJson['Value'];
                var promotionDescription = promotionJson['Description'];
                var promotionValidFromDate = promotionJson['ValidFromDate'];
                var promotionValidToDate = promotionJson['ValidToDate'];
                var promotionValidFrom = moment.utc(promotionValidFromDate, 'MM/DD/YYYY HH:mm').local();
                var promotionValidTo = moment.utc(promotionValidToDate, 'MM/DD/YYYY HH:mm').local();

                if (promotionType == 1)
                {
                    promotionType = 'Percentage Discount';
                }
                else if (promotionType == 2)
                {
                    promotionType = 'Flat Discount';
                }
                else if (promotionType == 3)
                {
                    promotionType = 'Free Ride';
                    promotionValue = 'N/A';
                }

                htmlString += '<tr><td>' + promotionType + '</td><td>' + promotionCode + '</td><td>' + promotionValue + '</td><td>' + promotionDescription + '</td><td>' + promotionValidFrom.format('MM/DD/YYYY HH:mm') + '</td><td>' + promotionValidTo.format('MM/DD/YYYY HH:mm') + '</td><td><a href="Promotion/View/' + promotionId + '" class="text-danger"><u>View</u></a></td></tr>';
            }
            tableBodyPromotions.html(htmlString);

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

function documentReady()
{
    loadPromotions();
}

$(document).ready(documentReady);