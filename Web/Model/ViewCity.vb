Imports Contract

Namespace Model
    Public Class ViewCity
        Implements IPagerModel(Of Contract.CityList, Contract.City)

        Dim _Cities As New Contract.CityList
        Dim _Skip As Integer
        Dim _PagerText As String
        Dim _Err1 As String

        Public Property Skip As Integer Implements IPagerModel(Of Contract.CityList, Contract.City).Skip
            Get
                Return _Skip
            End Get
            Set(value As Integer)
                _Skip = value
            End Set
        End Property

        Public Property PagerText As String Implements IPagerModel(Of Contract.CityList, Contract.City).PagerText
            Get
                Return _PagerText
            End Get
            Set(value As String)
                _PagerText = value
            End Set
        End Property

        Public Property Err1 As String Implements IPagerModel(Of Contract.CityList, Contract.City).Err1
            Get
                Return _Err1
            End Get
            Set(value As String)
                _Err1 = value
            End Set
        End Property

        Public Property DataListT As Contract.CityList Implements IPagerModel(Of Contract.CityList, Contract.City).DataListT
            Get
                Return _Cities
            End Get
            Set(value As Contract.CityList)
                _Cities = value
            End Set
        End Property
    End Class
End Namespace
