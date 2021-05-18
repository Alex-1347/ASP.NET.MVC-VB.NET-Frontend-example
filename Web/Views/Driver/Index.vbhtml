@Code
    ViewData("Title") = "Driver"
    ViewData("Selection") = "List"
End Code


@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/Drivers.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-10">
            <div class="card">
                <div class="card-body">
                    <div class="form-group has-danger" style="padding: 0px; margin: 4px;">
                        <div class="input-group" style="align-items:center;">
                            @Html.TextBox("input-driver-keyword", Nothing, New With {.class = "form-control", .placeholder = Resources.Driver.Index.Search, .autocomplete = "off"})
                            <button id="button-driver-search" class="btn btn-danger btn-round" style="margin-left: 20px;">
                                <i class="material-icons">search</i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-2">
            <div class="card">
                <div class="card-body">
                    <div class="form-group has-danger" style="padding: 0px; margin: 4px;">
                        <button id="button-driver-count" class="btn btn-danger btn-round" style="width: 100%;"></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="content-panel">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        @Resources.Driver.Index.Driver
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>@Resources.Driver.Index.Watch</th>
                                    <th>@Resources.Driver.Index.FirstName</th>
                                    <th>@Resources.Driver.Index.Email</th>
                                    <th>@Resources.Driver.Index.Phone</th>
                                    <th>Status</th>
                                    <th>Onboard</th>
                                    <th>Location</th>
                                    <th>Notification</th>
                                    <th>Bids</th>
                                    <th>Ride</th>
                                    <th>Message</th>
                                    <th>Review</th>
                                    <th>Payment</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-drivers"></tbody>
                        </Table>
                    </div>
                    <nav aria-label="Driver Navigation">
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