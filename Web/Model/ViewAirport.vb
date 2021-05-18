Imports Web.Contract
Namespace Model

    Public Class ViewAirport
        Implements IPagerModel(Of Contract.AirportList, Contract.Airport)

        Dim _Airports As New Contract.AirportList
        Dim _Skip As Integer
        Dim _PagerText As String
        Dim _Err1 As String

        Public Property DataListT As AirportList Implements IPagerModel(Of AirportList, Airport).DataListT
            Get
                Return _Airports
            End Get
            Set(value As AirportList)
                _Airports = value
            End Set
        End Property

        Public Property Skip As Integer Implements IPagerModel(Of AirportList, Airport).Skip
            Get
                Return _Skip
            End Get
            Set(value As Integer)
                _Skip = value
            End Set
        End Property

        Public Property PagerText As String Implements IPagerModel(Of AirportList, Airport).PagerText
            Get
                Return _PagerText
            End Get
            Set(value As String)
                _PagerText = value
            End Set
        End Property

        Public Property Err1 As String Implements IPagerModel(Of AirportList, Airport).Err1
            Get
                Return _Err1
            End Get
            Set(value As String)
                _Err1 = value
            End Set
        End Property
    End Class
End Namespace