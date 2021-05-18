Imports System.Web.Mvc
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Namespace Controllers

    Public Class AirportController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        ' GET: Airport
        Async Function Index() As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadAirport(0).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function [Previous](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadAirport(CInt(id) - 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function [Next](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadAirport(CInt(id) + 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Async Function ReadAirport(Skip As Integer) As Task(Of Model.ViewAirport)
            Dim Model As New Model.ViewAirport
            Model.Skip = Skip
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetAirportsForPager/{Skip}/10")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model.DataListT = JsonConvert.DeserializeObject(Of Contract.AirportList)(RespStr1)
                If Model.DataListT IsNot Nothing Then
                    Model.PagerText = $"Found {Model.DataListT.DataList.Count} Locations start from {Model.Skip}, Total {Model.DataListT.Total}"
                Else
                    Model.PagerText = $"Not found Cities start from {Model.Skip}"
                End If
            Else
                Model.PagerText = $"Not found Cities start from {Model.Skip}"
                Model.Err1 = "NoLocations-ServiceError "
            End If
            Return Await Task.Run(Function() Model)
        End Function


        Async Function Create() As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
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
                Return View()
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        <ActionName("View")>
        Async Function ViewAirport(Id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return View()
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

    End Class

End Namespace