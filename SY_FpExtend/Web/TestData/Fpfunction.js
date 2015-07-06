function PostDataToFp(url, username, password, method, parms, Jsdata) {
    $.ajax({
        type: "POST",
        url: "http://192.168.183.130/api",
        data: {
            username:"admin",
            password :"123456",
            method: "import_sources",
            sample_source_type:'基本资料--心研所',
            json:{"Name":"3708555","Description":"叶万福"}
        },
        dataType: "json",
        success: function (response) {
            alert(response)
        }
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
