@modelType Model.ViewAirport
@Code
    ViewData("Title") = "Airports"
    ViewData("Selection") = "Location"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Airports
                        <div class="pull-left">
                            <a href="@Url.Action("Create", "Airport")"><i class="material-icons" style="cursor:pointer;">add</i></a>
                        </div>
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>Name</th>
                                    <th>Country</th>
                                    <th>Name (Hebrew)</th>
                                    <th>Google Place Id</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-airports">
                                @If Model.DataListT IsNot Nothing Then
                                     @For I As Integer = 0 To Model.DataListT.DataList.Count - 1
                                        @<tr>
                                            <td>@Html.ActionLink(Model.DataListT.DataList(I).EName, "View", "Airport", New With {.id = Model.DataListT.DataList(I).Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Html.ActionLink("Country", "View", "Country", New With {.id = Model.DataListT.DataList(I).ToCountry}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.DataList(I).HName</td>
                                            <td>@Model.DataListT.DataList(I).GPlaceId</td>
                                         </tr>
                                     Next
                                End If
                             </tbody>
                        </Table>
                    </div>
                </div>
                @Html.Partial("Pager", Model)
            </div>
        </div>
    </div>
    <div Class="row" id="progress-panel" style="display: none;">
        <div Class="es-spinner-ring"></div>
    </div>
</div>