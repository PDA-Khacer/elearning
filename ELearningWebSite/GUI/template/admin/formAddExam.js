$(document).ready(function() {
    // -----------------------------------------------------------------------------------
    $("#mcq-select-num-ans").change(function(e) {
        e.preventDefault();
        switch ($(this).val()) {
            case "2":
                {
                    $("#contain-answer3").attr("hidden", true);
                    $("#contain-answer4").attr("hidden", true);
                    $("#contain-answer5").attr("hidden", true);
                    $("#contain-answer6").attr("hidden", true);
                    break;
                }
            case "3":
                {
                    $("#contain-answer3").attr("hidden", false);
                    $("#contain-answer4").attr("hidden", true);
                    $("#contain-answer5").attr("hidden", true);
                    $("#contain-answer6").attr("hidden", true);
                    break;
                }
            case "4":
                {
                    $("#contain-answer3").attr("hidden", false);
                    $("#contain-answer4").attr("hidden", false);
                    $("#contain-answer5").attr("hidden", true);
                    $("#contain-answer6").attr("hidden", true);
                    break;
                }
            case "5":
                {
                    $("#contain-answer3").attr("hidden", false);
                    $("#contain-answer4").attr("hidden", false);
                    $("#contain-answer5").attr("hidden", false);
                    $("#contain-answer6").attr("hidden", true);
                    break;
                }
            case "6":
                {
                    $("#contain-answer3").attr("hidden", false);
                    $("#contain-answer4").attr("hidden", false);
                    $("#contain-answer5").attr("hidden", false);
                    $("#contain-answer6").attr("hidden", false);
                    break;
                }
        }
    });
    // -----------------------------------------------------------------------------------
    $("#tf-select-num-ans").change(function(e) {
        e.preventDefault();
        switch ($(this).val()) {
            case "2":
                {
                    $("#contain-answer3-tf").attr("hidden", true);
                    $("#contain-answer4-tf").attr("hidden", true);
                    $("#contain-answer5-tf").attr("hidden", true);
                    $("#contain-answer6-tf").attr("hidden", true);
                    break;
                }
            case "3":
                {
                    $("#contain-answer3-tf").attr("hidden", false);
                    $("#contain-answer4-tf").attr("hidden", true);
                    $("#contain-answer5-tf").attr("hidden", true);
                    $("#contain-answer6-tf").attr("hidden", true);
                    break;
                }
            case "4":
                {
                    $("#contain-answer3-tf").attr("hidden", false);
                    $("#contain-answer4-tf").attr("hidden", false);
                    $("#contain-answer5-tf").attr("hidden", true);
                    $("#contain-answer6-tf").attr("hidden", true);
                    break;
                }
            case "5":
                {
                    $("#contain-answer3-tf").attr("hidden", false);
                    $("#contain-answer4-tf").attr("hidden", false);
                    $("#contain-answer5-tf").attr("hidden", false);
                    $("#contain-answer6-tf").attr("hidden", true);
                    break;
                }
            case "6":
                {
                    $("#contain-answer3-tf").attr("hidden", false);
                    $("#contain-answer4-tf").attr("hidden", false);
                    $("#contain-answer5-tf").attr("hidden", false);
                    $("#contain-answer6-tf").attr("hidden", false);
                    break;
                }
        }
    });
    // -----------------------------------------------------------------------------------
    $("#mapping-select-num-ans").change(function(e) {
        e.preventDefault();
        switch ($(this).val()) {
            case "2":
                {
                    $("#contain-answer3-mapping").attr("hidden", true);
                    $("#contain-answer4-mapping").attr("hidden", true);
                    $("#contain-answer5-mapping").attr("hidden", true);
                    $("#contain-answer6-mapping").attr("hidden", true);
                    break;
                }
            case "3":
                {
                    $("#contain-answer3-mapping").attr("hidden", false);
                    $("#contain-answer4-mapping").attr("hidden", true);
                    $("#contain-answer5-mapping").attr("hidden", true);
                    $("#contain-answer6-mapping").attr("hidden", true);
                    break;
                }
            case "4":
                {
                    $("#contain-answer3-mapping").attr("hidden", false);
                    $("#contain-answer4-mapping").attr("hidden", false);
                    $("#contain-answer5-mapping").attr("hidden", true);
                    $("#contain-answer6-mapping").attr("hidden", true);
                    break;
                }
            case "5":
                {
                    $("#contain-answer3-mapping").attr("hidden", false);
                    $("#contain-answer4-mapping").attr("hidden", false);
                    $("#contain-answer5-mapping").attr("hidden", false);
                    $("#contain-answer6-mapping").attr("hidden", true);
                    break;
                }
            case "6":
                {
                    $("#contain-answer3-mapping").attr("hidden", false);
                    $("#contain-answer4-mapping").attr("hidden", false);
                    $("#contain-answer5-mapping").attr("hidden", false);
                    $("#contain-answer6-mapping").attr("hidden", false);
                    break;
                }
        }
    });
    // -----------------------------------------------------------------------------------

});