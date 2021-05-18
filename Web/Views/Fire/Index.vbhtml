@ModelType Model.ViewFire
@Code
    ViewData("Title") = "Fire"
    ViewData("Selection") = "Fire"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Fire
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "Fire")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>View</th>

                                    <th>Note</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-countries">
                            </tbody>
                        </Table>
                    </div>
                    @Html.Partial("Pager", Model)
                </div>
            </div>
        </div>
    </div>
    <div Class="row" id="progress-panel" style="display: none;">
        <div Class="es-spinner-ring"></div>
    </div>
</div>
