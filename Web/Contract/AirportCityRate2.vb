Namespace Contract
	'If (airportCityRateType == 1)
	'                   {
	'                       airportCityRateType = 'Day';
	'                   }
	'                   ElseIf (airportCityRateType == 2)
	'                   {
	'                       airportCityRateType = 'Night';
	'                   }

	Public Class AirportCityRate2

		Public Property Id As System.Guid

		Public Property FromAirportId As System.Guid

		Public Property ToCityId As System.Guid

		Public Property Rate As Decimal

		Public Property DiscountRate As System.Nullable(Of Decimal)

		Public Property Type As Short

		Public Property InsertedOn As Date

		Public Property UpdatedOn As System.Nullable(Of Date)

		Public Property DeletedOn As System.Nullable(Of Date)

		Public Property IsDeleted As Boolean

		Public Property Airports_EName As String

		Public Property Airports_HName As String

		Public Property Airports_GPlaceId As String

		Public Property Cities_ToCountry As System.Nullable(Of System.Guid)

		Public Property Cities_EName As String

		Public Property Cities_HName As String
	End Class


End Namespace

