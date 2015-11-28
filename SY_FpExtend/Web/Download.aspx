<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="RuRo.Web.Download" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="include/js/consentFormPage.js"></script>
    <script src="include/js/setDateJs.js"></script>
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
   <%--     <div class="easyui-panel" title="下载知情同意书" style="width:800px;padding:30px 70px 50px 70px">
           <form  enctype="multipart/form-data" method="post" runat="server">
               <table>
                    <tr>
                        <td>样品源名称：</td>
                        <td ><input class="easyui-numberbox" name="PatientID" id="_91" data-options="required:true" /></td>
                    </tr>
                    <tr>
                        <td>存放路径</td>
                        <td><asp:FileUpload ID="idFile" Width="350px" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>上传日期：</td>
                        <td><input class="easyui-datebox" name="postdate" id="postdate" data-options="required:true,editable:false" /></td>
                    </tr>
                   <tr>
                       <td><a href="javascript:void(0)" id="btnGet" class="easyui-linkbutton" onclick="getImg()">上传图片</a></td>
                   </tr>
            </table>
            </form>

        </div>--%>
<%--        <a href="javascript:void(0)" id="btnGet" class="easyui-linkbutton" onclick="dowImga()">上传图片</a>--%>
    </form>
</body>
</html>
