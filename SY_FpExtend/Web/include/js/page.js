//初始化临床信息面板
$(function () {
    var editRow = undefined;
    var $ClinicalInfoDg = $('#ClinicalInfoDg');
    $ClinicalInfoDg.datagrid({
        title: '临床信息',
        columns: [[
            { field: 'ck', checkbox: true, width: '5%' },
            {
                field: 'DiagnoseTypeFlag', title: '诊断类型', width: '20%',
                formatter: function (value, row) {
                    return row.DiagnoseTypeFlag;
                },
                editor: {
                    type: 'combobox',
                    options: {
                        method: 'get',
                        valueField: 'DiagnoseTypeFlag',
                        textField: 'text',
                        url: '../Fp_Ajax/PageConData.aspx?conMarc=DiagnoseTypeFlag',
                        panelHeight: 'auto',
                        required: true
                    }
                }
            },
            {
                field: 'DiagnoseDateTime', title: '诊断日期', width: '20%', sortable: true, editor: { type: 'validatebox', options: { required: true } }
            },
            { field: 'ICDCode', title: 'ICD码', width: '15%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'DiseaseName', title: '疾病名称', width: '20%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'Description', title: '疾病描述', width: '20%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },
        ]],
        singleSelect: false,
        pagination: true,
        toolbar: [
            {
                text: '添加', iconCls: 'icon-add', handler: function ()
                {
                    if (editRow != undefined)
                    {
                    $ClinicalInfoDg.datagrid('endEdit', editRow);
                    }
                    if (editRow == undefined)
                    {
                    $ClinicalInfoDg.datagrid('insertRow', {
                        index: 0,
                        row: {}
    });
                    $ClinicalInfoDg.datagrid('beginEdit', 0);
                    editRow = 0;
                    }
                }
            }, '-', {
            text: '保存', iconCls: 'icon-save', handler: function () {
                $ClinicalInfoDg.datagrid('endEdit', editRow);

                //如果调用acceptChanges(),使用getChanges()则获取不到编辑和新增的数据。

                //使用JSON序列化datarow对象，发送到后台。
                var rows = $ClinicalInfoDg.datagrid('getChanges');

                var rowstr = JSON.stringify(rows);
                $.post('/Home/Create', rowstr, function (data) {

                });
            }
        }, '-', {
            text: '删除', iconCls: 'icon-remove', handler: function () {
                var row = $ClinicalInfoDg.datagrid('getSelected');
                if (row) {
                    var rowIndex = $ClinicalInfoDg.datagrid('getRowIndex', row);
                    $ClinicalInfoDg.datagrid('deleteRow', rowIndex);
                }
            }
        }, '-', {
            text: '修改', iconCls: 'icon-edit', handler: function () {
                var row = $ClinicalInfoDg.datagrid('getSelected');
                if (row != null) {
                    if (editRow != undefined) {
                        $ClinicalInfoDg.datagrid('endEdit', editRow);
                    }
                    if (editRow == undefined) {
                        var index = $ClinicalInfoDg.datagrid('getRowIndex', row);
                        $ClinicalInfoDg.datagrid('beginEdit', index);
                        editRow = index;
                        $ClinicalInfoDg.datagrid('unselectAll');
                    }
                } else {

                }
            }
        }],
        onAfterEdit: function (rowIndex, rowData, changes) {
            editRow = undefined;
        },
        onDblClickRow: function (rowIndex, rowData) {
            if (editRow != undefined) {
                $ClinicalInfoDg.datagrid('endEdit', editRow);
            }

            if (editRow == undefined) {
                $ClinicalInfoDg.datagrid('beginEdit', rowIndex);
                editRow = rowIndex;
            }
        },
        onClickRow: function (rowIndex, rowData) {
            if (editRow != undefined) {
                $ClinicalInfoDg.datagrid('endEdit', editRow);
            }
        }
   //加载模拟数据
    //$('#ClinicalInfoDg').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', getData());
});
})


//初始化样本信息面板
$(function () {
    var editRow = undefined;
    var $dg_SampleInfo = $('#dg_SampleInfo');
    $('#dg_SampleInfo').datagrid({
        title: '取样信息',
        columns: [[
            { field: 'SampleType', title: '样品类型', width: '15%', align: 'center',editor: { type: 'validatebox', options: { required: false } } },
            { field: 'Scount', title: '管数', width: '10%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },
            { field: 'Others', title: '其他信息', width: '10%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },//动态列--根据样品类型展示不同的数据
        ]],
        onClickRow: onClickRow,
        singleSelect: false,
        pagination: true
    });
    $('#dg_SampleInfo').datagrid({
        toolbar: [{
            iconCls: 'icon-add',
            handler: function () { append(); }
        }, '-', {
            iconCls: 'icon-remove',
            handler: function () { removeit(); }
        }]
    });
    
    //$('#dg_SampleInfo').datagrid({
    //    toolbar: [{
    //        text: '添加', iconCls: 'icon-add', handler: function () {
    //            if (editRow != undefined) {
    //                $dg_SampleInfo.datagrid('endEdit', editRow);
    //            }
    //            if (editRow == undefined) {
    //                $dg_SampleInfo.datagrid('insertRow', {
    //                    index: 0,
    //                    row: {}
    //                });
    //                $dg_SampleInfo.datagrid('beginEdit', 0);
    //                editRow = 0;
    //            }
    //        }
    //    }, '-', {
    //        text: '删除', iconCls: 'icon-remove', handler: function () {
    //            var row = $dg_SampleInfo.datagrid('getSelected');
    //            if (row) {
    //                var rowIndex = $dg_SampleInfo.datagrid('getRowIndex', row);
    //                $dg_SampleInfo.datagrid('deleteRow', rowIndex);
    //            }
    //        }
    //    }, '-', {
    //        text: '修改', iconCls: 'icon-edit', handler: function () {
    //            var row = $dg_SampleInfo.datagrid('getSelected');
    //            if (row != null) {
    //                if (editRow != undefined) {
    //                    $dg_SampleInfo.datagrid('endEdit', editRow);
    //                }
    //                if (editRow == undefined) {
    //                    var index = $dg_SampleInfo.datagrid('getRowIndex', row);
    //                    $dg_SampleInfo.datagrid('beginEdit', index);
    //                    editRow = index;
    //                    $dg_SampleInfo.datagrid('unselectAll');
    //                }
    //            } else {

    //            }
    //        }
    //    }],
    //});
});

///
var editIndex = undefined;
function endEditing() {
    if (editIndex == undefined) { return true }
    if ($('#dg_SampleInfo').datagrid('validateRow', editIndex)) {
        //var ed = $('#dg_SampleInfo').datagrid('getEditor', { index: editIndex, field: 'productid' });
        //var productname = $(ed.target).combobox('getText');
        //$('#dg_SampleInfo').datagrid('getRows')[editIndex]['productname'] = productname;
        $('#dg_SampleInfo').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}
function onClickRow(index) {
    if (editIndex != index) {
        if (endEditing()) {
            $('#dg_SampleInfo').datagrid('selectRow', index)
                    .datagrid('beginEdit', index);
            editIndex = index;
        } else {
            $('#dg_SampleInfo').datagrid('selectRow', editIndex);
        }
    }
}
//修改添加方法
function append() {
    if (endEditing()) {
        $('#dg_SampleInfo').datagrid('appendRow', { ck: true });
        editIndex = $('#dg_SampleInfo').datagrid('getRows').length - 1;
        $('#dg_SampleInfo').datagrid('selectRow', editIndex)
                .datagrid('beginEdit', editIndex);
    }
}
function removeit() {
    if (editIndex == undefined) { return }
    $('#dg_SampleInfo').datagrid('cancelEdit', editIndex)
            .datagrid('deleteRow', editIndex);
    editIndex = undefined;
}

function accept() {
    if (endEditing()) {
        $('#dg_SampleInfo').datagrid('acceptChanges');
    }
}
function reject() {
    $('#dg_SampleInfo').datagrid('rejectChanges');
    editIndex = undefined;
}
function getChanges() {
    var rows = $('#dg_SampleInfo').datagrid('getChanges');
    alert(rows.length + ' rows are changed!');
}
function getData() {
    var rows = [];
    for (var i = 1; i <= 200; i++) {
        var amount = Math.floor(Math.random() * 1000);
        var price = Math.floor(Math.random() * 1000);
        rows.push({
            DiagnoseTypeFlag: 'DiagnoseTypeFlag ' + i,
            DiagnoseDateTime: $.fn.datebox.defaults.formatter(new Date()),
            RegisterID: 'RegisterID ' + i,
            InPatientID: 'InPatientID' + i,
            ICDCode: 'ICDCode',
            DiseaseName: 'DiseaseName' + i,
            Description: 'Description ' + i
        });
    }
    return rows;
}

function pagerFilter(data) {
    if (typeof data.length == 'number' && typeof data.splice == 'function') {	// is array
        data = {
            total: data.length,
            rows: data
        }
    }
    var dg = $(this);
    var opts = dg.datagrid('options');
    var pager = dg.datagrid('getPager');
    pager.pagination({
        onSelectPage: function (pageNum, pageSize) {
            opts.pageNumber = pageNum;
            opts.pageSize = pageSize;
            pager.pagination('refresh', {
                pageNumber: pageNum,
                pageSize: pageSize
            });
            dg.datagrid('loadData', data);
        }
    });
    if (!data.originalRows) {
        data.originalRows = (data.rows);
    }
    var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
    var end = start + parseInt(opts.pageSize);
    data.rows = (data.originalRows.slice(start, end));
    return data;
}

//给In_CodeType下拉框绑定值
$(function () {
    $('#In_CodeType').combobox({
        editable: false,
        method: 'get',
        valueField: 'In_CodeType',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=In_CodeType',
        panelHeight: 'auto',
        onLoadSuccess: function () { //数据加载完毕事件
            $("#In_CodeType").combobox('setValue', '住院号');
        }
    })
})

//给性别下拉框绑定值
$(function () {
    $('#_115').combobox({
        editable: false,
        method: 'get',
        valueField: 'SexFlag',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SexFlag',
        panelHeight: 'auto',
    });
})

//给血型下拉框绑定值
$(function () {
    editable: false,
    $('#_116').combobox({
        method: 'get',
        valueField: 'BloodTypeFlag',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=BloodTypeFlag',
        panelHeight: 'auto',
    });
})

//给取材方式下拉框绑定值
$(function () {
    $('#_101').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SamplingMethod',
        multiple: true,
        method: 'get',
        valueField: 'samplingMethod',
        textField: 'text',
        panelHeight: 'auto',
    });
})


//初始化win弹窗在显示器中央
function doimport() {
    var width = 940;
    var height = 600;
    var l = Math.round((window.screen.width - width) / 2);
    var t = Math.round((window.screen.height - height) / 2);
    window.open('Login.aspx', 'newwindow', 'height=' + height + ', width=' + width + ', top=' + t + ',left=' + l + ',toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no')
}

//操作dg_SampleInfo
function remove() {
    var datagrid = $(this).datagrid;
    alert(datagrid);
}

//function appendSampleInfo()
//{
//    var index;
//    alert('sss');
//    $('#dg_SampleInfo').datagrid('insertRow', {
//        index: 0,
//        row: {}
//    }).datagrid('getRows').length - 1;
//    index = $('#dg_SampleInfo').datagrid.length;
//    $('#dg_SampleInfo').datagrid('beginEdit', index);
//}

//POST数据
function postData() {
    alert('Hello');
    $('#mainform').form({
        type: 'POST',
        url: "/Ajax/SubmitData.ashx",
        onSubmit: function () {
            // 做某些检查 
            // 返回 false 来阻止提交 
        },
        success: function (data) {
            alert(data)
        }
    });
    $('#mainform').submit();
}
