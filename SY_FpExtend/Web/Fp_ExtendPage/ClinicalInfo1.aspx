<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClinicalInfo1.aspx.cs" Inherits="RuRo.Web.Fp_ExtendPage.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../include/jquery-easyui-1.4.2/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.2/jquery.easyui.min.js"></script>
    <script src="../include/js/default.js"></script>
    <link href="../include/jquery-easyui-1.4.2/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.2/themes/icon.css" rel="stylesheet" />
    <script src="../include/js/page.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
	
	<table id="ClinicalInfoDg1" class="easyui-datagrid" title="诊断信息" style="width:1000px;height:auto"
			data-options="
				iconCls: 'icon-edit',
                pagination: true,
				singleSelect: true,
				toolbar: '#tb',
				url: 'datagrid_data1.json',
				method: 'get',
				onClickRow: onClickRow
			">
		<thead>
			<tr style="width:1000px">
				<th data-options="field:'ck',width:60,align:'center',editor:{type:'checkbox',options:{on:'P',off:''}}">选择</th>
                <th data-options="field:'DiagnoseTypeFlag',width:100,editor:'textbox'">诊断类型</th>
                <th data-options="field:'DiagnoseDateTime',width:100,editor:'textbox'">诊断日期</th>
				<th data-options="field:'RegisterID',width:150,align:'left',editor:'numberbox'">挂号ID</th>
                <th data-options="field:'InPatientID',width:150,align:'left',editor:'numberbox'">住院ID</th>
                <th data-options="field:'ICDCode',width:150,editor:'textbox'">ICD码</th>
                <th data-options="field:'DiseaseName',width:100,editor:'textbox'">疾病名称</th>
				<th data-options="field:'Description',width:200,editor:'textbox'">疾病描述</th>
			</tr>
		</thead>
	</table>

	<div id="tb" style="height:auto">
		<a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="append()">添加</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true" onclick="removeit()">删除</a>
	</div>
    <script type="text/javascript">
		        var editIndex = undefined;
		        function endEditing(){
			        if (editIndex == undefined){return true}
			        if ($('#ClinicalInfoDg1').datagrid('validateRow', editIndex)) {
			            var ed = $('#ClinicalInfoDg1').datagrid('getEditor', { index: editIndex, field: 'RegisterID' });
				        var productname = $(ed.target).combobox('getText');
				        $('#ClinicalInfoDg1').datagrid('getRows')[editIndex]['RegisterID'] = RegisterID;
				        $('#ClinicalInfoDg1').datagrid('endEdit', editIndex);
				        editIndex = undefined;
				        return true;
			        } else {
				        return false;
			        }
		        }
		            function onClickRow(index){
			            if (editIndex != index){
				            if (endEditing()){
				                $('#ClinicalInfoDg1').datagrid('selectRow', index)
							            .datagrid('beginEdit', index);
					            editIndex = index;
				            } else {
				                $('#ClinicalInfoDg1').datagrid('selectRow', editIndex);
				            }
			            }
		            }
		            function append(){
			            if (endEditing()){
			                $('#ClinicalInfoDg1').datagrid('appendRow', { status: 'P' });
			                editIndex = $('#ClinicalInfoDg1').datagrid('getRows').length - 1;
			                $('#ClinicalInfoDg1').datagrid('selectRow', editIndex)
						            .datagrid('beginEdit', editIndex);
			            }
		            }
		            function removeit(){
			            if (editIndex == undefined){return}
		                $('#ClinicalInfoDg1').datagrid('cancelEdit', editIndex)
					            .datagrid('deleteRow', editIndex);
			            editIndex = undefined;
		            }
		            function accept() {
		                if (endEditing()) {
		                    $('#ClinicalInfoDg1').datagrid('acceptChanges');
		                }
		            }
		            function reject() {
		                $('#ClinicalInfoDg1').datagrid('rejectChanges');
		                editIndex = undefined;
		            }
		            function getChanges() {
		                var rows = $('#ClinicalInfoDg1').datagrid('getChanges');
		                alert(rows.length + ' rows are changed!');
		            }

	</script>

    </form>
</body>
</html>
