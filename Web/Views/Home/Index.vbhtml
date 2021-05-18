@Code
    ViewData("Title") = "Login"
End Code
<div>
    <div class="page-header header-filter" filter-color="purple" style="background-image: url('@Url.Content("~/Assets/Image/bg2.jpg")'); background-size: cover; background-position: top center;">
        <div id="page-content" class="container">
            <div class="row">
                <div class="col-lg-4 col-md-6 col-sm-6 ml-auto mr-auto">
                    <div class="card card-signup">
                        <div class="card-header card-header-danger text-center">
                            <h4 class="card-title">@Resources.Home.Index.Registration</h4>
                        </div>
                        <div class="card-body" style="padding-top:18px;">
                            @Using Ajax.BeginForm("User/Authenticate", "Service", New AjaxOptions() With {
                                 .HttpMethod = "POST",
                                 .OnBegin = "OnAuthenticationBegin",
                                 .OnSuccess = "OnAuthenticationSuccess",
                                 .OnFailure = "OnAuthenticationFailure"})
                                @<div class="form-group has-danger">
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="material-icons">person_outline</i>
                                            </span>
                                        </div>
                                        @Html.TextBox("input-username", Nothing, New With {.class = "form-control", .placeholder = Resources.Home.Index.UserName})
                                    </div>
                                </div>
                                @<div class="form-group has-danger">
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="material-icons">lock_outline</i>
                                            </span>
                                        </div>
                                        @Html.Password("input-password", Nothing, New With {.class = "form-control", .placeholder = Resources.Home.Index.Pass})
                                    </div>
                                </div>
                                @Html.AntiForgeryToken()
                                @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                                    <label id="status-message" class="label" style="color: tomato;"></label>
                                </div>
                                @<div class="text-center" style="margin-left: -10px; margin-right: -30px; margin-top: 18px; margin-bottom: 18px;">
                                    <input id="button-authentication-submit" class="btn btn-danger btn-round" type="submit" value=@Resources.Home.Index.Enter />
                                </div>
                            End Using
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
@Section Scripts
    <script type="text/javascript" src="@Url.Content("~/Assets/JS/customized/AuthenticateAdministrator.js")"></script>
End Section