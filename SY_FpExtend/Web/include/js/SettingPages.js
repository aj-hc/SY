//查询表单设定
$(function () {
    var editRow = undefined;
    var $dg_GetSetting = $('#dg_GetSetting');
    $dg_GetSetting.datagrid({
        title: '设定表单',
        columns: [[
            { field: 'ck', checkbox: true, width: '5%' },
            { field: 'DefaultValue', title: '默认值', width: '20%', editor: { type: 'validatebox', options: { required: false } } },
            { field: 'DefaultTime', title: '添加日期', width: '15%', sortable: true, editor: { type: 'datebox', options: { required: false } } },
            { field: 'Department', title: '所属科室', width: '15%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'SettingValue', title: '所属字段', width: '15%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
        ]],
        singleSelect: false,
        fitColumns: true,
        rownumbers: true,//行号
        tools: [ {
            //text: '添加',
            iconCls: 'icon-add', handler: function () {
                $('#w').window('open');
            },
            position: 'right'
        }, '-', {
            //text: '删除',
            iconCls: 'icon-remove', handler: function () {
                var row = $dg_GetSetting.datagrid('getChecked');
                for (var i = 0; i < row.length; i++) {
                    var rowIndex = $dg_GetSetting.datagrid('getRowIndex', row[i]);
                    $dg_GetSetting.datagrid('deleteRow', rowIndex);
                }
                $("#dg_GetSetting").datagrid("clearSelections");
                editRow == undefined;
            }
        }
        ]
    })
})
//绑定ComSetting
$(function () {
    $('#ComSetting').combobox({
        editable: false,
        method: 'get',
        valueField: 'ComSetting',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=ComSetting',
        panelHeight: 'auto'
    });
});
//查询设定
function QuerySetting()
{
    
    var SettingValue = $('#ComSetting').combobox('getValue');
    $.ajax({
        type: 'post',
        dataType: "json",
        url: '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting',
        data: {SettingValue: SettingValue},
        success: function (data) {
            if (data != "") {
                $.messager.alert('提示', data);
            }
            else { $.messager.alert('提示', '未检测到添加信息', 'error'); return; }
        }
    });
}
//添加信息
function AddSetting()
{
    var username = $.cookie('username');
    var departments = $.cookie(username + 'department');
    //var Department = getCurrentDepartments();
    var SettingValue = $('#ComSetting').combobox('getValue');
    if (SettingValue == "") { $.messager.alert('提示', '添加的字段类型为空', 'error'); return; }
    var DefaultValue = $('#DefaultValue').textbox('getValue');
    var DefaultTime = $('#DefaultTime').textbox('getValue');
    //ajaxLoading();
    $.ajax({
        type: 'post',
        dataType: "json",
        url: '../Fp_Ajax/SubmitData.aspx?action=postSetting',
        data: {
            SettingValue: SettingValue,
            DefaultValue: DefaultValue,
            DefaultTime: DefaultTime,
            departments: departments
        },
        success: function (data) {
            //ajaxLoadEnd();
            $.messager.alert('提示', data);
        }
    });
}
//清除添加页面
function cleardg_GetSetting() {
    $('#cleardg_GetSetting').form('clear');
}
//采用jquery easyui loading css效果 
function ajaxLoading() {
    $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
    $("<div class=\"datagrid-mask-msg\"></div>").html("正在处理，请稍候。。。").appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
}
function ajaxLoadEnd() {
    $(".datagrid-mask").remove();
    $(".datagrid-mask-msg").remove();
}

