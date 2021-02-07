$(document).ready(function () {
    $('.scrollbar-inner').scrollbar();

    $(".socialLink").click(function () {
        var targetUrl = $(this).data("target");
        var socialLink = $(this).data("sociallink");

        recordPage("Social/" + socialLink);

        if (socialLink === "Email") {
            window.location.href = targetUrl;
        }
        else {
            var win = window.open(targetUrl, '_blank');
            win.focus();
        }
    });
});