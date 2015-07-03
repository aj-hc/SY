//初始化临床信息面板
function getDiagnoseTypeFlagJsonurl(Diagnoseurl)
{
    var temp;
    $.ajax({
        type: 'get',
        url:Diagnoseurl,
        async: false,
        datatype:'json',
        success: function (responseData)
        {
            temp = responseData;
        }
    });
    return temp;
}


var Diagnoseurl = '../Fp_Ajax/PageConData.aspx?conMarc=DiagnoseTypeFlag';
//$.window.suit_id = getDiagnoseTypeFlagJsonurl(Diagnoseurl);
var getData = getDiagnoseTypeFlagJsonurl(Diagnoseurl);
var getDtaJson = JSON.parse(getData);

function getDiagnoseTypeFlagJson(value, row, index)
{

    getjson = $.parseJSON(DiagnoseTypeFlagJson);
    if (value == 0) { return; }
    for (var i = 0; i < getjson.length; i++) {
        if (getjson[i].DiagnoseTypeFlag == value) { return getjson[i].text; }
    }
}

function getJsonObjLength(jsonObj) {
    var Length = 0;
    for (var item in jsonObj) {
        Length++;
    }
    return Length;
}

$(function () {
    var editRow = undefined;
    var $ClinicalInfoDg = $('#ClinicalInfoDg');
    $ClinicalInfoDg.datagrid({
        title: '临床信息',
        columns: [[
            { field: 'ck', checkbox: true, width: '5%' },
            {
                field: 'DiagnoseTypeFlag', title: '诊断类型', width: '20%',
                editor: {
                    type: 'combobox',
                    options: {
                        //method: 'get',
                        //url: '../Fp_Ajax/PageConData.aspx?conMarc=DiagnoseTypeFlag',
                        data: getDtaJson,
                        valueField: 'DiagnoseTypeFlag',
                        textField: 'text',
                        editable: false,
                        panelHeight: 'auto',
                        required: true
                    }
                }, formatter: function (value, rowData, rowIndex)
                   {
                        var getData=getDiagnoseTypeFlagJsonurl(Diagnoseurl);
                        var getDtaJson = JSON.parse(getData);
                        if (getDtaJson != "" || getDtaJson != null)
                        {
                            for (var i = 0; i < getDtaJson.length; i++)
                            {
                                //getDtaJson[i].DiagnoseDateTime
                                if (getDtaJson[i].DiagnoseTypeFlag == value) { return getDtaJson[i].text; }
                            }
                         }
                        else { return value; }
                    }
            },
            {
                field: 'DiagnoseDateTime', title: '诊断日期', width: '20%', sortable: true, editor: {
                    type: 'datebox', options:
                        {
                            required: true,
                            formatter: function (data)
                            {
                                var y = data.DiagnoseDateTime;
                                alert(y);
                                //return m + '/' + d + '/' + y;
                            }
                        }
                }
            },
            { field: 'ICDCode', title: 'ICD码', width: '15%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'DiseaseName', title: '疾病名称', width: '20%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'Description', title: '疾病描述', width: '20%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },
        ]],
        singleSelect: false,
        pagination:true,
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
                    $ClinicalInfoDg.datagrid('insertRow', {index: 0,row: {}});
                    $ClinicalInfoDg.datagrid('beginEdit', 0);
                    editRow = 0;
                    }
                }
            }, '-', {
                text: '保存', iconCls: 'icon-save', handler: function () {
                        $ClinicalInfoDg.datagrid('endEdit', editRow);
                        var rows = $ClinicalInfoDg.datagrid('getRows');
                        $('#ClinicalInfoDg').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', rows).datagrid('reload');
                        var rowstr = JSON.stringify(rows);
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
    $dg_SampleInfo.datagrid({
        title: '样本信息',
        columns: [[
            { field: 'SampleType', title: '样品类型', width: '15%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },
            { field: 'Scount', title: '管数', width: '10%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },
            {   field: 'combox1', title: '联动1', width: '20%',
                formatter: function (value, row) { return row.key; },
                editor: {
                    type: 'combobox',
                    options: {
                        method: 'get',
                        valueField: 'key',
                        textField: 'text',
                        url: '../Fp_Ajax/PageConData.aspx?conMarc=liandong1',
                        panelHeight: 'auto',
                        //onChange: function (newValue, oldvalue)
                        //{ 
                        //    var row = $('#dg_SampleInfo').datagrid('getSelected');
                        //    if (row == null) { row = 1 };
                        //    var rowIndex = $('#dg_SampleInfo').datagrid('getRowIndex', row);
                        //    var target = $('#dg_SampleInfo').datagrid('getEditor', { 'index': rowIndex, 'field': 'combox2' });
                        //    target.combobox('clear');
                        //    var url = '../Fp_Ajax/PageConData.aspx?conMarc=liandong2' + data.value;
                        //    $(ed.target).combobox('setValue', '2012');
                        //},
                        required: true
                    }
                }
            },
            //{   field: 'combox2', title: '联动2', width: '20%',
            //    editor: {type: 'combobox',options: {  }}
            //}, 
            { field: 'Others', title: '其他信息', width: '10%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },//动态列--根据样品类型展示不同的数据

        ]],
        singleSelect: false,
        pagination: true,
        toolbar: [
            {text: '添加', iconCls: 'icon-add', handler: function () {
                    if (editRow != undefined) {$dg_SampleInfo.datagrid('endEdit', editRow);}
                    if (editRow == undefined)
                    {
                        $dg_SampleInfo.datagrid('insertRow', { index: 0, row: {} });
                        $dg_SampleInfo.datagrid('beginEdit', 0);
                        editRow = 0;
                    }
                }
            }, '-',
            {text: '保存', iconCls: 'icon-save', handler: function () {
                $dg_SampleInfo.datagrid('endEdit', editRow);
                var rows = $dg_SampleInfo.datagrid('getRows');
                $('#dg_SampleInfo').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', rows).datagrid('reload');
                    var rows = $dg_SampleInfo.datagrid('getChanges');
                    var rowstr = JSON.stringify(rows);
             }
            }, '-',
            {text: '删除', iconCls: 'icon-remove', handler: function () {
                    var row = $dg_SampleInfo.datagrid('getSelected');
                    if (row)
                    {
                        var rowIndex = $dg_SampleInfo.datagrid('getRowIndex', row);
                        $dg_SampleInfo.datagrid('deleteRow', rowIndex);
                    }
                }
            }, '-',
            {text: '修改', iconCls: 'icon-edit', handler: function () {
                    var row = $dg_SampleInfo.datagrid('getSelected');
                    if (row != null)
                    {
                        if (editRow != undefined) {$dg_SampleInfo.datagrid('endEdit', editRow);}
                        if (editRow == undefined)
                        {
                            var index = $dg_SampleInfo.datagrid('getRowIndex', row);
                            $dg_SampleInfo.datagrid('beginEdit', index);
                            editRow = index;
                            $dg_SampleInfo.datagrid('unselectAll');
                        }
                    } else {}
                }
            }],
            onAfterEdit: function (rowIndex, rowData, changes) {editRow = undefined;},
            onDblClickRow: function (rowIndex, rowData) {
                 if (editRow != undefined) {$dg_SampleInfo.datagrid('endEdit', editRow);}
                 if (editRow == undefined) {$dg_SampleInfo.datagrid('beginEdit', rowIndex);editRow = rowIndex;}
            },
            onClickRow: function (rowIndex, rowData) {
                if (editRow != undefined) {$dg_SampleInfo.datagrid('endEdit', editRow);}}
    });
})

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
            //$("#In_CodeType").combobox('setValue', '住院号');
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
function remove()
{
    var datagrid = $(this).datagrid;
    alert(datagrid);
}

//POST数据
function postData() {
    var str = getpagedata();
    alert(str);
    $.ajax({
        type: 'post',
        url: '/Fp_Ajax/SubmitData.aspx?action=gethisdata&json=' + str,
        onSubmit: function () { },
        success: function (data) {
            alert(data);
        }
    });
}

//获取页面数据
function getpagedata()
{
    //序列化字段为JSON for 基本数据
    var querybycodeform = "";
    //传入方式、
    var In_CodeType = $('#In_CodeType').textbox('getValue');
    In_CodeType = tojson("In_CodeType", In_CodeType);
    querybycodeform = In_CodeType + ",";
    //传入号码
    var In_Code = $('#In_Code').textbox('getValue');//获取数据源
    In_Code = tojson("In_Code", In_Code);
    querybycodeform =querybycodeform+In_Code + ",";
    //姓名
    var _80 = $("#_80").textbox('getValue');
    _80 = tojson("_80", _80);
    querybycodeform = querybycodeform + _80 + ",";
    //住院号
    var _81 = $("#_81").textbox('getValue');
    _81 = tojson("_81", _81);
    querybycodeform = querybycodeform + _81 + ",";
    //就诊卡号
    var _82 = $("#_82").textbox('getValue');
    _82 = tojson("_82", _82);
    querybycodeform = querybycodeform + _82 + ",";
    //性别
    var _115 = $("#_115").textbox('getValue');
    _115 = tojson("_115", _115);
    querybycodeform = querybycodeform + _115 + ",";
    //出生日期
    var _84 = $("#_84").textbox('getValue');
    _84 = tojson("_84", _84);
    querybycodeform = querybycodeform + _84 + ",";
    //血型
    var _116 = $("#_116").textbox('getValue');
    _116 = tojson("_116", _116);
    querybycodeform = querybycodeform + _116 + ",";
    //联系人
    var _88 = $("#_88").textbox('getValue');
    _88 = tojson("_88", _88);
    querybycodeform = querybycodeform + _88 + ",";
    //联系人电话
    var _87 = $("#_87").textbox('getValue');
    _87 = tojson("_87", _87);
    querybycodeform = querybycodeform + _87 + ",";
    //联系电话
    var _86 = $("#_86").textbox('getValue');
    _86 = tojson("_86", _86);
    querybycodeform = querybycodeform + _86 + ",";
    //籍贯
    var _89 = $("#_89").textbox('getValue');
    _89 = tojson("_89", _89);
    querybycodeform = querybycodeform + _89 + ",";
    //门诊流水号
    var _90 = $("#_90").textbox('getValue');
    _90 = tojson("_90", _90);
    querybycodeform = querybycodeform + _90 + ",";
    //患者ID
    var _91 = $("#_91").textbox('getValue');
    _91 = tojson("_91", _91);
    querybycodeform = querybycodeform + _91 + ",";
    //住院ID
    var _93 = $("#_93").textbox('getValue');
    _93 = tojson("_93", _93);
    querybycodeform = querybycodeform + _93 + ",";
    //挂号ID 
    var _92 = $("#_92").textbox('getValue');
    _92 = tojson("_92", _92);
    querybycodeform = querybycodeform + _92;
    //序列化字段为JSON for 基本数据END
    //ClinicalInfoDg
    var _ClinicalInfoDg = $('#ClinicalInfoDg').datagrid('getChecked');
    var rowClinicalInfoDg = JSON.stringify(_ClinicalInfoDg);
    rowClinicalInfoDg = tojson("ClinicalInfoDg", rowClinicalInfoDg);
    //SampleInfoDiv
    var sampleInfoDiv = "";
    //采集人
    var _99 = $("#_99").textbox('getValue');
    _99 = tojson("_99", _99);
    sampleInfoDiv = _99 + ",";
    //采集目的
    var _100 = $("#_100").textbox('getValue');
    _100 = tojson("_100", _100);
    sampleInfoDiv = sampleInfoDiv + _100 + ",";
    //取材日期
    var _103 = $("#_103").textbox('getValue');
    _103 = tojson("_103", _103);
    sampleInfoDiv = sampleInfoDiv + _103 + ",";
    //取材方式
    var _101 = $("#_101").combobox('getValues');
    _101 = tojson("_101", _101);
    sampleInfoDiv = sampleInfoDiv + _101 + ",";
    //取材时间
    var _104 = $("#_104").textbox('getValue');
    _104 = tojson("_104", _104);
    sampleInfoDiv = sampleInfoDiv + _104 + ",";
    //取材描述
    var _110 = $("#_110").textbox('getValue');
    _110 = tojson("_110", _110);
    sampleInfoDiv = sampleInfoDiv + _110 + ",";
    //取材医护
    var _109 = $("#_109").textbox('getValue');
    _109 = tojson("_109", _109);
    sampleInfoDiv = sampleInfoDiv + _109 + ",";
    //研究方案
    var _102 = $("#_102").textbox('getValue');
    _102 = tojson("_102", _102);
    sampleInfoDiv = sampleInfoDiv + _102 + ",";
    //过期日期
    var _107 = $("#_107").textbox('getValue');
    _107 = tojson("_107", _107);
    sampleInfoDiv = sampleInfoDiv + _107 + ",";
    //备注
    var _112 = $("#_112").textbox('getValue');
    _112 = tojson("_112", _112);
    sampleInfoDiv = sampleInfoDiv + _112 + "";
    //sampleInfoDiv end
    var _dg_SampleInfo = $('#dg_SampleInfo').datagrid('getChecked');
    var rowdg_SampleInfo = JSON.stringify(_dg_SampleInfo);
    rowdg_SampleInfo = tojson("dg_SampleInfo", rowdg_SampleInfo);
    //拼接字符串
    querybycodeform = tojson("querybycodeform", querybycodeform);
    sampleInfoDiv = tojson("sampleInfoDiv", sampleInfoDiv);
    var str = tojson("mianfrom", querybycodeform + "," + rowClinicalInfoDg + "," + sampleInfoDiv + "," + rowdg_SampleInfo);
    return str;
}
//转化为JSON数据
function tojson(name,values)
{
    var str;
    str = '{\"' + name + '\":' + values + '\"}';
    return str;
}

//显示COMBOXvalue
var comboboxData;
var  depOrProId;
$(function option()
{
    var url = "";

})
