Namespace Contract
    Public Class TripLocationList
        Implements IListTotal(Of TripLocation)

        Dim _TripLocation As List(Of TripLocation)
        Dim _Total As Integer

        Public Property TripLocation As IEnumerable(Of TripLocation) Implements IListTotal(Of TripLocation).DataList
            Get
                Return _TripLocation
            End Get
            Set(value As IEnumerable(Of TripLocation))
                _TripLocation = value
            End Set
        End Property

        Public Property Total As Integer Implements IListTotal(Of TripLocation).Total
            Get
                Return _Total
            End Get
            Set(value As Integer)
                _Total = value
            End Set
        End Property
    End Class

End Namespace