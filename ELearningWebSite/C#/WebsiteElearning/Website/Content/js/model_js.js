//////////////////////////////////////////// Student
$("#modal-student-search-allCheck").change(function (e) {
    e.preventDefault();
    if ($(this).is(':checked')) {
        $('.container-model-result-search-student').find('.modal-student-search-check').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $('#modal-addstudent-btn-add').attr('disabled', false);
        });
    } else {
        $('.container-model-result-search-student').find('.modal-student-search-check').each(function (index, element) {
            // element == this
            $(element).attr('checked', false);
            $('#modal-addstudent-btn-add').attr('disabled', true);
        });
    }
});


///////////////////
$("#modal-student-resultFind-allCheck").change(function (e) {
    e.preventDefault();
    if ($(this).is(':checked')) {
        $('.container-model-student-in-class').find('.modal-student-resultStudent-check').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $('#modal-addstudent-btn-del').attr('disabled', false);
        });
    } else {
        $('.container-model-student-in-class').find('.modal-student-resultStudent-check').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $(element).attr('checked', false);
            $('#modal-addstudent-btn-del').attr('disabled', true);
        });
    }
});


//////////////////////////////////////////// Teacher
$("#modal-search-teacher-checkbox-all").change(function (e) {
    e.preventDefault();
    if ($(this).is(':checked')) {
        $('.container-model-result-search-teacher').find('.modal-search-teacher-checkbox').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $('#modal-search-teacher-btn-add').attr('disabled', false);
        });
    } else {
        $('.container-model-result-search-teacher').find('.modal-search-teacher-checkbox').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $(element).attr('checked', false);
            $('#modal-search-teacher-btn-add').attr('disabled', true);
        });
    }
});


///////////////////
$("#modal-result-teacher-checkbox-all").change(function (e) {
    e.preventDefault();
    if ($(this).is(':checked')) {
        $('.container-model-teacher-in-class').find('.modal-result-teacher-checkbox').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $('#modal-result-teacher-btn-del').attr('disabled', false);
        });
    } else {
        $('.container-model-teacher-in-class').find('.modal-result-teacher-checkbox').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $(element).attr('checked', false);
            $('#modal-result-teacher-btn-del').attr('disabled', true);
        });
    }
});


////////////////////////////////////////// Lecture
$("#selection-resourse-finding").change(function (e) {
    e.preventDefault();
    if ($(this).val() == "tkbh") {
        $(".container-modal-search-teacher-lec").hide();
        $(".container-model-result-search-teacher-lec").hide();
        $(".container-modal-search-lecture").show();
        $(".container-model-result-search-lecture").show();
    } else {
        $(".container-modal-search-teacher-lec").show();
        $(".container-model-result-search-teacher-lec").show();
        $(".container-modal-search-lecture").hide();
        $(".container-model-result-search-lecture").hide();
    }
});

// -------------------------------------
$("#modal-search-teacher-checkbox-all-lec").change(function (e) {
    e.preventDefault();
    if ($(this).is(':checked')) {
        $('.container-model-result-search-teacher-lec').find('.modal-search-teacher-checkbox-lec').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $('#modal-list-lecture-btn-add').attr('disabled', false);
        });
    } else {
        $('.container-model-result-search-teacher-lec').find('.modal-search-teacher-checkbox-lec').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $(element).attr('checked', false);
            $('#modal-list-lecture-btn-add').attr('disabled', true);
        });
    }
});

// check từng check box 
$('.modal-search-teacher-checkbox').change(function (e) {

    e.preventDefault();
    var isCheck = false;
    $('.container-model-result-search-teacher-lec').find('.modal-search-teacher-checkbox-lec').each(function (index, element) {
        // element == this
        if ($(element).is(":checked")) {
            isCheck = true;
        }
    });
    if (isCheck) {
        $('#modal-list-lecture-btn-add').attr('disabled', true);
        $('#modal-list-lecture-btn-add').attr('disabled', false);
    } else {
        $('#modal-list-lecture-btn-add').attr('disabled', true);
    }
});

// -------------------------------------
$("#modal-search-lecture-checkbox-all-lec").change(function (e) {
    e.preventDefault();
    if ($(this).is(':checked')) {
        $('.container-model-result-search-lecture').find('.modal-search-lecture-checkbox-lec').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $('#modal-list-lecture-search-btn-add').attr('disabled', false);
        });
    } else {
        $('.container-model-result-search-lecture').find('.modal-search-lecture-checkbox-lec').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $(element).attr('checked', false);
            $('#modal-list-lecture-search-btn-add').attr('disabled', true);
        });
    }
});

// check từng check box 
$('.modal-search-lecture-checkbox-lec').change(function (e) {
    e.preventDefault();
    var isCheck = false;
    $('.container-model-result-search-lecture').find('.modal-search-lecture-checkbox-lec').each(function (index, element) {
        // element == this
        if ($(element).is(":checked")) {
            isCheck = true;
        }
    });
    if (isCheck) {
        $('#modal-list-lecture-search-btn-add').attr('disabled', true);
        $('#modal-list-lecture-search-btn-add').attr('disabled', false);
    } else {
        $('#modal-list-lecture-search-btn-add').attr('disabled', true);
    }
});

// -------------------------------------
$("#modal-class-lecture-checkbox-all-lec").change(function (e) {
    e.preventDefault();
    if ($(this).is(':checked')) {
        $('.container-model-lecture-in-class').find('.modal-class-lecture-checkbox-lec').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $('#modal-list-lecture-class-btn-add').attr('disabled', false);
        });
    } else {
        $('.container-model-lecture-in-class').find('.modal-class-lecture-checkbox-lec').each(function (index, element) {
            // element == this
            $(element).attr('checked', true);
            $(element).attr('checked', false);
            $('#modal-list-lecture-class-btn-add').attr('disabled', true);
        });
    }
});

// check từng check box 
$('.modal-class-lecture-checkbox-lec').change(function (e) {
    e.preventDefault();
    var isCheck = false;
    $('.container-model-lecture-in-class').find('.modal-class-lecture-checkbox-lec').each(function (index, element) {
        // element == this
        if ($(element).is(":checked")) {
            isCheck = true;
        }
    });
    if (isCheck) {
        $('#modal-list-lecture-class-btn-add').attr('disabled', true);
        $('#modal-list-lecture-class-btn-add').attr('disabled', false);
    } else {
        $('#modal-list-lecture-class-btn-add').attr('disabled', true);
    }
});



///////// ajax
$.ajax({
    url: '/ClassCourse/LstTeacherModal/1002',
    contentType: 'application/html; charset=utf-8',
    type: 'GET',
    dataType: 'html',
    success: function (result) {
        $('.containTableTeacher-detailView-modal').html(result);
    }
});

$.ajax({
    url: '/ClassCourse/LstStudentModal/1002',
    contentType: 'application/html; charset=utf-8',
    type: 'GET',
    dataType: 'html',
    success: function (result) {
        $('.containTableStudent-detailView-modal').html(result);
    }
});

$('#findStudent-btn').click(function (e) {
    e.preventDefault();
    var text = $('#findStudentInSystem-tb').val();

    $.ajax({
        url: '/ClassCourse/FindStudent',
        contentType: 'application/html; charset=utf-8',
        data : { key: text },
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('.result-find-student-modal').html(result);
        },
        error: function () {
            alert("lỗi");
        }
    });
});

$('#findTeacher-btn').click(function (e) {
    e.preventDefault();
    var text = $('#findTeacher-tb').val();

    $.ajax({
        url: '/ClassCourse/FindTeacher',
        contentType: 'application/html; charset=utf-8',
        data: { key: text },
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('.result-find-teacher-modal').html(result);
        },
        error: function () {
            alert("lỗi");
        }
    });
});

$('#modal-addstudent-btn-add').click(function (e) {
    e.preventDefault();
    var lstId = "";
    $('.container-model-result-search-student').find('.modal-student-search-check:checked').each(function (index, element) {
        lstId += $(element).closest('td').find('.idAcc').text() + '.';
    });

    $.ajax({
        url: '/ClassCourse/AddStudentInClass',
        contentType: 'application/html; charset=utf-8',
        data: { lstId: lstId },
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('.containTableStudent-detailView-modal').html(result);
            alert("Thêm thành công!");
        },
        error: function () {
            alert("lỗi");
        }
    });
});

$('#modal-addstudent-btn-del').click(function (e) {
    e.preventDefault();
    var lstId = "";
    $('.container-model-student-in-class').find('.modal-student-resultStudent-check:checked').each(function (index, element) {
        lstId += $(element).closest('td').find('.idAcc').text() + '.';
    });
    alert(lstId);

    $.ajax({
        url: '/ClassCourse/RemoveStudentFormClass',
        contentType: 'application/html; charset=utf-8',
        data: { lstId: lstId },
        type: 'GET',
        dataType: 'html',
        success: function (result) {
            $('.containTableStudent-detailView-modal').html(result);
            alert("Xóa thành công!");
        },
        error: function () {
            alert("lỗi");
        }
    });
});

