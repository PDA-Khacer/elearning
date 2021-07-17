$(document).ready(function () {

    //$('.container-mymodal').load('@Url.Action("Modal","ClassCourse")');

    //$.get('@Url.Action("Modal","ClassCourse")', function (data) {
    //    $('.container-mymodal').html(data);
    //}); 



    $("#selection-humnan-resourse").change(function(e) {
        e.preventDefault();
        if ($(this).val() == "dssv") {
            $("#container-selection-dssv").show();
            $("#container-selection-dsgv").hide();
        } else {
            $("#container-selection-dssv").hide();
            $("#container-selection-dsgv").show();
        }
    });

    $.ajax({
        url: '/ClassCourse/Modal',
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('.container-mymodal').html(result);
        }
    });

    $.ajax({
        url: '/ClassCourse/LstTeacher/1002',
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('.containTableTeacher-detailView').html(result);
        }
    });

    $.ajax({
        url: '/ClassCourse/LstStudent/1002',
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('.containTableStudent-detailView').html(result);
        }
    });
});
