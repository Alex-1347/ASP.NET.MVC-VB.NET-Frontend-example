<!DOCTYPE html>
<html lang="en" dir="ltr">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>@ViewBag.Title - TaxiStar</title>
    @Styles.Render("~/bundle/font/google")
    @Styles.Render("~/bundle/font/google/hebrew")
    @Styles.Render("~/bundle/font/awesome")
    @Styles.Render("~/bundle/admin/css")
    @RenderSection("Styles", required:=False)
    <style>
        .btn-gray:hover, .btn-gray:focus, .btn-gray:active {
            background-color: #f44336;
            box-shadow: 0 4px 20px 0 rgba(0,0,0,.14),0 7px 10px -5px rgba(244,67,54,.4);
        }
    </style>
</head>
<body>
    <div class="wrapper">
        <div class="sidebar" data-color="danger" data-background-color="white" data-image="@Url.Content("~/Assets/Admin/img/sidebar-1.jpg")">
            <div class="logo">
                @Html.ActionLink("TaxiStar", "Index", "Dashboard", Nothing, New With {.class = "simple-text logo-normal"})
            </div>
            <div class="sidebar-wrapper">
                <ul class="nav">
                    @Code
                        If ViewData("Selection").Equals("Dashboard") Then
                            @<li class="nav-item active">
                                <a class="nav-link" href="@Url.Action("Index", "Dashboard")">
                                    <i class="material-icons">dashboard</i>
                                    <p>@Resources.Shared._DashboardLayout.MainBoard</p>
                                </a>
                            </li>
                        Else
                            @<li class="nav-item">
                                <a class="nav-link" href="@Url.Action("Index", "Dashboard")">
                                    <i class="material-icons">dashboard</i>
                                    <p>@Resources.Shared._DashboardLayout.MainBoard</p>
                                </a>
                            </li>
                        End If

                        @Html.Raw("<hr style='margin-bottom:   0px;margin-top: -5px;padding-left: 10px;padding-right: 10px;display: Table-caption;' />")

                        If ViewData("Selection").Equals("Location") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                <a class="nav-link" href="@Url.Action("Index", "Location")">
                                    <i class="material-icons">add_location</i>
                                    <p>Location</p>
                                </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Location")">
                                     <i class="material-icons">add_location</i>
                                     <p>Location</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("Rates") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Rates")">
                                     <i class="material-icons">style</i>
                                     <p>Rates</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Rates")">
                                     <i class="material-icons">style</i>
                                     <p>Rates</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("Categorize") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Categorize")">
                                     <i class="material-icons">view_week</i>
                                     <p>Categorize</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Categorize")">
                                     <i class="material-icons">view_week</i>
                                     <p>Categorize</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("List") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "List")">
                                     <i class="material-icons">menu</i>
                                     <p>List</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "List")">
                                     <i class="material-icons">menu</i>
                                     <p>List</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("UserWorkflow") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "UserWorkflow")">
                                     <i class="material-icons">hail</i>
                                     <p>User Workflow</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "UserWorkflow")">
                                     <i class="material-icons">hail</i>
                                     <p>User Workflow</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("DriverRegistration") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "DriverRegistration")">
                                     <i class="material-icons">perm_contact_calendar</i>
                                     <p>Driver Registration</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "DriverRegistration")">
                                     <i class="material-icons">perm_contact_calendar</i>
                                     <p>Driver Registration</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("DriverWorkflow") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "DriverWorkflow")">
                                     <i class="material-icons">directions_car_filled</i>
                                     <p>Driver Workflow</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "DriverWorkflow")">
                                     <i class="material-icons">directions_car_filled</i>
                                     <p>Driver Workflow</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("Financial") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Financial")">
                                     <i class="material-icons">monetization_on</i>
                                     <p>Financial</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Financial")">
                                     <i class="material-icons">monetization_on</i>
                                     <p>Financial</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("Communication") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Communication")">
                                     <i class="material-icons">chat</i>
                                     <p>Communication</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "Communication")">
                                     <i class="material-icons">chat</i>
                                     <p>Communication</p>
                                 </a>
                            </li>
                        End If

                        If ViewData("Selection").Equals("ServerControl") Then
                            @<li class="nav-item active" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "ServerControl")">
                                     <i class="material-icons">loop</i>
                                     <p>Server control</p>
                                 </a>
                            </li>
                        Else
                            @<li class="nav-item" style="margin-top:-20px;">
                                 <a class="nav-link" href="@Url.Action("Index", "ServerControl")">
                                     <i class="material-icons">loop</i>
                                     <p>Server control</p>
                                 </a>
                            </li>
                        End If


                        @Html.Raw("<hr style='margin-bottom:   0px;margin-top: -5px;padding-left: 10px;padding-right: 10px;display: Table-caption;' />")

                        @<li class="nav-item" style="margin-top:-20px;">
                            <a class="nav-link" href="@Url.Action("Logout", "Dashboard")">
                                <i class="material-icons">power</i>
                                <p>@Resources.Shared._DashboardLayout.Output</p>
                            </a>
                        </li>
                    End Code
                </ul>
            </div>
        </div>
        <div class="main-panel">
            <nav class="navbar navbar-expand-lg navbar-transparent  navbar-absolute fixed-top">
                <div class="container-fluid">
                    <div class="navbar-wrapper">
                    </div>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navigation" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="navbar-toggler-icon icon-bar"></span>
                        <span class="navbar-toggler-icon icon-bar"></span>
                        <span class="navbar-toggler-icon icon-bar"></span>
                    </button>
                    <div class="collapse navbar-collapse justify-content-end" id="navigation">
                    </div>
                </div>
            </nav>
            <div class="content" style="margin-top: 20px;">
                @RenderBody()
            </div>
        </div>
    </div>

    @*@Scripts.Render("~/bundle/js")*@
    @Scripts.Render("~/bundle/admin/js")
    @RenderSection("Scripts", required:=False)
</body>
</html>
