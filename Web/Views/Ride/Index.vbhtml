@Code ViewData("Title") = "Ride"
    ViewData("Selection") = "List"
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
                        Ride
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "Ride")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>View Trip</th>
                                    <th>View Ride</th>
                                    <th>User</th>
                                    <th>Driver</th>
                                    <th>Car</th>
                                    <th>ArrivalTime</th>
                                    <th>WaitTime</th>
                                    <th>Review</th>
                                    <th>Rating</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-countries"></tbody>
                        </Table>
                    </div>
                    <nav aria-label="Ride Navigation">
                        <ul class="pagination justify-content-center">
                            <li id="page-first" class="page-item">
                                <a class="page-link text-danger">First</a>
                            </li>
                            <li id="page-previous" class="page-item">
                                <a class="page-link text-danger">Previous</a>
                            </li>
                            <li class="page-item">
                                <a id="page-count" class="page-link text-danger"></a>
                            </li>
                            <li id="page-next" class="page-item">
                                <a class="page-link text-danger">Next</a>
                            </li>
                            <li id="page-last" class="page-item">
                                <a class="page-link text-danger">Last</a>
                            </li>
                        </ul>
                    </nav>
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="progress-panel" style="display: none;">
        <div class="es-spinner-ring"></div>
    </div>
</div>
