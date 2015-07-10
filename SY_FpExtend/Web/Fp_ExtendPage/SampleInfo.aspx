<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleInfo.aspx.cs" Inherits="RuRo.Web.Fp_ExtendPage.SampleInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        table tr td {
            text-align: right;
            padding: 2px;
        }

        /*input {
            width: 150px;
        }*/

        .h {
            margin: 3px;
        }

        /*.easyui-panel {
            width: 800px;
            padding: 10px;  
        }*/

            .easyui-panel div {
                padding: 1px;
            }

        /*#SampleInfoDiv {
            width: 800px;
        }*/
    </style>
</head>
<body>
    <form id="SampleInfoFrom">
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
                            <input class="easyui-textbox" id="_100" name="_100" style="width: 380px;" /></td>
                    </tr>
                    <tr>
                        <td>取材日期：</td>
                        <td>
                            <input class="easyui-datebox" id="_103" name="_103" /></td>
                        <td>取材方式：</td>
                        <td>
                            <select class="easyui-combobox" id="_101" name="_101" data-options="panelHeight:'auto',multiple:true" style="width: 380px;">
                                <option value="手术前">手术前</option>
                                <option value="手术时">手术时</option>
                                <option value="手术一周后">手术一周后</option>
                                <option value="化疗前">化疗前</option>
                                <option value="化疗两周期结束后，第三周化疗期前">化疗两周期结束后，第三周化疗期前</option>
                                <option value="四周期化疗结束后">四周期化疗结束后</option>
                                <option value="第五周期化疗前">第五周期化疗前</option>
                                <option value="第六周期化疗技术后">第六周期化疗技术后</option>
                                <option value="靶向治疗前">靶向治疗前</option>
                                <option value="疾病出现进展时">疾病出现进展时</option>
                                <option value="更换治疗方案前">更换治疗方案前</option>
                                <option value="其他">其他</option>
                            </select></td>
                    </tr>
                    <tr>
                        <td>取材时间：</td>
                        <td>
                            <input class="easyui-textbox" id="_104" name="_104" /></td>
                        <td>取材描述：</td>
                        <td>
                            <input class="easyui-textbox" id="_110" name="_102" style="width: 380px;" /></td>
                    </tr>
                    <tr>
                        <td>取材医护：</td>
                        <td>
                            <input class="easyui-textbox" id="_109" name="_109" /></td>
                        <td>研究方案：</td>
                        <td>
                            <input class="easyui-textbox" id="_102" name="_102" style="width: 380px;" /></td>
                    </tr>
                    <tr>
                        <td>过期日期：</td>
                        <td>
                            <input class="easyui-datebox" id="_107" name="_107" /></td>
                        <td>备注：</td>
                        <td>
                            <input class="easyui-textbox" id="_112" name="_112" style="width: 380px" /></td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="dg_SampleInfo"></div>
    </form>
</body>
</html>
