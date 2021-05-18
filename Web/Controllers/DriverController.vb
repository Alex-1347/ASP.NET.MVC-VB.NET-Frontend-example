Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports Newtonsoft.Json

Namespace Controllers
    Public Class DriverController
        Inherits Controller

        Protected Overrides Sub OnActionExecuted(ctx As ActionExecutedContext)
            MyBase.OnActionExecuted(ctx)
            If Not ctx.HttpContext.User.Identity.IsAuthenticated Then
                'ctx.HttpContext.Response.Redirect("/User/Authenticate")
            End If
        End Sub

        Function Index() As ActionResult
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return View()
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <ActionName("View")>
        Async Function ViewDriver(Id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model As New Model.ViewDriver
                Model.NotifParm = New Model.NotificationParamaters
                Model.GeoCoordinates = New Contract.GeoCoordinates
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Admin_SERVICE}Driver/{Id.ToString().ToUpperInvariant()}")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    Model.Driver = JsonConvert.DeserializeObject(Of Contract.Driver)(RespStr1)
                Else
                    Model.Err1 = "NoDriver-ServiceError "
                End If
                Model.DeleteDriverAtAll = False
                If Model.Driver.Status = 1 Then
                    'Pending Contact Verification
                    Model.ContactIsCorrent = False
                    Model.DocumentsIsCorrect = False
                    Model.DriverIsActive = False
                ElseIf Model.Driver.Status = 2 Then
                    'Pending Document Verification
                    Model.ContactIsCorrent = True
                    Model.DocumentsIsCorrect = False
                    Model.DriverIsActive = False
                ElseIf Model.Driver.Status = 3 Then
                    Model.ContactIsCorrent = True
                    Model.DocumentsIsCorrect = True
                    Model.DriverIsActive = True
                ElseIf Model.Driver.Status = 4 Then
                    'Active | Pending Document Update Verification
                    Model.ContactIsCorrent = True
                    Model.DocumentsIsCorrect = False
                    Model.DriverIsActive = True
                ElseIf Model.Driver.Status = 5 Then
                    'Suspended
                    Model.ContactIsCorrent = True
                    Model.DocumentsIsCorrect = True
                    Model.DriverIsActive = False
                End If
                Dim Resp2 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{Id.ToString().ToUpperInvariant()}/Car")
                If Resp2.IsSuccessStatusCode Then
                    Dim RespStr2 As String = Await Resp2.Content.ReadAsStringAsync()
                    Model.Cars = JsonConvert.DeserializeObject(Of List(Of Contract.Car))(RespStr2)
                Else
                    Model.Err1 &= "NoCars-ServiceError "
                End If
                Dim Resp3 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{Id.ToString().ToUpperInvariant()}/Document")
                If Resp3.IsSuccessStatusCode Then
                    Dim RespStr3 As String = Await Resp3.Content.ReadAsStringAsync()
                    Model.Documents = JsonConvert.DeserializeObject(Of List(Of Model.ViewDocument))(RespStr3)
                Else
                    Model.Err1 &= "NoDocuments-ServiceError "
                End If
                Dim Result As Tuple(Of String, String) = Await SmartHttpClient.GetStreamToBase64String($"{Helper.Constants.Driver_SERVICE}{Id.ToString().ToUpperInvariant()}/Image/Thumbnail")
                If Result.Item2 = "OK" Then
                    Model.EncodedPhoto = Result.Item1
                Else
                    Model.Err1 &= Result.Item2
                End If
                Dim DriverStatusList As New List(Of SelectListItem)
                DriverStatusList.Add(New SelectListItem With {.Text = "Pending Contact Verification", .Value = 1})
                DriverStatusList.Add(New SelectListItem With {.Text = "Pending Document Verification", .Value = 2})
                DriverStatusList.Add(New SelectListItem With {.Text = "Active", .Value = 3})
                DriverStatusList.Add(New SelectListItem With {.Text = "Active | Pending Document Update Verification", .Value = 4})
                DriverStatusList.Add(New SelectListItem With {.Text = "Suspended", .Value = 5})
                DriverStatusList.ForEach(Sub(x) If x.Value = Model.Driver.Status Then x.Selected = True)
                ViewData("DriverStatusList") = DriverStatusList
                Dim Resp4 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{Id.ToString().ToUpperInvariant()}/GetInstanceIDs")
                If Resp4.IsSuccessStatusCode Then
                    Dim RespStr4 As String = Await Resp4.Content.ReadAsStringAsync()
                    Dim Res4 = JsonConvert.DeserializeObject(Of Model.DeviceInstanceList)(RespStr4)
                    Model.DeviceInstances = Res4.InstanceList
                Else
                    Model.Err1 &= "NoDocuments-ServiceError "
                End If
                Dim SC As New ServiceController
                Dim RideTypeJson As JsonResult = Await SC.GetRideTypes()
                Dim RideTypeList As New List(Of SelectListItem)
                For Each One As Web.Contract.RideType In RideTypeJson.Data
                    RideTypeList.Add(New SelectListItem With {.Text = One.EName, .Value = One.Id.ToString})
                Next
                ViewData("RideTypeList") = RideTypeList
                Return View(Model)
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <ActionName("ViewDocument")>
        Async Function ViewDriverDocument(DriverId As String, DocId As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Dim Model = New Model.ViewDocumentFile
                Dim DocumentList As New List(Of Contract.Document)
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/Document")
                If Resp1.IsSuccessStatusCode Then
                    Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                    DocumentList = JsonConvert.DeserializeObject(Of List(Of Contract.Document))(RespStr1)
                    Dim CurDoc As Contract.Document = DocumentList.Where(Function(X) X.Id.ToString = DocId).FirstOrDefault
                    If CurDoc IsNot Nothing Then
                        Model.Id = CurDoc.Id
                        Model.DriverId = Guid.Parse(DriverId)
                        Model.Type = CurDoc.Type
                        Model.ValidFrom = CurDoc.ValidityFrom
                        Model.ValidTo = CurDoc.ValidTo
                        Model.Verified = CurDoc.IsVerified
                        Model.Identifier = CurDoc.Identifier
                        '
                        Dim Result As Tuple(Of String, String) = Await SmartHttpClient.GetStreamToBase64String($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/Document/{DocId.ToString}/File")
                        If Result.Item2 = "OK" Then
                            Model.EncodedDocument = Result.Item1
                        Else
                            Model.Err1 &= Result.Item2
                        End If
                    Else
                        Model.Err1 &= "NoDocuments-ServiceError "
                    End If
                Else
                    Model.Err1 &= "NoDocuments-ServiceError "
                End If
                Return View("ViewDocument", Model)
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        Async Function DocumentUpdate(DriverId As String, DocId As String, submitButton As String) As Threading.Tasks.Task(Of ActionResult)
            If submitButton = "Set document valid" Then
                Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/Document/{DocId.ToString().ToUpperInvariant()}/SetValid")
            ElseIf submitButton = "Delete document" Then
                Dim Resp2 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/Document/{DocId.ToString().ToUpperInvariant()}/Delete")
            End If
            Return Await Task.Run(Function() RedirectToAction("View", New With {.Id = DriverId}))
        End Function

        Async Function Update(DriverId As String, submitButton As String) As Threading.Tasks.Task(Of ActionResult)
            If submitButton = Resources.Driver.View.DriverUpdate Then
                'idiotic ASP.NET MVC checkbox logic
                'if checked, request.form("DocumentCheckBox")="cc1b2bcd-d9d6-4ec2-94e3-c684005a938b,false"
                'if not checked request.form("DocumentCheckBox")="false"
                If Request.Form("DeleteDriverAtAll").Contains(",") Then
                    Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/Delete")
                    Return Await Task.Run(Function() RedirectToAction("Index"))
                ElseIf Not Request.Form("ContactCheckBox").Contains(",") Then
                    'Pending Contact Verification
                    Dim Resp2 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/SetStatus/1")
                    Return Await Task.Run(Function() RedirectToAction("Index"))
                ElseIf Request.Form("ContactCheckBox").Contains(",") And Not Request.Form("DocumentCheckBox").Contains(",") And Not Request.Form("ActiveCheckBox").Contains(",") Then
                    'Pending Document Verification
                    Dim Resp3 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/SetStatus/2")
                    Return Await Task.Run(Function() RedirectToAction("Index"))
                ElseIf Request.Form("ContactCheckBox").Contains(",") And Request.Form("DocumentCheckBox").Contains(",") And Request.Form("ActiveCheckBox").Contains(",") Then
                    'Active
                    Dim Resp4 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/SetStatus/3")
                    Return Await Task.Run(Function() RedirectToAction("Index"))
                ElseIf Request.Form("ContactCheckBox").Contains(",") And Not Request.Form("DocumentCheckBox").Contains(",") And Request.Form("ActiveCheckBox").Contains(",") Then
                    'Active | Pending Document Update Verification
                    Dim Resp5 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/SetStatus/4")
                    Return Await Task.Run(Function() RedirectToAction("Index"))
                ElseIf Not Request.Form("ActiveCheckBox").Contains(",") Then
                    'Suspended
                    Dim Resp6 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/SetStatus/5")
                    Return Await Task.Run(Function() RedirectToAction("Index"))
                End If
                Return Await Task.Run(Function() RedirectToAction("View", New With {.Id = DriverId}))
                'handle event from second button
                'ElseIf submitButton = Resources.Driver.View.DeletingDriver Or submitButton = "Deleting" Then '???? truncate
                '    Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/Delete")
                '    Return Await Task.Run(Function() RedirectToAction("Index"))
            End If

        End Function


        Public Function GetCurrentDriverStatus(DriverStatusList As List(Of SelectListItem), CurStatus As Integer) As String
            For Each One In DriverStatusList
                If One.Value = CurStatus Then
                    Return One.Text
                End If
            Next
        End Function

        <HttpPost>
        Async Function SendNotification(DriverId As String, Distance As Integer, Time As Integer) As Threading.Tasks.Task(Of ActionResult)
            For Each OneKey As String In Request.Form.AllKeys
                If OneKey.StartsWith("button-send-notification-submit") Then
                    Exit For
                ElseIf OneKey.StartsWith("button-get-device-location") Then
                    Return Await GetDeviceLocationRequest(DriverId, OneKey.Replace("button-get-device-location-", ""))
                End If
            Next
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/PushNotification/Distance/Time")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                'Dim Res1 = JsonConvert.DeserializeObject(Of Model.DeviceInstanceList)(RespStr1)
            End If
            Return Await Task.Run(Function() RedirectToAction("View", New With {.Id = DriverId}))
        End Function

        Async Function GetDeviceLocationRequest(DriverId As String, DeviceID As String) As Threading.Tasks.Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/GetDeviceLocation/{DeviceID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Dim Res1 = JsonConvert.DeserializeObject(Of Contract.GeoCoordinates)(RespStr1)
            End If
            Return Await Task.Run(Function() RedirectToAction("View", New With {.Id = DriverId}))
        End Function

        Async Function UpdateCar(DriverId As String) As Threading.Tasks.Task(Of ActionResult)
            For Each OneKey As String In Request.Form.AllKeys
                If OneKey.StartsWith("button-car-add-submit") Then
                    Exit For
                ElseIf OneKey.StartsWith("button-set-current-car-") Then
                    Return Await SelectActiveCar(DriverId, OneKey.Replace("button-set-current-car-", ""))
                End If
            Next
            Return Await Task.Run(Function() RedirectToAction("View", New With {.Id = DriverId}))
        End Function

        Async Function SelectActiveCar(DriverId As String, CarId As String) As Threading.Tasks.Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverId.ToString().ToUpperInvariant()}/Car/{CarId}/Select")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Dim Res1 = JsonConvert.DeserializeObject(Of Contract.Car)(RespStr1)
            End If
            Return Await Task.Run(Function() RedirectToAction("View", New With {.Id = DriverId}))
        End Function

    End Class
End Namespace