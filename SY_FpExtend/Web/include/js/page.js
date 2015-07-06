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
        pagination: true,
        pagePosition: 'bottom',
        pageNumber: 1,
        pageSize: 5,
        pageList: [5, 10, 15, 20],
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
                    for (var i = 0; i < rows.length; i++) {
                        if (rows[i].DiagnoseDateTime == undefined || rows[i].DiagnoseDateTime == "") {
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
    //var pager = $("#ClinicalInfoDg").datagrid("getPager");
    //pager.pagination({
    //    onSelectPage: function (pageNo, pageSize) {
    //        var data = $("#ClinicalInfoDg").datagrid("getData");
    //        var arr = [];
    //        for (var i = 0; i < data.rows.length - 1; i++) {
    //            arr.push
    //                ({
    //                    "Description": data.rows[i].Description,
    //                    "DiagnoseDateTime": data.rows[i].DiagnoseDateTime,
    //                    "DiagnoseTypeFlag": data.rows[i].DiagnoseTypeFlag,
    //                    "DiseaseName": data.rows[i].DiseaseName,
    //                    "ICDCode": data.rows[i].ICDCode
    //                });
    //        }
    //        var start = (pageNo - 1) * pageSize;
    //        var end = start + pageSize;
    //        $("#ClinicalInfoDg").datagrid("loadData", arr.slice(start, end));
    //        pager.pagination('refresh', {
    //            total: data.rows.length,
    //            pageNumber: pageNo
    //        });
    //    }
    //});
})
//function pagerFilter(data) {
//    var dg = $('#ClinicalInfoDg').datagrid();
//    var opts = dg.datagrid('options');
//    var pager = dg.datagrid('getPager');
//    pager.pagination({
//        onSelectPage: function (pageNum, pageSize) {
//            opts.pageNumber = pageNum;
//            opts.pageSize = pageSize;
//            pager.pagination('refresh', {
//                pageNumber: pageNum,
//                pageSize: pageSize
//            });
//            dg.datagrid('loadData', data);
//        }
//    });
//    if (!data.originalRows) {
//        data.originalRows = (data.rows);
//    }
//    var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
//    var end = start + parseInt(opts.pageSize);
//    data.rows = (data.Rows.slice(start, end));
//    return data;
//}
//诊断类型JSON
var SampleInfotarget;
var SampleInfobool = true;
var SampleInfoadd = true;
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
            {
                field: 'Organ', title: '器官系统', width: '30%', align: 'center',
                editor: {
                    type: 'combobox',
                    options:
                     {
                         data: getDtaJsonSampleInfo,
                         valueField: 'ID',
                         textField: 'NAME',
                         editable: false,
                         panelHeight: 'auto',
                         required: false,
                         onSelect: function (rec) {
                             var row = $dg_SampleInfo.datagrid("getSelections");
                             var rowIndex = $dg_SampleInfo.datagrid('getRowIndex', row[0]);
                             var target = $('#dg_SampleInfo').datagrid('getEditor', { 'index': rowIndex, 'field': 'Classification' }).target;
                             SampleInfotarget = target;
                             target.combobox('clear');
                             var url = '../Fp_Ajax/PageConData.aspx?conMarc=linkagefrom&id=' + rec.ID;
                             liandongurl = url;
                             if (liandongurl == "") { return; }
                             var liandongdata = getliandongJsonurl(liandongurl);
                             var getDtaJsonliandong = JSON.parse(liandongdata);
                             var getDtaJsonliandong2 = getDtaJsonliandong.ds;
                             target.combobox('loadData', getDtaJsonliandong2);
                         }
                     }
                }, formatter: function (value, rowData, rowIndex) {
                    var getData = getSampleInfourlJsonurl(SampleInfourl);
                    var getDtaJson = JSON.parse(getData);
                    var getDtaJsonds = getDtaJson.ds;
                    if (getDtaJsonds != "" || getDtaJsonds != null) {
                        for (var i = 0; i < getDtaJsonds.length; i++) {
                            if (getDtaJsonds[i].ID == value) {
                                if (liandongurl == "") { return; }
                                else
                                {
                                    var com2value = SampleInfotarget.combobox("getValue");
                                    var liandongdata = getliandongJsonurl(liandongurl);
                                    var getDtaJsonliandong = JSON.parse(liandongdata);
                                    var getDtaJsonliandong2 = getDtaJsonliandong.ds;
                                    for (var j = 0; j < getDtaJsonliandong2.length; j++) {
                                        if (com2value == getDtaJsonliandong2[j].ID) {
                                            getDtaJsonliandong2[j].NAME;
                                            SampleInfotarget.combobox("setText", getDtaJsonliandong2[j].NAME);
                                        }
                                    }
                                    //target.combobox('loadData', getDtaJsonliandong2);
                                }
                                return getDtaJsonds[i].NAME;
                            }
                        }
                    }
                    else { return value; }
                }
            },
            {
                field: 'Classification', title: '二级下拉', width: '30%', align: 'center', editor: {
                    type: 'combobox', options: {
                        valueField: 'NAME',
                        textField: 'NAME'
                    },
                    formatter: function (value, rowData, rowIndex) {
                        if (liandongurl == "") { return; }
                        var getData = getliandongJsonurl(liandongurl);
                        var getDtaJson = JSON.parse(getData);
                        var getDtaJsonds = getDtaJson.ds;
                        if (getDtaJsonds != "" || getDtaJsonds != null) {
                            for (var i = 0; i < getDtaJsonds.length; i++) {
                                if (getDtaJsonds[i].ID == value) { return getDtaJsonds[i].NAME; }
                            }
                        }
                        else { return value; }
                    }
                }
            }
            //{ field: 'Remark', title: '备注', width: '40%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },//动态列--根据样品类型展示不同的数据

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
                        var rows = $dg_SampleInfo.datagrid('getRows');
                        for (var i = 0; i < rows.length; i++) {
                            if (rows[i].SampleType == null || rows.Scount == "" || rows.Organ == "") {
                                $.messager.alert('提示', '请保存上一条样品后再继续添加', 'error');
                                $dg_SampleInfo.datagrid('beginEdit', i);
                                return;
                            }
                        };
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
                    for (var i = 0; i < rows.length; i++) {
                        if (rows[i].Scount <= 0 || rows[i].Scount == "" || rows[i].SampleType == "" || rows[i].SampleType == undefined) {
                            $dg_SampleInfo.datagrid('beginEdit', i);
                            bool = false;
                        }
                    }
                    if (bool == true) {
                        SampleInfoadd = true;
                        $dg_SampleInfo.datagrid('endEdit', editRow);
                        var rowstr = JSON.stringify(rows);
                    }
                    else {
                        SampleInfoadd = false;
                        $.messager.alert('提示', '试管数量必须大于0,且样本类型不能为空', 'error');
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
        //selectOnNavigation:$(this).is(':checked'),
        onLoadSuccess: function () { //数据加载完毕事件
            //$("#In_CodeType").combobox('setValue', '住院号');
        }
    })
})

//给sample_source_typecmb下拉框绑定值
$(function () {
    $('#sample_source_typecmb').combobox({
        editable: false,
        method: 'get',
        valueField: 'value',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SampleSocrceType',
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

//给取材时段下拉框绑定值
$(function () {
    $('#_113').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SamplingMethod',
        multiple: true,
        method: 'get',
        valueField: 'samplingMethod',
        textField: 'text',
        panelHeight: 'auto'
    });
})
//绑定采集人
$(function () {
    $('#_99').combobox({
        editable: true,
        panelHeight: '200px',
        delay: '600',
        valueField: 'EmployeeNo',
        textField: 'EmployeeName',
        onChange: function (newVal, oldVal) {
            var faultAddr = encodeURI(newVal);
            //faultAddr = encodeURI(faultAddr);  //需要通过两次编码
            if (newVal == "" || newVal == oldVal) {
                $('#_99').combobox('clear');
                return;
            }
            else {
                var url = '../Fp_Ajax/PageConData.aspx?conMarc=Employee&com=' + faultAddr;
                $('#_99').combobox('reload', url);
            }
        },
        onHidePanel: function () {
            var o = $('#_99').combobox('getValue');//获取采集人的EmployeeNo
            var url = '../Fp_Ajax/PageConData.aspx?conMarc=Employee&com=' + o;
            var temp = getEmployee(url);
            var tempjson = JSON.parse(temp);
            $('#_109').combobox({
                editable: true,
                data: tempjson,
                valueField: 'EmployeeNo',
                textField: 'EmployeeName'
            });
            $('#_109').combobox('setValue', tempjson.EmployeeName);
        }
    });
})
function getEmployee(Employeeurl) {
    var temp;
    $.ajax({
        type: 'get',
        url: Employeeurl,
        async: false,
        datatype: 'json',
        success: function (responseData) {
            temp = responseData;
        }
    });
    return temp;
}

//POST数据
function postData() {
    var name = $('#_80').textbox('getText');
    var hzid = $('#_91').textbox('getText');
    if (name == "" || hzid == "") { $.messager.alert('提示', '必须输入姓名以及患者ID', 'error'); return; }
    else
    {
        var strcodeform = querybycodeform();
        //ClinicalInfoDg 
        var _ClinicalInfoDg = $('#ClinicalInfoDg').datagrid('getChecked');
        for (var i = 0; i < _ClinicalInfoDg.length - 1; i++) {
            if (_ClinicalInfoDg[i].DiagnoseDateTime == "") {
                $.messager.alert('提示', '诊断日期存在未输入字段，请重新输入', 'error'); return;
            }
        }
        var rowClinicalInfoDg = JSON.stringify(_ClinicalInfoDg);
        var strSampleInfoDiv = getSampleInfoFormData();
        //querySampleInfoDiv();
        //_dg_SampleInfo
        var _dg_SampleInfo = $('#dg_SampleInfo').datagrid('getRows');
        for (var i = 0; i < _dg_SampleInfo.length - 1; i++) {
            if (_dg_SampleInfo[i].Scount == "" || _dg_SampleInfo[i].Scount == 0 || _dg_SampleInfo[i].Scount < 0) {
                $.messager.alert('提示', '试管数必须大于1', 'error'); return;
            }
        }
        var rowdg_SampleInfo = JSON.stringify(_dg_SampleInfo);
        //var sueedata = '{"success": true,"msg": "1 条记录成功导入.","message": "1 条记录成功导入.","status": "DONE","job_id": "source_importers:import:27b08e12c9332b983e68a074a27876d4"}';
        //var data = JSON.parse(sueedata);
        //if (data.success == true) {
        //    $.messager.alert('提示', '导入成功：' + data.message); return;
        //}
        //else { $.messager.alert('提示', '导入失败：' + data.message); return; }
        $.ajax({
            type: 'post',
            url: '/Fp_Ajax/SubmitData.aspx?action=gethisdata&codeform=' + strcodeform + '&_ClinicalInfoDg=' + rowClinicalInfoDg + '&strSampleInfoDiv='
                + strSampleInfoDiv + '&_dg_SampleInfo=' + rowdg_SampleInfo,
            onSubmit: function () { },
            success: function (data) {
                if (data == "") { $.messager.alert('提示', '服务器未响应', 'error'); return; }
                else
                {
                    var getData = $.parseJSON(data);
                    if (getData.success == true) {
                        $.messager.alert('提示', '导入成功：' + data.message); return;
                    }
                    else { $.messager.alert('提示', '导入失败：' + data.message); return; }
                }
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

//SampleInfoDiv 数据获取
function querySampleInfoDiv() {
    var sampleInfoDiv = "";
    //采集人
    var _99 = $("#_99").combobox('getValue');
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
    var _109 = $("#_109").combobox('getValue');
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
if (getDtaJsonSampleType) {
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
//if (getdtaSampleInfo) {
getdtaSampleInfo = JSON.parse(getSampleInfoData);
getDtaJsonSampleInfo = getdtaSampleInfo.ds;
////}

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
    var hzid = $('#_91').textbox('getText');
    if (name == "" || hzid == "") { $.messager.alert('提示', '必须输入姓名以及患者ID', 'error'); return; }
    else
    {
        var _baseinfo = getBaseInfoFormData();

        //var _baseinfo=querySampleInfoDiv();
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
                if (data == "") { $.messager.alert('提示', '服务器未响应', 'error'); return; }
                else
                {
                    var getData = $.parseJSON(data);
                    if (getData.success == true) {
                        $.messager.alert('提示', '导入成功：' + data.message); return;
                    }
                    else { $.messager.alert('提示', '导入失败：' + data.message); return; }
                }
            }
        });
    }

}

//POST数据
function postPatientInfo() {
    var name = $('#_80').textbox('getText');
    var hzid = $('#_91').textbox('getText');
    var sample_source_type = $('#sample_source_typecmb').combobox('getValue')
    if (!sample_source_type) { $.messager.alert('提示', '必须选择基本信息类型', 'error'); return; }
    if (name == "" || hzid =="") { $.messager.alert('提示', '必须输入姓名以及患者ID', 'error'); return; }
    else
    {
        var _baseinfo = getBaseInfoFormData();

        //ClinicalInfoDg 
        var _ClinicalInfoDg = $('#ClinicalInfoDg').datagrid('getChecked');
        if (_ClinicalInfoDg) {
            for (var i = 0; i < _ClinicalInfoDg.length - 1; i++) {
                if (_ClinicalInfoDg[i].DiagnoseDateTime == "") {
                    $.messager.alert('提示', '请选择诊断日期', 'error'); return;
                }
            }
        }
        var rowClinicalInfoDg = JSON.stringify(_ClinicalInfoDg);
        $.ajax({
            type: 'post',
            dataType: "json",
            url: '/Fp_Ajax/SubmitData.aspx?action=postPatientinfo',
            data: {
                sample_source_type:sample_source_type,
                baseinfo: _baseinfo,
                clinicalInfoDg: rowClinicalInfoDg
            },
            onSubmit: function () {

            },
            success: function (data) {
                if (data) {
                    if (data.success == "True") { $.messager.show({ title: '提示！', msg: '导入成功：' + data.msg, showType: 'show' }); return; }
                    else if (data.success == "False") { $.messager.show({ title: '提示！', msg: '导入失败：' + data.msg, showType: 'show' }); return; }
                }
                else {
                    $.messager.alert('提示', '服务器未响应', 'error'); return;
                }
                //推送不过加个注释
            }
        });
    }
}

function getBaseInfoFormData() {
    var sampleinfo = $("#BaseInfoForm").serializeArray();
    var base;
    if (sampleinfo) {
        base = JSON.stringify(sampleinfo);
    }
    return base;
}

function getSampleInfoFormData() {
    var sampleinfo = $("#SampleInfoForm").serializeArray();
    var samp;
    if (sampleinfo) {
        samp = JSON.stringify(sampleinfo);
    }
    return samp;
}