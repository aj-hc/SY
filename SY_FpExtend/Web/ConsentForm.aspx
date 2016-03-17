<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsentForm.aspx.cs" Inherits="RuRo.Web.ConsentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="include/js/setDateJs.js"></script>
    <script src="include/jquery-easyui-1.4.3/jquery.form.js"></script>
    <script src="include/js/ajaxfileupload.js"></script>
    <script src="include/js/consentFormPage.js"></script>
    <title>上传知情同意书</title>
</head>
<body>
    <div class="easyui-panel" title="知情同意书管理" style="width: 800px; padding: 30px 70px 50px 70px">
        <form enctype="multipart/form-data" method="post" runat="server">
            <table>
                <tr>
                    <td>姓名：</td>
                    <td><input class="easyui-textbox" name="txtname" id="txtname" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>样品源名称：</td>
                    <td>
                        <input class="easyui-numberbox" name="txtPatientID" id="txtPatientID" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>读取知情同意书：</td>
                     <td><input type="file" id="IdFile" name="IdFile" style="width:300px"></td>
                    
                </tr>
                <tr>
                    <td>上传日期：</td>
                    <td>
                        <input class="easyui-datebox" name="fromdate" id="fromdate" data-options="required:true,editable:false" /></td>
                </tr>
                <tr>
                    <td><a href="javascript:void(0)" id="btnGet" class="easyui-linkbutton" onclick="ajaxFileUpload()">上传图片</a></td>
                    <%--<td><asp:Button ID="ImgNoOK" runat="server" Text="上传图片" OnClick="ImgNoOK_Click" /></td>--%>
                </tr>
            </table>
        </form>
    </div>
  <script type="text/javascript">

  </script>
</body>
</html>
