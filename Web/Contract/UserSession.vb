Namespace Contract

    Public Class UserSession

        Public Property Id As Guid

        Public Property UserId As Guid

        Public Property SessionId As String

        Public Property User As User

        Public Property AccessToken As UserToken

        Public Property ReissueToken As UserToken

    End Class

End Namespace
