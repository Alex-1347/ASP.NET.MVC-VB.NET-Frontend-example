Imports Web.Contract

Namespace Model
    Public Class ViewLocation
        Implements IPagerModel(Of Contract.LocationList, Contract.Location)

        Dim _Locations As New Contract.LocationList
        Dim _Skip As Integer
        Dim _PagerText As String
        Dim _Err1 As String

        Public Property DataListT As LocationList Implements IPagerModel(Of LocationList, Location).DataListT
            Get
                Return _Locations
            End Get
            Set(value As LocationList)
                _Locations = value
            End Set
        End Property

        Public Property Skip As Integer Implements IPagerModel(Of LocationList, Location).Skip
            Get
                Return _Skip
            End Get
            Set(value As Integer)
                _Skip = value
            End Set
        End Property

        Public Property PagerText As String Implements IPagerModel(Of LocationList, Location).PagerText
            Get
                Return _PagerText
            End Get
            Set(value As String)
                _PagerText = value
            End Set
        End Property

        Public Property Err1 As String Implements IPagerModel(Of LocationList, Location).Err1
            Get
                Return _Err1
            End Get
            Set(value As String)
                _Err1 = value
            End Set
        End Property
    End Class
End Namespace
