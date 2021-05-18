@Code
    ViewData("Title") = Resources.Dashboard.Index.MainBoard
    ViewData("Selection") = "Dashboard"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    @*<script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/plugins/chartist.min.js")"></script>*@
    @*<script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/Summary.js")"></script>*@
End Section


@Using (Html.BeginForm("Jump", "Menu", Nothing, FormMethod.Post, New With {.OnSubmit = "ShowWaitGif(event)"}))
    @<div class="container-fluid">
        <div class="row" id="content-panel">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">
                            Server Function Quick Launch Panel
                        </h4>
                    </div>
                    <div class="card-body">
                        <div class="row" id="content-panel">

                            <div class="col-md-2">
                                @Html.Partial("LocationMenu")
                                @Html.Partial("RatesMenu")
                                @Html.Partial("CategorizeMenu")
                            </div>
                            <div class="col-md-2">
                                @Html.Partial("ListMenu")
                            </div>
                            <div class="col-md-2">
                                @Html.Partial("UserWorkflowMenu")
                            </div>

                            <div class="col-md-2">
                                @Html.Partial("DriverRegistrationMenu")
                                @Html.Partial("DriverWorkflowMenu")
                            </div>

                            <div class="col-md-2">
                                @Html.Partial("FinancialMenu")
                                @Html.Partial("CommunicationMenu")
                            </div>

                            <div class="col-md-2">
                                @Html.Partial("ServerControlMenu")
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

End Using

    <div class="container-fluid">
        <div class="row" id="content-panel">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">
                            Frontend Version
                        </h4>
                    </div>
                    <div class="card-body">
                        @Html.Raw(ViewBag.FrontendVersion)
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">
                            Backend Version
                        </h4>
                    </div>
                    <div class="card-body">
                        @Html.Raw(ViewBag.BackendVersion)
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row" id="content-panel">

        </div>
    </div>

    <div class="row" id="progress-panel" style="display: none;">
        <div class="es-spinner-ring"></div>
    </div>
