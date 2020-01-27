if (!tmx.services.login) tmx.services.login = {};

tmx.services.login.add = function (loginData, onSuccess, onError) {

  var url = "/api/users/login";

  var settings = {
    cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: loginData
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "POST"
  };

  $.ajax(url, settings);

};

tmx.services.login.reset = function (tokenData, onSuccess, onError) {

  var url = "/api/users/resetpassword";
  var settings = {
    cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: tokenData
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "PUT"
  };
  $.ajax(url, settings);
};

tmx.services.login.sendForgotPassword = function (emailData, onSuccess, onError) {

  var url = "/api/users/sendEmail";
  var settings = {
    cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: emailData
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "POST"
  };
  $.ajax(url, settings);
}