//превью названия лота
document.getElementById('LotName').addEventListener('change', function () {
	document.querySelector('figcaption').innerHTML = this.value;
});

//превью изображения лота
document.getElementById('LotImage').addEventListener('change', function() {
	var preview = document.querySelector('img');
	var file = this.files[0];
	var reader = new FileReader();

	reader.addEventListener("load", function () {
		preview.src = reader.result;
	}, false);

	if (file) {
		reader.readAsDataURL(file);
	}
});

