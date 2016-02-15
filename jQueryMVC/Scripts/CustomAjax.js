// document.onload
$(function () {

    $('#getData').click(function () {

        var id = $('#txtName').val();

        var url = "/Home/Welcome";
        $.get(url, { input: id }, function (data) {

            if (data == "null")
            {
                $("#response").html("Please complete the form.");
                return;
            }

            var items = '<table><tr><th>Name</th><th>Address</th></tr>';
            $.each(data, function (i, student) {
                items += "<tr><td>" + student.Name + "</td><td>" + student.Address + "</td></tr>";
            });
            items += "</table>";


            $("#response").html(items);
        });
    })



})