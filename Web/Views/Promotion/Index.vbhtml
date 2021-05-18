@Code
    ViewData("Title") = "Promotions"
    ViewData("Selection") = "Rates"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/Promotions.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Promotions
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "Promotion")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>Type</th>
                                    <th>Code</th>
                                    <th>Value</th>
                                    <th>Description</th>
                                    <th>Valid From</th>
                                    <th>Valid To</th>
                                    <th>View</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-promotions"></tbody>
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