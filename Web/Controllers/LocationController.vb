Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class LocationController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        Public Async Function Index() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadLocations(0).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        <HttpPost>
        Public Async Function Index(submitButton As String) As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                For Each OneKey As String In Request.Form.AllKeys
                    Select Case OneKey
                        Case "button-get-airport"
                            Return Await Task.Run(Function() RedirectToAction("Index", "Airport"))
                        Case "button-get-country"
                            Return Await Task.Run(Function() RedirectToAction("Index", "Country"))
                        Case "button-get-city"
                            Return Await Task.Run(Function() RedirectToAction("Index", "City"))
                        Case "button-get-place"
                            Return Await Task.Run(Function() RedirectToAction("Place"))
                    End Select
                Next
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function


        Public Async Function Place() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Place", ReadLocations(0).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Async Function ReadLocations(Skip As Integer) As Task(Of Model.ViewLocation)
            Dim Model As New Model.ViewLocation
            Model.Skip = Skip
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetLocations/{Skip}/10")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model.DataListT = JsonConvert.DeserializeObject(Of Contract.LocationList)(RespStr1)
                If Model.DataListT IsNot Nothing Then
                    Model.PagerText = $"Found {Model.DataListT.Locations.Count} Locations start from {Model.Skip}, Total {Model.DataListT.Total}"
                Else
                    Model.PagerText = $"Not found Locations start from {Model.Skip}"
                End If
            Else
                Model.PagerText = $"Not found Locations start from {Model.Skip}"
                Model.Err1 = "NoLocations-ServiceError "
            End If
            Return Await Task.Run(Function() Model)
        End Function

        Public Async Function [Previous](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadLocations(CInt(id) - 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function [Next](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadLocations(CInt(id) + 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        <HttpGet>
        Async Function Create() As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Contract.Location
                Return Await Task.Run(Function() View(Model))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function


        <HttpPost>
        Async Function Create(PostData As Contract.Location) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Parameters As New Dictionary(Of String, String)()
                Parameters.Add("Address", PostData.Address)
                Parameters.Add("City", PostData.City)
                Parameters.Add("Latitude", PostData.Latitude)
                Parameters.Add("Longitude", PostData.Longitude)
                Parameters.Add("GPlaceId", PostData.GPlaceId)
                Parameters.Add("ToCity", PostData.ToCity.ToString)
                'Dim Resp1 = Await SmartHttpClient.Post($"{Helper.Constants.Location_SERVICE}CreateLocation", Parameters) 'http://localhost/Backend/LocationService.svc/CreateLocation
                Dim Resp1 = Await SmartHttpClient.Post($"http://192.168.0.102:80/Backend/LocationService.svc/CreateLocation", Parameters)
                If Resp1.IsSuccessStatusCode Then
                    Return Await Task.Run(Function() RedirectToAction("Place"))
                Else
                    Return Await Task.Run(Function() View(PostData))
                End If
            Else
                Return Await Task.Run(Function() RedirectToAction("Place"))
            End If
        End Function

        Async Function ViewOneLocation(Id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Contract.Location
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetLocation/{Id.ToString().ToUpperInvariant()}")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Model = JsonConvert.DeserializeObject(Of Contract.Location)(RespStr1)
                Else
                    Model.Err1 = "NoDriver-ServiceError "
                End If
                Return Await Task.Run(Function() View("View", Model))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Async Function GetCities(Prefix As String) As Task(Of JsonResult)
            Dim Model As New List(Of String)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCities")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model = JsonConvert.DeserializeObject(Of List(Of String))(RespStr1)
            End If
            Return Await Task.Run(Function() Json(Model, JsonRequestBehavior.AllowGet))
        End Function

        Function GetCities1(Prefix As String) As List(Of Contract.Cities)
            Dim Model As New List(Of Contract.Cities)
            Dim Resp1 = SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCities").Result
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Resp1.Content.ReadAsStringAsync().Result
                Model = JsonConvert.DeserializeObject(Of List(Of Contract.Cities))(RespStr1)
            End If
            Return Model
        End Function

        Async Function CityHelp() As Task(Of ActionResult)
            Return Await Task.Run(Function() View("CityHelp", GetCities1("")))
        End Function

    End Class
End Namespace