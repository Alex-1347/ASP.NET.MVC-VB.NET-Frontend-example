Imports System.Globalization

Namespace Contract

    Public Class Document

        Public Property Id As Guid

        Public Property AssociatedId As Guid

        Public Property AssociationType As Int16

        Public Property Type As Int16

        Public Property Identifier As String

        Public Property ValidFrom As Date

        Public Property ValidityFrom As String
            Get
                Return ValidFrom.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                ValidFrom = DateTime.ParseExact(value, "MM/dd/yyyy", CultureInfo.InvariantCulture)
            End Set
        End Property

        Public Property ValidTo As Date

        Public Property ValidityTo As String
            Get
                Return ValidTo.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                ValidTo = DateTime.ParseExact(value, "MM/dd/yyyy", CultureInfo.InvariantCulture)
            End Set
        End Property

        Public Property IsVerified As Boolean

        Public Property InsertedOn As DateTime

        Public Property InsertDate As String
            Get
                Return InsertedOn.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
            End Get
            Set(Value As String)
                If Not String.IsNullOrWhiteSpace(Value) Then
                    InsertedOn = DateTime.ParseExact(Value, "MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property UpdatedOn As Nullable(Of DateTime)

        Public Property UpdateDate As String
            Get
                If UpdatedOn.HasValue Then
                    Return UpdatedOn.Value.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
                End If
                Return Nothing
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    UpdatedOn = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property DeletedOn As Nullable(Of DateTime)

        Public Property DeleteDate As String
            Get
                If DeletedOn.HasValue Then
                    Return DeletedOn.Value.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
                End If
                Return Nothing
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    DeletedOn = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property IsDeleted As Boolean

        Public Property File As File

    End Class

End Namespace
