Namespace Model
    Public Class ViewDriver
        Public Property Driver As Contract.Driver
        Public Property EncodedPhoto As String
        Public Property Documents As List(Of ViewDocument)
        Public Property Cars As List(Of Contract.Car)
        Public Property DeviceInstances As List(Of Instances)
        Public Property Err1 As String
        Public Property ContactIsCorrent As Boolean
        Public Property DriverIsActive As Boolean
        Public Property DocumentsIsCorrect As Boolean
        Public Property DeleteDriverAtAll As Boolean
        Public Property NotifParm As NotificationParamaters
        Public Property GeoCoordinates As Contract.GeoCoordinates
    End Class

    Public Class NotificationParamaters
        Public Property Distance As Integer
        Public Property Time As Integer
    End Class



End Namespace

