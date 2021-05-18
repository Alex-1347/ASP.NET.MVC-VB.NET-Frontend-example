Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class CityController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        Async Function Index() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadCity(0).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function [Previous](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadCity(CInt(id) - 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function [Next](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadCity(CInt(id) + 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        <HttpGet>
        Async Function Create() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Contract.Cities
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCountries")
                If Resp1.IsSuccessStatusCode Then
                    Dim Content As String = Await Resp1.Content.ReadAsStringAsync()
                    Dim ReadingList As List(Of Contract.Country) = JsonConvert.DeserializeObject(Of List(Of Contract.Country))(Content)
                    Dim CountryList As New List(Of SelectListItem)
                    ReadingList.ForEach(Sub(x)
                                            CountryList.Add(New SelectListItem With {.Text = x.EName, .Value = x.Id.ToString})
                                        End Sub)
                    ViewData("CountryList") = CountryList
                End If
                Return View(Model)
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <HttpPost>
        Async Function Create(PostData As Contract.Cities) As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                If ModelState.IsValid Then
                    Dim CountryID As Guid = Guid.Parse(PostData.CityID.ToString)
                    Dim Parameters As New Dictionary(Of String, String)
                    Parameters.Add("City", PostData.City)
                    Parameters.Add("CityID", Guid.Parse(PostData.CityID.ToString).ToString)
                    Dim Resp1 = Await SmartHttpClient.Post($"{Helper.Constants.Location_SERVICE}CreateCity", Parameters)
                    If Resp1.IsSuccessStatusCode Then
                        Return Await Task.Run(Function() RedirectToAction("Index"))
                    Else
                        Return Await Task.Run(Function() View("Create", PostData))
                    End If
                Else
                    Return RedirectToAction("Create")
                End If
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <ActionName("ViewCity")>
        Async Function ViewCity(Id As String) As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Contract.CityCountry
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCityCountry/{Id}")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Model = JsonConvert.DeserializeObject(Of Contract.CityCountry)(RespStr1)

                    Dim ViewLocationModel As New Model.ViewLocation
                    Dim Resp2 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetLocationForCity/{Id}")

                    If Resp2.IsSuccessStatusCode Then
                        Dim RespStr2 As String = Await Resp2.Content.ReadAsStringAsync()
                        Dim LS As List(Of Contract.Location) = JsonConvert.DeserializeObject(Of List(Of Contract.Location))(RespStr2)
                        ViewLocationModel.DataListT = New Contract.LocationList
                        ViewLocationModel.DataListT.Locations = New List(Of Contract.Location)
                        LS.ForEach(Sub(X) ViewLocationModel.DataListT.Locations.Append(X))
                    End If
                    ViewData("Location") = ViewLocationModel
                End If
                Return View(Model)
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        Async Function ReadCity(Skip As Integer) As Task(Of Model.ViewCity)
            Dim Model As New Model.ViewCity
            Model.Skip = Skip
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCity/{Skip}/10")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model.DataListT = JsonConvert.DeserializeObject(Of Contract.CityList)(RespStr1)
                If Model.DataListT IsNot Nothing Then
                    Model.PagerText = $"Found {Model.DataListT.Cities.Count} Cities start from {Model.Skip}, Total {Model.DataListT.Total}"
                Else
                    Model.PagerText = $"Not found Cities start from {Model.Skip}"
                End If
            Else
                Model.PagerText = $"Not found Cities start from {Model.Skip}"
                Model.Err1 = "NoCities-ServiceError "
            End If
            Return Await Task.Run(Function() Model)
        End Function

    End Class
End Namespace