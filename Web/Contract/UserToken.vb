Imports System.Globalization

Namespace Contract

    Public Class UserToken

        Public Property Id As Guid

        Public Property AssociatedId As Guid

        Public Property AssociationType As Int32

        Public Property Type As Int32

        Public Property Token As String

        Public Property Platform As Int32


        Public Property ExpiresOn As DateTime

        Public Property ExpiryDate As String
            Get
                Return ExpiresOn.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    ExpiresOn = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property


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
