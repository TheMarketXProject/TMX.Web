if (!TMX.services.gyn) TMX.services.gyn = {};

TMX.services.gyn.createGynCase = function (gynCaseData, onSuccess, onError) {

    var url = "/api/GynCaseForm";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: gynCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "POST"
    };

    $.ajax(url, settings);
}

TMX.services.gyn.updateGynCase = function (id, gynCaseData, onSuccess, onError) {

    var url = "/api/GynCaseForm/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: gynCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "PUT"
    };

    $.ajax(url, settings);

}

TMX.services.gyn.getGynCase = function (id, onSuccess, onError) {

    var url = "/api/GynCaseForm/" + id;
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

TMX.services.gyn.getGynCaseByHospital = function (hospitalId, onSuccess, onError) {

    var url = "/api/GynCaseForm/Hospital/" + hospitalId;
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

TMX.services.gyn.getGynCaseList = function (onSuccess, onError) {

    var url = "/api/GynCaseForm/";
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

TMX.services.gyn.deleteGynCase = function (id, onSuccess, onError) {

    var url = "/api/GynCaseForm/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "DELETE"
    };

    $.ajax(url, settings);
}

TMX.services.gyn.getHospitals = function (onSuccess, onError) {

    var url = "/api/Hospitals/";
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
