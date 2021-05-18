Imports System.ComponentModel.DataAnnotations
Imports System.Globalization

Namespace Contract

    Public Class TripRequest1

        <Display(Name:="From Location ID (Guid)", Description:="Get ID in Location menu")>
        <Required(ErrorMessage:="Mandatory field")>
        Public Property FromLocationID As Guid

        <Display(Name:="To Location ID (Guid)", Description:="Get ID in Location menu")>
        <Required(ErrorMessage:="Mandatory field")>
        Public Property ToLocationID As Guid

        <Display(Name:="TripType Regular/InterCity/AirportCity")>
        <Required(ErrorMessage:="Mandatory field")>
        Public Property TripType As Integer
        'Regular = 1
        'InterCity = 2
        'AirportCity = 3

        <Display(Name:="Scheduled Yes/No")>
        <Required(ErrorMessage:="Mandatory field")>
        Public Property Scheduled As Boolean

        <Display(Name:="BidEnabled Yes/No")>
        <Required(ErrorMessage:="Mandatory field")>
        Public Property BidEnabled As Boolean

        Public Property DepartureTime As DateTime

        <Display(Name:="Departure DateTime (MM/dd/yyyy HH:mm)")>
        <DataType(DataType.DateTime, ErrorMessage:="MM/dd/yyyy HH:mm")>
        <DisplayFormat(ApplyFormatInEditMode:=True, DataFormatString:="{0:MM/dd/yyyy HH:mm}")>
        <Required(ErrorMessage:="Mandatory field")>
        Public Property DepartureDateTime As String
            Get
                Return DepartureTime.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                If Not String.IsNullOrEmpty(value) Then
                    DepartureTime = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        <Display(Name:="FareType")>
        <Required(ErrorMessage:="Mandatory field")>
        Public Property FareType As Int16

        <Display(Name:="PaymentMethod Id (Guid)")>
        Public Property PaymentMethodId As Nullable(Of Guid)

        <Display(Name:="Note")>
        Public Property Note As String

        <Display(Name:="Promotion Id (Guid)")>
        Public Property PromotionID As Nullable(Of Guid)

    End Class

End Namespace