Imports System.Web.Mvc
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Namespace Controllers
    Public Class DeviceController
        Inherits Controller

        Async Function Index() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadDevice(0).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function [Previous](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadDevice(CInt(id) - 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function [Next](id As String) As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View("Index", ReadDevice(CInt(id) + 10).Result))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Async Function ReadDevice(Skip As Integer) As Task(Of Model.ViewDevice)
            Dim Model As New Model.ViewDevice
            Model.Skip = Skip
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}GetDevices/{Skip}/10")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
                Model.DataListT = JsonConvert.DeserializeObject(Of Contract.DeviceList)(RespStr1)
                If Model.DataListT IsNot Nothing Then
                    Model.PagerText = $"Found {Model.DataListT.DataList.Count} Devices start from {Model.Skip}, Total {Model.DataListT.Total}"
                Else
                    Model.PagerText = $"Not found Devices start from {Model.Skip}"
                End If
            Else
                Model.PagerText = $"Not found Devices start from {Model.Skip}"
                Model.Err1 = "NoDevices-ServiceError "
            End If
            Return Await Task.Run(Function() Model)
        End Function

        Async Function Push() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View())
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        <HttpPost>
        Async Function Push(DriverID As String, DeviceID As String, TripID As String) As Task(Of ActionResult)
            Dim Resp1 = Await SmartHttpClient.Get($"{Helper.Constants.Driver_SERVICE}{DriverID}/PushOneNotification/{DeviceID}/{TripID}")
            If Resp1.IsSuccessStatusCode Then
                Dim RespStr1 As String = Await Resp1.Content.ReadAsStringAsync()
            End If
            Return Await Task.Run(Function() RedirectToAction("Index"))
        End Function

    End Class
End Namespace