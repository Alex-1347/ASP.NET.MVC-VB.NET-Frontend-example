Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class AirportCityRateController
        Inherits Controller
        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        ' GET: AirportCityRate
        Async Function Index() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadRates(0).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function


        Async Function ReadRates(Skip As Integer) As Task(Of Model.ViewAirCityRates)
            Dim Model As New Model.ViewAirCityRates
            Model.Skip = Skip
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetAirportCityRates/{Skip}/10")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model.DataListT = JsonConvert.DeserializeObject(Of Contract.AirCityRateList)(RespStr1)
                If Model.DataListT IsNot Nothing Then
                    Model.PagerText = $"Found {Model.DataListT.AirCityRates.Count} Rates start from {Model.Skip}, Total {Model.DataListT.Total}"
                Else
                    Model.PagerText = $"Not found Locations start from {Model.Skip}"
                End If
            Else
                Model.PagerText = $"Not found Locations start from {Model.Skip}"
                Model.Err1 = "NoAirCityRates-ServiceError "
            End If
            Return Await Task.Run(Function() Model)
        End Function


        Public Async Function [Previous](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadRates(CInt(id) - 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function [Next](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadRates(CInt(id) + 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function GetAirportCityRate2(FromAirportIdPart As String, ToCityIdPart As String) As Threading.Tasks.Task(Of ActionResult)
            Dim Model As New List(Of Contract.AirportCityRate2)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetAirportCityRate/{FromAirportIdPart}/{ToCityIdPart}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model = JsonConvert.DeserializeObject(Of List(Of Contract.AirportCityRate2))(RespStr1)
            End If
            Return Await Task.Run(Function() View("Index", Model))
        End Function


        <ActionName("View")>
        Async Function ViewAirportCityRate(Id As String) As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Contract.AirportCityRate2
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetAirCityRate/{Id}")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Model = JsonConvert.DeserializeObject(Of Contract.AirportCityRate2)(RespStr1)
                End If
                Return Await Task.Run(Function() View("View", Model))
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <HttpPost>
        Async Function Update(PostData As Contract.AirportCityRate2, submitbutton As String) As Task(Of ActionResult)
            If ModelState.IsValid Then
                If submitbutton = "Update Rate" Then
                    Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}UpdateRate/{PostData.Id}/{PostData.Rate}/{If(PostData.DiscountRate, 0)}")
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    If RespStr1 = """OK""" Then
                        Return Await Task.Run(Function() RedirectToAction("Index"))
                    Else
                        Return Await Task.Run(Function() RedirectToAction("View", New With {.Id = PostData.Id}))
                    End If
                ElseIf submitbutton = "Delete Rate" Then
                    Return Task.Run(Function() DeleteRate(PostData.Id.ToString)).Result
                End If
            End If
        End Function


        <HttpGet>
        Async Function Create() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCountries")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Dim Contries As List(Of Contract.Country) = JsonConvert.DeserializeObject(Of List(Of Contract.Country))(RespStr1)
                    Dim CountryList As New List(Of SelectListItem)
                    CountryList.Add(New SelectListItem With {.Text = "(select)", .Value = Guid.Empty.ToString})
                    Contries.ForEach(Sub(x) CountryList.Add(New SelectListItem With {.Text = x.EName, .Value = x.Id.ToString}))
                    ViewData("CountryList") = CountryList
                End If
                Dim Model As New Contract.AirportCityRate2
                Return Await Task.Run(Function() View("Create", Model))
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <HttpPost>
        Async Function Create(Postdata As NameValueCollection) As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim RQ As New Contract.AirportCityRate1
                RQ.FromAirportId = Guid.Parse(Request.Form("AirPortDatas"))
                RQ.ToCityId = Guid.Parse(Request.Form("CityDatas"))
                If Not String.IsNullOrWhiteSpace(Request.Form("Rate")) Then
                    RQ.Rate = CDec(Request.Form("Rate"))
                End If
                If Not String.IsNullOrWhiteSpace(Request.Form("DiscountRate")) Then
                    RQ.DiscountRate = CDec(Request.Form("DiscountRate"))
                Else
                    RQ.DiscountRate = 0
                End If
                RQ.Type = CInt(Request.Form("Type"))
                Dim Parameters As New Dictionary(Of String, String)
                Parameters.Add("FromAirportId", RQ.FromAirportId.ToString)
                Parameters.Add("ToCityId", RQ.ToCityId.ToString)
                Parameters.Add("Rate", RQ.Rate)
                Parameters.Add("DiscountRate", RQ.DiscountRate)
                Parameters.Add("Type", RQ.Type)
                Dim Resp1 = Await SmartHttpClient.Post($"{Helper.Constants.Location_SERVICE}CreateAirportsCityRate", Parameters)
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Return Await Task.Run(Function() RedirectToAction("Index"))
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        Async Function DeleteRate(ID As String) As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}DeleteRate/{ID}")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    If RespStr1 = """OK""" Then
                        Return Await Task.Run(Function() RedirectToAction("Index"))
                    Else
                        Return Await Task.Run(Function() RedirectToAction("Index"))
                    End If
                Else
                    Return Await Task.Run(Function() RedirectToAction("Index"))
                End If
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        Async Function CityHelp() As Task(Of ActionResult)
            Return Await Task.Run(Function() View("CityHelp", GetCities1("")))
        End Function

        Async Function AirHelp() As Task(Of ActionResult)
            Return Await Task.Run(Function() View("AirHelp", GetAirport("")))
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

        Function GetAirport(Prefix As String) As List(Of Contract.Airport)
            Dim Model As New List(Of Contract.Airport)
            Dim Resp1 = SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetAirports").Result
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Resp1.Content.ReadAsStringAsync().Result
                Model = JsonConvert.DeserializeObject(Of List(Of Contract.Airport))(RespStr1)
            End If
            Return Model
        End Function

        Async Function CheckCityID(ID As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCityInfo/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Dim Model As Contract.CityCountry = JsonConvert.DeserializeObject(Of Contract.CityCountry)(RespStr1)
                ViewBag.Name = Model.Cities_EName
            Else
                ViewBag.Name = "Server error"
            End If
            Return PartialView("Name")
        End Function

        Async Function CheckAirID(ID As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetAirportInfo/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Dim Model As Contract.Airport = JsonConvert.DeserializeObject(Of Contract.Airport)(RespStr1)
                ViewBag.Name = Model.EName
            Else
                ViewBag.Name = "Server error"
            End If
            Return PartialView("Name")
        End Function


        Async Function AirportCity(id As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetAirportsForCountry/{id}")
            If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Dim Airports As List(Of Contract.Airport) = JsonConvert.DeserializeObject(Of List(Of Contract.Airport))(RespStr1)
                    Dim AirportDatas As New List(Of SelectListItem)
                    AirportDatas.Add(New SelectListItem With {.Text = "(select)", .Value = Guid.Empty.ToString})
                    Airports.ForEach(Sub(x) AirportDatas.Add(New SelectListItem With {.Text = x.EName, .Value = x.Id.ToString}))
                    ViewData("Airports") = AirportDatas
                End If
                Dim Resp2 = Await SmartHttpClient.Get($"{Helper.Constants.Location_SERVICE}GetCityForCountry/{id}")
                If Resp2.IsSuccessStatusCode Then
                    Dim RespStr2 As String = Await Resp2.Content.ReadAsStringAsync()
                    Dim CityList As List(Of Contract.CityCountry) = JsonConvert.DeserializeObject(Of List(Of Contract.CityCountry))(RespStr2)
                    Dim CityDatas As New List(Of SelectListItem)
                    CityDatas.Add(New SelectListItem With {.Text = "(select)", .Value = Guid.Empty.ToString})
                CityList.ForEach(Sub(x) CityDatas.Add(New SelectListItem With {.Text = x.Cities_EName, .Value = x.Cities_Id.ToString}))
                    ViewData("Cities") = CityDatas
                End If
            Return Await Task.Run(Function() PartialView("AirportCity"))
        End Function


    End Class

End Namespace