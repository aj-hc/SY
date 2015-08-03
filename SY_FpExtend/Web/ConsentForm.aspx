<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsentForm.aspx.cs" Inherits="RuRo.Web.ConsentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="include/js/consentFormPage.js"></script>
    <title></title>
</head>
<body>
        <div class="easyui-panel" title="知情同意书管理" style="width:800px;padding:30px 70px 50px 70px">
            <form id="querybycodeform">
                <div runat="server">
                    查找方式：
                    <input id="In_CodeType" class="easyui-combobox" name="querybycode" style="width: 200px;" data-options="prompt:'请选择条码类型',required:true" />
                    <input id="In_Code" class="easyui-textbox" data-options="prompt:'请输入条码',required:true" />
                    <a href="javascript:void(0)" id="btnGet" class="easyui-linkbutton" onclick="querybycode()">查询患者信息</a>
                </div>
            </form>
            <table>
                <tr>
                    <td>读取知情同意书：</td>
                    <td><input class="easyui-filebox" 
                       name="file1" id="file1"
                       data-options="prompt:'选择知情同意书路径',buttonText:'浏览',buttonAlign: 'right',editable:false,required:true"
                       style="width:400px"></td>
                </tr>
                <tr>
                    <td>设置日期：</td>
                    <td><input class="easyui-datebox" name="fromdate" id="fromdate" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td><a href="javascript:void(0)" id="btnGet" class="easyui-linkbutton" onclick="">上传图片</a></td>
                </tr>
            </table>
                     
            </>
        </div>
</body>
</html>
