$(document).ready(() => {
    $(".test-item").hover(function() {
        $(this).css({"background-color": "rgba(86, 89, 227, 0.6)"});
        $('html,body').css('cursor','pointer');
    },
    function(){
        $(this).css("background-color", "white");
        $('html,body').css('cursor','default');
      });

    $("#testsButton").hover(() => {
        $(".tests-container").show();
    }, () => {
        $(".tests-container").hide();
    });
});