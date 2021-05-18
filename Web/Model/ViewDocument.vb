Imports System.Globalization

Namespace Model
    Public Class ViewDocument
        Public Property Id As Guid
        Public Property DriverId As Guid
        Public Property Type As Integer
            Set(value As Integer)
                Select Case value
                    Case 1 : TypeStr = "Drivig License"
                    Case 2 : TypeStr = "Car License"
                    Case 3 : TypeStr = "Car Insurnce"
                    Case 4 : TypeStr = "Taxi Permit"
                End Select
            End Set
            Get
                Return Type
            End Get
        End Property
        Public Property TypeStr As String
        Public Property Identifier As String
        Public Property ValidFrom As Date
        Public Property ValidTo As Date
        Public Property Verified As Boolean
        Public Property ValidityTo As String
            Get
                Return ValidTo.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                ValidTo = DateTime.ParseExact(value, "MM/dd/yyyy", CultureInfo.InvariantCulture)
            End Set
        End Property
        Public Property ValidityFrom As String
            Get
                Return ValidFrom.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                ValidFrom = DateTime.ParseExact(value, "MM/dd/yyyy", CultureInfo.InvariantCulture)
            End Set
        End Property

    End Class
    Public Class ViewDocumentFile
        Inherits ViewDocument
        Public Property EncodedDocument As String
        Public Property Err1 As String

    End Class

    Public Enum DriverDocumentType
        DrivigLicense = 1
        CarLicense = 2
        CarInsurnce = 3
        TaxiPermit = 4
    End Enum

End Namespace
