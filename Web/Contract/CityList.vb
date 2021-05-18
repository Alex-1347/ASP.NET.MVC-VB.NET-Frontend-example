Namespace Contract
    Public Class CityList
        Implements IListTotal(Of City)

        Private _Cities As List(Of Contract.City)
        Private _Total As Integer

        Public Property Cities As IEnumerable(Of City) Implements IListTotal(Of City).DataList
            Get
                Return _Cities
            End Get
            Set(value As IEnumerable(Of City))
                _Cities = value
            End Set
        End Property

        Public Property Total As Integer Implements IListTotal(Of City).Total
            Get
                Return _Total
            End Get
            Set(value As Integer)
                _Total = value
            End Set
        End Property
    End Class
End Namespace

