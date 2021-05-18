@ModelType List(Of Contract.Airport)
@Code
    Layout = Nothing
    ViewData("Selection") = "Rates"
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Supported city</title>
</head>
<body>
    <div>
        @For Each One As Contract.Airport In Model
            @<div>
                @One.EName
            </div>
        Next
    </div>
</body>
</html>
