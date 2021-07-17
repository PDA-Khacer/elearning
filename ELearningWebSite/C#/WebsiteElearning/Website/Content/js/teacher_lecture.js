$.ajax({
    url: '/Lecture/Modal',
    contentType: 'application/html; charset=utf-8',
    type: 'GET',
    dataType: 'html',
    success: function (result) {
        $('.container-mymodal').html(result);
    }
});