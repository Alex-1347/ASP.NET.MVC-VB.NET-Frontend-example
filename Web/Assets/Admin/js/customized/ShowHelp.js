	function AjaxRequest(ClickID, ReadValurFromID, ShowResultID) {
		$(ClickID).click(function(e) {

			e.preventDefault();

			var textBoxVal = $(ReadValurFromID).val();
			var url = $(this).attr("href");
			url = url + "?id=" + textBoxVal;

			$.get(url, function(response) {

				$(ShowResultID).html(response);
			});

		});
	}