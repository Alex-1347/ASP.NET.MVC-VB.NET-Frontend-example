@ModelType List(Of Contract.Cities)
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Supported city</title>
</head>
<body>
    <div>
        @For Each One As Contract.Cities In Model
            @<div>
                @One.City
                &nbsp;
                (@One.Country)
            </div>
        Next
    </div>
</body>
</html>
