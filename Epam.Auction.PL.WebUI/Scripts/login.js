$('#Registration').on('click', function () {
	$('.modal-title').text('Регистрация');
	$("input[type='text']").attr("name", "newName");
	$("input[type='password']").attr("name", "newPassword");
	$('.loginBtn').text('Зарегистрироваться');
	$(".error-msg").text('Пользователь с таким именем уже существует');
	$('#modal-form').modal();
})

$('#Login').on('click', function () {
	$('.modal-title').text('Вход');
	$("input[type='text']").attr("name", "name");
	$("input[type='password']").attr("name", "password");
	$('.loginBtn').text('Войти');
	$(".error-msg").text('Неверное имя пользователя или пароль');
	$('#modal-form').modal();
})


$('#ajax-modal-form').submit(function (e) {
	e.preventDefault();
	$.ajax({
		type: 'POST',
		url: $(this).attr('action'),
		data: $(this).serialize(),
		success: function (data) {
			$('.modal').modal('hide');
			window.location.reload();
		},
		error: function () {
			$("#modal-msg").modal();
		}
	});
});



