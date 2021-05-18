@ModelType Model.ViewDriver
@Code
    ViewData("Title") = "Driver"
    ViewData("Selection") = "DriverRegistration"

End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
    <script type="text/javascript">


        $(document).ready(function () {


            var ContactCheckBoxRef = $("#ContactCheckBox");
            var ContactCheckBoxRefNo = $("#ContactCheckBoxNo");
            var ActiveCheckBoxRef = $("#ActiveCheckBox");
            var ActiveCheckBoxRefNo = $("#ActiveCheckBoxNo");
            var DocumentCheckBoxRef = $("#DocumentCheckBox");
            var DocumentCheckBoxRefNo = $("#DocumentCheckBoxNo");


            ContactCheckBoxRef.click(function () {
                var status = ContactCheckBoxRef.prop('checked');
                ContactCheckBoxRefNo.prop("checked", !status);
            });

            ContactCheckBoxRefNo.click(function () {
                var status = ContactCheckBoxRefNo.prop('checked');
                ContactCheckBoxRef.prop("checked", !status);
            });

           ActiveCheckBoxRef.click(function () {
                var status = ActiveCheckBoxRef.prop('checked');
                ActiveCheckBoxRefNo.prop("checked", !status);
            });

            ActiveCheckBoxRefNo.click(function () {
                var status = ActiveCheckBoxRefNo.prop('checked');
                ActiveCheckBoxRef.prop("checked", !status);;
            });

            DocumentCheckBoxRef.click(function () {
                var status = DocumentCheckBoxRef.prop('checked');
                DocumentCheckBoxRefNo.prop("checked", !status);
            });

            DocumentCheckBoxRefNo.click(function () {
                var status = DocumentCheckBoxRefNo.prop('checked');
                DocumentCheckBoxRef.prop("checked", !status);
            });

    

        });
    </script>

End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">@Resources.Driver.View.Driver</h4>
                </div>
                <div class="card-body">
                    <div class="card-avatar" style="margin-bottom:40px;margin-top:20px;">
                        @code
                            Dim ImgSrc As String = $"data:image/jpg;base64,{Model.EncodedPhoto}"
                        End Code
                        <img src="@ImgSrc" class="img" id="input-driver-profile-image" style="height:160px;width:160px;border-radius:50%;box-shadow:0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);" />
                    </div>
                    @Using Html.BeginForm("Update", "Driver", New With {.DriverId = Model.Driver.Id.ToString}, FormMethod.Post, New With {.onsubmit = "ShowWaitGif(this)"})
                        @<input type="hidden" name="input-driver-id" id="input-driver-id" Class="form-control" />
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-driver-first-name" style="position:inherit">Name</label>
                                        @Html.TextBox("input-driver-first-name", Model.Driver.Name, New With {.class = "form-control", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-driver-first-name" style="position:inherit">Current Status</label>
                                        @Html.TextBox("input-driver-first-status", DirectCast(Me.ViewContext.Controller, Web.Controllers.DriverController).GetCurrentDriverStatus(ViewData("DriverStatusList"), Model.Driver.Status), New With {.class = "form-control", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-driver-phone" style="position:inherit">@Resources.Driver.View.Email</label>
                                        @Html.TextBox("input-driver-email", Model.Driver.Email, New With {.class = "form-control", .type = "email", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-driver-phone" style="position:inherit">@Resources.Driver.View.Phone (+972-XXXXXXX)</label>
                                        @Html.TextBox("input-driver-phone", Model.Driver.PhoneNumber, New With {.class = "form-control", .type = "tel", .readonly = "readonly"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @*@<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label for="input-driver-status">@Resources.Driver.View.Situation</label>
                                        <select class="form-control" id="input-driver-status" name="input-driver-status">
                                            @code
                                                For Each X In DirectCast(ViewData("DriverStatusList"), List(Of SelectListItem))
                                                    @: <option value="@X.Value">@X.Text</option>
                                                Next
                                            End Code
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>*@
                        @<div class="row">
                            <div class="col-md-3">
                                @Html.CheckBox("ContactCheckBox", Model.ContactIsCorrent, New With {.value = Model.Driver.Id, .checked = Model.ContactIsCorrent})
                                <label for="input-driver-status">Contact is correct</label>
                            </div>
                            <div class="col-md-3">
                                @Html.CheckBox("DocumentCheckBox", Model.DocumentsIsCorrect, New With {.value = Model.Driver.Id, .checked = Model.DocumentsIsCorrect})
                                <label for="input-driver-status">All documents is correct</label>
                            </div>
                            <div class="col-md-3">
                                @Html.CheckBox("ActiveCheckBox", Model.DriverIsActive, New With {.value = Model.Driver.Id, .checked = Model.DriverIsActive})
                                <label for="input-driver-status">Driver is active</label>
                            </div>
                            <div class="col-md-3">
                                @Html.CheckBox("DeleteDriverAtAll", Model.DeleteDriverAtAll, New With {.value = Model.Driver.Id, .checked = Model.DeleteDriverAtAll})
                                <label for="input-driver-status">Delete driver at all</label>
                            </div>
                        </div>
                        @<div class="row">
                            <div class="col-md-3">
                                @Html.CheckBox("ContactCheckBoxNo", Not Model.ContactIsCorrent, New With {.value = Model.Driver.Id, .checked = Not Model.ContactIsCorrent})
                                <label for="input-driver-status">or unchecked</label>
                            </div>
                            <div class="col-md-3">
                                @Html.CheckBox("DocumentCheckBoxNo", Not Model.DocumentsIsCorrect, New With {.value = Model.Driver.Id, .checked = Not Model.DocumentsIsCorrect})
                                <label for="input-driver-status">or pending verification</label>
                            </div>
                            <div class="col-md-3">
                                @Html.CheckBox("ActiveCheckBoxNo", Not Model.DriverIsActive, New With {.value = Model.Driver.Id, .checked = Not Model.DriverIsActive})
                                <label for="input-driver-status">or suspended</label>
                            </div>
                            <div class="col-md-3">
                                @Html.Raw("&nbsp;")
                            </div>
                        </div>
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-driver-update-submit" class="btn btn-danger btn-round" type="submit" name="submitButton" value=@Resources.Driver.View.DriverUpdate />
                            @*<input id="button-driver-delete-submit" class="btn btn-danger btn-round" type="submit" name="submitButton" value=@Resources.Driver.View.DeletingDriver />*@
                        </div>
                    End Using
                </div>
            </div>
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">
                        @Resources.Driver.View.Documents
                    </h4>
                </div>
                <div class="card-body">
                    @Using Html.BeginForm("Driver/Document/View", "Service")
                        @<div Class="table-responsive">
                            <Table Class="table">
                                <thead Class="text-danger">
                                    <tr>
                                        <th>@Resources.Driver.Index.Watch</th>
                                        <th>@Resources.Driver.View.Type</th>
                                        <th>@Resources.Driver.View.Identifier</th>
                                        <th>@Resources.Driver.View.ValidFrom</th>
                                        <th>@Resources.Driver.View.ValidTo</th>
                                        <th>@Resources.Driver.View.Validation</th>
                                    </tr>
                                </thead>
                                <tbody id="table-body-documents">
                                    @if Model.Documents IsNot Nothing Then
                                        @For Each OneDoc As Model.ViewDocument In Model.Documents
                                            @<tr>
                                                <td>@Html.ActionLink("View", "ViewDocument", New With {.DriverId = Model.Driver.Id, .DocId = OneDoc.Id}, New With {.Class = "text-danger", .style = "text-decoration:underline", .onclick = "ShowWaitGif(event)"})</td>
                                                <td>@OneDoc.TypeStr</td>
                                                <td>@OneDoc.Identifier</td>
                                                <td>@OneDoc.ValidFrom</td>
                                                <td>@OneDoc.ValidTo</td>
                                                <td>@OneDoc.Verified</td>
                                            </tr>
                                        Next
                                    End If
                                </tbody>
                            </Table>
                        </div>
                        @Html.AntiForgeryToken()
                    End Using
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Related data</h4>
                </div>
                <div class="card-body">
                    <div Class="table-responsive">
                        <Table Class="table">
                            <thead Class="text-danger">
                                <tr>
                                    <th>Ride</th>
                                    <th>Message</th>
                                    <th>Review</th>
                                    <th>Payment</th>
                                    <th>Location</th>
                                    <th>Cars</th>
                                    <th>Notification</th>
                                    <th>Bids</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-documents">
                                <tr>
                                    <td><a href="/Ride/View/@Model.Driver.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Message/View/@Model.Driver.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Review/View/@Model.Driver.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Payment/View/@Model.Driver.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Location/ViewDevicesLocation/@Model.Driver.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Car/View/@Model.Driver.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Driver/ViewNotification/@Model.Driver.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Bids/View/@Model.Driver.Id" class="text-danger"><u>View</u></a></td>
                                </tr>
                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Mobile device</h4>
                </div>
                <div class="card-body">
                    @Using Html.BeginForm("SendNotification", "Driver", New With {.DriverId = Model.Driver.Id.ToString}, FormMethod.Post, New With {.onsubmit = "ShowWaitGif(this)"})
                        @<div Class="table-responsive">
                            <Table Class="table">
                                <thead Class="text-danger">
                                    <tr>
                                        <th>ViewLocation</th>
                                        <th>Latitude</th>
                                        <th>Longitude</th>
                                        <th>LoginDate</th>
                                    </tr>
                                </thead>
                                <tbody id="table-body-documents">
                                    @if Model.DeviceInstances IsNot Nothing Then
                                    @For Each One As Model.Instances In Model.DeviceInstances
                                        @<tr>
                                            <td>
                                                <a href="/Location/ViewDeviceLocation/@One.ID">
                                                    @If (One.Type = 1) Then
                                                        @Html.Raw("Android")
                                                    Else
                                                        @Html.Raw("IOS")
                                                    End If
                                                </a>
                                            </td>
                                            <td>
                                                @One.Latitude
                                            </td>
                                            <td>
                                                @One.Longitude
                                            </td>
                                            <td>
                                                @One.CrDate
                                            </td>
                                             @*<input id="button-get-device-location-@One.ID" class="btn btn-link btn-round" type="submit" name="button-get-device-location-@One.ID" value="Read" />*@
                                        </tr>
                                    Next
                                    End If
                                </tbody>
                            </Table>
                        </div>
                        @<div class="row">
                             <div class="col-md-6">
                                 <div class="form-group">
                                     <label class="bmd-label-floating" for="input-car-color" style="position:inherit">Distance (km)</label><br />
                                     @Html.TextBox("Distance", Model.NotifParm.Distance, New With {.class = "col-md-10", .placeholder = 10})
                                 </div>
                             </div>
                             <div class="col-md-6">
                                 <div class="form-group">
                                     <label class="bmd-label-floating" for="input-car-color" style="position:inherit">Time forward (minutes)</label><br />
                                     @Html.TextBox("Time", Model.NotifParm.Time, New With {.class = "col-md-10", .placeholder = 30})
                                 </div>
                             </div>

                             
                        </div>
                         @<div Class="form-group">
                                     <input id = "button-send-notification-submit" Class="btn btn-danger btn-round" type="submit" name="button-send-notification-submit" value="Send Notification" />
                                     <Label>(*) about only possibly rides</label>
                                     @Html.AntiForgeryToken()
                        </div>
                    End Using
                </div>
            </div>
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">@Resources.Driver.View.Vehicle</h4>
                </div>
                <div class="card-body">
                    @Using Html.BeginForm("UpdateCar", "Driver", New With {.DriverId = Model.Driver.Id.ToString}, FormMethod.Post, New With {.onsubmit = "ShowWaitGif(this)"})
                        @<div Class="table-responsive">
                            <Table Class="table">
                                <thead Class="text-danger">
                                    <tr>
                                        <th>Selected</th>
                                        <th>RideType</th>
                                        <th>Manufacturer</th>
                                        <th>Model</th>
                                        <th>Color</th>
                                        <th>Registration</th>
                                    </tr>
                                </thead>
                                <tbody id="table-body-documents">
                                    @If Model.Cars IsNot Nothing Then
                                        @For Each OneCar As Contract.Car In Model.Cars
                                            @<tr>
                                                 <td>
                                                     @If OneCar.Selected Then
                                                            @<i Class="material-icons" style="color:red">star</i>
                                                     Else
                                                            @<input 
                                                                   id="button-set-current-car-@OneCar.Id" 
                                                                   Class="btn btn-link btn-round" type="submit" 
                                                                   name="button-set-current-car-@OneCar.Id" 
                                                                   value="Set" />
                                                     End If
                                                 </td>
                                                 <td>
                                                         <select Class="form-control" id="input-car-ride-type" name="input-car-ride-type">
                                                    @code
                                                        For Each X In DirectCast(ViewData("RideTypeList"), List(Of SelectListItem))
                                                            @: <option value="@X.Value">@X.Text</option>
                                                        Next
                                                    End Code
                                                    </select>
                                                </td>
                                                <td>
                                                    @OneCar.Manufacturer
                                                </td>
                                                <td>
                                                    @OneCar.Model
                                                </td>
                                                <td>
                                                    @OneCar.Color
                                                </td>
                                                <td>
                                                    @OneCar.Registration
                                                </td>
                                            </tr>
                                                        Next
                                    End If
                                </tbody>
                            </Table>
                        </div>
                        @<div Class="form-group">
                            @Html.AntiForgeryToken()
                            <input id="button-car-add-submit" Class="btn btn-danger btn-round" type="submit" name="button-car-add-submit" value="Add vehicle" />
                            <label>(*) only selected car can be linked to mobile phone</label>
                        </div>
                                                        End Using
                </div>
            </div>
        </div>
    </div>
    <div Class="row" id="progress-panel" style="display: none;">
        <div Class="es-spinner-ring"></div>
    </div>
</div>