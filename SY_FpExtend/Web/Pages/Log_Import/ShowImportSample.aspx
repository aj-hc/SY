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
                <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="queryreport()" style="width: 80px">查询</a>
            </div>
        </form>
    </div>
    <div style="height: 400px">
        <div id="gd_Show_Import_Sampe"></div>
    </div>
    <script type="text/javascript">
        //创建datagrid
        $(function (){
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
                ]]
            });
        });
        //变换查询方式
        function change_Ser_Method() {
            var value = "";
            var username = $.cookie('username');
            var departments = $.cookie(username + 'department');
            var comtype = $('#ser_Method_Type').combobox('getValue');
            //获取值
            if (comtype == "user") {
                value ="1-"+ username;//获取当前用户
            }
            else {
                value ="2-"+ departments;//获取当前科室
            }
            return value;
        }
        //查询数据
        function queryreport() {
            var type = change_Ser_Method();//根据查询类型获取值
            var stratDate = $('#ser_Method_Type').textbox('getValue');
            var endDate = $('#ser_Method_Type').textbox('getValue');
            if (stratDate == "" || endDate == "") { $.messager.alert('错误', '查询日期不能为空', 'error'); return; }
            else {
                    if (!dateCompare) { $.messager.alert('错误', '开始日期不能大于结束日期', 'error'); return; }
                    else {
                        $.ajax({
                            type: 'GET',
                            url: '/Fp_Ajax/GetData.aspx?action=getLogImport',
                            data: {
                                Importtype: type,
                                stratDate: stratDate,
                                endDate: endDate
                            },
                            onSubmit: function () { },
                            success: function (data) {
                                if (data == "") { $.messager.alert('查询不到数据'); return; }
                                else {
                                    var ds = data.ds;
                                    if (ds[0] == undefined) { $.messager.alert('返回数据有误'); return; }
                                    else {
                                        $('#gd_Show_Import_Sampe').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', ds).datagrid('reload');
                                    }
                                }
                            }
                        });
                    }
                 }
        }
        //比较日期
        function dateCompare(startdate, enddate) {
            var arr = startdate.split("-");
            var starttime = new Date(arr[0], arr[1], arr[2]);
            var starttimes = starttime.getTime();

            var arrs = enddate.split("-");
            var lktime = new Date(arrs[0], arrs[1], arrs[2]);
            var lktimes = lktime.getTime();

            if (starttimes >= lktimes) {
                return false;
            }
            else
                return true;
        }
        //分页辅助
        function pagerFilter(data) {
            if (typeof data.length == 'number' && typeof data.splice == 'function') {	// is array
                data = { total: data.length, rows: data }
            }
            var dg = $(this);
            var opts = dg.datagrid('options');
            var pager = dg.datagrid('getPager');
            pager.pagination({
                onSelectPage: function (pageNum, pageSize) {
                    opts.pageNumber = pageNum;
                    opts.pageSize = pageSize;
                    pager.pagination('refresh', { pageNumber: pageNum, pageSize: pageSize });
                    dg.datagrid('loadData', data);
                }
            });
            if (!data.originalRows) { data.originalRows = (data.rows); }
            var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
            var end = start + parseInt(opts.pageSize);
            data.rows = (data.originalRows.slice(start, end));
            return data;
        }
    </script>
</body>
</html>
