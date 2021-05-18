Imports System.ComponentModel.DataAnnotations
Imports System.Globalization

Namespace Contract
	Public Class CityCountry
		Property Cities_Id As System.Guid
		Property Cities_ToCountry As System.Nullable(Of System.Guid)
		<Display(Name:="Name")>
		Property Cities_EName As String
		<Display(Name:="Hebrew")>
		Property Cities_HName As String
		Property Cities_InsertedOn As Date
		Property Cities_UpdatedOn As System.Nullable(Of Date)
		Property Cities_DeletedOn As System.Nullable(Of Date)
		Property Cities_IsDeleted As Boolean
		Property Countries_Id As System.Guid
		<Display(Name:="Country")>
		Property Countries_EName As String
		Property Countries_HName As String
		<Display(Name:="Country code")>
		Property Countries_Code As String
		<Display(Name:="Phone code")>
		Property Countries_PhoneCode As String
		Property Countries_InsertedOn As Date
		Property Countries_UpdatedOn As System.Nullable(Of Date)
		Property Countries_DeletedOn As System.Nullable(Of Date)
		Property Countries_IsDeleted As Boolean
	End Class

End Namespace

