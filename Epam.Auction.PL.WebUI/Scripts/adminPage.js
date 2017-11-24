$('#adminBtn').text('Личный кабинет');
$('#adminBtn').attr("href", "cabinet.cshtml");

$('#btn-toggle-search').click(function (e) {
	e.preventDefault();
	e.stopPropagation();
	$('#admin-search-panel').toggleClass("hide");
});

$('#ajax-list-adminPage').click(function (e) {
	e.preventDefault();
	var target = $(e.target);
	var url = target.attr('href');
	$.ajax({
		type: 'GET',
		url: url,
		success: function (data) {
			$('#lotsWrapAdmin').html(data);
		},
		error: function () {
			$('#lotsWrapAdmin').html('Не найдено');
		}
	});
});

$('#admin-search-panel').on('click', function (e) {
	e.stopPropagation();
})
$('#admin-search-panel').submit(function (e) {
	var url = $(this).attr('action');
	var data = $(this).serialize();
	sendAjaxPost(url, data);
	e.preventDefault();
});

function sendAjaxPost(url, data) {
	$.ajax({
		type: 'POST',
		url: url,
		data: data,
		success: function (data) {
			$('#lotsWrapAdmin').html(data);
		},
		error: function () { $('#lotsWrapAdmin').html('Не найдено'); }
	});
}


