// check từng check box 
$('.modal-student-search-check').change(function (e) {
    e.preventDefault();
    var isCheck = false;
    $('.container-model-result-search-student').find('.modal-student-search-check').each(function (index, element) {
        // element == this
        if ($(element).is(":checked")) {
            isCheck = true;
        }
    });
    if (isCheck) {
        $('#modal-addstudent-btn-add').attr('disabled', true);
        $('#modal-addstudent-btn-add').attr('disabled', false);
    } else {
        $('#modal-addstudent-btn-add').attr('disabled', true);
    }
});

$('.modal-student-resultStudent-check').change(function (e) {

    e.preventDefault();
    var isCheck = false;
    $('.container-model-student-in-class').find('.modal-student-resultStudent-check').each(function (index, element) {
        // element == this
        if ($(element).is(":checked")) {
            isCheck = true;
        }
    });
    if (isCheck) {
        $('#modal-addstudent-btn-del').attr('disabled', true);
        $('#modal-addstudent-btn-del').attr('disabled', false);
    } else {
        $('#modal-addstudent-btn-del').attr('disabled', true);
    }
});

$('.modal-search-teacher-checkbox').change(function (e) {

    e.preventDefault();
    var isCheck = false;
    $('.container-model-result-search-teacher').find('.modal-search-teacher-checkbox').each(function (index, element) {
        // element == this
        if ($(element).is(":checked")) {
            isCheck = true;
        }
    });
    if (isCheck) {
        $('#modal-search-teacher-btn-add').attr('disabled', true);
        $('#modal-search-teacher-btn-add').attr('disabled', false);
    } else {
        $('#modal-search-teacher-btn-add').attr('disabled', true);
    }
});

// check từng check box 
$('.modal-result-teacher-checkbox').change(function (e) {
    e.preventDefault();
    var isCheck = false;
    $('.container-model-teacher-in-class').find('.modal-result-teacher-checkbox').each(function (index, element) {
        // element == this
        if ($(element).is(":checked")) {
            isCheck = true;
        }
    });
    if (isCheck) {
        $('#modal-result-teacher-btn-del').attr('disabled', true);
        $('#modal-result-teacher-btn-del').attr('disabled', false);
    } else {
        $('#modal-result-teacher-btn-del').attr('disabled', true);
    }
});