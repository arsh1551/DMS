function SendEmailForResetPwd() {
    if ($("#Email").val() != '' && validateEmail($.trim($("#Email").val()))) {
        var forgetpassword = new Object();
        forgetpassword.Email = $("#Email").val();
        $('body').loading({
            stoppable: true,
            message: 'Processing.........',
            theme: 'dark'
        });
        $.ajax({
            data: JSON.stringify(forgetpassword),
            contentType: "application/json",
            url: $_ForgetUserPassword,
            type: "POST",
            success: function (response) {                
                if (response == true) {
                    $(':loading').loading('stop');
                    $('#msg').text("");
                    $('#showmsg').text("We have sent an email to " + $("#Email").val()+ " Click the link in the email to reset your password");
                }
                else {
                    $(':loading').loading('stop');
                    $('#msg').text("Please enter a registered email address");
                }
            }
        });
    }
    else {
        $("#Email").css('border-color', 'red')
        $("#Email").focus();
    }
}
function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

