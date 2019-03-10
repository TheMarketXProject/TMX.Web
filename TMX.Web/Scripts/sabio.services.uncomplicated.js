if (!TMX.services.uncomplicated) TMX.services.uncomplicated = {};

TMX.services.uncomplicated.createUncompCase = function (caseData, onSuccess, onError) {

    var url = "/api/UncompCaseForm";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: caseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "POST"
    };

    $.ajax(url, settings);
}

TMX.services.uncomplicated.getUncompCaseByHospital = function (hospitalId, onSuccess, onError) {

    var url = "/api/UncompCaseForm/Hospital/" + hospitalId;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    };

    $.ajax(url, settings);
}

