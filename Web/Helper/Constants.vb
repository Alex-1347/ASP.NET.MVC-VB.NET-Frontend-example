Namespace Helper

    Public Class Constants

        Public Shared ReadOnly Core_SERVICE As String = ConfigurationManager.AppSettings("WcfEndpoint") & "CoreService.svc/"
        Public Shared ReadOnly Admin_SERVICE As String = ConfigurationManager.AppSettings("WcfEndpoint") & "AdminService.svc/"
        Public Shared ReadOnly User_SERVICE As String = ConfigurationManager.AppSettings("WcfEndpoint") & "UserService.svc/"
        Public Shared ReadOnly Driver_SERVICE As String = ConfigurationManager.AppSettings("WcfEndpoint") & "DriverService.svc/"
        Public Shared ReadOnly Trip_SERVICE As String = ConfigurationManager.AppSettings("WcfEndpoint") & "TripService.svc/"
        Public Shared ReadOnly Location_SERVICE As String = ConfigurationManager.AppSettings("WcfEndpoint") & "LocationService.svc/"
    End Class


End Namespace