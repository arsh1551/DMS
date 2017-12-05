//$(document).ready(function () {
//    $('#BirthDate').datepicker({
//        dateFormat: "dd/MM/yyyy"
//    });
  
    $('#dvAlertSuccess').hide();
//});


//function UpdateSuccess(e) {
//    $('#dvSuccess').show();
//    $('#Modal-Header').text("");
//    $('#lblSuccess').text('Individiual Client Updated Successfully.');
//    //$('#dvClientDetail').load('GetIndividualClientDetail');
//    //$('#ModalClose').click();
//}

$('#UserName').on('blur', function (e) {
    $.ajax({
        type: "POST",
        url: "UserExists11",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ UserName: $("#UserName").val() }),
        success: function (response) {
            if (response == true) {
                $('#dvAlertDanger').css("display", "block");
                $('#lblAlertDanger').text("UserName Already Exists");
                $('#btnSubmit').prop("disabled", true);
            }
            else {
                $('#dvAlertDanger').css("display", "none");
                $('#lblAlertDanger').text(" ");
                $('#btnSubmit').prop("disabled", false);
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
});