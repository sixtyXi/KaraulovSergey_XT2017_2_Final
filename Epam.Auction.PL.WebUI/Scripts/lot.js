$('#ajax-lot-form').submit(function (e) {
	e.preventDefault();
	var url = $(this).attr('action') + '&newCost=' + $('#currentCost').val();
	$.ajax({
		type: 'GET',
		url: url,
		success: function (data) {
			window.location.reload();
		},
		error: function () {
			$('#Login').click();
		}
	});
})