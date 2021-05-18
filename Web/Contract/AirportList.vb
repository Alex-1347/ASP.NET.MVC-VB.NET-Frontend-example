Imports Web.Contract
Namespace Contract
    Public Class AirportList
        Implements IListTotal(Of Contract.Airport)

        Private _Airports As List(Of Contract.Airport)
        Private _Total As Integer

        Public Property DataList As IEnumerable(Of Airport) Implements IListTotal(Of Airport).DataList
            Get
                Return _Airports
            End Get
            Set(value As IEnumerable(Of Airport))
                _Airports = value
            End Set
        End Property

        Public Property Total As Integer Implements IListTotal(Of Airport).Total
            Get
                Return _Total
            End Get
            Set(value As Integer)
                _Total = value
            End Set
        End Property
    End Class
End Namespace