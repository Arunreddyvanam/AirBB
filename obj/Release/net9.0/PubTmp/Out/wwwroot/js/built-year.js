jQuery.validator.addMethod("builtyearrange", function (value, element, param) {

    if (!value) return false;

    var selectedDate = new Date(value);
    if (selectedDate.toString() === "Invalid Date") return false;

    var maxYears = Number(param);

    var today = new Date();
    var earliestAllowed = new Date();
    earliestAllowed.setFullYear(today.getFullYear() - maxYears);

    return (selectedDate <= today && selectedDate >= earliestAllowed);
});

jQuery.validator.unobtrusive.adapters.addSingleVal("builtyearrange", "years");
