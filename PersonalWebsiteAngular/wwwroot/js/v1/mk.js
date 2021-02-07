$(document).ready(function () {
    var experience = $(".bio-experience").text();
    experience = experience.replace("10 years", ((new Date()).getFullYear() - 2006) + " years");
    $(".bio-experience").text(experience);

    var copyright = "Michael Kennedy " + (new Date()).getFullYear();
    $(".bio-copyright").text(copyright);
    $(".bio-copyright-small").attr("title", copyright);
    resize();

    $('.scrollbar-inner').scrollbar();

    $(".expandable").click(function () {
        expandSection($(this));
    });

    $(".socialLink").click(function () {
        var targetUrl = $(this).data("target");
        var socialLink = $(this).data("sociallink");

        if (typeof (ga) != "undefined") {
            ga('send', 'pageview', "Social/" + socialLink);
        }

        if (socialLink == "Email") {
            window.location.href = targetUrl;
        }
        else {
            var win = window.open(targetUrl, '_blank');
            win.focus();        
        }
    });

    $(".blog-section").click(function () {
        var targetUrl = $(this).data("target");
        window.location.href = targetUrl;
    });    

    $(".content-main-scroll").scroll(function () {
        adjustContentHeaders();
    });

    $(".expandableSection .scrollbar-inner").scroll(function () {
        adjustSubHeaders();
    });

    $("#contentExtended").mouseenter(function () {
        hideScrollbar(true);
    });

    $("#contentExtended").mouseleave(function () {
        hideScrollbar(false);
    });
});

$(window).resize(function () {
    resize();
    adjustContentHeaders();
    adjustSubHeaders();
    adjustExpandedSectionHeight();
});

function adjustContentHeaders() {
    $(".pinnableContent").each(function () {
        if ($(this).offset().top <= 49) {
            $(this).prev().css("position", "fixed");
            $(this).prev().css("top", "47px");
        }
        else {
            $(this).prev().css("position", "absolute");
            $(this).prev().css("top", "");
        }
    });
}

function adjustSubHeaders() {
    $(".expandableSection").each(function () {
        var $section = $(this);
        var $header = $section.find(".expandableSection-header-name");
        var $bottomItem = null;

        $section.find(".expandableSection-header").each(function () {
            if ($(this).offset().top <= 20) {
                $bottomItem = $(this);
            }
        });

        var reset = false;

        if ($bottomItem != null) {
            var text = $bottomItem.find(".expandableSection-name").text();

            if ($header.attr("default") == null) {
                $header.attr("default", $header.text());
            }

            if (text != null && text != "") {
                $header.text(text);
            }
            else {
                reset = true;
            }
        }
        else {
            reset = true;
        }

        if (reset) {
            $header.text($header.attr("default"));
        }

    });
}

function hideSection() {
    $("#contentExtended").attr("selectedItem", "");    

    var animateDistance = "-35%";
    var isMobile = false;
    if ($(window).width() <= 600) {
        animateDistance = "-100%";
        isMobile = true;
    }

    if (isMobile) {
        setTimeout(function () {
            $("#contentExtended").width("35%");
        }, 500);
    }

    $("#contentMain").animate({ left: "0" }, 500);
    $("#contentExtended").animate({ right: animateDistance }, 500);
}

function expandSection(e) {
    var expandedState = $("#contentExtended").attr("state");
    var selectedItem = $("#contentExtended").attr("selectedItem");
    var targetSection = "mkContent";       
    var currentItem = e.data("target");

    e.find(".expandableContentItem .expandableSection-header").clone().appendTo($("#contentExtended .expandableSection.mkContent .expandableSection-header"));
    e.find(".expandableContentItem .expandableSection-footer").clone().appendTo($("#contentExtended .expandableSection.mkContent .expandableSection-footer"));
    
    $(".expandableSection").removeClass("expanded");

    var animateDistance = "-35%";
    var isMobile = false;
    if ($(window).width() <= 600) {
        animateDistance = "-100%";
        isMobile = true;        
    }    

    if (isMobile) {
        $("#contentExtended").width($(window).width() - 10);
    }

    if (selectedItem == null || selectedItem == "" || selectedItem !== currentItem) {
        $(".expandableSection.mkContent").load("/v1" + e.data("target"))
        $(".scrollbar-inner").scrollTop(0);

        $(".expandableSection").hide();
        $(".expandableSection." + targetSection).addClass("expanded");
        $(".expandableSection." + targetSection).show();
        $("#contentExtended").attr("selectedItem", currentItem);

        $("#contentMain").animate({ left: animateDistance }, 500);
        $("#contentExtended").animate({ right: "0%" }, 500);

        adjustSubHeaders();
    }
    else {        
        $("#contentExtended").attr("selectedItem", "");
        $("#contentMain").animate({ left: "0" }, 500);
        $("#contentExtended").animate({ right: animateDistance }, 500);
        hideScrollbar(false);
    }

    adjustExpandedSectionHeight();
}

function adjustExpandedSectionHeight() {
    var headerHeight = $(".expandableSection.expanded .expandableSection-header").height();
    var footerHeight = $(".expandableSection.expanded .expandableSection-footer").height();
    $(".expandableSection.expanded .expandableSection-details").height($(".expandableSection.expanded").height() - headerHeight - footerHeight - 36 - 2);
}

function resize() {
    if (window.innerHeight <= 620) {
        $("#bio-contact-std").hide();
        $("#bio-contact-small").show();
    }
    else {
        $("#bio-contact-std").show();
        $("#bio-contact-small").hide();
    }
}

function hideScrollbar(state) {
    if (state) {
        $(".content-main-scroll").parent().find(".scroll-y").css("visibility", "hidden");
    }
    else {
        $(".content-main-scroll").parent().find(".scroll-y").css("visibility", "visible");
    }
}