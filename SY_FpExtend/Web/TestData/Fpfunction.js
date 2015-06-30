function PostDataToFp(url, username, password, method, parms, Jsdata) {
    var urlStr = url + "username=" + username + "&password=" + password + "&password=" + method
    var dataStr = "";
    if (parms) {
        dataStr += parms;
    }
    if (Jsdata) {
        dataStr = dataStr + "&json=" + Jsdata;
    }
    $.post(urlStr, dataStr, function callback() {

    });
}

function GetDataFromFp(url, username, password, method, parms) {

    var urlStr = url + "username=" + username + "&password=" + password + "&password=" + method
    if (parms) {
        urlStr += parms;
    }
    $.get(urlStr, function callback() {

    });
}