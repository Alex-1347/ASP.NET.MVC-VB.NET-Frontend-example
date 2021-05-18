Namespace Contract

    Public Class Driver

        Public Shared ReadOnly OnboardingAddCar = 1
        Public Shared ReadOnly OnboardingAddDrivingLicense = 2
        Public Shared ReadOnly OnboardingAddCarLicense = 3
        Public Shared ReadOnly OnboardingAddCarInsurance = 4
        Public Shared ReadOnly OnboardingAddTaxiPermit = 5
        Public Shared ReadOnly OnboardingComplete = 6

        Public Property Id As Guid

        Public Property Name As String

        Public Property Email As String

        Public Property PhoneCountryId As Guid

        Public Property PhoneNumber As String

        Public Property Status As Int16

        Public Property OnboardingStatus As Int16

    End Class

End Namespace