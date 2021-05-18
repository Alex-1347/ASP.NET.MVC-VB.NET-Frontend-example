Namespace Contract
    Public Class LocationList
        Implements IListTotal(Of Contract.Location)

        Dim _Locations As List(Of Contract.Location)
        Dim _Total As Integer

        Public Property Locations As IEnumerable(Of Location) Implements IListTotal(Of Location).DataList
            Get
                Return _Locations
            End Get
            Set(value As IEnumerable(Of Location))
                _Locations = value
            End Set
        End Property

        Public Property Total As Integer Implements IListTotal(Of Location).Total
            Get
                Return _Total
            End Get
            Set(value As Integer)
                _Total = value
            End Set
        End Property
    End Class

End Namespace
