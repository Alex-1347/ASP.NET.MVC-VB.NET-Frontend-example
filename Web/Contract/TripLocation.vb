Imports System.Globalization

Namespace Contract
    Public Class TripLocation

        Public Property Id As Guid
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
        Public Property RideTypeId As Guid
        Public Property DriverId As Nullable(Of Guid)
        Public Property CarId As Nullable(Of Guid)
        Public Property DepartureLocationId As Guid
        Public Property DestinationLocationId As Guid
        Public Property DestinationLocationId2 As Nullable(Of Guid)
        Public Property DestinationLocationId3 As Nullable(Of Guid)
        Public Property DestinationLocationId4 As Nullable(Of Guid)
        Public Property Scheduled As Boolean
        Public Property BidEnabled As Boolean
        Public Property DepartureTime As Nullable(Of DateTime)
        Public Property DepartureDateTime As String
            Get
                If DepartureTime.HasValue Then
                    Return DepartureTime.Value.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
                Return Nothing
            End Get
            Set(value As String)

            End Set
        End Property
        Public Property ArrivalTime As Nullable(Of DateTime)
        Public Property ArrivalDateTime As String
            Get
                If ArrivalTime.HasValue Then
                    Return ArrivalTime.Value.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
                Return Nothing
            End Get
            Set(value As String)

            End Set
        End Property
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
        Public Property PaymentMethodId As Nullable(Of Guid)
        Public Property FareId As Nullable(Of Guid)
        Public Property PromotionId As Nullable(Of Guid)
        Public Property Note As String
        Public Property Distance As Nullable(Of Int64)
        Public Property Duration As Nullable(Of Int64)
        Public Property WaitTime As Nullable(Of Int64)
        Public Property TravelPath As String
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
        Public Property User As User
        Public Property RideType As RideType
        Public Property Driver As Driver
        Public Property Car As Car
        Public Property DepartureLocation As Location
        Public Property DestinationLocation As Location
        Public Property DestinationLocation2 As Location
        Public Property DestinationLocation3 As Location
        Public Property DestinationLocation4 As Location
        Public Property PaymentMethod As UserCard
        Public Property Fare As TripFare
        Public Property Promotion As Contract.Promotion
        Public Property City As String
        Public Property CityId As Nullable(Of Guid)
        Public Property DepartureLocation_ToCity As System.Nullable(Of System.Guid)
        Public Property DepartureLocation_City As String
        Public Property DepartureLocation_Address As String
        Public Property DepartureLocation_Latitude As System.Nullable(Of Decimal)
        Public Property DepartureLocation_Longitude As System.Nullable(Of Decimal)
        Public Property DepartureLocation_GPlaceId As String
        Public Property DestinationLocation_ToCity As System.Nullable(Of System.Guid)
        Public Property DestinationLocation_City As String
        Public Property DestinationLocation_Address As String
        Public Property DestinationLocation_Latitude As System.Nullable(Of Decimal)
        Public Property DestinationLocation_Longitude As System.Nullable(Of Decimal)
        Public Property DestinationLocation_GPlaceId As String
        Public Property DestinationLocationId2_ToCity As System.Nullable(Of System.Guid)
        Public Property DestinationLocationId2_City As String
        Public Property DestinationLocationId2_Address As String
        Public Property DestinationLocationId2_Latitude As System.Nullable(Of Decimal)
        Public Property DestinationLocationId2_Longitude As System.Nullable(Of Decimal)
        Public Property DestinationLocationId2_GPlaceId As String
        Public Property DestinationLocationId3_ToCity As System.Nullable(Of System.Guid)
        Public Property DestinationLocationId3_City As String
        Public Property DestinationLocationId3_Address As String
        Public Property DestinationLocationId3_Latitude As System.Nullable(Of Decimal)
        Public Property DestinationLocationId3n_Longitude As System.Nullable(Of Decimal)
        Public Property DestinationLocationId3_GPlaceId As String
        Public Property DestinationLocationId4_ToCity As System.Nullable(Of System.Guid)
        Public Property DestinationLocationId4_City As String
        Public Property DestinationLocationId4_Address As String
        Public Property DestinationLocationId4_Latitude As System.Nullable(Of Decimal)
        Public Property DestinationLocationId4_Longitude As System.Nullable(Of Decimal)
        Public Property DestinationLocationId4_GPlaceId As String
    End Class

End Namespace
