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
                editor: {
                    type: 'combobox',
                    options: {
                        data: getDtaJsonDiagnoseTypeFlag,
                        valueField: 'DiagnoseTypeFlag',
                        textField: 'text',
                        editable: false,
                        panelHeight: 'auto',
                        required: true
                    }
                }, formatter: function (value, rowData, rowIndex) {
                    var getData = getDiagnoseTypeFlagJsonurl(Diagnoseurl);
                    var getDtaJson = JSON.parse(getData);
                    if (getDtaJson != "" || getDtaJson != null) {
                        for (var i = 0; i < getDtaJson.length; i++) {
                            if (getDtaJson[i].DiagnoseTypeFlag == value) { return getDtaJson[i].text; }
                        }
                    }
                    else { return value; }
                }
            },
            {
                field: 'DiagnoseDateTime', title: '诊断日期', width: '20%', sortable: true, editor: { type: 'datebox', options: { required: false } }
            },
            { field: 'ICDCode', title: 'ICD码', width: '15%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'DiseaseName', title: '疾病名称', width: '20%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'Description', title: '疾病描述', width: '20%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },
        ]],
        singleSelect: false,
        fitColumns: true,
        rownumbers: true,//行号 
        pagination: {
            pageSize: 10,//每页显示的记录条数，默认为10 
            pageList: [5, 10, 15],//可以设置每页记录条数的列表 
            beforePageText: '第',//页数文本框前显示的汉字 
            afterPageText: '页    共 {pages} 页',
            displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录',
            onRefresh: function (pageNumber, pageSize) {
                alert(pageNumber, pageSize);
            }
        },
        toolbar: [
            {
                text: '添加', iconCls: 'icon-add', handler: function () {
                    if (editRow != undefined) {
                        $ClinicalInfoDg.datagrid('endEdit', editRow);
                    }
                    if (editRow == undefined) {
                        $ClinicalInfoDg.datagrid('insertRow', { index: 0, row: {} });
                        $ClinicalInfoDg.datagrid('beginEdit', 0);
                        editRow = undefined;
                    }
                }
            }, '-', {
                text: '保存', iconCls: 'icon-save', handler: function () {
                    $('#ClinicalInfoDg').datagrid('acceptChanges');
                    var rows = $ClinicalInfoDg.datagrid('getRows');
                    var bool = true;
                    for (var i = 0; i < rows.length; i++)
                    {
                        if (rows[i].DiagnoseDateTime == undefined || rows[i].DiagnoseDateTime == "")
                        {
                            $ClinicalInfoDg.datagrid('beginEdit', i);
                            bool = false;
                        }
                    }
                    if (bool == true) {
                        $ClinicalInfoDg.datagrid('endEdit', editRow);
                        var rowstr = JSON.stringify(rows);
                    }
                    else {
                        $.messager.alert('提示', '日期不能为空', 'error');
                    }
                }
            }, '-', {
                text: '删除', iconCls: 'icon-remove', handler: function () {
                    var row = $ClinicalInfoDg.datagrid('getChecked');
                    for (var i = 0; i < row.length; i++) {
                        var rowIndex = $ClinicalInfoDg.datagrid('getRowIndex', row[i]);
                        $ClinicalInfoDg.datagrid('deleteRow', rowIndex);
                    }
                    $("#ClinicalInfoDg").datagrid("clearSelections");
                    //if (row) {
                    //    var rowIndex = $ClinicalInfoDg.datagrid('getRowIndex', row);
                    //    $ClinicalInfoDg.datagrid('deleteRow', rowIndex);
                    editRow == undefined;
                    //}
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
                    } else { }
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
    });
})
//诊断类型JSON
var SampleInfotarget;
//初始化样本信息面板
$(function () {
    var editRow = undefined;
    var $dg_SampleInfo = $('#dg_SampleInfo');
    $dg_SampleInfo.datagrid({
        title: '样本信息',
        columns: [[
            {
                field: 'SampleType', title: '样品类型', width: '25%', align: 'center', editor: {
                    type: 'combobox', options: {
                        data: getDtaJsonSampleType,
                        valueField: 'value',
                        textField: 'text',
                        editable: false,
                        panelHeight: 'auto',
                        required: true
                    }
                }, formatter: function (value, rowData, rowIndex) {
                    var getData = getSampleTypeJson(SampleTypeurl);
                    if (getData) {
                        var getDtaJson = JSON.parse(getData);
                        for (var i = 0; i < getDtaJson.length; i++) {
                            if (getDtaJson[i].value == value) { return getDtaJson[i].text; }
                        }
                    }
                    else { return value; }
                }
            },
            { field: 'Scount', title: '管数', width: '5%', align: 'center', editor: { type: 'numberbox', options: { required: false } } },
            //{
            //    field: 'SystemOrgan', title: '器官系统', width: '20%',
            //    editor: {
            //        type: 'combobox',
            //        options:
            //         {
            //            data: getDtaJsonSampleInfo,
            //            valueField: 'ID',
            //            textField: 'NAME',
            //            editable: false,
            //            panelHeight: 'auto',
            //            required: true,
            //            onSelect: function (rec)
            //            {
            //                var row = $dg_SampleInfo.datagrid("getSelections");
            //                var rowIndex = $dg_SampleInfo.datagrid('getRowIndex', row[0]);
            //                var target = $('#dg_SampleInfo').datagrid('getEditor', { 'index': rowIndex, 'field': 'combox2' }).target;
            //                SampleInfotarget = target;
            //                target.combobox('clear');
            //                var url = '../Fp_Ajax/PageConData.aspx?conMarc=linkagefrom&id=' + rec.ID;
            //                liandongurl = url;
            //                if (liandongurl == "") { return; }
            //                var liandongdata = getliandongJsonurl(liandongurl);
            //                var getDtaJsonliandong = JSON.parse(liandongdata);
            //                var getDtaJsonliandong2 = getDtaJsonliandong.ds;
            //                target.combobox('loadData', getDtaJsonliandong2);
            //            }
            //          } 
            //    }, formatter: function (value, rowData, rowIndex)
            //    {
            //        var getData = getSampleInfourlJsonurl(SampleInfourl);
            //        var getDtaJson = JSON.parse(getData);
            //        var getDtaJsonds = getDtaJson.ds;
            //        if (getDtaJsonds != "" || getDtaJsonds != null)
            //        {
            //            for (var i = 0; i < getDtaJsonds.length; i++)
            //            {
            //                if (getDtaJsonds[i].ID == value)
            //                {
            //                    if (liandongurl == "") { return; }
            //                    else
            //                    {
            //                        var com2value = SampleInfotarget.combobox("getValue");
            //                        var liandongdata = getliandongJsonurl(liandongurl);
            //                        var getDtaJsonliandong = JSON.parse(liandongdata);
            //                        var getDtaJsonliandong2 = getDtaJsonliandong.ds;
            //                        for (var j = 0; j < getDtaJsonliandong2.length; j++) {
            //                            if (com2value == getDtaJsonliandong2[j].ID)
            //                            {
            //                                getDtaJsonliandong2[j].NAME;
            //                                SampleInfotarget.combobox("setText", getDtaJsonliandong2[j].NAME);
            //                            }
            //                        }
            //                        //target.combobox('loadData', getDtaJsonliandong2);
            //                    }
            //                    return getDtaJsonds[i].NAME;
            //                }
            //            }
            //        }
            //        else { return value; }
            //    }
            //    },
            //{
            //    field: 'combox2', title: '联动2', width: '20%', editor: {
            //        type: 'combobox', options: {
            //            valueField: 'ID',
            //            textField: 'NAME',
            //        },
            //        formatter: function (value, rowData, rowIndex) {
            //            if (liandongurl == "") { return;}
            //            var getData = getliandongJsonurl(liandongurl);
            //            var getDtaJson = JSON.parse(getData);
            //            var getDtaJsonds = getDtaJson.ds;
            //            if (getDtaJsonds != "" || getDtaJsonds != null) {
            //                for (var i = 0; i < getDtaJsonds.length; i++) {
            //                    if (getDtaJsonds[i].ID == value) { return getDtaJsonds[i].NAME; }
            //                }
            //            }
            //            else { return value; }
            //        }
            //    }
            //},
            { field: 'Remark', title: '备注', width: '70%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },//动态列--根据样品类型展示不同的数据

        ]],
        singleSelect: false,
        pagination: true,
        toolbar: [
            {
                text: '添加', iconCls: 'icon-add', handler: function () {
                    if (editRow != undefined) {
                        $dg_SampleInfo.datagrid('endEdit', editRow);
                    }
                    if (editRow == undefined) {
                        $dg_SampleInfo.datagrid('insertRow', { index: 0, row: {} });
                        $dg_SampleInfo.datagrid('beginEdit', 0);
                        editRow = undefined;
                    }
                }
            }, '-',
            {
                text: '保存', iconCls: 'icon-save', handler: function () {
                    $('#dg_SampleInfo').datagrid('acceptChanges');
                    var rows = $dg_SampleInfo.datagrid('getRows');
                    var bool = true;
                    for (var i = 0; i < rows.length; i++)
                    {
                        if (rows[i].Scount <= 0 || rows[i].Scount == "")
                        {
                            $dg_SampleInfo.datagrid('beginEdit', i);
                            bool = false;
                        }
                    }
                    if (bool == true) {
                        $dg_SampleInfo.datagrid('endEdit', editRow);
                        var rowstr = JSON.stringify(rows);
                    }
                    else
                    {
                        $.messager.alert('提示', '试管数量必须大于0', 'error');
                    }
                }
            }, '-',
            {
                text: '删除', iconCls: 'icon-remove', handler: function () {
                    var row = $dg_SampleInfo.datagrid('getChecked');
                    for (var i = 0; i < row.length; i++) {
                        var rowIndex = $dg_SampleInfo.datagrid('getRowIndex', row[i]);
                        $dg_SampleInfo.datagrid('deleteRow', rowIndex);
                    }
                    $("#dg_SampleInfo").datagrid("clearSelections");
                    editRow == undefined;
                }
            }, '-',
            {
                text: '修改', iconCls: 'icon-edit', handler: function () {
                    var row = $dg_SampleInfo.datagrid('getSelected');
                    if (row != null) {
                        if (editRow != undefined) { $dg_SampleInfo.datagrid('endEdit', editRow); }
                        if (editRow == undefined) {
                            var index = $dg_SampleInfo.datagrid('getRowIndex', row);
                            $dg_SampleInfo.datagrid('beginEdit', index);
                            editRow = index;
                            $dg_SampleInfo.datagrid('unselectAll');
                        }
                    } else { }
                }
            }],
        onAfterEdit: function (rowIndex, rowData, changes) {
            editRow = undefined;
        },
        onDblClickRow: function (rowIndex, rowData) {
            if (editRow != undefined) {
                $dg_SampleInfo.datagrid('endEdit', editRow);
            }
            if (editRow == undefined) {
                $dg_SampleInfo.datagrid('beginEdit', rowIndex);
                editRow = rowIndex;
            }
        },
        onClickRow: function (rowIndex, rowData) {
            if (editRow != undefined) {
                $dg_SampleInfo.datagrid('endEdit', editRow);
            }
        }
    });
})

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
        panelHeight: 'auto'
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
        panelHeight: 'auto'
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
        panelHeight: 'auto'
    });
})


//POST数据
function postData() {
    var name = $('#_80').textbox('getText');
    if (name == "") { $.messager.alert('提示', '请输入姓名', 'error'); return; }
    else
    {
        var _baseinfo = querybycodeform();
        //ClinicalInfoDg 
        var _ClinicalInfoDg = $('#ClinicalInfoDg').datagrid('getChecked');
        for (var i = 0; i < _ClinicalInfoDg.length - 1; i++) {
            if (_ClinicalInfoDg[i].DiagnoseDateTime == "") {
                $.messager.alert('提示', '诊断日期存在未输入字段，请重新输入', 'error'); return;
            }
        }
        var rowClinicalInfoDg = JSON.stringify(_ClinicalInfoDg);
        var strSampleInfoDiv = querySampleInfoDiv();
        //_dg_SampleInfo
        var _dg_SampleInfo = $('#dg_SampleInfo').datagrid('getRows');
        for (var i = 0; i < _dg_SampleInfo.length - 1; i++) {
            if (_dg_SampleInfo[i].Scount == "" || _dg_SampleInfo[i].Scount == 0 || _dg_SampleInfo[i].Scount < 0) {
                $.messager.alert('提示', '试管数必须大于1', 'error'); return;
            }
        }
        var rowdg_SampleInfo = JSON.stringify(_dg_SampleInfo);

        $.ajax({
            type: 'post',
            url: '/Fp_Ajax/SubmitData.aspx?action=postData',
            data: {
                baseinfo: _baseinfo,
                clinicalInfoDg: rowClinicalInfoDg,
                sampleInfo: strSampleInfoDiv,
                sampleInfoDg: rowdg_SampleInfo
            },
            onSubmit: function () { },
            success: function (data) {
                var getData = $.parseJSON(data);
                if (getData.state) {
                    alert(getData.state);
                }
                else { alert("上传失败"); }
            }
        });
    }

}

//获取页面数据
function querybycodeform() {
    //序列化字段为JSON for 基本数据
    var querybycodeform = "";
    //传入方式、
    var In_CodeType = $('#In_CodeType').textbox('getValue');
    In_CodeType = tojson("In_CodeType", In_CodeType);
    querybycodeform = In_CodeType + ",";
    //传入号码
    var In_Code = $('#In_Code').textbox('getValue');//获取数据源
    In_Code = tojson("In_Code", In_Code);
    querybycodeform = querybycodeform + In_Code + ",";
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
    return querybycodeform;
}

//SampleInfoForm 数据获取
function querySampleInfoDiv() {
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
    return sampleInfoDiv;
}

//SampleInfoForm 数据获取
function getSampleInfoFormData() {
    var sampleinfo = $("#SampleInfoForm").serializeArray();
    var s;
    if (sampleinfo) {
      s=  JSON.stringify(sampleinfo);
    }
    return s;
}

//SampleInfoForm 数据获取
function getBaseInfoFormData() {
    var sampleinfo = $("#BaseInfoForm").serializeArray();
    var s;
    if (sampleinfo) {
        s = JSON.stringify(sampleinfo);
    }
    return s;
}

//转化为JSON数据
function tojson(name, values) {
    var str;
    str = '{\"' + name + '\":' + values + '\"}';
    return str;
}

//显示COMBOXvalue
var comboboxData;
var depOrProId;
$(function option() {
    var url = "";

})

//初始化面板DiagnoseTypeFlagCOMBOBOX
function getDiagnoseTypeFlagJsonurl(Diagnoseurl) {
    var temp;
    $.ajax({
        type: 'get',
        url: Diagnoseurl,
        async: false,
        datatype: 'json',
        success: function (responseData) {
            temp = responseData;
        }
    });
    return temp;
}
var Diagnoseurl = '../Fp_Ajax/PageConData.aspx?conMarc=DiagnoseTypeFlag';
var getDiagnoseTypeFlagData = getDiagnoseTypeFlagJsonurl(Diagnoseurl);
var getDtaJsonDiagnoseTypeFlag = JSON.parse(getDiagnoseTypeFlagData);

//初始化面板SampleType
function getSampleTypeJson(SampleTypeurl) {
    var temp;
    $.ajax({
        type: 'get',
        url: SampleTypeurl,
        async: false,
        //datatype: 'json',
        success: function (responseData) {
            temp = responseData;
        }
    });
    return temp;
}
var SampleTypeurl = '../Fp_Ajax/PageConData.aspx?conMarc=SampleType';
var getSampleTypeData = getSampleTypeJson(SampleTypeurl);
var getDtaJsonSampleType;
if (getSampleTypeData) {
    getDtaJsonSampleType = JSON.parse(getSampleTypeData);
}

//联动数据绑定值
function getSampleInfourlJsonurl(SampleInfourl) {
    var temp;
    $.ajax({
        type: 'get',
        url: SampleInfourl,
        async: false,
        datatype: 'json',
        success: function (responseData) {
            temp = responseData;
        }
    });
    return temp;
}
var SampleInfourl = '../Fp_Ajax/PageConData.aspx?conMarc=linkage';
var getSampleInfoData = getSampleInfourlJsonurl(SampleInfourl);
var getdtaSampleInfo;
var getDtaJsonSampleInfo;
if (getdtaSampleInfo) {
    getdtaSampleInfo = JSON.parse(getSampleInfoData);
    getDtaJsonSampleInfo = getdtaSampleInfo.ds;
}

//下级绑定值
function getliandongJsonurl(liandongurl) {
    var temp;
    $.ajax({
        type: 'get',
        url: liandongurl,
        async: false,
        datatype: 'json',
        success: function (responseData) {
            temp = responseData;
        }
    });
    return temp;
}
var liandongurl;
var getliandongData = getliandongJsonurl(liandongurl);
var getDtaJsonliandong;

//POST数据
function postData1() {
    var name = $('#_80').textbox('getText');
    if (name == "") { $.messager.alert('提示', '请输入姓名', 'error'); return; }
    else
    {
        var _baseinfo = getBaseInfoFormData();

        //ClinicalInfoDg 
        var _ClinicalInfoDg = $('#ClinicalInfoDg').datagrid('getChecked');
        for (var i = 0; i < _ClinicalInfoDg.length - 1; i++) {
            if (_ClinicalInfoDg[i].DiagnoseDateTime == "") {
                $.messager.alert('提示', '诊断日期存在未输入字段，请重新输入', 'error'); return;
            }
        }
        var rowClinicalInfoDg = JSON.stringify(_ClinicalInfoDg);
        //获取sampleinfo 数据
        var strSampleInfoDiv = getSampleInfoFormData();
        //_dg_SampleInfo
        var _dg_SampleInfo = $('#dg_SampleInfo').datagrid('getRows');
        for (var i = 0; i < _dg_SampleInfo.length - 1; i++) {
            if (_dg_SampleInfo[i].Scount == "" || _dg_SampleInfo[i].Scount == 0 || _dg_SampleInfo[i].Scount < 0) {
                $.messager.alert('提示', '试管数必须大于1', 'error'); return;
            }
        }
        var rowdg_SampleInfo = JSON.stringify(_dg_SampleInfo);
        $.ajax({
            type: 'post',
            dataType: "json",
            url: '/Fp_Ajax/SubmitData.aspx?action=postData',
            data: {
                baseinfo: _baseinfo,
                clinicalInfoDg: rowClinicalInfoDg,
                sampleInfo: strSampleInfoDiv,
                sampleInfoDg: rowdg_SampleInfo
            },
            onSubmit: function () {
               
            },
            success: function (data) {
                var getData = $.parseJSON(data);
                if (getData.state) {
                    alert(getData.state);
                }
                else { alert("上传失败"); }
            }
        });
    }

}
