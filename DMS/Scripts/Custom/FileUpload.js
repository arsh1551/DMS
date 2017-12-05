var $form = null;
$(function () {
    $form = $('#fileupload').fileupload({
        dataType: 'json'
    });
    $('#fileupload').addClass('fileupload-processing');
});
$.ajax({
    type: 'GET',
    contentType: "application/json; charset=utf-8",
    url: $_GetFileList,
    success: function (data) {
        $('#fileupload').fileupload('option', 'done').call($('#fileupload'), $.Event('done'), { result: { files: data.files } })
        $('#fileupload').removeClass('fileupload-processing');
    }
});
