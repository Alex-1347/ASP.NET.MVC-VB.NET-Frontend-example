Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        'bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
        '            "~/Scripts/jquery-{version}.js"))

        'bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
        '            "~/Scripts/jquery.validate*"))

        '' Use the development version of Modernizr to develop with and learn from. Then, when you're
        '' ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
        'bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
        '            "~/Scripts/modernizr-*"))

        'bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
        '          "~/Scripts/bootstrap.js"))

        'bundles.Add(New StyleBundle("~/Content/css").Include(
        '          "~/Content/bootstrap.css",
        '          "~/Content/site.css"))

        bundles.UseCdn = True

        Dim GoogleFontBundle As New StyleBundle("~/bundle/font/google", "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons")
        bundles.Add(GoogleFontBundle)

        Dim GoogleHebrewFontBundle As New StyleBundle("~/bundle/font/google/hebrew", "https://fonts.googleapis.com/css?family=Varela+Round&display=swap")
        bundles.Add(GoogleHebrewFontBundle)

        Dim AwesomeFontBundle As New StyleBundle("~/bundle/font/awesome", "https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css")
        bundles.Add(AwesomeFontBundle)

        Dim CSSBundle As New StyleBundle("~/bundle/css")
        CSSBundle = CSSBundle.Include("~/Assets/CSS/material-kit*", "~/Assets/CSS/site.css")
        bundles.Add(CSSBundle)

        Dim AdminCSSBundle As New StyleBundle("~/bundle/admin/css")
        AdminCSSBundle = AdminCSSBundle.Include("~/Assets/Admin/css/material-dashboard.css")
        'AdminCSSBundle = AdminCSSBundle.Include("~/Assets/Admin/css/material-dashboard-rtl.css")
        AdminCSSBundle = AdminCSSBundle.Include("~/Assets/Admin/css/site.css")
        AdminCSSBundle = AdminCSSBundle.Include("~/Assets/Admin/css/material-dashboard.css")
        AdminCSSBundle = AdminCSSBundle.Include("~/Assets/Admin/css/bootstrap-datetimepicker.min.css")
        bundles.Add(AdminCSSBundle)

        Dim JSBundle As New ScriptBundle("~/bundle/js")
        'JSBundle = JSBundle.Include("~/Assets/JS/core/jquery.min.js", "~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Assets/JS/core/popper.min.js", "~/Assets/JS/core/bootstrap-material-design.min.js")
        JSBundle = JSBundle.Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery.unobtrusive-ajax.min.js","~/Scripts/jquery.validate*", "~/Assets/JS/core/popper.min.js", "~/Assets/JS/core/bootstrap-material-design.min.js")
        JSBundle = JSBundle.Include("~/Assets/JS/plugins/moment.min.js", "~/Assets/JS/plugins/bootstrap-datetimepicker.js", "~/Assets/JS/plugins/nouislider.min.js")
        JSBundle = JSBundle.Include("~/Assets/JS/material-kit*")
        bundles.Add(JSBundle)

        Dim AdminJSBundle As New ScriptBundle("~/bundle/admin/js")
        'JSBundle = JSBundle.Include("~/Assets/JS/core/jquery.min.js", "~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Assets/JS/core/popper.min.js", "~/Assets/JS/core/bootstrap-material-design.min.js")
        'AdminJSBundle = AdminJSBundle.Include("~/Assets/Admin/js/core/jquery.min.js", "~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Assets/Admin/js/core/popper.min.js", "~/Assets/Admin/js/core/bootstrap-material-design.min.js")
        AdminJSBundle = AdminJSBundle.Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Assets/Admin/js/core/popper.min.js", "~/Assets/Admin/js/core/bootstrap-material-design.min.js")
        AdminJSBundle = AdminJSBundle.Include("~/Assets/Admin/js/plugins/perfect-scrollbar.jquery.min.js", "~/Assets/Admin/js/plugins/bootstrap-notify.js")
        AdminJSBundle = AdminJSBundle.Include("~/Assets/Admin/js/plugins/moment.min.js", "~/Assets/Admin/js/plugins/arrive.min.js", "~/Assets/Admin/js/plugins/bootstrap-datetimepicker.min.js", "~/Assets/Admin/js/plugins/bootstrap-selectpicker.js")
        AdminJSBundle = AdminJSBundle.Include("~/Assets/Admin/js/material-dashboard.min.js")
        AdminJSBundle = AdminJSBundle.Include("~/Assets/Admin/js/site.js")
        bundles.Add(AdminJSBundle)

        BundleTable.EnableOptimizations = True

    End Sub
End Module

