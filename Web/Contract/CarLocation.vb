Imports System.Globalization

Namespace Contract

    Public Class CarLocation

        Public Property Id As Guid

        Public Property CarId As Guid

        Public Property Latitude As Decimal

        Public Property Longitude As Decimal

        Public Property Status As Int16

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

    End Class

End Namespace
