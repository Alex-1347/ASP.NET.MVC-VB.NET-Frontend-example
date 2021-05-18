Imports System.Globalization

Namespace Contract

    Public Class User

        Public Property Id As Guid

        Public Property CompanyId As Nullable(Of Guid)

        Public Property Language As Int16

        Public Property Name As String

        Public Property Email As String

        Public Property PhoneCountryId As Guid

        Public Property PhoneNumber As String

        Public Property Status As Int16

    End Class

End Namespace
