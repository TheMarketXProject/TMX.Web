if (!tmx.services.registration) tmx.services.registration = {};

tmx.services.registration.add = function (regData, onSuccess, onError) {

  var url = "/api/users/register";

  var settings = {
    cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: regData
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "POST"
  };

  $.ajax(url, settings);
};