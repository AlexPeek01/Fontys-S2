//document.addEventListener('DOMContentLoaded', function () {
//    var modal = document.getElementById("myModal");
//    var span = document.getElementsByClassName("close")[0];
//    modal.style.display = "none";
//});

function OpenCreateNetworkModal() {
    var modal = document.getElementById("myModal");
    modal.style.display = "block";
}
function CloseModal() {
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
}
function GetFileName() {
    var filename = document.getElementById("getFile").value;
    var namearray = filename.substring(12, filename.length);
    document.getElementById("imagebuttonField").textContent = namearray;
}
function GetBase64FromImage(info) {
    var file = new air.File(info);
    var bytes = new air.ByteArray();
    if (file.exists) {
        var stream = new air.FileStream();
        stream.open(file, air.FileMode.READ);
        bytes.endian = air.Endian.LITTLE_ENDIAN;
        stream.readBytes(bytes, 0, file.size);
        stream.close();
    }
    return bytes;
}
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah')
                .attr('src', e.target.result)
                .width(150)
                .height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}
