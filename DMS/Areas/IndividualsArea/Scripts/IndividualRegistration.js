$(document).ready(function () {
    $('#BirthDate').datepicker({
        dateFormat: "dd/MM/yyyy"
    });
    $('#dvFirmName').hide();
    if ($('#hdnMessage').val() != '') {
        $('#dvRegister').hide();
    }
    else {
        $('#dvRegister').show();
    }
    $("#btnProfile").click(function () {

        $('#dvSuccess').hide();
        $('#Modal-Header').text("Edit Individual Client");
        $.ajax({
            type: "POST",
            url: "GetIndividualClientDetail",
            contentType: "application/json; charset=utf-8",
            dataType: 'html',
            success: function (data) {
                $('#dvClientDetail').html(data);
                $('#dvClientDetail form').data('validator', null);
                $.validator.unobtrusive.parse('#dvClientDetail form');
            },
            error: function (response) {
                alert('Some Error Occured');
            }
        });
    });
    function Success(data) {
        if (data.Prefix == 1) {
            $('#Prefix').val(1);
        }
        else {
            $('#Prefix').val(2);
        }
        $('#IndividualRecordId').val(data.IndividualRecordId);
        $('#FirstName').val(data.FirstName);
        $('#MiddleName').val(data.MiddleName);
        $('#LastName').val(data.LastName);
        $('#BirthDate').val(data.BirthDate);
        $('#SSNumber').val(data.SSN);
        $('#Phone').val(data.Phone);
        $('#Suffix').val(data.Suffix);
    };

    $('#SSN').keydown(function (e) {
        if (e.shiftKey || e.ctrlKey || e.altKey) {
            e.preventDefault();
        } else {
            var key = e.keyCode;
            if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105)) && !(key == 9)) {
                e.preventDefault();
            }
        }
    });
    $('#SSNumber').keydown(function (e) {
        if (e.shiftKey || e.ctrlKey || e.altKey) {
            e.preventDefault();
        } else {
            var key = e.keyCode;
            if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105)) && !(key == 9)) {
                e.preventDefault();
            }
        }
    });

    $('#Phone').keydown(function (e) {
        if (e.shiftKey || e.ctrlKey || e.altKey || e.tabKey) {
            e.preventDefault();
        } else {
            var key = e.keyCode;
            if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105)) && !(key == 9)) {
                e.preventDefault();
            }
        }
    });
    $('#SSN').on('blur', function (e) {
        $.ajax({
            type: "POST",
            url: 'IsSSNExists',
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ SSN: $("#SSN").val() }),
            success: function (response) {
                if (response == true) {
                    $('#dvAlertDanger').css("display", "block");
                    $('#lblAlertDanger').text("SSN Already Exists");
                    $('#btnSubmit').prop("disabled", true);
                    $('#dvAlertSuccess').hide();
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
    $('#SSNumber').on('blur', function (e) {
        $.ajax({
            type: "POST",
            url: 'IsSSNExistsForIndividualClient',
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ SSN: $("#SSNumber").val(), IndividualRecordId: $('#IndividualRecordId').val() }),
            success: function (response) {
                if (response == true) {
                    $('#dvAlertDanger').css("display", "block");
                    $('#lblAlertDanger').text("SSN Already Exists");
                    $('#dvAlertSuccess').hide();
                    $('#btnUpdate').prop("disabled", true);
                }
                else {
                    $('#dvAlertDanger').css("display", "none");
                    $('#lblAlertDanger').text(" ");
                    $('#btnUpdate').prop("disabled", false);
                }
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    $('#rdoFirm').click(function (e) {
        $('#dvFirmName').show()
    });
    $('#rdoIndividual').click(function (e) {
        $('#dvFirmName').hide()
    });

});
$('#EmailAddress').on('blur', function (e) {
    $.ajax({
        type: "POST",
        url: "IsEmailExists",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ EmailAddress: $("#EmailAddress").val() }),
        success: function (response) {
            if (response == true) {
                $('#dvAlertDanger').css("display", "block");
                $('#lblAlertDanger').text("Email Already Exists");
                $('#dvAlertSuccess').hide();
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
$('#UserName').on('blur', function (e) {
    $.ajax({
        type: "POST",
        url: "IsUserExists",
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

function UpdateSuccess(e) {
    $('#dvSuccess').show();
    $('#Modal-Header').text("");
    $('#lblSuccess').text('Individiual Client Updated Successfully.');
}

