$(document).ready(() => {
    $("#finishButton").hover(function() {
        $(this).css("background-color", "rgba(115, 112, 112, 0.2)");
        $(this).css('cursor', 'pointer');
    },
    function(){
        $(this).css({"background-color": "rgba(64, 64, 64, 0.2)"});
        $(this).css('cursor', 'default');
      });

      $("#finishButton").click(() => {
            console.log("clicked");
      });
});