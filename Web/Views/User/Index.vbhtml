@Code
    ViewData("Title") = "Users"
    ViewData("Selection") = "List"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/Users.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-body">
                    <div class="form-group has-danger" style="padding: 0px; margin: 4px;">
                        <div class="input-group" style="align-items:center;">
                            @Html.TextBox("input-user-keyword", Nothing, New With {.class = "form-control", .placeholder = Resources.User.Index.SearchByUserName, .autocomplete = "off"})
                            <button id="button-user-search" class="btn btn-danger btn-round" style="margin-left: 20px;">
                                <i class="material-icons">search</i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <div class="form-group has-danger" style="padding: 0px; margin: 4px;">
                        <button id="button-user-count" class="btn btn-danger btn-round" style="width: 100%;"></button>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        @Resources.User.Index.Users
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>@Resources.User.Index.Watch</th>
                                    <th>@Resources.User.Index.Name</th>
                                    <th>@Resources.User.Index.Email</th>
                                    <th>@Resources.User.Index.Phone</th>
                                    <th>Status</th>
                                    <th>Trips</th>
                                    <th>Messages</th>
                                    <th>Reviews</th>
                                    <th>Payments</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-users"></tbody>
                        </Table>
                    </div>
                    <nav aria-label="User Navigation">
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