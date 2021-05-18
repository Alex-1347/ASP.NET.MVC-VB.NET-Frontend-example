Imports System.Web.Mvc

Namespace Controllers
    Public Class PaymentController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        ' GET: Payment
        Function Index() As ActionResult
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Model.ViewPayment
                Return View(Model)
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function
    End Class
End Namespace