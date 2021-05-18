@Code ViewData("Title") = "Reviews"
    ViewData("Selection") = "Review"
    End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts

End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Review
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "Bid")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>Ride</th>
                                    <th>Driver</th>
                                    <th>Rating</th>
                                    <th>Date</th>
                                    <th>Review</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-countries"></tbody>
                        </Table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="progress-panel" style="display: none;">
        <div class="es-spinner-ring"></div>
    </div>
</div>
