Namespace Contract

    Public Class AirportCityRate

        Public Property Id As Guid

        Public Property FromAirportId As Guid

        Public Property ToCityId As Guid

        Public Property Type As Int16

        Public Property Rate As Decimal

        Public Property DiscountRate As Nullable(Of Decimal)

        Public Property FromAirport As Airport

        Public Property ToCity As City

    End Class

End Namespace