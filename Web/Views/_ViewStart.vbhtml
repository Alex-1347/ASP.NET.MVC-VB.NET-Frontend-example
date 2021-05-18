@Code
    Dim UserState = Session.Item("USER_STATE")
    If UserState IsNot Nothing Then
        Layout = "~/Views/Shared/_DashboardLayout.vbhtml"
    Else
        Layout = "~/Views/Shared/_Layout.vbhtml"
    End If
End Code