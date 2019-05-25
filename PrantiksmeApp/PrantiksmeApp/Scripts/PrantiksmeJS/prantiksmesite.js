
var subDirectory = "/../../";


$(document).ready(function () {
    //Project JS


    //Date Picker Js Start-----------------


    $(".date-picker").datepicker({ dateFormat: "dd/mm/yy", timeFormat: "hh:mm:ss", maxDate: "0", changeMonth: true, changeYear: true, yearRange: "-100:+5" });
    $(".date-picker-future").datepicker({ dateFormat: "dd/mm/yy", timeFormat: "hh:mm:ss", changeMonth: true, changeYear: true, yearRange: "-100:+5" });
    $(".date-picker-now").datepicker({ dateFormat: "dd/mm/yy", timeFormat: "hh:mm:ss", maxDate: "0", changeMonth: true, changeYear: true, yearRange: "-100:+0" }).datepicker("setDate", "0");
    $(".birthDatePicker").datepicker({ dateFormat: "dd/mm/yy", changeMonth: true, changeYear: true, yearRange: "-100:+0" });


    //----------------Check Fiscal Year Range End------------------

    $(document.body).on("change", ".date-picker", function () {
        var date = tryToDate($(this).val());
        var isFutureDate = checkItsFutureDate(date);
        if (isFutureDate == true) {
            failedMsg("Sorry, Input Date Can't Be Greater Than To date");
            $(this).val("");
        }
    });

    $(document.body).on("change", ".date-picker-now", function () {
        var date = tryToDate($(this).val());
        var isFutureDate = checkItsFutureDate(date);
        if (isFutureDate == true) {
            failedMsg("Sorry, Input Date Can't Be Greater Than To date");
            $(this).datepicker({ dateFormat: "dd/mm/yy", timeFormat: "hh:mm:ss", maxDate: "0" }).datepicker("setDate", "0");
        }
    });


    function tryToDate(dateParam) {
        var dateTime = dateParam.split(" ");
        var date = dateTime[0].split("/");
        return new Date(date[2], (date[1] - 1), date[0]);
    }

    function checkItsFutureDate(dateTime) {
        var now = new Date();
        var future = false;
        if (Date.parse(now) < Date.parse(dateTime)) {
            future = true;
        }
        return future;
    }



    function getTodayDate() {
        var tdate = new Date();
        var dd = tdate.getDate();
        var mm = tdate.getMonth();
        var yyyy = tdate.getFullYear();
        var currentDate = dd + "/" + (mm + 1) + "/" + yyyy;
        return currentDate;
    }
    //Date Picker Js End-----------------

});