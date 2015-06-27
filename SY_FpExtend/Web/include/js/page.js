
//初始化临床信息面板
$(function () {
    $('#ClinicalInfoDg').datagrid({
        title: '临床信息',
        columns: [[
            { field: 'ck', checkbox: true, width: '5%' },
            { field: 'DiagnoseTypeFlag', title: '诊断类型', width: '15%' },
            { field: 'DiagnoseDateTime', title: '诊断日期', width: '10%', sortable: true },
            { field: 'ICDCode', title: 'ICD码', width: '10%', align: 'center', sortable: true },
            { field: 'DiseaseName', title: '疾病名称', width: '20%', align: 'center', sortable: true },
            { field: 'Description', title: '疾病描述', width: '20%', align: 'center' },
        ]],
        singleSelect: false,
        pagination: true
    });
   //加载模拟数据
    //$('#ClinicalInfoDg').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', getData());
});

//初始化样本信息面板
$(function () {
    $('#dg_SampleInfo').datagrid({
        title: '取样信息',
        columns: [[
            { field: 'SampleType', title: '样品类型', width: '15%', align: 'center' },
            { field: 'Scount', title: '管数', width: '10%', align: 'center'},
            { field: 'Others', title: '其他信息', width: '10%', align: 'center' },//动态列--根据样品类型展示不同的数据
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
            handler: function () { remove(); }
        }]
    });
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
function append() {
    if (endEditing()) {
        $('#dg_SampleInfo').datagrid('appendRow');
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
///

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
        method: 'get',
        valueField: 'In_CodeType',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=In_CodeType',
        panelHeight: 'auto',
    });
})
//给性别下拉框绑定值
$(function () {
    $('#_115').combobox({
        method: 'get',
        valueField: 'SexFlag',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SexFlag',
        panelHeight: 'auto',
    });
})
//给血型下拉框绑定值
$(function () {
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
        multiple:true,
        method: 'get',
        valueField: 'samplingMethod',
        textField: 'text',
        panelHeight: 'auto',
    });
})


//初始化win
function but() {
    window.open('ExtendPage.aspx', 'title', 'height=600px,width=940px,top=0,left=0,toolbar=no,menubar=no,resizable=no,scrollbars=yes,location=no,status=no');
}

//function but() {

//}


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




