var modal;
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
function LeaveNetwork() {
    var networkID = $('networkID').val();
    $.get("/Network/LeaveNetwork?networkID=" + networkID, (data) => {
    })
}
$("#newServiceBtn").click(() => {
    modal = $("#myModal");
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
$("#closeCreate").click(() => {
    modal = $("#myModal");
    changeModalState();
});
