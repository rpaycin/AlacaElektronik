function fieldValidationControl(fieldKey, message) {
    var fieldValue = $("#" + fieldKey).val();
    if (fieldValue == '' || fieldValue == null || fieldValue == undefined) {
        toastr.error(message)
        return false;
    }

    return true;
}