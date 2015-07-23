<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RuRo.Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>RuRo样本信息管理系统插件</title>
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="include/css/index.css" rel="stylesheet" />
    <script src="include/jquery-easyui-1.4.3/outlook2.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden"  scroll="no">
    <noscript>
        <div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
            <img src="Images/IndexImg/noscript.gif" alt='抱歉，请开启脚本支持！'/>
        </div>
    </noscript>
    <div region="north" split="true" border="false" style="overflow: hidden; height: 30px;background: url(Images/IndexImg/layout-browser-hd-bg.gif) #7f99be repeat-x center 50%;line-height: 20px;color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float:right; padding-right:20px;" class="head">
            <asp:Label ID="laName" Text="" runat="server"></asp:Label>&nbsp;
            <a href="#" id="loginOut">安全退出</a>
        </span>
        <span style="padding-left:10px; font-size: 16px; ">
            <img src="Images/IndexImg/blocks.gif" width="20" height="20" align="absmiddle" />广东省人民医院生物样品管理库
        </span>
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2; ">
        <div class="footer">安杰生物科技公司</div>
    </div>
    <div region="west" split="true" title="导航菜单" style="width:180px;" id="west">
        <div class="easyui-accordion" fit="false" border="false"><!--  导航内容 -->
            <div title="插件管理" data-options="iconCls:'icon-sys'" style="overflow:auto;padding:0px;">
                <ul>
                    <li><div><a target="mainFrame" href="ExtendPage.aspx"><span></span>导入样品</a></div></li> 
                    <li><div><a target="mainFrame" href="demo.html"><span></span>知情同意书</a></div></li> 
                </ul>
            </div>
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow-y:hidden">
        <div id="tabs" class="easyui-tabs"  fit="true" border="false" >
            <div title="欢迎使用" style="padding:20px;overflow:hidden;" id="home">
				<h1>欢迎进入</h1>
            </div>
        </div>
    </div>
</body>
</html>
