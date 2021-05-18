Imports System.Globalization

Namespace Model

    Public Class DeviceInstanceList
        Public Property InstanceList As List(Of Instances)
    End Class

    Public Class Instances
        Public ID As Guid
        Public Property Type As Integer
        Public Property InstanceId As String
        Public Property CrDate As DateTime
        Public Property Latitude As Decimal
        Public Property Longitude As Decimal
    End Class

End Namespace