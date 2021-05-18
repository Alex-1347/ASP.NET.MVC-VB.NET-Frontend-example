@Code
    ViewData("Title") = "Location"
    ViewData("Selection") = "Location"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
    <style>
        .btn-gray:hover, .btn-gray:focus, .btn-gray:active {
            background-color: #f44336;
            box-shadow: 0 4px 20px 0 rgba(0,0,0,.14),0 7px 10px -5px rgba(244,67,54,.4);
        }
    </style>
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
End Section

<div class="container-fluid">

        @Using (Html.BeginForm("Jump", "Menu", Nothing, FormMethod.Post, New With {.OnSubmit = "ShowWaitGif(event)"}))
            @<div Class="col-md-2">
                @Html.Partial("LocationMenu")
            </div>
        End Using
</div>