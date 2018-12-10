$(function () {
    $("#fromdate1").datepicker({
        numberOfMonths: 1,
        onSelect: function (selected) {
            var dt = new Date(selected.split("/").reverse().join("/"));//new Date(selected);
            dt.setDate(dt.getDate() + 0);
            //$("#todate1").datepicker("option", "minDate", dt);
        },
        dateFormat: 'dd/mm/yy',
    });
    //$("#todate1").datepicker({
    //    numberOfMonths: 1,
    //    onSelect: function (selected) {
    //        var dt = new Date(selected.split("/").reverse().join("/"));//new Date(selected);
    //        dt.setDate(dt.getDate() - 0);
    //        $("#fromdate1").datepicker("option", "maxDate", dt);
    //    },
    //    dateFormat: 'dd/mm/yy',
    //});
});