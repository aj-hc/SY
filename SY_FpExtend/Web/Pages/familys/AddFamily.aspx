<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFamily.aspx.cs" Inherits="RuRo.Web.Pages.familys.AddFamily" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加家族关联</title>
    <script src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="../../include/css/default.css" rel="stylesheet" />
    <script src="../../include/js/jquery.cookie.js"></script>
    <link href="../../include/css/Family.css" rel="stylesheet" />
</head>
<body>
    <div class="easyui-panel" style="width: 80%;">
        <div style="width: 200px; height: 200px; float: left; display: inline; border-right: dotted; border-width: 1px;">
            <span>查找样本源基本信息</span>
            <br />
            <br />
            <div>患者ID：<input class="easyui-textbox" name="PatientID" id="PatientID" data-options="required:true" style="width: 110px;" /></div>
            <br />
            <div>姓  名：<input class="easyui-textbox" name="PatientName" id="PatientName" data-options="required:true" style="width: 110px;" /></div>
            <br />
            <div><a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="" style="width: 80px">查询</a></div>
        </div>
        <div style="width: auto; height: 100px; float: left; margin-left: 10px; display: inline">
            <span>信息勾选：</span>
            <div id="get_Sample_Source" style="width: 500px; height: auto"></div>
        </div>
    </div>
    <div class="easyui-panel" style="width: 80%; padding: 1px; margin-top: 10px; height: 300px;">
        <div id="Save_Family" style="width: 800px;"></div>
    </div>
    <div id="footer" style="width: 600px; padding: 5px; margin: 10px" data-options="region:'south',">
        <a href="javascript:void(0)" class="easyui-linkbutton" id="submit" style="width: auto" onclick="postPatientInfo()">导入关联</a>
    </div>
    <!--关系信息录入框 -->
    <div id="w" class="easyui-window" title="家系添加" data-options="modal:false,closed:true,minimizable:false,maximizable:false,iconCls:'icon-add'" style="width: 436px; height: 299px; padding: 1px;">
        <div style="padding: 1px">
            <form id="setFamily" method="post">
                <table>
                    <tr>
                        <td style="width: 100px;">姓名:</td>
                        <td>
                            <input class="easyui-textbox" name="FamilyName" id="FamilyName" data-options="required:true,multiple:false,prompt:'请选择添加数据的诊断类型'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">关联人ID:</td>
                        <td>
                            <input class="easyui-textbox" type="text" name="FamilyNameID" id="FamilyNameID" data-options="required:true,prompt:'请选择诊断日期'" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px;">关系:</td>
                        <td>
                            <input class="easyui-combobox" type="text" name="FamilyNameNexus" id="FamilyNameNexus" data-options="required:false" /></td>
                    </tr>
                </table>
            </form>
            <div style="text-align: center; padding: 5px;">
                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="submitFormClinicalInfoDg()" style="margin: 8px">添加</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="clearsetClinicalInfoDg()" style="margin: 8px">清除</a>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //get_Sample_Source
        $(function () {
            var editRow = undefined;
            var $get_Sample_Source = $('#get_Sample_Source');
            $get_Sample_Source.datagrid({
                title: '病人基本信息',
                singleSelect: false,
                rownumbers: true,
                columns: [[
                    { field: 'ck', checkbox: true, width: '5%' },
                    { field: 'SampleSoure', title: '样本源名称', width: '30%', align: 'center' },
                    { field: 'Name', title: '姓名', width: '20%', align: 'center' },
                    { field: 'Sex', title: '性别', width: '20%', align: 'center' },
                    { field: 'date', title: '出生日期', width: '20%', align: 'center' }
                ]]
            });
        });
        //Save_Family
        $(function () {
            var editRow = undefined;
            var $Save_Family = $('#Save_Family');
            $Save_Family.datagrid({
                title: '添加家系',
                columns: [[
                    { field: 'SampleSoure', title: '样本源名称', width: '15%', align: 'center' },
                    { field: 'Name', title: '姓名', width: '10%', align: 'center' },
                    { field: 'Sex', title: '性别', width: '5%', align: 'center' },
                    { field: 'date', title: '出生日期', width: '10%', align: 'center' },
                    { field: 'date', title: '关系人ID', width: '15%', align: 'center' },
                    { field: 'date', title: '关系人姓名', width: '10%', align: 'center' },
                    { field: 'date', title: '关系', width: '10%', align: 'center' },
                ]],
                singleSelect: false,
                fitColumns: true,
                rownumbers: true,//行号
                tools: [
                    {
                        //text: '添加',
                        iconCls: 'icon-add', handler: function () {
                            $('#w').window('open');
                        },
                        position: 'right'
                    }, '-', {
                        //text: '删除',
                        iconCls: 'icon-remove', handler: function () {
                            var row = $Save_Family.datagrid('getChecked');
                            for (var i = 0; i < row.length; i++) {
                                var rowIndex = $Save_Family.datagrid('getRowIndex', row[i]);
                                $Save_Family.datagrid('deleteRow', rowIndex);
                            }
                            $("#Save_Family").datagrid("clearSelections");
                            editRow == undefined;
                        }
                    }
                ]
            })
        });
    </script>
</body>
</html>
