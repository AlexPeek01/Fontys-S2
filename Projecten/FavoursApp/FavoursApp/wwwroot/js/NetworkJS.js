document.addEventListener('DOMContentLoaded', function () {
    var modal = document.getElementById("myModal");
    var span = document.getElementsByClassName("close")[0];
    modal.style.display = "none";
});

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