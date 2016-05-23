<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtendPage.aspx.cs" Inherits="RuRo.Web.ExtendPage" %>

<!doctype html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <script src="../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link href="include/css/default.css" rel="stylesheet" />
    <script src="../include/js/default.js"></script>
    <script src="include/js/sy_func.js"></script>
    <script src="include/js/page.js"></script>
    <script src="include/js/BindFuncToId.js"></script>
    <!--知情同意书 -->
    <script src="include/js/ajaxfileupload.js"></script>
    <script src="include/js/consentFormPage.js"></script>
    <script src="include/js/setDateJs.js"></script>
    <title>样品录入</title>
</head>
<body style="overflow: auto;">
    <%-- <div id="main" style="width: 900px; padding: 1px;">--%>
    <div id="main">
        <div class="easyui-panel" style="width: 900px; padding: 1px;">
            <div>
                <%--<a href="javascript:void(0)" id="loginOut" class="easyui-linkbutton" data-options="plain:true" style="position: absolute; right: 15px; top: 10px" onclick="loginOut()">注销</a><%--注销操作，清除cookie，关闭--%>
                <%-- <asp:Label id="lakeshi" runat="server" Text=""></asp:Label>--%>
                <ul>
                    <li><b>查找患者</b></li>
                </ul>
            </div>
            <form id="querybycodeform">
                <div runat="server">
                    查找方式：
                <input id="In_CodeType" class="easyui-combobox" name="querybycode" style="width: 100px;" data-options="prompt:'请选择条码类型',required:true" />
                    <input id="In_Code" class="easyui-textbox" style="width: 100px;" data-options="prompt:'请输入条码',required:true" />
                    <a href="javascript:void(0)" id="btnGet" class="easyui-linkbutton" onclick="querybycode()">查询患者信息</a>
                </div>
            </form>
        </div>
        <div class="h"></div>
        <div id="patient">
            <div id="hand" style="width: 900px; float: left; padding: 1px;">
                <div class="easyui-panel" style="width: 900px; float: left;">
                    <div style="padding: 1px">
                        <b>基本资料：</b>
                        <form id="BaseInfoForm">
                            <div id="BaseInfoDiv" runat="server" style="padding: 0px;">
                                <table>
                                    <tr>
                                        <td>姓名：</td>
                                        <td style="float: left">
                                            <input class="easyui-textbox" name="PatientName" id="_80" data-options="required:true" style="width: 110px;" /></td>
                                        <td class="name">住院号：</td>
                                        <td>
                                            <input class="easyui-textbox" name="IPSeqNoText" id="_81" data-options="required:false" style="width: 110px;" /></td>
                                        <td>就诊卡号：</td>
                                        <td>
                                            <input class="easyui-textbox" name="PatientCardNo" id="_82" data-options="required:false" style="width: 110px;" /></td>
                                    </tr>
                                    <tr>
                                        <td>性别：</td>
                                        <td>
                                            <input class="easyui-combobox" name="SexFlag" id="_115" data-options=" required:false" style="width: 110px;" /></td>
                                        <td>出生日期：</td>
                                        <td>
                                            <input class="easyui-datebox" name="BirthDay" id="_84" data-options="required:false" style="width: 110px;" /></td>
                                        <td>血型：</td>
                                        <td>
                                            <input class="easyui-combobox" name="BloodTypeFlag" id="_116" data-options="required:false" style="width: 110px;" /></td>
                                    </tr>
                                    <tr>
                                        <td>联系人：</td>
                                        <td>
                                            <input class="easyui-textbox" name="ContactPerson" id="_88" data-options="required:false" style="width: 110px;" /></td>
                                        <td>联系人电话：</td>
                                        <td>
                                            <input class="easyui-textbox" name="ContactPhone" id="_87" data-options="required:false" style="width: 110px;" /></td>
                                        <td>联系电话：</td>
                                        <td>
                                            <input class="easyui-textbox" name="Phone" id="_86" data-options="required:false" style="width: 110px;" /></td>
                                    </tr>
                                    <tr>
                                        <td>籍贯：</td>
                                        <td>
                                            <input class="easyui-textbox" name="NativePlace" id="_89" data-options="required:false" style="width: 110px;" /></td>
                                        <td>门诊流水号：</td>
                                        <td>
                                            <input class="easyui-textbox" name="RegisterSeqNO" id="_90" data-options="required:false" style="width: 110px;" /></td>
                                        <%--<td>知情同意书编码：</td>
                                        <td><input class="easyui-combobox" name="ConsentBook" id="ConsentBook" data-options="required:false" /></td>--%>
                                        <td>患者ID：</td>
                                        <td>
                                            <input class="easyui-textbox" name="PatientID" id="_91" data-options="required:true" style="width: 110px;" /></td>
                                    </tr>
                                    <tr>
                                        <td style="display: none">住院ID：</td>
                                        <td style="display: none">
                                            <input class="easyui-textbox" name="InPatientID" id="_93" data-options="required:false" style="width: 110px;" /></td>
                                        <td style="display: none">挂号ID：</td>
                                        <td style="display: none">
                                            <input class="easyui-textbox" name="RegisterID" id="_92" data-options="required:false" style="width: 110px;" /></td>
                                    </tr>
                                </table>
                            </div>
                        </form>
                    </div>
                </div>
             <!--charu-->
            </div>
            <div class="h"></div>
            <div style="width: 900px; float: left;">
                <form id="ClinicalInfoForm">
                    <%--1、临床信息列表展现--%>
                    <%--2、临床信息详细信息展现--%>
                    <%--3、单独导入临床信息操作--%>
                    <div class="easyui-panel">
                        <div id="ClinicalInfoDg" style="height: 205px; width: 100%"></div>
                    </div>
                </form>
            </div>
            <div style="width: 900px; float: left; padding: 1px;">
                <div id="sample">
                    <div class="easyui-panel">
                        <div style="padding: 2px"><b>标本信息 </b></div>
                        <form id="SampleInfoForm">
                            <%--1、共有字段信息展现--字段标识--%>
                            <%--2、样本特有字段、管数、位置信息展现--%>
                            <div id="SampleInfoDiv" runat="server">
                                <table>
                                    <tr>
                                        <td>录入人：</td>
                                        <td>
                                            <input class="easyui-combobox" id="_99" name="_99" style="width: 110px;" /></td>
                                        <td>采集目的：</td>
                                        <td>
                                            <input class="easyui-combobox" id="_100" name="_100" style="width: 200px;" /></td>
                                    </tr>
                                    <tr>
                                        <td>取材时间：</td>
                                        <td>
                                            <input class="easyui-textbox" id="_104" name="_104" style="width: 110px;" /></td>
                                        <td>取材描述：</td>
                                        <td>
                                            <input class="easyui-textbox" id="_110" name="_110" style="width: 200px;" /></td>
                                    </tr>
                                    <tr>
                                        <td>取材医护：</td>
                                        <td>
                                            <input class="easyui-combobox" id="_109" name="_109" style="width: 110px;" /></td>
                                        <td>研究方案：</td>
                                        <td>
                                            <input class="easyui-textbox" id="_102" name="_102" style="width: 200px;" /></td>
                                    </tr>
                                    <tr>
                                        <td>过期日期：</td>
                                        <td>
                                            <input class="easyui-datebox" id="_107" name="_107" style="width: 110px;" /></td>
                                        <td>备注：</td>
                                        <td>
                                            <input class="easyui-textbox" id="_112" name="_112" style="width: 200px" /></td>
                                    </tr>
                                    <tr>
                                        <td>取材日期：</td>
                                        <td>
                                            <input class="easyui-datebox" id="_103" name="_103" style="width: 110px;" /></td>
                                        <td>取材时段：</td>
                                        <td>
                                            <input class="easyui-combobox" id="_113" name="_113" style="width: 200px;" data-options="multiple:true" /></td>
                                    </tr>
                                </table>
                            </div>
                        </form>
                    </div>
                    <div class="h"></div>
                    <form id="dg_SampleInfoForm">
                        <div class="easyui-panel">
                            <div id="dg_SampleInfo" class="easyui-datagrid" style="height: auto" data-options="rownumbers:true,singleSelect:false,"></div>
                        </div>
                    </form>
                </div>
            </div>
            <div class="h"></div>
            <div id="footer" style="width: 900px; padding: 5px; margin: 10px" data-options="region:'south',">
                <a href="javascript:void(0)" class="easyui-linkbutton" id="submit" style="width: auto" onclick="postPatientInfo()">导入信息</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" id="cancleSubmit" style="width: auto" onclick="CloseWebPage()">取消导入</a>
                <%-- <a href="javascript:void(0)" class="easyui-linkbutton" id="cancleSubmit" style="width: auto" onclick="Cleardg_SampleInfo()">清空样品信息</a>--%>
            </div>
        </div>
    </div>
    <!--临床信息录入框 -->
    <div id="w" class="easyui-window" title="添加临床数据" data-options="modal:false,closed:true,minimizable:false,maximizable:false,iconCls:'icon-add'" style="width: 436px; height: 299px; padding: 10px;">
        <div style="padding: 10px">
            <form id="setClinicalInfoDg" method="post">
                <table>
                    <tr>
                        <td style="width: 100px;">诊断类型:</td>
                        <td>
                            <input class="easyui-combobox" name="diagnoseTypeFlag" id="diagnoseTypeFlag" data-options="required:true,multiple:false,prompt:'请选择添加数据的诊断类型'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">诊断日期:</td>
                        <td>
                            <input class="easyui-datebox" type="text" name="diagnoseDateTime" id="diagnoseDateTime" data-options="required:true,prompt:'请选择诊断日期'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">ICD码:</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="icdcode" id="icdcode" data-options="required:false" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">疾病名称:</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="diseaseName" id="diseaseName" data-options="required:false" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">疾病描述:</td>
                        <td>
                            <input class="easyui-textbox" name="description" id="description" data-options="required:false" style="height: 60px" /></td>
                    </tr>
                </table>
            </form>
            <div style="text-align: center; padding: 5px;">
                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="submitFormClinicalInfoDg()" style="margin: 8px">添加</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="clearsetClinicalInfoDg()" style="margin: 8px">清除</a>
            </div>
        </div>
    </div>
    <%--样本信息录入框--%>
    <div id="addSampleForm" class="easyui-window" title="添加样品信息" data-options="modal:true,closed:true,minimizable:false,maximizable:false,iconCls:'icon-add'" style="width: 410px; height: 299px; padding: 5px;">
        <div style="padding: 10px">
            <form id="sampleInfoFormToDg" method="post">
                <table>
                    <tr>
                        <td style="width: 100px;">样品类型:</td>
                        <td>
                            <input class="easyui-combobox" name="sampleTypeE" id="sampleTypeE" data-options="required:true,multiple:false,prompt:'请选择样品类型'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">体积:</td>
                        <td>

                            <input class="easyui-combobox" name="volumeE" id="volumeE" data-options="value:500,required:false,editable:true,prompt:'输入样品体积时请注意单位'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">管数:</td>
                        <td>
                            <input class="easyui-combobox" name="ScountE" id="ScountE" data-options="min:1,value:1,required:true,prompt:'请输入分管数'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">样品来源:</td>
                        <td>
                            <input class="easyui-combobox" name="sampleType_S" id="sampleType_S" data-options="required:true,editable:false,prompt:'请选择样品来源'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">用途:</td>
                        <td>
                            <input class="easyui-combobox" name="sampleType_U" id="sampleType_U" data-options="required:true,editable:false,prompt:'请选择用途'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">样品课题组:</td>
                        <td>
                            <input class="easyui-combobox" name="SampleGroupE" id="SampleGroupE" data-options="required:false,editable:false,multiple:false,prompt:'请选择样品组'" /></td>
                    </tr>
                    <%--                        <tr>
	    			        <td style="width:100px;">脏器:</td>
	    			        <td><input class="easyui-combobox" type="text" name="organE" id="organE" data-options="required:false"/></td>
                        </tr>
                        <tr>
	    			        <td style="width:100px;">脏器细分:</td>
                            <td><input class="easyui-combobox" type="text" name="organsubdivisionE" id="organsubdivisionE" data-options="required:false"/></td>
                        </tr>--%>
                </table>
            </form>
            <div style="text-align: center; padding: 5px;">
                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="AddSampleInfoToDg()" style="margin: 8px">添加</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="clearSampleInfoAddForm()" style="margin: 8px">清除</a>
            </div>
        </div>
    </div>
    <!--知情同意书管理-->
    <div class="easyui-panel" title="知情同意书管理" style="width: 900px; padding: 1px;">
        <form enctype="multipart/form-data" method="post" runat="server">
            <table>
                <tr>
                    <td>姓名：</td>
                    <td style="float: left"><input class="easyui-textbox" name="txtname" id="txtname" data-options="required:true" style="width: 110px;" /></td>
                    <td>样品源名称：</td>
                    <td style="float: left"><input class="easyui-numberbox" name="txtPatientID" id="txtPatientID" data-options="required:true" style="width: 110px;" /></td>
                </tr>
                <tr>
                    <td>上传文件：</td>
                    <td style="float: left"><input type="file" id="IdFile" name="IdFile" style="width: 150px"></td>
                    <td>上传日期：</td>
                    <td style="float: left"><input class="easyui-datebox" name="fromdate" id="fromdate" data-options="required:true,editable:false" style="width: 150px" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><a href="javascript:void(0)" id="btnGet" class="easyui-linkbutton" style="width: 50px; height:30px" onclick="ajaxFileUpload()">上传</a>
                        &nbsp;注：请在导入信息后上传知情同意书
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
