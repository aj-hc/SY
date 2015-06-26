﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtendPage.aspx.cs" Inherits="RuRo.Web.ExtendPage" %>

<!doctype html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.2/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.2/jquery.easyui.min.js"></script>
    <script src="../include/js/default.js"></script>
    <script src="include/js/sy_func.js"></script>
    <script src="include/js/page.js"></script>
    <link href="../include/jquery-easyui-1.4.2/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.2/themes/icon.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <title>样品录入</title>
</head>
<body style="overflow: auto;">
    <div id="main" style="width: 900px; padding: 1px;">
        <form id="querybycodeform">
            <div class="easyui-panel">
                <div><b>查找患者</b></div>
                <div runat="server">
                    查找方式：
                <input id="In_CodeType" class="easyui-combobox" name="querybycode" style="width: 200px;" />
                    <input id="In_Code" class="easyui-textbox" />
                    <a href="#" onclick="querybycode()" id="btnGet" class="easyui-linkbutton">查询患者信息</a>
                </div>
            </div>
        </form>
        <div class="h"></div>
        <form id="BaseInfoForm">
            <div class="easyui-panel">
                <div style="padding: 2px"><b>患者基本资料</b></div>
                <div id="BaseInfoDiv" runat="server" style="padding: 5px;">
                    <table>
                        <tr>

                            <td>姓名：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_80" id="_80" data-options="required:true" /></td>
                            <td class="name">住院号：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_81" id="_81" data-options="required:false" /></td>
                            <td>就诊卡号：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_82" id="_82" data-options="required:false" /></td>
                        </tr>
                        <tr>
                            <td>性别：</td>
                            <td>
                                <input class="easyui-combobox" name="_115" id="_115" style="width: 204px" data-options=" required:false " />
                            </td>
                            <td>出生日期：</td>
                            <td>
                                <input class="easyui-datebox" type="text" name="_84" id="_84" data-options="required:false" style="z-index: 9999;" /></td>
                            <td>血型：</td>
                            <td>
                                <input class="easyui-combobox" type="text" name="_116" id="_116" data-options="required:false" /></td>
                        </tr>
                        <tr>
                            <td>联系人：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_88" id="_88" data-options="required:false" /></td>
                            <td>联系人电话：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_87" id="_87" data-options="required:false" /></td>
                            <td>联系电话：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_86" id="_86" data-options="required:false" /></td>
                        </tr>
                        <tr>
                            <td>籍贯：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_89" id="_89" data-options="required:false" /></td>
                            <td>门诊流水号：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_90" id="_90" data-options="required:false" /></td>
                            <td>患者ID：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_91" id="_91" data-options="required:false" /></td>
                        </tr>
                        <tr>
                            <td>住院ID：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_93" id="_93" data-options="required:false" /></td>
                            <td>挂号ID：</td>
                            <td>
                                <input class="easyui-textbox" type="text" name="_92" id="_92" data-options="required:false" /></td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
        <div class="h"></div>
        <form id="ClinicalInfoForm">
            <%--1、临床信息列表展现--%>
            <%--2、临床信息详细信息展现--%>
            <%--3、单独导入临床信息操作--%>
            <div class="easyui-panel">
                <div id="ClinicalInfoDg" style="height: 360px; width: 100%"></div>
            </div>
        </form>
        <div class="h"></div>
        <form id="SampleInfoForm">
            <%--1、共有字段信息展现--字段标识--%>
            <%--2、样本特有字段、管数、位置信息展现--%>
            <div class="easyui-panel">

                <div style="padding: 2px"><b>标本信息 </b></div>
                <div id="SampleInfoDiv" runat="server">
                    <table>
                        <tr>
                            <td>采集人：</td>
                            <td>
                                <input class="easyui-textbox" id="_99" name="_99" /></td>
                            <td>采集目的：</td>
                            <td>
                                <input class="easyui-textbox" id="_100" name="_100" style="width: 484px;" /></td>
                        </tr>
                        <tr>
                            <td>取材日期：</td>
                            <td>
                                <input class="easyui-datebox" id="_103" name="_103" /></td>
                            <td>取材方式：</td>
                            <td>
                                <input class="easyui-combobox"  id="_101" name="_101" style="width: 484px;"/></td>
                        </tr>
                        <tr>
                            <td>取材时间：</td>
                            <td>
                                <input class="easyui-textbox" id="_104" name="_104" /></td>
                            <td>取材描述：</td>
                            <td>
                                <input class="easyui-textbox" id="_110" name="_102" style="width: 484px;" /></td>
                        </tr>
                        <tr>
                            <td>取材医护：</td>
                            <td>
                                <input class="easyui-textbox" id="_109" name="_109" /></td>
                            <td>研究方案：</td>
                            <td>
                                <input class="easyui-textbox" id="_102" name="_102" style="width: 484px;" /></td>
                        </tr>
                        <tr>
                            <td>过期日期：</td>
                            <td>
                                <input class="easyui-datebox" id="_107" name="_107" /></td>
                            <td>备注：</td>
                            <td>
                                <input class="easyui-textbox" id="_112" name="_112" style="width: 484px" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="h"></div>
            <div class="easyui-panel">
                <div id="dg_SampleInfo" class="easyui-datagrid" style="height: auto" data-options="rownumbers:true,singleSelect:false,pagination: true"></div>
            </div>
        </form>
        <div id="footer" style="padding: 5px; margin: 10px" data-options="region:'south',">
            <a href="javascript:void(0)" class="easyui-linkbutton" onclick="postData();" style="width: auto">添加样本</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" onclick="" style="width: auto">取消录入</a>
        </div>
    </div>
</body>
</html>
