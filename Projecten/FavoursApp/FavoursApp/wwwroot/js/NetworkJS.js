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
    var networkID = $('networkID').val();
    $.get("/Network/LeaveNetwork?networkID=" + networkID, (data) => {
    })
}

//Click events
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
$("#confirmBtn").click(() => {
    LeaveNetwork();
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
