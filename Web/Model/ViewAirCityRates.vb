Imports Web.Contract

Namespace Model
    Public Class ViewAirCityRates
        Implements IPagerModel(Of AirCityRateList, AirportCityRate2)

        Dim _Skip As Integer
        Dim _PagerText As String
        Dim _Err1 As String
        Dim _DataList As New AirCityRateList

        Public Property DataListT As AirCityRateList Implements IPagerModel(Of AirCityRateList, AirportCityRate2).DataListT
            Get
                Return _DataList
            End Get
            Set(value As AirCityRateList)
                _DataList = value
            End Set
        End Property

        Public Property Skip As Integer Implements IPagerModel(Of AirCityRateList, AirportCityRate2).Skip
            Get
                Return _Skip
            End Get
            Set(value As Integer)
                _Skip = value
            End Set
        End Property

        Public Property PagerText As String Implements IPagerModel(Of AirCityRateList, AirportCityRate2).PagerText
            Get
                Return _PagerText
            End Get
            Set(value As String)
                _PagerText = value
            End Set
        End Property

        Public Property Err1 As String Implements IPagerModel(Of AirCityRateList, AirportCityRate2).Err1
            Get
                Return _Err1
            End Get
            Set(value As String)
                _Err1 = value
            End Set
        End Property

    End Class
End Namespace

