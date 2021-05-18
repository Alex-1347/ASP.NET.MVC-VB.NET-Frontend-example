@ModelType Model.CreateTripModel
@Code
    ViewData("Title") = "Create Trip"
    ViewData("Selection") = "Categorize"
End Code

@Section Styles
    <link rel="stylesheet" type="text/css" href="@Url.Content("~/Assets/Admin/CSS/spinner.css")" />
End Section

@Section Scripts

    @*<script type="text/javascript"
            $(document).ready(function(){
            $("#trip-date").datepicker({ dateformat : 'MM/dd/yyyy HH:mm'})
            })
        </script>    *@

    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/RideTypes.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowWaitGif.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Assets/Admin/JS/customized/ShowHelp.js")"></script>
End Section

<div class="container-fluid">
    <div class="row" id="content-panel">
        <div class="col-md-8">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Create Trip</h4>
                </div>
                <div class="card-body">
                    @Using Html.BeginForm("Create", "Trip", FormMethod.Post, New With {.OnSubmit = "ShowWaitGif(event)"})
                        @<div class="row">
                            <div class="col-md-12">
                                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.UserID, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="row">
                                        <div class="col-md-4">
                                            @Html.EditorFor(Function(model) model.UserID, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "00000000-0000-0000-0000-000000000000"}})
                                            @Html.ValidationMessageFor(Function(model) model.UserID, "", New With {.class = "text-danger"})
                                        </div>
                                        <div class="col-md-2">
                                            <a id="UserIDcheckLink" class="btn btn-link btn-danger" href="@Url.Action("CheckUserID")">check</a>
                                        </div>
                                        <div class="col-md-6 align-self-center" id="CheckUser">
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.FromLocationID, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="row">
                                        <div class="col-md-4">
                                            @Html.EditorFor(Function(model) model.Trip.FromLocationID,
New With {.htmlAttributes = New With {
.class = "form-control",
.placeholder = "00000000-0000-0000-0000-000000000000",
.title = ModelMetadata.FromLambdaExpression(Function(x As Model.CreateTripModel) x.Trip.FromLocationID, ViewData).Description}})
                                            @Html.ValidationMessageFor(Function(model) model.Trip.FromLocationID, "", New With {.class = "text-danger"})
                                        </div>
                                        <div class="col-md-2">
                                            <a id="FromLocationIDcheckLink" class="btn btn-link btn-danger" href="@Url.Action("CheckFromLocationID")">check</a>
                                        </div>
                                        <div class="col-md-6 align-self-center" id="CheckFromLocation">
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.ToLocationID, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="row">
                                        <div class="col-md-4">
                                            @Html.EditorFor(Function(model) model.Trip.ToLocationID, New With {.htmlAttributes = New With {
.class = "form-control",
.placeholder = "00000000-0000-0000-0000-000000000000",
.title = ModelMetadata.FromLambdaExpression(Function(x As Model.CreateTripModel) x.Trip.FromLocationID, ViewData).Description}})
                                            @Html.ValidationMessageFor(Function(model) model.Trip.ToLocationID, "", New With {.class = "text-danger"})
                                        </div>
                                        <div class="col-md-2">
                                            <a id="ToLocationIDcheckLink" class="btn btn-link btn-danger" href="@Url.Action("CheckToLocationID")">check</a>
                                        </div>
                                        <div class="col-md-6 align-self-center" id="CheckToLocation">
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.TripType, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="col-md-4">
                                        @Html.DropDownListFor(Function(model) model.Trip.TripType, DirectCast(ViewData("TripTypeList"), List(Of SelectListItem)), New With {.class = "form-control"})
                                        @Html.ValidationMessageFor(Function(model) model.Trip.TripType, "", New With {.class = "text-danger"})
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.Scheduled, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="col-md-1">
                                        @Html.EditorFor(Function(model) model.Trip.Scheduled, New With {.htmlAttributes = New With {.class = "form-control"}})
                                        @Html.ValidationMessageFor(Function(model) model.Trip.Scheduled, "", New With {.class = "text-danger"})
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.BidEnabled, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="col-md-1">
                                        @Html.EditorFor(Function(model) model.Trip.BidEnabled, New With {.htmlAttributes = New With {.class = "form-control"}})
                                        @Html.ValidationMessageFor(Function(model) model.Trip.BidEnabled, "", New With {.class = "text-danger"})
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.DepartureDateTime, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="col-md-4">
                                        @Html.EditorFor(Function(model) model.Trip.DepartureDateTime, New With {.htmlAttributes = New With {.Class = "form-control"}})
                                        @Html.ValidationMessageFor(Function(model) model.Trip.DepartureDateTime, "", New With {.class = "text-danger"})
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.FareType, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="col-md-4">
                                        <div class="checkbox">
                                            @Html.DropDownListFor(Function(model) model.Trip.FareType, DirectCast(ViewData("FireTypeList"), List(Of SelectListItem)), New With {.class = "form-control"})
                                            @Html.ValidationMessageFor(Function(model) model.Trip.FareType, "", New With {.class = "text-danger"})
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.PaymentMethodId, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="row">
                                        <div class="col-md-4">
                                            @Html.EditorFor(Function(model) model.Trip.PaymentMethodId, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "00000000-0000-0000-0000-000000000000"}})
                                            @Html.ValidationMessageFor(Function(model) model.Trip.PaymentMethodId, "", New With {.class = "text-danger"})
                                        </div>
                                        <div class="col-md-2">
                                            <a id="PaymentMethodIdcheckLink" class="btn btn-link btn-danger" href="@Url.Action("CheckPaymentMethodId")">check</a>
                                        </div>
                                        <div class="col-md-6 align-self-center" id="CheckPaymentMethod">
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.PromotionID, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="row">
                                        <div class="col-md-4">
                                            @Html.EditorFor(Function(model) model.Trip.PromotionID, New With {.htmlAttributes = New With {.class = "form-control", .placeholder = "00000000-0000-0000-0000-000000000000"}})
                                            @Html.ValidationMessageFor(Function(model) model.Trip.PromotionID, "", New With {.class = "text-danger"})
                                        </div>
                                        <div class="col-md-2">
                                            <a id="PromotionIDcheckLink" class="btn btn-link btn-danger" href="@Url.Action("CheckPromotionID")">check</a>
                                        </div>
                                        <div class="col-md-6 align-self-center" id="CheckPromotion">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    @Html.LabelFor(Function(model) model.Trip.Note, htmlAttributes:=New With {.class = "control-label col-md-12"})
                                    <div class="col-md-12">
                                        @Html.TextAreaFor(Function(model) model.Trip.Note, 3, 80, New With {.htmlAttributes = New With {.class = "form-control"}})
                                        @Html.ValidationMessageFor(Function(model) model.Trip.Note, "", New With {.class = "text-danger"})
                                    </div>
                                </div>
                            </div>
                        </div>
                        @Html.AntiForgeryToken()
                        @<div class="text-center" style="margin-top: 8px; margin-left: 6px; margin-right: -16px;">
                            <label id="status-message" class="label" style="color: tomato;"></label>
                        </div>
                        @<div class="text-center" style="margin-top: 18px; margin-bottom: 18px;">
                            <input id="button-create-ride-type-submit" class="btn btn-danger btn-round" type="submit" value="Create New Trip" />
                        </div>
                    End Using
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="progress-panel" style="display: none;">
        <div class="es-spinner-ring"></div>
    </div>
</div>


@Scripts.Render("~/Scripts/jquery-3.4.1.js")
@*@Scripts.Render("~/Scripts/jquery.validate.js")
    @Scripts.Render("~/Scripts/jquery.unobtrusive-ajax.js")
    @Scripts.Render("~/Scripts/jquery.validate.unobtrusive.js")*@

<script type="text/javascript">
$(function() {

    AjaxRequest("#UserIDcheckLink","#UserID","#CheckUser");
    AjaxRequest("#FromLocationIDcheckLink","#Trip_FromLocationID","#CheckFromLocation");
    AjaxRequest("#ToLocationIDcheckLink","#Trip_ToLocationID","#CheckToLocation");
    AjaxRequest("#PaymentMethodIdcheckLink","#Trip_PaymentMethodId","#CheckPaymentMethod");
    AjaxRequest("#PromotionIDcheckLink","#Trip_PromotionID","#CheckPromotion");
});
</script>



