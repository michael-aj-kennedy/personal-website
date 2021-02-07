window.dataLayer = window.dataLayer || [];

function gtag() { dataLayer.push(arguments); }

function setupAnalytics() {
    if (window.location.href.toLowerCase().indexOf("mikekennedy") >= 0) {
        gtag('js', new Date());
        gtag('config', 'UA-56743116-2');
        (function (i, s, o, g, r, a, m) { i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () { (i[r].q = i[r].q || []).push(arguments) }, i[r].l = 1 * new Date(); a = s.createElement(o), m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m) })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');
        ga('create', 'UA-56743116-2', 'auto');
        ga('send', 'pageview', location.pathname);
    }
}

function recordPage(location) {
    debugger;
    if (window.location.href.toLowerCase().indexOf("mikekennedy") >= 0) {
        ga('send', 'pageview', location);
    }    
}


