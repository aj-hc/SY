<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtendPage.aspx.cs" Inherits="RuRo.Web.ExtendPage" %>

<!doctype html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="include/css/default.css" rel="stylesheet" />
    <script src="../include/js/default.js"></script>
    <script src="include/js/sy_func.js"></script>
    <script src="include/js/page.js"></script>
    <script src="include/js/BindFuncToId.js"></script>
    <title>样品录入</title>
</head>
<body style="overflow: auto;">
    <div id="main" style="width: 900px; padding: 1px;">
        <div class="easyui-panel">
            <div>
            <a href="#" id="loginOut" class="easyui-linkbutton" data-options="plain:true" style="position:absolute;right:15px;top:10px">注销</a><%--注销操作，清除cookie，关闭--%>
                <ul>
                    <li><b>查找患者</b></li>
                </ul>
            </div>
            <form id="querybycodeform">
                <div runat="server">
                    查找方式：
                <input id="In_CodeType" class="easyui-combobox" name="querybycode" style="width: 200px;" data-options="prompt:'请选择条码类型',required:true" />
                    <input id="In_Code" class="easyui-textbox" data-options="prompt:'请输入条码',required:true" />
                    <a href="#" id="btnGet" class="easyui-linkbutton">查询患者信息</a>
                </div>
            </form>
        </div>
        <div class="h"></div>
        <div id="patient">
            <div class="easyui-panel">
                <div style="padding: 2px">
                    <b>基本资料：</b>
                    <form id="BaseInfoForm">
                        <div id="BaseInfoDiv" runat="server" style="padding: 5px;">
                            <table>
                                <tr>
                                    <td>姓名：</td>
                                    <td>
                                        <input class="easyui-textbox" name="PatientName" id="_80" data-options="required:true" /></td>
                                    <td class="name">住院号：</td>
                                    <td>
                                        <input class="easyui-textbox" name="IPSeqNoText" id="_81" data-options="required:false" /></td>
                                    <td>就诊卡号：</td>
                                    <td>
                                        <input class="easyui-textbox" name="PatientCardNo" id="_82" data-options="required:false" /></td>
                                </tr>
                                <tr>
                                    <td>性别：</td>
                                    <td>
                                        <input class="easyui-combobox" name="SexFlag" id="_115" style="width: 204px" data-options=" required:false" /></td>
                                    <td>出生日期：</td>
                                    <td>
                                        <input class="easyui-datebox" name="BirthDay" id="_84" data-options="required:false" /></td>
                                    <td>血型：</td>
                                    <td>
                                        <input class="easyui-combobox" name="BloodTypeFlag" id="_116" data-options="required:false" /></td>
                                </tr>
                                <tr>
                                    <td>联系人：</td>
                                    <td>
                                        <input class="easyui-textbox" name="ContactPerson" id="_88" data-options="required:false" /></td>
                                    <td>联系人电话：</td>
                                    <td>
                                        <input class="easyui-textbox" name="ContactPhone" id="_87" data-options="required:false" /></td>
                                    <td>联系电话：</td>
                                    <td>
                                        <input class="easyui-textbox" name="Phone" id="_86" data-options="required:false" /></td>
                                </tr>
                                <tr>
                                    <td>籍贯：</td>
                                    <td>
                                        <input class="easyui-textbox" name="NativePlace" id="_89" data-options="required:false" /></td>
                                    <td>门诊流水号：</td>
                                    <td>
                                        <input class="easyui-textbox" name="RegisterSeqNO" id="_90" data-options="required:false" /></td>
                                    <td>患者ID：</td>
                                    <td>
                                        <input class="easyui-textbox" name="PatientID" id="_91" display="none" data-options="required:true" /></td>
                                </tr>
                                <tr>
                                    <td>住院ID：</td>
                                    <td>
                                        <input class="easyui-textbox" name="InPatientID" id="_93" data-options="required:false" /></td>
                                    <td>挂号ID：</td>
                                    <td>
                                        <input class="easyui-textbox" name="RegisterID" id="_92" data-options="required:false" /></td>
                                </tr>
                            </table>
                        </div>
                    </form>
                </div>
                <div class="h"></div>
                <form id="ClinicalInfoForm">
                    <%--1、临床信息列表展现--%>
                    <%--2、临床信息详细信息展现--%>
                    <%--3、单独导入临床信息操作--%>
                    <div class="easyui-panel">
                        <div id="ClinicalInfoDg" style="height: 260px; width: 100%"></div>
                    </div>
                </form>
            </div>
            <div class="h"></div>
            <div id="sample">
                <div class="easyui-panel">
                    <div style="padding: 2px"><b>标本信息 </b></div>
                    <form id="SampleInfoForm">
                        <%--1、共有字段信息展现--字段标识--%>
                        <%--2、样本特有字段、管数、位置信息展现--%>
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
                    </form>
                </div>
                <div class="h"></div>
                <form id="dg_SampleInfoForm">
                    <div class="easyui-panel">
                        <div id="dg_SampleInfo" class="easyui-datagrid" style="height: auto" data-options="rownumbers:true,singleSelect:false,pagination: true"></div>
                    </div>
                </form>
            </div>
            <div id="footer" style="padding: 5px; margin: 10px" data-options="region:'south',">
                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="postPatientInfo()" id="submit" style="width: auto">导入信息</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="CloseWebPage()" style="width: auto">取消导入</a>
            </div>
        </div>

        <!--登陆框-->
        <div id="Login" class="easyui-dialog" style="width: 300px; padding: 30px 50px 20px 50px" title="请登录助手" data-options="closed:true">
            <form id="frmLogin" runat="server" enableviewstate="false">
                <div style="margin-bottom: 10px">
                    <input class="easyui-textbox" id="username" name="username" style="width: 100%; height: 40px; padding: 12px" data-options="prompt:'username',iconCls:'icon-man',iconWidth:38" />
                </div>
                <div style="margin-bottom: 20px">
                    <input class="easyui-textbox" id="password" name="password" style="width: 100%; height: 40px; padding: 12px" type="password" data-options="prompt:'password',iconCls:'icon-lock',iconWidth:38" />
                </div>
                <div style="text-align: center; padding: 5px">
                    <a href="javascript:void(0)" style="margin: 0px 10px 0px 10px" class="easyui-linkbutton" onclick="login()">登陆</a>
                    <a href="javascript:void(0)" style="margin: 0px 10px 0px 10px" class=" easyui-linkbutton" onclick="$('#Login').dialog('close')">取消</a>
                </div>
            </form>
        </div>
</body>
</html>
