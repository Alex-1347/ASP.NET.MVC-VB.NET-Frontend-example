Imports System.Web.Mvc

Namespace Controllers
    Public Class BidController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        ' GET: Bid
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace