if (!tmx.services.userTokens) tmx.services.userTokens = {};

tmx.services.userTokens.add = function (tokenData, onSuccess, onError) {

  var url = "/api/users/UserTokens";

  var settings = {
    cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: tokenData
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "POST"
  };

  $.ajax(url, settings);
};