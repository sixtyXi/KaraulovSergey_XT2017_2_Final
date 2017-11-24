$('#ajax-form').submit(function (e) {
	var url = $(this).attr('action');
	var data = $(this).serialize();
	sendAjaxPost(url, data);
	e.preventDefault();
});

$('#ajax-list').on('click', function (e) {
	var target = $(e.target);
	var url = target.attr('href');
	var data = target.serializeArray();
	data.push({ name: 'Category', value: target.attr('data-id') });
	e.preventDefault();
	sendAjaxPost(url, data);
})

function sendAjaxPost(url, data) {
	$.ajax({
		type: 'POST',
		url: url,
		data: data,
		success: function (data) {
			$('#lotsWrap').html(data);
		},
		error: function () { $('#lotsWrap').html('Не найдено'); }
	});
}

//переход на страницу размещения лота
$('#ajax-placed-link').click(function (e) {
	e.preventDefault();
	$.ajax({
		type: 'GET',
		url: $(this).attr('href'),
		success: function (data) {
			window.location.href = "/Pages/placeLot.cshtml";
		},
		error: function () {
			$('#Login').click();
		}
	});
})
