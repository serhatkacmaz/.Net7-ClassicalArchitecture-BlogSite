
// Image preview
function previewImage(event, previewElementId) {
    var reader = new FileReader();
    reader.onload = function () {
        var preview = document.getElementById(previewElementId);
        preview.src = reader.result;
        preview.style.display = 'block';
    }
    reader.readAsDataURL(event.target.files[0]);
}
