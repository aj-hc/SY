<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleInfo.aspx.cs" Inherits="RuRo.Web.Fp_ExtendPage.SampleInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../include/jquery-easyui-1.4.2/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.2/jquery.easyui.min.js"></script>
    <link href="../include/jquery-easyui-1.4.2/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.2/themes/icon.css" rel="stylesheet" />
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
    <form id="form2">
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
        <div><br /></div>
        <div class="easyui-panel">
            <div id="tb" style="height: auto">
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="append()" style="width: auto">添加样本</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true" onclick="removeit()" style="width: auto">移除样本</a>
            </div>
            <table id="dg_SampleInfo" class="easyui-datagrid" title="取样信息" style="width: 99%; height: auto"
                data-options="rownumbers:true,singleSelect:false,url:'',method:'get',toolbar: '#tb',pagination: true">
                <thead>
                    <tr>
                        <th data-options="field:'ck',checkbox:true" style="width: 15px"></th>
                        <th data-options="field:'DiagnoseTypeFlag',
                            formatter:function(value,row){
							return row.productname;
						},
						editor:{
							type:'combobox',
							options:{
								valueField:'productid',
								textField:'productname',
								method:'get',
								url:'',
								required:true
							}
						}"
                            style="width: 25%">研究脏器</th>
                        <th data-options="field:'DiagnoseDateTime',
                             formatter:function(value,row){
							return row.productname;
						},
						editor:{
							type:'combobox',
							options:{
								valueField:'productid',
								textField:'productname',
								method:'get',
								url:'',
								required:true
							}
						}"
                            style="width: 30%">标本类型</th>
                        <th data-options="field:'savemethod',width:300,editor:'textbox'">保存方式</th>
                    </tr>
                </thead>
            </table>
        </div>
    </form>
     <script type="text/javascript">
		 var editIndex = undefined;
         function endEditing(){
             if (editIndex == undefined){return true}
             if ($('#dg_SampleInfo').datagrid('validateRow', editIndex)) {
                 var ed = $('#dg_SampleInfo').datagrid('getEditor', { index: editIndex, field: 'productid' });
                 var productname = $(ed.target).combobox('getText');
                 $('#dg_SampleInfo').datagrid('getRows')[editIndex]['productname'] = productname;
                 $('#dg_SampleInfo').datagrid('endEdit', editIndex);
                 editIndex = undefined;
                 return true;
             } else {
                 return false;
             }
         }
         function onClickRow(index){
             if (editIndex != index){
                 if (endEditing()){
                     $('#dg_SampleInfo').datagrid('selectRow', index)
                             .datagrid('beginEdit', index);
                     editIndex = index;
                 } else {
                     $('#dg_SampleInfo').datagrid('selectRow', editIndex);
                 }
             }
         }
         function append(){
             if (endEditing()){
                 $('#dg_SampleInfo').datagrid('appendRow', { status: 'P' });
                 editIndex = $('#dg_SampleInfo').datagrid('getRows').length - 1;
                 $('#dg_SampleInfo').datagrid('selectRow', editIndex)
                         .datagrid('beginEdit', editIndex);
             }
         }
         function removeit(){
             if (editIndex == undefined){return}
             $('#dg_SampleInfo').datagrid('cancelEdit', editIndex)
                     .datagrid('deleteRow', editIndex);
             editIndex = undefined;
         }
	</script>
</body>
</html>
