Namespace Contract

    Public Class InterCityRate

        Public Property Id As Guid

        Public Property FromCityId As Guid

        Public Property ToCityId As Guid

        Public Property Type As Int16

        Public Property Rate As Decimal

        Public Property DiscountRate As Nullable(Of Decimal)

        Public Property FromCity As City

        Public Property ToCity As City

    End Class

End Namespace