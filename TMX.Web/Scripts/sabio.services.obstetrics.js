if (!TMX.services.obstetrics){
TMX.services.obstetrics = {};
}

TMX.services.obstetrics.createObCase = function (obCaseData, onSuccess, onError) {

    var url = "/api/ObCaseForm";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: obCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "POST"
    };

    $.ajax(url, settings);
}

TMX.services.obstetrics.updateObCase = function (id, obCaseData, onSuccess, onError) {

    var url = "/api/ObCaseForm/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: obCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "PUT"
    };

    $.ajax(url, settings);
    
}

TMX.services.obstetrics.getObCase = function (id, onSuccess, onError) {

    var url = "/api/ObCaseForm/" + id;
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

TMX.services.obstetrics.getObCaseByHospital = function (hospitalId, onSuccess, onError) {

    var url = "/api/ObCaseForm/Hospital/" + hospitalId;
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

TMX.services.obstetrics.getObCaseList = function (onSuccess, onError) {

    var url = "/api/ObCaseForm/";
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

TMX.services.obstetrics.deleteObCase = function (id, onSuccess, onError) {

    var url = "/api/ObCaseForm/" + id;
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

TMX.services.obstetrics.getHospitals = function (onSuccess, onError) {

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
