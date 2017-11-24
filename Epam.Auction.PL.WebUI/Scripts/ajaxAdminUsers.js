////обработка удаления-добавления прав пользователей
$('.del-role-form').on('submit', SendRoleForUser);
$('.add-role-form').on('submit', SendRoleForUser);

function SendRoleForUser (e) {
	e.preventDefault();
	var data = $(e.target).serializeArray();
	data.push({ name: 'userName', value: $(this).attr('data-userName') });
	$.ajax({
		type: 'POST',
		url: $(this).attr('action'),
		data: data,
		success: function (data) {
			$('#userAction').click();
		},
		error: function () {
			$('#lotsWrapAdmin').html('Не выполнено');
		}
	});
}

////добавление категории
$('#category-form').on('submit', function (e) {
	e.preventDefault();
	$.ajax({
		type: 'POST',
		url: $(this).attr('action'),
		data: $(this).serialize(),
		success: function (data) {
			$('#lotsWrapAdmin').html('Добавлено');
		},
		error: function () {
			$('#lotsWrapAdmin').html('Не выполнено');
		}
	});
})

$('.btn-delete-lot').click(function (e) {
	e.preventDefault();
	//var target = $(e.target);
	//var url = target.attr('href');
	$.ajax({
		type: 'GET',
		url: $(this).attr('href'),
		success: function (data) {
			$('#lotsWrapAdmin').html('Удалено!');
		},
		error: function () {
			$('#lotsWrapAdmin').html('Запрос не выполнен');
		}
	});
})