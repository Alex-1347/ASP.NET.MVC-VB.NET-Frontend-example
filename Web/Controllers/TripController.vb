Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class TripController
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
                Return Await Task.Run(Function() View(ReadTrips(0).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function
        Public Async Function [Previous](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadTrips(CInt(id) - 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function
        Public Async Function [Next](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadTrips(CInt(id) + 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function
        Async Function ReadTrips(Skip As Integer) As Task(Of Model.ViewTrips)
            Dim Model As New Model.ViewTrips
            Model.Skip = Skip
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}GetTrips/{Skip}/10")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model.DataListT = JsonConvert.DeserializeObject(Of Contract.TripLocationList)(RespStr1)
                If Model.DataListT IsNot Nothing Then
                    Model.PagerText = $"Found {Model.DataListT.TripLocation.Count} Trips start from {Model.Skip}, Total {Model.DataListT.Total}"
                Else
                    Model.PagerText = $"Not found Trips start from {Model.Skip}"
                End If
            Else
                Model.PagerText = $"Not found Trips start from {Model.Skip}"
                Model.Err1 = "NoTrips-ServiceError "
            End If
            Return Await Task.Run(Function() Model)
        End Function

        <HttpGet>
        Async Function Create() As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Model.CreateTripModel
                Dim Trip As New Contract.TripRequest1
                Model.Trip = Trip
                ViewData("TripTypeList") = CreateDropDownListFromEnum(GetType(Contract.TripTypes))
                ViewData("FireTypeList") = CreateDropDownListFromEnum(GetType(Contract.TripFareTypes))
                Return Await Task.Run(Function() View(Model))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function
        Function CreateDropDownListFromEnum(X As Type) As List(Of SelectListItem)
            Dim EnumTypeList = New List(Of SelectListItem)
            Dim Start As New SelectListItem
            Start.Value = 0
            Start.Text = "(select)"
            EnumTypeList.Add(Start)
            For Each OneVal As Integer In [Enum].GetValues(X)
                Dim OneName = [Enum].GetName(X, OneVal)
                Dim One As New SelectListItem
                One.Value = OneVal
                One.Text = OneName
                EnumTypeList.Add(One)
            Next
            Return EnumTypeList
        End Function
        Function SetSelectedItem(DropDownList As List(Of SelectListItem), SelectedValue As Integer) As List(Of SelectListItem)
            For Each One As SelectListItem In DropDownList
                One.Selected = False
            Next
            For Each One As SelectListItem In DropDownList
                If One.Value = SelectedValue Then
                    One.Selected = True
                    Exit For
                End If
            Next
            Return DropDownList
        End Function

        <HttpPost>
        Async Function Create(PostData As Model.CreateTripModel) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                If ModelState.IsValid Then
                    Dim TripRequestDict As New Dictionary(Of String, String)
                    TripRequestDict.Add("BidEnabled", IIf(PostData.Trip.BidEnabled, "1", "0"))
                    TripRequestDict.Add("Scheduled", IIf(PostData.Trip.Scheduled, "1", "0"))
                    TripRequestDict.Add("DepartureDateTime", PostData.Trip.DepartureDateTime)
                    If PostData.Trip.TripType > 0 Then
                        TripRequestDict.Add("TripType", PostData.Trip.TripType)
                    End If
                    If PostData.Trip.FareType > 0 Then
                        TripRequestDict.Add("FareType", PostData.Trip.FareType)
                    End If
                    TripRequestDict.Add("FromLocationID", PostData.Trip.FromLocationID.ToString)
                    TripRequestDict.Add("ToLocationID", PostData.Trip.ToLocationID.ToString)
                    If Not String.IsNullOrWhiteSpace(PostData.Trip.Note) Then
                        TripRequestDict.Add("Note", PostData.Trip.Note)
                    End If
                    If Not String.IsNullOrWhiteSpace(PostData.Trip.PaymentMethodId.ToString.Replace("0", "")) Then
                        TripRequestDict.Add("PaymentMethodId", PostData.Trip.PaymentMethodId.ToString)
                    End If
                    If Not String.IsNullOrWhiteSpace(PostData.Trip.PromotionID.ToString.Replace("0", "")) Then
                        TripRequestDict.Add("PromotionID", PostData.Trip.PromotionID.ToString)
                    End If
                    Dim JsonChildNode As String = JsonConvert.SerializeObject(TripRequestDict)

                    Dim Parameters As New Dictionary(Of String, String)
                    Parameters.Add("UserId", PostData.UserID.ToString)
                    Parameters.Add("TripRequest", "@@@")

                    Dim Resp1 = Await SmartHttpClient.Post($"{Helper.Constants.Trip_SERVICE}Create1", Parameters, """@@@""", JsonChildNode)
                    If Resp1.IsSuccessStatusCode Then
                        Return Await Task.Run(Function() RedirectToAction("Index"))
                    Else
                        ViewData("TripTypeList") = CreateDropDownListFromEnum(GetType(Contract.TripTypes))
                        ViewData("FireTypeList") = CreateDropDownListFromEnum(GetType(Contract.TripFareTypes))
                        Return Await Task.Run(Function() View("Create", PostData))
                    End If
                Else
                    Return Await Task.Run(Function() RedirectToAction("Create"))
                End If
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function
        Async Function CheckUserID(ID As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}CheckUserID/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                ViewBag.Name = RespStr1
            Else
                ViewBag.Name = "Server error"
            End If
            Return PartialView("Name")
        End Function
        Async Function CheckFromLocationID(ID As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}CheckFromLocationID/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                ViewBag.Name = RespStr1
            Else
                ViewBag.Name = "Server error"
            End If
            Return PartialView("Name")
        End Function
        Async Function CheckToLocationID(ID As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}CheckToLocationID/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                ViewBag.Name = RespStr1
            Else
                ViewBag.Name = "Server error"
            End If
            Return PartialView("Name")
        End Function
        Async Function CheckPaymentMethodId(ID As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}CheckPaymentMethodId/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                ViewBag.Name = RespStr1
            Else
                ViewBag.Name = "Server error"
            End If
            Return PartialView("Name")
        End Function
        Async Function CheckPromotionID(ID As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}CheckPromotionID/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                ViewBag.Name = RespStr1
            Else
                ViewBag.Name = "Server error"
            End If
            Return PartialView("Name")
        End Function

        <HttpGet>
        Async Function ViewOneTrip(ID As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Model.CreateTripModel
                Dim Trip As New Contract.TripRequest1
                Model.Trip = Trip
                Model.TripID = Guid.Parse(ID)
                ViewData("TripTypeList") = CreateDropDownListFromEnum(GetType(Contract.TripTypes))
                ViewData("FireTypeList") = CreateDropDownListFromEnum(GetType(Contract.TripFareTypes))
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}GetTrip/{ID}")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Dim TripAsContract As Contract.TripLocation = JsonConvert.DeserializeObject(Of Contract.TripLocation)(RespStr1)
                    Model.UserID = TripAsContract.UserId
                    Trip.BidEnabled = TripAsContract.BidEnabled
                    Trip.DepartureDateTime = TripAsContract.DepartureDateTime
                    Trip.FareType = TripAsContract.FareType
                    Trip.FromLocationID = TripAsContract.DepartureLocationId
                    Trip.ToLocationID = TripAsContract.DepartureLocationId
                    Trip.Note = TripAsContract.Note
                    Trip.PaymentMethodId = TripAsContract.PaymentMethodId
                    Trip.PromotionID = TripAsContract.PromotionId
                    Trip.Scheduled = TripAsContract.Scheduled
                    Trip.TripType = TripAsContract.Type
                    ViewData("TripTypeList") = SetSelectedItem(DirectCast(ViewData("TripTypeList"), List(Of SelectListItem)), Trip.TripType)
                    ViewData("FireTypeList") = SetSelectedItem(DirectCast(ViewData("FireTypeList"), List(Of SelectListItem)), Trip.FareType)
                Else
                    Model.Err1 = Resp1.ReasonPhrase
                End If
                Return Await Task.Run(Function() View(Model))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        <HttpPost>
        Async Function Delete(ID As String) As Threading.Tasks.Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}DelTrip/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                If RespStr1 = """OK""" Then
                    Return Await Task.Run(Function() RedirectToAction("Index"))
                Else
                    Return Await Task.Run(Function() RedirectToAction("ViewOneTrip", New With {.ID = ID}))
                End If
            Else
                Return Await Task.Run(Function() RedirectToAction("ViewOneTrip", New With {.ID = ID}))
            End If
        End Function
        Async Function ViewUserTrips(ID As String) As Threading.Tasks.Task(Of ActionResult)
            Dim Model As New Model.ViewTrips
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Trip_SERVICE}GetUserTrips/{ID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model.DataListT = JsonConvert.DeserializeObject(Of Contract.TripLocationList)(RespStr1)
                If Model.DataListT IsNot Nothing Then
                    Model.PagerText = $"Found {Model.DataListT.TripLocation.Count} Trips start from {Model.Skip}, Total {Model.DataListT.Total}"
                Else
                    Model.PagerText = $"Not found Trips start from {Model.Skip}"
                End If
            Else
                Model.PagerText = $"Not found Trips start from {Model.Skip}"
                Model.Err1 = "NoTrips-ServiceError "
            End If
            Return Await Task.Run(Function() View("Index", Model))
        End Function

    End Class
End Namespace