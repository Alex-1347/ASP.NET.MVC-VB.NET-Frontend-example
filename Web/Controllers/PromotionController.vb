Imports System.Web.Mvc

Namespace Controllers
    Public Class PromotionController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        ' GET: Promotion
        Function Index() As ActionResult
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return View()
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        Function Create() As ActionResult
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return View()
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <ActionName("View")>
        Function ViewFeature(Id As String) As ActionResult
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return View()
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

    End Class
End Namespace