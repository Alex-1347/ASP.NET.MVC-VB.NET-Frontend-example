Namespace Contract

    Public Enum TripTypes
        Regular = 1
        InterCity = 2
        AirportCity = 3
    End Enum

    Public Enum TripFareTypes
        MeterPostpaid = 1
        InterCityGovtPrepaid = 2
        InterCityDiscountPrepaid = 3
        InterCityGovtPostpaid = 4
        InterCityDiscountPostpaid = 5
        AirportCityGovtPrepaid = 6
        AirportCityDiscountPrepaid = 7
        AirportCityGovtPostpaid = 8
        AirportCityDiscountPostpaid = 9
    End Enum

    Public Enum TripStatuses As Int16
        Pending = 1
        Requested = 2
        Confirmed = 3
        OnTrip = 4
        Complete = 5
        CancelledUser = 6
        CancelledDriver = 7
        CancelledNoRide = 8
        CancelledSystem = 9
    End Enum

    Public Enum TripPaymentStatuses
        Pending = 1
        Complete = 2
        Failed = 3
        RefundPending = 4
        RefundComplete = 5
        RefundFailed = 6
        Cancelled = 7
    End Enum
End Namespace
