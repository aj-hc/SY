<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RuRo.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <link href="include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <link href="include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="include/js/jquery.cookie.js"></script>
    <%--<script src="include/js/page.js"></script>--%>
    <%--<script src="include/js/sy_func.js"></script>--%>
    <title>FreezerPro</title>
    <script type="text/javascript">
        //初始化win弹窗在显示器中央
        function doimport() {
            var width = 970;
            var height = 650;
            var l = Math.round((window.screen.width - width) / 2);
            var t = Math.round((window.screen.height - height) / 2);
            window.open('Login.aspx', 'newwindow', 'height=' + height + ', width=' + width + ', top=' + t + ',left=' + l + ',toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')
        }
        //$(function () {
        //    $(".side").css({ 'width': '24px', 'padding-right': '5px' });
        //    $(".side ul li").hover(function () {
        //        $(this).find(".sidebox").stop().animate({ "width": "124px" }, 200).css({ "opacity": "1", "filter": "Alpha(opacity=100)", "background": "192237" })
        //    }, function () {
        //        $(this).find(".sidebox").stop().animate({ "width": "45px" }, 200).css({ "opacity": "0.9", "filter": "Alpha(opacity=80)", "background": "192237" })
        //    });
        //});
        //检测浏览器
        function getBrowserInfo() {
            var agent = navigator.userAgent.toLowerCase();
            var regStr_ie = /msie [\d.]+;/gi;
            var regStr_ff = /firefox\/[\d.]+/gi
            var regStr_chrome = /chrome\/[\d.]+/gi;
            var regStr_saf = /safari\/[\d.]+/gi;
            //IE
            if (agent.indexOf("msie") > 0) {
                return "IE";
            }

            //firefox
            if (agent.indexOf("firefox") > 0) {
                return "";
                //return agent.match(regStr_ff);
            }

            //Chrome
            if (agent.indexOf("chrome") > 0) {
                return "";
            }

            //Safari
            if (agent.indexOf("safari") > 0 && agent.indexOf("chrome") < 0) {
                return "IE";
            }

        }
        var browser = getBrowserInfo();
        if (browser == undefined || browser=="") {}
        else
        {
            if (browser == "IE") {
                $.messager.confirm('提示！', '浏览器版本过低，是否下载谷歌浏览器，是：下载，否：退出', function (r) {
                    if (r) {
                        window.open("page.html", "newwindow", "height=100,width=400,toolbar=no,menubar=no,scrollbars=no,resizable=no, location=no,status=no");
                    }
                    else { window.close();}
                });

            }
        }

    </script>
</head>
<body style="width: 100%; height: 100%">
    <%--嵌套页--%>
    <div id="main" style="width: 100%; height: 100%">
<%--        <div id="logo" style="width: 100%; height: 40px; position: absolute; top: 2px; left: 50px;">
            <img src="../Images/LoGo.jpg" style="width:80%; height: 38px; z-index: 100"></img></div>--%>
        <iframe runat="server" id="FreezerPro" name="FreezerPro" frameborder="0" style="width: 100%; height: 100%;"></iframe>

        <form action="/" method="post" runat="server" id="from">
            <%--菜单栏--%>
            <div class="side">
                <ul>
                    <li><a href="#" id="btnextend" onclick="doimport()">
                        <div class="sidebox">
                            <img src="../Images/Images/ant.png" style="width: 21px; height: 15px" />&nbsp;打开扩展</div>
                    </a></li>
                </ul>
            </div>
            <%--<div id="MenuBar" runat="server"><a href="#" id="btnextend" onclick="doimport()" >扩展</a></div>--%>
        </form>
    </div>
    <script type="text/javascript">
        //window.onbeforeunload = function () {
        //    if (document.all) {
        //        if (event.clientY < 0) {
        //            $.cookie('password', null);
        //        }
        //    } else {
        //        $.cookie('password', null);
        //    }
        //}
    </script>
</body>
</html>
