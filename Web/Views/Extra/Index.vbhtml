@Code
    ViewData("Title") = "Extras"
    ViewData("Selection") = "Rates"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/Extras.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Extras
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "Extra")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>Name</th>
                                    <th>Name (English)</th>
                                    <th>Price</th>
                                    <th>View</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-extras"></tbody>
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