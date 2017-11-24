$('#ajax-list-cabinet').click(function (e) {
	e.preventDefault();
	var target = $(e.target);
	var url = target.attr('href');
	$.ajax({
		type: 'GET',
		url: url,
		success: function (data) {
			$('#lotsWrapCab').html(data);
		},
		error: function () {
			$('#lotsWrapCab').html('Не найдено');
		}
	});
})