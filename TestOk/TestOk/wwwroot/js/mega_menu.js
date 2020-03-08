$(document).ready(() => {
    $(".test-item").hover(function() {
        $(this).css({"background-color": "rgba(86, 89, 227, 0.6)"});
    },
    function(){
        $(this).css("background-color", "white");
      });

    $("#testsButton").hover(() => {
        $(".tests-container").show();
    }, () => {
        $(".tests-container").hide();
    });
});