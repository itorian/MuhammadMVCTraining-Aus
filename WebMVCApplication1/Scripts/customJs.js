
$(function () {

    //function getParameterByName(name, url) {
    //    if (!url) url = window.location.href;
    //    name = name.replace(/[\[\]]/g, "\\$&");
    //    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
    //        results = regex.exec(url);
    //    if (!results) return null;
    //    if (!results[2]) return '';
    //    return decodeURIComponent(results[2].replace(/\+/g, " "));
    //}

    //var status = getParameterByName('status');
    //if (status == "success")
    //    toastrNotification('Record inserted', 'success');
    //if (status == "error")
    //    toastrNotification('Error in inserting', 'error');


    //// Display toast notification
    function toastrNotification(message, type) {
        if (type == 'success')
            toastr.success(message);
        if (type == 'error')
            toastr.error(message);
        if (type == 'info')
            toastr.info(message);
    }

    //// Create new student
    $('.btnCreate').click(function () {
        var name = $('#Name').val();
        var address = $('#Address').val();
        var token = $('input[name="__RequestVerificationToken"]').val();

        var url = "/Student/Create";
        $.post(url, { Name: name, Address: address, __RequestVerificationToken: token }, function (data) {
            if (data.result == true) {
                //window.location.href = "../student/index?status=success";
                toastrNotification('Record inserted', 'success');
            }
            if (data.result == false)
                toastrNotification('Please complete form', 'error');
        });
    });

    //// Load all students
    var url = "/Student/LoadStudents";
    $.get(url, null, function (data) {

        $.each(data, function (key, value) {

            for (var i = 0; i < value.length; i++) {
                console.log(value[i].Name);
                console.log(value[i].Address);
            }


        });

        


        //$(".studentList").html(data);
    });



})