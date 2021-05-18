Namespace Contract
    Public Class AirCityRateList
        Implements IListTotal(Of AirportCityRate2)

        Private _AirCityRates As List(Of AirportCityRate2)
        Private _Total As Integer

        Public Property AirCityRates As IEnumerable(Of AirportCityRate2) Implements IListTotal(Of AirportCityRate2).DataList
            Get
                Return _AirCityRates
            End Get
            Set(value As IEnumerable(Of AirportCityRate2))
                _AirCityRates = value
            End Set
        End Property

        Public Property Total As Integer Implements IListTotal(Of AirportCityRate2).Total
            Get
                Return _Total
            End Get
            Set(value As Integer)
                _Total = value
            End Set
        End Property
    End Class

End Namespace
