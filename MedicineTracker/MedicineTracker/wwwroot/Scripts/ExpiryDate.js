jQuery.validator.addMethod("expiryDate",
    function (value, element, param) {

        if (Math.ceil((new Date(value)).getTime() - (new Date()).getTime()) / (1000 * 3600 * 24) < 30) {
            return false;
        }
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("expiryDate");