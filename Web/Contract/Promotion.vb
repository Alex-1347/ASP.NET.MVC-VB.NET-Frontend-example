Imports System.Globalization
Imports System.Runtime.Serialization

Namespace Contract
    <DataContract>
    Public Class Promotion
        <DataMember>
        Public Property Id As Guid
        <DataMember>
        Public Property Type As Int16
        <DataMember>
        Public Property Code As String
        <DataMember>
        Public Property Value As Decimal
        <DataMember>
        Public Property Description As String

        <IgnoreDataMember>
        Public Property ValidFrom As DateTime

        Public Property ValidFromDate As String
            Get
                Return ValidFrom.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    ValidFrom = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        <IgnoreDataMember>
        Public Property ValidTo As DateTime
        <DataMember>
        Public Property ValidToDate As String
            Get
                Return ValidTo.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    ValidTo = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property
        <DataMember>
        Public Property UsageLimit As Int32
        <DataMember>
        Public Property PerUserUsageLimit As Int32

    End Class

End Namespace
