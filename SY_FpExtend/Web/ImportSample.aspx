﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportSample.aspx.cs" Inherits="RuRo.Web.ImportSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div hidden="hidden" id="sample">
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
                                <input class="easyui-combobox" id="_99" name="_99" /></td>
                            <td>采集目的：</td>
                            <td>
                                <input class="easyui-textbox" id="_100" name="_100" style="width: 484px;" /></td>
                        </tr>
                        <tr>
                            <td>取材日期：</td>
                            <td>
                                <input class="easyui-datebox" id="_103" name="_103" /></td>
                            <td>取材时段：</td>
                            <td>
                                <input class="easyui-combobox" id="_113" name="_113" style="width: 484px;" /></td>
                        </tr>
                        <tr>
                            <td>取材时间：</td>
                            <td>
                                <input class="easyui-textbox" id="_104" name="_104" /></td>
                            <td>取材描述：</td>
                            <td>
                                <input class="easyui-textbox" id="_110" name="_110" style="width: 484px;" /></td>
                        </tr>
                        <tr>
                            <td>取材医护：</td>
                            <td>
                                <input class="easyui-combobox" id="_109" name="_109" /></td>
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
        </form>
        <div class="h"></div>
        <form id="dg_SampleInfoForm">
            <div class="easyui-panel">
                <div id="dg_SampleInfo" class="easyui-datagrid" style="height: auto" data-options="rownumbers:true,singleSelect:false,pagination: true"></div>
            </div>
        </form>
    </div>
</body>
</html>
