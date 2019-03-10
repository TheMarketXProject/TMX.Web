var TMX = {
    layout: {}
    , page: {
        handlers: {}
        , startUp: null
    }
    , services: { Events: {} }
};

TMX.layout.startUp = function () {


    if (TMX.page.startUp) {
        console.debug("TMX.layout.startUp fired and found TMX.page.startUp");
        TMX.page.startUp();
    }
};

$(document).ready(TMX.layout.startUp);
