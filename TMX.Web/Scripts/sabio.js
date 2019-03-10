var TMX = {
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


TMX.layout.startUp = function () {

    //this does a null check on TMX.page.startUp
    if (TMX.page.startUp) {
        console.log("TMX.page.startup");
        TMX.page.startUp();
    }
};
$(document).ready(TMX.layout.startUp);
