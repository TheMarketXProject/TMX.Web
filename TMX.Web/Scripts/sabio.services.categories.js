if (!TMX.services.categories) {
    TMX.services.categories = {};
}

//OBSTETRICAL/////////////////////////////////////////////////////////////////
TMX.services.categories.getObCategory = function (id, onSuccess, onError) {

    var url = "/api/Categories/ObCategory" + id;
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

TMX.services.categories.getObCategoryList = function (onSuccess, onError) {

    var url = "/api/Categories/ObCategories";
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

//GYNECOLOGY/////////////////////////////////////////////////////////////////
TMX.services.categories.getGynCategory = function (id, onSuccess, onError) {

    var url = "/api/Categories/GynCategory" + id;
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

TMX.services.categories.getGynCategoryList = function (onSuccess, onError) {

    var url = "/api/Categories/GynCategories";
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

//OFFICE PRACTICE//////////////////////////////////////////////////////////////
TMX.services.categories.getOfficeCategory = function (id, onSuccess, onError) {

    var url = "/api/Categories/OfficeCategory" + id;
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

TMX.services.categories.getOfficeCategoryList = function (onSuccess, onError) {

    var url = "/api/Categories/OfficeCategories";
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

