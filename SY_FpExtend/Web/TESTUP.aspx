<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TESTUP.aspx.cs" Inherits="RuRo.Web.TESTUP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
    <link href="include/css/uploadify.css" rel="stylesheet" />
    <script src="include/js/jquery.uploadify.min.js"></script>
    <title>TEST</title>
</head>
<body>
    <form>
        <div id="queue"></div>
        <input id="file_upload" name="file_upload" type="file" multiple="true">
    </form>
</body>
</html>
