//Global variables
var modal;

//Modal functions
function changeModalState() {
    if (typeof modal[0] !== "undefined") {
        console.log(modal[0]);
        if (modal[0].style.display == "block") {
            modal[0].style.display = "none";
        }
        else {
            modal[0].style.display = "block";
        }
    }
}

//Network functions
function LeaveNetwork() {
    var networkID = $('#networkID').val();
    $.get("/Network/LeaveNetwork?networkID=" + networkID, (data) => {
        window.location.replace(window.location.origin + "/Network/Index");
    })
    modal = $("#confirmModal");
    changeModalState();
}
$(document).ready(function () {
    //Filter networks
    $("#search").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#searchtable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});
//Click events
$("#search").click(() => {
    $('#search').val("");
});
$("#newServiceBtn").click(() => {
    modal = $("#myModal");
    changeModalState();
});
$('#newNetworkBtn').click(() => {
    modal = $("#networkModal");
    changeModalState();
});
$("#leaveNetworkBtn").click(() => {
    modal = $("#confirmModal");
    changeModalState();
});
$("#cancelBtn").click(() => {
    modal = $("#confirmModal");
    changeModalState();
});
$("#closeNetworkModal").click(() => {
    modal = $("#networkModal");
    changeModalState();
});
$("#closeCreate").click(() => {
    modal = $("#myModal");
    changeModalState();
});
