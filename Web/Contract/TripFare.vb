Imports System.Globalization

Namespace Contract

    Public Class TripFare

        Public Property Id As Guid

        Public Property TripId As Guid

        Public Property Type As Int16

        Public Property RideFare As Decimal

        Public Property AddOnFare As Decimal

        Public Property SubTotal As Decimal

        Public Property Discount As Decimal

        Public Property VAT As Decimal

        Public Property Total As Decimal

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