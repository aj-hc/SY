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
})
//添加信息
function AddSetting()
{
    var SettingValue = $('#ComSetting').combobox('')
}


//加载科室的方式
function getCurrentDepartments()
{
    var CurrentDepartments = "";
    $.ajax({
        type: 'post',
        dataType: "json",
        url: '../Fp_Ajax/PageConData.aspx?conMarc=CurrentDepartments',
        success: function (data) {
            if (data != "")
            {
                CurrentDepartments = data;
            }
            else { $.messager.alert('提示', '未获取到当前科室，请重新登陆', 'error'); return; }
        }
    });
    return CurrentDepartments;
}

