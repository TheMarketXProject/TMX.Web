if (!TMX.services.hospitals){
    TMX.services.hospitals = {};
}

TMX.services.hospitals.addHospital = function (hospitalData, onSuccess, onError) {

    var url = "/api/Hospitals";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: hospitalData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "POST"
    };

    $.ajax(url, settings);
}

TMX.services.hospitals.updateHospital = function (id, hospitalData, onSuccess, onError) {

    var url = "/api/Hospitals/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: hospitalData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "PUT"
    };

    $.ajax(url, settings);

}

TMX.services.hospitals.getHospital = function (id, onSuccess, onError) {

    var url = "/api/Hospitals/" + id;
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

TMX.services.hospitals.getHospitalList = function (onSuccess, onError) {

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

TMX.services.hospitals.deleteHospital = function (id, onSuccess, onError) {

    var url = "/api/Hospitals/" + id;
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