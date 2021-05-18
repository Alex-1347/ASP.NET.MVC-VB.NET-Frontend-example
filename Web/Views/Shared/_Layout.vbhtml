<!DOCTYPE html>
<html lang="en" dir="ltr">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no">
    <link rel="icon" type="image/png" href="~/Assets/Image/favicon.png">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>@ViewBag.Title - TaxiStar</title>
    @Styles.Render("~/bundle/font/google")
    @Styles.Render("~/bundle/font/awesome")
    @Styles.Render("~/bundle/css")
</head>
<body>
    <div class="navbar navbar-transparent navbar-color-on-scroll fixed-top navbar-expand-lg" color-on-scroll="100" id="sectionsNav">
        <div class="container">
            <div class="navbar-translate">
                @Html.ActionLink("TaxiStar", "Index", "Home", Nothing, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav ml-auto"></ul>
            </div>
        </div>
    </div>
    <div>
        @RenderBody()
    </div>
    <footer class="footer fixed-bottom">
        <div class="container">
            <div class="copyright float-right" style="color: white;">
                @*&copy; @DateTime.Now.Year <a href="http://eccelor.com" target="_blank" style="color: white;"><u>Eccelor Systems</u></a>
        version 0.01*@
            </div>
        </div>
    </footer>

    @Scripts.Render("~/bundle/js")
    @RenderSection("Scripts", required:=False)
</body>
</html>