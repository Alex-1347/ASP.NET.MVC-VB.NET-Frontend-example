<nav aria-label="Trip Navigation">
    <ul Class="pagination justify-content-center">
        <li id="page-first" Class="page-item">
            @Html.ActionLink("First", "Index", Nothing, New With {.Class = "page-link text-danger", .onclick = "ShowWaitGif(event)"})
        </li>
        <li id="page-previous" Class="page-item">
            @If Model.Skip > 0 Then
                @Html.ActionLink("Previous", "Previous", New With {.id = Model.Skip}, New With {.Class = "page-link text-danger", .onclick = "ShowWaitGif(event)"})
            End If

        </li>
        <li Class="page-item">
            <span style="padding-top:5px;display:table-cell;"> (@Model.PagerText)</span>
        </li>
        <li id="page-next" Class="page-item">
            @If Model.Skip + 10 < Model.DataListT.Total Then
                @Html.ActionLink("Next", "Next", New With {.id = Model.Skip}, New With {.Class = "page-link text-danger", .onclick = "ShowWaitGif(event)"})
            End If
        </li>
    </ul>
</nav>
