<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FieldSetting.aspx.cs" Inherits="RuRo.Web.Pages.FieldSetting" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../include/js/jquery.cookie.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="../include/css/default.css" rel="stylesheet" />
    <script src="../include/js/default.js"></script>
    <script src="../include/js/SettingPages.js"></script>
</head>
<body>
    <div>
        <div class="easyui-panel" style="width: 900px; padding: 1px;">
            <div>
                <ul>
                    <li><b>字段设定</b></li>
                </ul>
            </div>
            <div runat="server">
                字段名称：<input class="easyui-combobox" id="ComSetting" name="ComSetting" style="width: 110px;" />
                <a href="javascript:void(0)" id="btnGet" class="easyui-linkbutton" onclick="QuerySetting()">查询</a>
            </div>
        </div>
        <form id="connent">
            <div class ="easyui-panel">
                <div id="dg_GetSetting" class="easyui-datagrid" style="height: auto" data-options="rownumbers:true,singleSelect:false,"></div>
            </div>
        </form>
        <div id="w" class="easyui-window" title="字段值设定" data-options="modal:false,closed:true,minimizable:false,maximizable:false,iconCls:'icon-add'" style="width: 436px; height: 299px; padding: 10px;">
            <div style="padding: 10px">
                <form id="setdg_GetSetting" method="post">
                    <table>
                        <tr hidden="true">
                            <td style="width: 100px;">所属字段:</td>
                            <td><input class="easyui-textbox" type="text" name="SettingValue" id="SettingValue" data-options="required:false" /></td>
                        </tr>
                        <tr>
                            <td style="width: 100px;">添加默认值:</td>
                            <td><input class="easyui-textbox" type="text" name="DefaultValue" id="DefaultValue" data-options="required:false" /></td>
                        </tr>
                         <tr>
                            <td style="width: 100px;">添加日期:</td>
                            <td><input class="easyui-datebox" type="text" name="DefaultTime" id="DefaultTime" data-options="required:false" /></td>
                        </tr>
                    </table>
                </form>
                <div style="text-align: center; padding: 5px;">
                    <a href="javascript:void(0)" class="easyui-linkbutton" onclick="AddSetting()" style="margin: 8px">添加</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" onclick="cleardg_GetSetting()" style="margin: 8px">清除</a>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
