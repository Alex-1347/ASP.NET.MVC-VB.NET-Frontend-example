Imports Web.Model

Namespace Contract
    Public Class DeviceList
        Implements IListTotal(Of DriverDevice)

        Dim _DataList As List(Of DriverDevice)
        Dim _Total As Integer

        Public Property DataList As IEnumerable(Of DriverDevice) Implements IListTotal(Of DriverDevice).DataList
            Get
                Return _DataList
            End Get
            Set(value As IEnumerable(Of DriverDevice))
                _DataList = value
            End Set
        End Property
        Public Property Total As Integer Implements IListTotal(Of DriverDevice).Total
            Get
                Return _Total
            End Get
            Set(value As Integer)
                _Total = value
            End Set
        End Property
    End Class
End Namespace