Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class UserController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        ' GET: User
        Function Index() As ActionResult
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return View()
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <ActionName("View")>
        Async Function ViewEmployee(Id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Model.ViewUser
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Admin_SERVICE}User/{Id.ToString().ToUpperInvariant()}")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Model.User = JsonConvert.DeserializeObject(Of Contract.User)(RespStr1)
                Else
                    Model.Err1 = "NoDriver-ServiceError "
                End If
                Return View(Model)
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

    End Class
End Namespace