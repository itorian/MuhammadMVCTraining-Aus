﻿$.validator.unobtrusive.adapters.addSingleVal("exclude", "str");
$.validator.addMethod("exclude", function (value, element, exclude) {
    if (value) {
        for (var i = 0; i < exclude.length; i++) {
            if (jQuery.inArray(exclude[i], value) != -1) {
                return false;
            }
        }
    }
    return true;
});
