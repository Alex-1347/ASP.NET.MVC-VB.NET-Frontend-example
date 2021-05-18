Imports System.ComponentModel.DataAnnotations
Imports System.Globalization

Namespace Contract

    Public Class Location

        Public Property ID As Nullable(Of Guid)
        Public Property Address As String
        Public Property ToCity As Nullable(Of Guid)

        <Display(Name:="Warning! Please type city from supported cities")>
        Public Property City As String

        <Display(Name:="Warning! Please type Latitude from GoogleMaps like 22.318587")>
        Public Property Latitude As Decimal
        <Display(Name:="Warning! Please type Longitude from GoogleMaps like 73.170802")>
        Public Property Longitude As Decimal
        <Display(Name:="Warning! Please type GPlaceId from GoogleMaps like ChIJETj1hbfIXzkRd0M7CE_ImL8")>
        Public Property GPlaceId As String
        Public Property InsertedOn As DateTime
        Public Property InsertedDateStr As String
            Get
                Return InsertedOn.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
            End Get
            Set(value As String)
                If Not String.IsNullOrWhiteSpace(value) Then
                    InsertedOn = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)
                End If
            End Set
        End Property

        Public Property Err1 As String

    End Class

End Namespace
