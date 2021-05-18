Imports Web.Contract

Namespace Model
    Public Class ViewTrips
        Implements IPagerModel(Of Contract.TripLocationList, Contract.TripLocation)


        Dim _Trips As New Contract.TripLocationList
        Dim _Skip As Integer
        Dim _PagerText As String
        Dim _Err1 As String

        Public Property DataListT As TripLocationList Implements IPagerModel(Of TripLocationList, TripLocation).DataListT
            Get
                Return _Trips
            End Get
            Set(value As TripLocationList)
                _Trips = value
            End Set
        End Property

        Public Property Skip As Integer Implements IPagerModel(Of TripLocationList, TripLocation).Skip
            Get
                Return _Skip
            End Get
            Set(value As Integer)
                _Skip = value
            End Set
        End Property

        Public Property PagerText As String Implements IPagerModel(Of TripLocationList, TripLocation).PagerText
            Get
                Return _PagerText
            End Get
            Set(value As String)
                _PagerText = value
            End Set
        End Property

        Public Property Err1 As String Implements IPagerModel(Of TripLocationList, TripLocation).Err1
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property
    End Class

End Namespace
