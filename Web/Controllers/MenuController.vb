Imports System.Web.Mvc
Imports System.Threading.Tasks
Namespace Controllers
    Public Class MenuController
        Inherits Controller

        Async Function Index() As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View())
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

        Public Async Function Jump() As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                For Each OneKey As String In Request.Form.AllKeys
                    Select Case OneKey
                        Case "button-AddCard"
                        Case "button-AcceptBid"
                        Case "button-AcceptFire"
                        Case "button-Airport" : Return Await Task.Run(Function() RedirectToAction("Index", "Airport"))
                        Case "button-AirportCityRate" : Return Await Task.Run(Function() RedirectToAction("Index", "AirportCityRate"))
                        Case "button-ApproveDocuments"
                        Case "button-AuthenticationRestart"
                        Case "button-BidsList"
                        Case "button-CalculateDistance"
                        Case "button-CarList" : Return Await Task.Run(Function() RedirectToAction("Index", "Car"))
                        Case "button-CarTypes" : Return Await Task.Run(Function() RedirectToAction("Index", "CarType"))
                        Case "button-CheckDistance"
                        Case "button-City" : Return Await Task.Run(Function() RedirectToAction("Index", "City"))
                        Case "button-Country" : Return Await Task.Run(Function() RedirectToAction("Index", "Country"))
                        Case "button-CreateBid"
                        Case "button-CreateFire"
                        Case "button-DeviceList" : Return Await Task.Run(Function() RedirectToAction("Index", "Device"))
                        Case "button-DriverList" : Return Await Task.Run(Function() RedirectToAction("Index", "Driver"))
                        Case "button-DriverRegistration"
                        Case "button-EndRide"
                        Case "button-EndRide"
                        Case "button-Extra" : Return Await Task.Run(Function() RedirectToAction("Index", "Extra"))
                        Case "button-FireList"
                        Case "button-IISNodeRestart"
                        Case "button-InterCityRate" : Return Await Task.Run(Function() RedirectToAction("Index", "InterCityRate"))
                        Case "button-MessageList"
                        Case "button-NotificationList"
                        Case "button-NotificationRestart"
                        Case "button-PayFire"
                        Case "button-Payment"
                        Case "button-PaymentList"
                        Case "button-Place" : Return Await Task.Run(Function() RedirectToAction("Place", "Location"))
                        Case "button-Promotion" : Return Await Task.Run(Function() RedirectToAction("Index", "Promotion"))
                        Case "button-Review"
                        Case "button-ReviewList" : Return Await Task.Run(Function() RedirectToAction("Index", "Review"))
                        Case "button-RideList" : Return Await Task.Run(Function() RedirectToAction("Index", "Ride"))
                        Case "button-RideTypes" : Return Await Task.Run(Function() RedirectToAction("Index", "RideType"))
                        Case "button-SelectVehicle"
                        Case "button-SendMessage"
                        Case "button-SendMessages"
                        Case "button-SendMessages"
                        Case "button-SendNotification"
                        Case "button-SendNotification"
                        Case "button-SetStatus"
                        Case "button-StartRide"
                        Case "button-StartRide"
                        Case "button-TripRequest"
                        Case "button-TripRequestList" : Return Await Task.Run(Function() RedirectToAction("Index", "Trip"))
                        Case "Button-UpdateLocation"
                        Case "button-UploadDocuments"
                        Case "button-UploadPhoto"
                        Case "button-UploadVehicles"
                        Case "button-UserList" : Return Await Task.Run(Function() RedirectToAction("Index", "User"))
                        Case "button-UserRegistration"
                        Case Else
                            Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
                    End Select
                Next
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function


    End Class
End Namespace