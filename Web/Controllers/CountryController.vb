Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class CountryController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        ' GET: Country
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
        Async Function ViewCountry(Id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New List(Of Contract.CityCountry)
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCityForCountry/{Id}")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Model = JsonConvert.DeserializeObject(Of List(Of Contract.CityCountry))(RespStr1)
                End If
                Return View(Model)
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

    End Class
End Namespace