Imports System.Globalization

Namespace Contract

    Public Class TripAvailabilityRequest1

        Public Property FromLocationID As Guid

        Public Property ToLocationID As Guid


        Public Property TripType As Integer
        'Regular = 1
        'InterCity = 2
        'AirportCity = 3


        Public Property Scheduled As Boolean


        Public Property BidEnabled As Boolean


        Public Property DepartureTime As DateTime


        Public Property DepartureDateTime As String
            Get
                Return DepartureTime.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    DepartureTime = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property


        Public Property FareType As Int16


        Public Property PaymentMethodId As Nullable(Of Guid)


        Public Property Note As String


        Public Property PromotionID As Nullable(Of Guid)

    End Class

End Namespace