Imports System.Web.Mvc
Imports System.Threading.Tasks
Namespace Controllers
    Public Class RatesController
        Inherits Controller

        Function Index() As ActionResult
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return View()
            Else
                Return RedirectToAction("Index", "Home")
            End If
        End Function

        <HttpPost>
        Public Async Function Index(submitButton As String) As Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                For Each OneKey As String In Request.Form.AllKeys
                    Select Case OneKey
                        Case "button-InterCityRate"
                            Return Await Task.Run(Function() RedirectToAction("Index", "InterCityRate"))
                        Case "button-AirportCityRate"
                            Return Await Task.Run(Function() RedirectToAction("Index", "AirportCityRate"))
                        Case "button-Promotion"
                            Return Await Task.Run(Function() RedirectToAction("Index", "Promotion"))
                        Case "button-Extra"
                            Return Await Task.Run(Function() RedirectToAction("Index", "Extra"))
                    End Select
                Next
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function

    End Class
End Namespace