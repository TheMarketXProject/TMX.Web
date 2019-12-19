var tmx = {
    layout: {},
    page: {
        handlers: {},
        startUp: null
    },
    services: {},
    ui: {
        notifications: {},
        startUp: null
    }
};


tmx.layout.startUp = function () {

    //this does a null check on tmx.page.startUp
    if (tmx.page.startUp) {
        console.log("tmx.page.startup");
        tmx.page.startUp();
    }
};
$(document).ready(tmx.layout.startUp);
