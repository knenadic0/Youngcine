$(document).ready(function () {
    var url = window.location.href;
    url = url.substr(url.indexOf("/") + 1);
    url = url.substr(url.indexOf("/") + 1);
    url = url.substr(url.indexOf("/") + 1);
    url = url.substr(url.indexOf("/") + 1);
    if (url.indexOf("/") != -1) {
        url = url.substring(0, url.indexOf("/"));
    }

    var el = "." + url.toLowerCase() + "-nav";
    $(el).addClass("active");
})