function loadSummary()
{
    var contentPanel = $('#content-panel');
    var progressPanel = $('#progress-panel');

    var maleManpower = 0;
    var femaleManpower = 0;

    var p104Manpower = 0;
    var p108Manpower = 0;
    var p181Manpower = 0;
    var p1962Manpower = 0;
    var pDial100Manpower = 0;
    var pKhilkhilatManpower = 0;
    var pMHUManpower = 0;
    var pRoadSafetyManpower = 0;

    contentPanel.hide();
    progressPanel.show();

    var serviceUrl = '/Service/Summary/Manpower';

    $.ajax({
        url: serviceUrl,
        type: 'GET',
        async: true,
        cache: false,
        contentType: false,
        processData: false,
        success: function (returnedData)
        {
            console.log(JSON.stringify(returnedData));

            var count = 0;
            var genderWiseManpowerJson = returnedData['Gender'];
            for (var genderWiseManpowerIndex in genderWiseManpowerJson)
            {
                var genderManpower = genderWiseManpowerJson[genderWiseManpowerIndex];
                if (count == 0)
                    maleManpower = genderManpower['Value'];
                else if (count == 1)
                    femaleManpower = genderManpower['Value'];
                count++;
            }

            count = 0;
            var projectWiseManpowerJson = returnedData['Project'];
            for (var projectWiseManpowerIndex in projectWiseManpowerJson)
            {
                var projectManpower = projectWiseManpowerJson[projectWiseManpowerIndex];
                if (count == 0)
                    p104Manpower = projectManpower['Value'];
                else if (count == 1)
                    p108Manpower = projectManpower['Value'];
                else if (count == 2)
                    p181Manpower = projectManpower['Value'];
                else if (count == 3)
                    p1962Manpower = projectManpower['Value'];
                else if (count == 4)
                    pDial100Manpower = projectManpower['Value'];
                else if (count == 5)
                    pKhilkhilatManpower = projectManpower['Value'];
                else if (count == 6)
                    pMHUManpower = projectManpower['Value'];
                else if (count == 7)
                    pRoadSafetyManpower = projectManpower['Value'];
                count++;
            }

            setTimeout(function ()
            {
                summaryGenderWiseManpower = {
                    labels: ['Male', 'Female'],
                    series: [
                        [maleManpower, femaleManpower]
                    ]
                };

                optionsSummaryGenderWiseManpower = {
                    seriesBarDistance: 0
                };

                var summaryGenderWiseManpowerChart = Chartist.Bar('#chart-gender-wise-summary', summaryGenderWiseManpower, optionsSummaryGenderWiseManpower);
                md.startAnimationForBarChart(summaryGenderWiseManpowerChart);

                summaryProjectWiseManpower = {
                    labels: ['104', '108', '181', '1962', 'Dial-100', 'Khilkhilat', 'MHU', 'Road Safety'],
                    series: [
                        [p104Manpower, p108Manpower, p181Manpower, p1962Manpower, pDial100Manpower, pKhilkhilatManpower, pMHUManpower, pRoadSafetyManpower]
                    ]
                };

                optionsSummaryProjectWiseManpower = {
                    seriesBarDistance: 0
                };

                var summaryProjectWiseManpowerChart = Chartist.Bar('#chart-project-wise-summary', summaryProjectWiseManpower, optionsSummaryProjectWiseManpower);
                md.startAnimationForBarChart(summaryProjectWiseManpowerChart);
            }, 500);

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
    loadSummary();
}

$(document).ready(documentReady);