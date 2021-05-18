@ModelType Model.ViewUser
@Code 
    ViewData("Title") = "View User"
    ViewData("Selection") = "UserWorkflow"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ViewUser.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">@Resources.User.View.Client</h4>
                </div>
                <div class="card-body">
                    <div class="card-avatar" style="margin-bottom:40px;margin-top:20px;">
                        <img class="img" id="input-user-profile-image" style="height:160px;width:160px;border-radius:50%;box-shadow:0 16px 38px -12px rgba(0, 0, 0, 0.56), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);object-fit: cover;" />
                    </div>
                    @Using Ajax.BeginForm("User/Update", "Service", New AjaxOptions() With {.HttpMethod = "PUT", .OnBegin = "OnUpdateUserBegin", .OnSuccess = "OnUpdateUserSuccess", .OnFailure = "OnUpdateUserFailure"})
                        @<input type="hidden" name="input-user-id" id="input-user-id" class="form-control" />
                        @<div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="has-danger">
                                        <label class="bmd-label-floating" for="input-user-first-name" style="position:inherit">@Resources.User.View.FirstName</label>
                                        @Html.TextBox("input-user-first-name", Nothing, New With {.class = "form-control"})
                                    </div>
                                </div>
                            </div>
                        </div>
                                        @<div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="has-danger">
                                                        <label class="bmd-label-floating" for="input-user-email" style="position:inherit">@Resources.User.View.Email</label>
                                                        @Html.TextBox("input-user-email", Nothing, New With {.class = "form-control", .type = "email", .readonly = "readonly"})
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <div class="has-danger">
                                                        <label class="bmd-label-floating" for="input-user-phone" style="position:inherit">@Resources.User.View.Phone (+972-XXXXXXX)</label>
                                                        @Html.TextBox("input-user-phone", Nothing, New With {.class = "form-control", .type = "tel", .readonly = "readonly"})
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                                        @<div class="row">
                                                            <div class="col-md-12">
                                                                <div class="form-group">
                                                                    <div class="has-danger">
                                                                        <label for="input-user-status">@Resources.User.View.Situation</label>
                                                                        <select class="form-control" id="input-user-status" name="input-user-status">
                                                                            <option value="-1" selected="selected">Select Status</option>
                                                                            <option value="1">Active</option>
                                                                            <option value="2">Suspended</option>
                                                                        </select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                                        @Html.AntiForgeryToken()
                                                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                                                             <label id="status-message" class="label" style="color: tomato;"></label>
                                                        </div>
                                                         @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                                                             <input id="button-user-update-submit" class="btn btn-danger btn-round" type="submit" value="@Resources.User.View.CustomerUpdate" />
                                                             <input id="button-user-delete-submit" class="btn btn-danger btn-round" type="button" value="@Resources.User.View.DeleteClient" />
                                                         </div>
                    End Using
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Related data</h4>
                </div>
                <div class="card-body">
                    <div Class="table-responsive">
                        <Table Class="table">
                            <thead Class="text-danger">
                                <tr>
                                    <th>Trips</th>
                                    <th>Messages</th>
                                    <th>Reviews</th>
                                    <th>Payments</th>
                                </tr>
                            </thead>
                            <tbody id="table-body-documents">
                                <tr>
                                    <td><a href="/Trip/ViewUserTrips/@Model.User.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Message/ViewUserMessages/@Model.User.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Review/ViewUserReviews/@Model.User.Id" class="text-danger"><u>View</u></a></td>
                                    <td><a href="/Payment/ViewUserPayments/@Model.User.Id" class="text-danger"><u>View</u></a></td>
                                </tr>
                            </tbody>
                        </Table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="progress-panel" style="display: none;">
        <div class="es-spinner-ring"></div>
    </div>
</div>