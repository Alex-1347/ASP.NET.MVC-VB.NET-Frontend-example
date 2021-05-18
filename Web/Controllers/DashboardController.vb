Imports System.Web.Mvc
Imports System.Text
Namespace Controllers
    Public Class DashboardController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        ' GET: Dashboard
        Async Function Index() As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim TXT As String = My.Computer.FileSystem.ReadAllText(IO.Path.Combine(Server.MapPath("~"), "version.txt"))
                ViewBag.FrontendVersion = TXT.Replace(vbCrLf, "<br>")
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Core_SERVICE}GetVersion")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespArr1 As Byte() = Await Resp1.Content.ReadAsByteArrayAsync
                    Dim Str1 = Encoding.UTF8.GetString(RespArr1)
                    Dim Str2 = Str1.Replace("\\", "\").Replace("""", "").Replace("\u000d\u000a", "<br>") 'manual transform Unicode to UTF8 file Version.txt
                    ViewBag.BackendVersion = Str2
                End If
                Return View()
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        Function Logout() As ActionResult
            Session.Clear()
            Session.Abandon()
            Return RedirectToAction("Index", "Home")
        End Function

    End Class
End Namespace