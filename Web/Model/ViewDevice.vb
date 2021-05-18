Imports Contract
Imports Web.Contract

Namespace Model
    Public Class ViewDevice
        Implements IPagerModel(Of Contract.DeviceList, Contract.DriverDevice)

        Dim _DataListT As DeviceList
        Dim _Skip As Integer
        Dim _PagerText As String
        Dim _Err1 As String

        Public Property DataListT As DeviceList Implements IPagerModel(Of DeviceList, DriverDevice).DataListT
            Get
                Return _DataListT
            End Get
            Set(value As DeviceList)
                _DataListT = value
            End Set
        End Property

        Public Property Skip As Integer Implements IPagerModel(Of DeviceList, DriverDevice).Skip
            Get
                Return _Skip
            End Get
            Set(value As Integer)
                _Skip = value
            End Set
        End Property

        Public Property PagerText As String Implements IPagerModel(Of DeviceList, DriverDevice).PagerText
            Get
                Return _PagerText
            End Get
            Set(value As String)
                _PagerText = value
            End Set
        End Property

        Public Property Err1 As String Implements IPagerModel(Of DeviceList, DriverDevice).Err1
            Get
                Return _Err1
            End Get
            Set(value As String)
                _Err1 = value
            End Set
        End Property
    End Class
End Namespace