Imports System.IO

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim UserState As Contract.User = Session.Item("USER_STATE")
        If UserState IsNot Nothing Then
            Return RedirectToAction("Index", "Dashboard")
        Else
            Return View()
        End If
    End Function

End Class