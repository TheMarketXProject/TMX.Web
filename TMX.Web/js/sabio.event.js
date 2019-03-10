TMX.page.handlers.onSubmitFormClicked = function (evt) {
    evt.preventDefault();
    //validate data

    //submit confirmation message
    //send home 
    

    var targetFormId = $(this).attr("data-formId");
    var targetForm = $(targetFormId);
    var targetCommentElement = null;

    if (TMX.page.lastReplyLink) {

        targetCommentElement = $(TMX.page.lastReplyLink).closest(".comment-content");
    };

    var formGrab = TMX.page.grabDataInput(targetForm);

    TMX.page.showComments();
    TMX.page.addComment(formGrab, targetCommentElement);

    targetForm[0].reset();
    TMX.page.lastReplyLink = null;
    $("#myModal").modal("hide");
};


TMX.objects = [];

TMX.page.wireUpReplies = function (context, data) {

    var repliesFound = $(".reply", context);
    //  console.log("Found these many replies to wire up:" + repliesFound.length);
    // console.dir(repliesFound);
    console.log(repliesFound);


    TMX.objects.push(repliesFound);

    repliesFound.on("click", TMX.page.handlers.onReplyClicked);


}



TMX.page.subtmitComments = function () {
    $(".eventForm").slideDown();
}


TMX.page.goTo = function (jQueryObject) {

    var topOfComments = jQueryObject.offset().top;

    var animateOptions = {
        scrollTop: topOfComments
    };

    $('html, body').animate(animateOptions, 2000);
}
