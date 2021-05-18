@ModelType Model.ViewDevice
@Code
    ViewData("Title") = "Devices"
    ViewData("Selection") = "List"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        Devices
                    </h4>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <Table class="table">
                            <thead class="text-danger">
                                <tr>
                                    <th>Notification</th>
                                    <th>Name</th>
                                    <th>PhoneNumber</th>
                                    <th>Email</th>
                                    <th>DeviceType</th>
                                    <th>DeviceLatitude</th>
                                    <th>DeviceLongitude</th>
                                    <th>InsertedOn</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-cities">
                                @If Model.DataListT IsNot Nothing Then
                                    @For I As Integer = 0 To Model.DataListT.DataList.Count - 1
                                        @<tr>
                                            <td>@Html.ActionLink("Push", "Push", "Device", New With {.DeviceId = Model.DataListT.DataList(I).DeviceId, .DriverId = Model.DataListT.DataList(I).Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                            <td>@Model.DataListT.DataList(I).Name</td>
                                            <td>@Model.DataListT.DataList(I).PhoneNumber</td>
                                            <td>@Model.DataListT.DataList(I).Email</td>
                                            <td>@Model.DataListT.DataList(I).DeviceType</td>
                                            <td>@Model.DataListT.DataList(I).DeviceLatitude</td>
                                            <td>@Model.DataListT.DataList(I).DeviceLongitude</td>
                                            <td>@Model.DataListT.DataList(I).InsertedOn</td>
                                          </tr>
                                    Next
                                End If
                            </tbody>
                        </Table>
                    </div>
                    @Html.Partial("Pager", Model)
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="progress-panel" style="display: none;">
        <div class="es-spinner-ring"></div>
    </div>
</div>