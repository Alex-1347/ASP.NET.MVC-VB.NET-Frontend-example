Imports System.Globalization

Namespace Contract

    Public Class Trip

        Public Property Id As Guid

        Public Property UserId As Guid

        Public Property Type As Int16
            Get
                Return Type
            End Get
            Set(value As Int16)
                Select Case value
                    Case 1 : TypeStr = "Regular"
                    Case 2 : TypeStr = "InterCity"
                    Case 3 : TypeStr = "AirportCity"
                End Select
            End Set
        End Property
        Public Property TypeStr As String
        Public Property City As String
        Public Property CityId As Nullable(Of Guid)
        Public Property FareId As Nullable(Of Guid)

        Public Property RequestType As Int16
        Public Property DepartureLocationId As String
        Public Property DestinationLocationId As String
        Public Property Scheduled As Boolean
        Public Property BidEnabled As Boolean
        Public Property DepartureLatitude As Decimal
        Public Property DepartureLongitude As Decimal

        Public Property FareType As Int16
            Get
                Return FareType
            End Get
            Set(value As Int16)
                Select Case value
                    Case 0 : FareTypeStr = "Undefined"
                    Case 1 : FareTypeStr = "MeterPostpaid"
                    Case 2 : FareTypeStr = "InterCityGovtPrepaid"
                    Case 3 : FareTypeStr = "InterCityDiscountPrepaid"
                    Case 4 : FareTypeStr = "InterCityGovtPostpaid"
                    Case 5 : FareTypeStr = "InterCityDiscountPostpaid"
                    Case 6 : FareTypeStr = "AirportCityGovtPrepaid"
                    Case 7 : FareTypeStr = "AirportCityDiscountPrepaid"
                    Case 8 : FareTypeStr = "AirportCityGovtPostpaid"
                    Case 9 : FareTypeStr = "AirportCityDiscountPostpaid"
                End Select
            End Set
        End Property

        Public Property FareTypeStr As String

        Public Property DepartureAddress As String

        Public Property DestinationLatitude As Decimal

        Public Property DestinationLongitude As Decimal

        Public Property DestinationAddress As String

        Public Property DepartureTime As Nullable(Of DateTime)

        Public Property DepartureDateTime As String
            Get
                If DepartureTime.HasValue Then
                    Return DepartureTime.Value.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
                Return Nothing
            End Get
            Set(Value As String)
                If Not String.IsNullOrWhiteSpace(Value) Then
                    DepartureTime = DateTime.ParseExact(Value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property ArrivalTime As Nullable(Of DateTime)

        Public Property Arrival As String
            Get
                If ArrivalTime.HasValue Then
                    Return ArrivalTime.Value.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
                Return Nothing
            End Get
            Set(Value As String)
                If Not String.IsNullOrWhiteSpace(Value) Then
                    ArrivalTime = DateTime.ParseExact(Value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property Passengers As Int32

        Public Property PaymentType As Int16

        Public Property PaymentMethodId As Nullable(Of Guid)

        Public Property EstimatedFare As Double

        Public Property ActualFare As Nullable(Of Double)

        Public Property EstimatedDistance As Double

        Public Property ActualDistance As Nullable(Of Double)

        Public Property EstimatedDuration As Int64

        Public Property ActualDuration As Nullable(Of Int64)

        Public Property WaitTime As Nullable(Of Int64)

        Public Property FlightNo As String

        Public Property CarId As Nullable(Of Guid)
        Public Property RideTypeId As Nullable(Of Guid)

        Public Property Status As Int16
            Get
                Return Status
            End Get
            Set(value As Int16)
                Select Case value
                    Case 1 : StatusStr = "Pending"
                    Case 2 : StatusStr = "Requested"
                    Case 3 : StatusStr = "Confirmed"
                    Case 4 : StatusStr = "OnTrip"
                    Case 5 : StatusStr = "Complete"
                    Case 6 : StatusStr = "CancelledUser"
                    Case 7 : StatusStr = "CancelledDriver"
                    Case 8 : StatusStr = "CancelledNoRide"
                    Case 9 : StatusStr = "CancelledSystem"
                End Select
            End Set
        End Property
        Public Property StatusStr As String
        Public Property PaymentStatus As Int16
            Get
                Return PaymentStatus
            End Get
            Set(value As Int16)
                Select Case value
                    Case 1 : PaymentStatusStr = "Pending"
                    Case 2 : PaymentStatusStr = "Complete"
                    Case 3 : PaymentStatusStr = "Failed"
                    Case 4 : PaymentStatusStr = "RefundPending"
                    Case 5 : PaymentStatusStr = "RefundComplete"
                    Case 6 : PaymentStatusStr = "RefundFailed"
                    Case 7 : PaymentStatusStr = "Cancelled"
                End Select
            End Set
        End Property
        Public Property PaymentStatusStr As String

        Public Property PromotionId As Nullable(Of Guid)
        Public Property InsertedOn As DateTime
        Public Property InsertDate As String
            Get
                Return InsertedOn.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
            End Get
            Set(Value As String)
                If Not String.IsNullOrWhiteSpace(Value) Then
                    InsertedOn = DateTime.ParseExact(Value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property UpdatedOn As Nullable(Of DateTime)

        Public Property UpdateDate As String
            Get
                If UpdatedOn.HasValue Then
                    Return UpdatedOn.Value.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
                Return Nothing
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    UpdatedOn = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property Note As String

        Public Property DeletedOn As Nullable(Of DateTime)

        Public Property DeleteDate As String
            Get
                If DeletedOn.HasValue Then
                    Return DeletedOn.Value.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
                Return Nothing
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    DeletedOn = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property DriverId As Nullable(Of Guid)

        Public Property IsDeleted As Boolean

        Public Property User As Contract.User

        Public Property RequestedRideType As Contract.RideType

        Public Property ActualRideType As Contract.RideType

        Public Property Estimate As Contract.TripFare

        Public Property Fare As Contract.TripFare

        Public Property Transactions As List(Of Contract.Transaction)

        Public Property Car As Car

        Public Property Conversation As Conversation

    End Class

End Namespace
