if (!tmx.services.messaging) tmx.services.messaging = {};


tmx.services.messaging.sendConfirmEmail = function (regTokenData, onSuccess, onError) {

  var url = "/api/message/ConfirmEmail";

  var setting = {
    cache: false,
    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
    data: regTokenData,
    success: onSuccess,
    error: onError,
    type: "post"

  };

  $.ajax(url, setting);
};