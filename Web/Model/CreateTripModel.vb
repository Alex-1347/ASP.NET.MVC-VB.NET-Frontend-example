Imports System.ComponentModel.DataAnnotations

Namespace Model

    Public Class CreateTripModel

        <Display(Name:="User ID (Guid)")>
        Property UserID As Guid
        Property Trip As Contract.TripRequest1
        Property Err1 As String
        Property TripID As Nullable(Of Guid)
    End Class

End Namespace