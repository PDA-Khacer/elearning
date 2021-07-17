$(document).ready(function() {
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
    //////////////////////////////////////////// Student
    $("#modal-student-search-allCheck").change(function(e) {
        e.preventDefault();
        if ($(this).is(':checked')) {
            $('.container-model-result-search-student').find('.modal-student-search-check').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $('#modal-addstudent-btn-add').attr('disabled', false);
            });
        } else {
            $('.container-model-result-search-student').find('.modal-student-search-check').each(function(index, element) {
                // element == this
                $(element).attr('checked', false);
                $('#modal-addstudent-btn-add').attr('disabled', true);
            });
        }
    });

    // check từng check box 
    $('.modal-student-search-check').change(function(e) {

        e.preventDefault();
        var isCheck = false;
        $('.container-model-result-search-student').find('.modal-student-search-check').each(function(index, element) {
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

    ///////////////////
    $("#modal-student-resultFind-allCheck").change(function(e) {
        e.preventDefault();
        if ($(this).is(':checked')) {
            $('.container-model-student-in-class').find('.modal-student-resultStudent-check').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $('#modal-addstudent-btn-del').attr('disabled', false);
            });
        } else {
            $('.container-model-student-in-class').find('.modal-student-resultStudent-check').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $(element).attr('checked', false);
                $('#modal-addstudent-btn-del').attr('disabled', true);
            });
        }
    });

    // check từng check box 
    $('.modal-student-resultStudent-check').change(function(e) {

        e.preventDefault();
        var isCheck = false;
        $('.container-model-student-in-class').find('.modal-student-resultStudent-check').each(function(index, element) {
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

    //////////////////////////////////////////// Teacher
    $("#modal-search-teacher-checkbox-all").change(function(e) {
        e.preventDefault();
        if ($(this).is(':checked')) {
            $('.container-model-result-search-teacher').find('.modal-search-teacher-checkbox').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $('#modal-search-teacher-btn-add').attr('disabled', false);
            });
        } else {
            $('.container-model-result-search-teacher').find('.modal-search-teacher-checkbox').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $(element).attr('checked', false);
                $('#modal-search-teacher-btn-add').attr('disabled', true);
            });
        }
    });

    // check từng check box 
    $('.modal-search-teacher-checkbox').change(function(e) {

        e.preventDefault();
        var isCheck = false;
        $('.container-model-result-search-teacher').find('.modal-search-teacher-checkbox').each(function(index, element) {
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

    ///////////////////
    $("#modal-result-teacher-checkbox-all").change(function(e) {
        e.preventDefault();
        if ($(this).is(':checked')) {
            $('.container-model-teacher-in-class').find('.modal-result-teacher-checkbox').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $('#modal-result-teacher-btn-del').attr('disabled', false);
            });
        } else {
            $('.container-model-teacher-in-class').find('.modal-result-teacher-checkbox').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $(element).attr('checked', false);
                $('#modal-result-teacher-btn-del').attr('disabled', true);
            });
        }
    });

    // check từng check box 
    $('.modal-result-teacher-checkbox').change(function(e) {
        e.preventDefault();
        var isCheck = false;
        $('.container-model-teacher-in-class').find('.modal-result-teacher-checkbox').each(function(index, element) {
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

    ////////////////////////////////////////// Lecture
    $("#selection-resourse-finding").change(function(e) {
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
    $("#modal-search-teacher-checkbox-all-lec").change(function(e) {
        e.preventDefault();
        if ($(this).is(':checked')) {
            $('.container-model-result-search-teacher-lec').find('.modal-search-teacher-checkbox-lec').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $('#modal-list-lecture-btn-add').attr('disabled', false);
            });
        } else {
            $('.container-model-result-search-teacher-lec').find('.modal-search-teacher-checkbox-lec').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $(element).attr('checked', false);
                $('#modal-list-lecture-btn-add').attr('disabled', true);
            });
        }
    });

    // check từng check box 
    $('.modal-search-teacher-checkbox').change(function(e) {

        e.preventDefault();
        var isCheck = false;
        $('.container-model-result-search-teacher-lec').find('.modal-search-teacher-checkbox-lec').each(function(index, element) {
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
    $("#modal-search-lecture-checkbox-all-lec").change(function(e) {
        e.preventDefault();
        if ($(this).is(':checked')) {
            $('.container-model-result-search-lecture').find('.modal-search-lecture-checkbox-lec').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $('#modal-list-lecture-search-btn-add').attr('disabled', false);
            });
        } else {
            $('.container-model-result-search-lecture').find('.modal-search-lecture-checkbox-lec').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $(element).attr('checked', false);
                $('#modal-list-lecture-search-btn-add').attr('disabled', true);
            });
        }
    });

    // check từng check box 
    $('.modal-search-lecture-checkbox-lec').change(function(e) {
        e.preventDefault();
        var isCheck = false;
        $('.container-model-result-search-lecture').find('.modal-search-lecture-checkbox-lec').each(function(index, element) {
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
    $("#modal-class-lecture-checkbox-all-lec").change(function(e) {
        e.preventDefault();
        if ($(this).is(':checked')) {
            $('.container-model-lecture-in-class').find('.modal-class-lecture-checkbox-lec').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $('#modal-list-lecture-class-btn-add').attr('disabled', false);
            });
        } else {
            $('.container-model-lecture-in-class').find('.modal-class-lecture-checkbox-lec').each(function(index, element) {
                // element == this
                $(element).attr('checked', true);
                $(element).attr('checked', false);
                $('#modal-list-lecture-class-btn-add').attr('disabled', true);
            });
        }
    });

    // check từng check box 
    $('.modal-class-lecture-checkbox-lec').change(function(e) {
        e.preventDefault();
        var isCheck = false;
        $('.container-model-lecture-in-class').find('.modal-class-lecture-checkbox-lec').each(function(index, element) {
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
});