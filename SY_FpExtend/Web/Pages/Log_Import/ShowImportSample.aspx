<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowImportSample.aspx.cs" Inherits="RuRo.Web.Pages.Log_Import.ShowImportSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>展示样本记录信息</title>
    <script src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="../../include/css/default.css" rel="stylesheet" />

</head>
<body>
    <div>
        <form id="log_Show_Ser_Form" style="margin: 2px; padding: 2px">
            <div>
                <span>查找方式：</span>
                <select onchange="change_Ser_Method()" class="easyui-combobox" id="ser_Method_Type">
                    <option value="user">当前用户</option>
                    <option value="department">当前科室</option>
                </select>
            </div>
            <div>
                <div id="cc" class="easyui-calendar"></div>
                <span>开始日期：</span><input id="strat_Date" style="width: 95px" class="easyui-datebox" data-options="sharedCalendar:'#cc'" />
                <span>结束日期：</span><input id="end_Date" style="width: 95px" class="easyui-datebox" data-options="sharedCalendar:'#cc'" />
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" style="width: 80px">查询</a>
            </div>
        </form>
    </div>
    <div style="height:400px">
    <div id="gd_Show_Import_Sampe"></div></div>
    <script type="text/javascript">
        ////创建datagrid
        $(function () {
            $('#gd_Show_Import_Sampe').datagrid({
                url: 'ShowImportSample.aspx',
                method: 'get',
                title: '记录',
                //width: 700,
                height: 'auto',
                nowrap: false,
                striped: true,
                border: true,
                collapsible: false,//是否可折叠的 
                fit: true,//自动大小
                //sortName: 'code', 
                //sortOrder: 'desc', 
                remoteSort: false,
                idField: 'Id',
                singleSelect: false,//是否单选 
                pagination: true,//分页控件 
                rownumbers: true,//行号  
                columns: [[
                    { field: 'Id', title: 'Id', width: 80, hidden: true },
                    { field: 'PatientID', title: '唯一标识', width: "10%", align: 'center' },
                    { field: 'PatientName', title: '姓名', width: "10%", align: 'center' },
                    { field: 'SexFlag', title: '性别', width: "10%", align: 'center' },
                    { field: 'Import_Date', title: '日期', width: "15%", align: 'center' },
                    { field: 'TB_CONSENT_FORM', title: '知情同意', width: '10%', align: 'center' },
                    { field: 'Others', title: '样本信息', width: '40%', align: 'center' },
                ]],
            });
        });
        //变换查询方式
        function change_Ser_Method() {
            alert("change");
        }
    </script>
</body>
</html>
