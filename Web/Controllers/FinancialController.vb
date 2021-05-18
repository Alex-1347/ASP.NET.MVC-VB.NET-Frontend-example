Imports System.Web.Mvc
Imports System.Threading.Tasks
Namespace Controllers
    Public Class FinancialController
        Inherits Controller

        Async Function Index() As Threading.Tasks.Task(Of ActionResult)
            Dim UserState As Contract.User = Session.Item("USER_STATE")
            If UserState IsNot Nothing Then
                Return Await Task.Run(Function() View())
            Else
                Return Await Task.Run(Function() RedirectToAction("Index", "Home"))
            End If
        End Function
    End Class
End Namespace