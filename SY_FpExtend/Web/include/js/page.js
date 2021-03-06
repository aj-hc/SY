﻿
/*------------------初始化datagrid--------------------------- */
//初始化临床信息面板
$(function () {
    var editRow = undefined;
    var $ClinicalInfoDg = $('#ClinicalInfoDg');
    $ClinicalInfoDg.datagrid({
        title: '临床信息',
        columns: [[
            { field: 'ck', checkbox: true, width: '5%' },
            { field: 'DiagnoseTypeFlag', title: '诊断类型', width: '12%', editor: { type: 'validatebox', options: { required: false } } },
            { field: 'DiagnoseDateTime', title: '诊断日期', width: '15%', sortable: true, editor: { type: 'datebox', options: { required: false } } },
            { field: 'ICDCode', title: 'ICD码', width: '20%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'DiseaseName', title: '疾病名称', width: '20%', align: 'center', sortable: true, editor: { type: 'validatebox', options: { required: false } } },
            { field: 'Description', title: '疾病描述', width: '20%', align: 'center', editor: { type: 'validatebox', options: { required: false } } },
        ]],
        singleSelect: false,
        fitColumns: true,
        rownumbers: true,//行号
        tools: [{
            // text: '保存',
            iconCls: 'icon-save', handler: function () {
                $('#ClinicalInfoDg').datagrid('acceptChanges');
                var rows = $ClinicalInfoDg.datagrid('getRows');
                var bool = true;
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].DiagnoseDateTime == undefined || rows[i].DiagnoseDateTime == "") {
                        $ClinicalInfoDg.datagrid('beginEdit', i);
                        bool = false;
                    }
                }
                if (bool == true) { $ClinicalInfoDg.datagrid('endEdit', editRow); var rowstr = JSON.stringify(rows); }
                else { $.messager.alert('提示', '日期不能为空', 'error'); }
            }
        }, '-', {
            //text: '添加',
            iconCls: 'icon-add', handler: function () {
                $('#w').window('open');
            },
            position: 'right'
        }, '-', {
            //text: '删除',
            iconCls: 'icon-remove', handler: function () {
                var row = $ClinicalInfoDg.datagrid('getChecked');
                for (var i = 0; i < row.length; i++) {
                    var rowIndex = $ClinicalInfoDg.datagrid('getRowIndex', row[i]);
                    $ClinicalInfoDg.datagrid('deleteRow', rowIndex);
                }
                $("#ClinicalInfoDg").datagrid("clearSelections");
                editRow == undefined;
            }
        }
        ]
        //onAfterEdit: function (rowIndex, rowData, changes) {editRow = undefined;},
        //onClickRow: function (rowIndex, rowData) {if (editRow != undefined) {$ClinicalInfoDg.datagrid('endEdit', editRow);}}
    })
})
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
        singleSelect: false,
        //pagination: true,
        rownumbers: true,
        columns: [[
            { field: 'SampleType', title: '样品类型', width: '20%', align: 'center' },
            //{ field: 'SampleGroup', title: '样品组', width: '20%', align: 'center' },
            { field: 'Volume', title: '体积', width: '5%', align: 'center' },
            { field: 'Scount', title: '管数', width: '5%', align: 'center' },
            //{ field: 'Organ', title: '器官', width: '20%', align: 'center' },
            //{ field: 'OrganSubdivision', title: '器官细分', width: '30%', align: 'center' },
            { field: 'laiyuan', title: '样品来源', width: '10%', align: 'center', hidden: 'false' },
            { field: 'yongtu', title: '用途', width: '15%', align: 'center', hidden: 'false' },
            { field: 'Sample_group', title: '样品组', width: '15%', align: 'center', hidden: 'false' }
        ]],
        tools: [
            //{
            //    // text: '保存',
            //    iconCls: 'icon-save',
            //    handler: function () {
            //        $('#dg_SampleInfo').datagrid('acceptChanges');
            //        //var rows = $dg_SampleInfo.datagrid('getRows');
            //        //var bool = true;
            //        //for (var i = 0; i < rows.length; i++) {
            //        //    if (rows[i].Scount <= 0 || rows[i].Scount == "" || rows[i].SampleType == "" || rows[i].SampleType == undefined) {
            //        //        $dg_SampleInfo.datagrid('beginEdit', i);
            //        //        bool = false;
            //        //    }
            //        //}
            //        //if (bool == true) {
            //        //    SampleInfoadd = true;
            //        //    $dg_SampleInfo.datagrid('endEdit', editRow);
            //        //    var rowstr = JSON.stringify(rows);
            //        //}
            //        //else {
            //        //    SampleInfoadd = false;
            //        //    $.messager.alert('提示', '试管数量必须大于0,且样本类型不能为空', 'error');
            //        //}
            //    }
            //}, '-',
            {
                // text: '添加',
                iconCls: 'icon-add',
                handler: function () {
                    //var rows= $('#dg_SampleInfo').datagrid('getRows');
                    //for (var i = 0; i < rows.length; i++)
                    //{
                    //    var strstate = rows[i].State;
                    //    if (strstate.indexOf("重新提交") > 0)
                    //    {
                    //        $.messager.alert('提示', '请把未提交的样本信息提交后再添加', 'error');
                    //        return;
                    //    }
                    // }
                    $('#addSampleForm').window('open');
                }
            }, '-',
            {
                //text: '删除',
                iconCls: 'icon-remove',
                handler: function () {
                    var row = $dg_SampleInfo.datagrid('getChecked');
                    for (var i = 0; i < row.length; i++) {
                        var rowIndex = $dg_SampleInfo.datagrid('getRowIndex', row[i]);
                        $dg_SampleInfo.datagrid('deleteRow', rowIndex);
                    }
                    $("#dg_SampleInfo").datagrid("clearSelections");
                    editRow == undefined;
                }
            }],
        onAfterEdit: function (rowIndex, rowData, changes) { editRow = undefined; },
        onDblClickRow: function (rowIndex, rowData) {
            if (editRow != undefined) { $dg_SampleInfo.datagrid('endEdit', editRow); }
            if (editRow == undefined) { $dg_SampleInfo.datagrid('beginEdit', rowIndex); editRow = rowIndex; }
        },
        onClickRow: function (rowIndex, rowData) {
            if (editRow != undefined) { $dg_SampleInfo.datagrid('endEdit', editRow); }
        }
    });
})
/*------------------初始化datagrid end--------------------------- */

/*------------------基本信息绑定--------------------------- */
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

//给In_CodeType下拉框绑定值
$(function () {
    var username = $.cookie('username');
    var In_CodeType = $.cookie(username + 'In_CodeType');
    $('#In_CodeType').combobox({
        editable: false,
        method: 'get',
        valueField: 'In_CodeType',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=In_CodeType',
        panelHeight: 'auto',
        onChange: In_CodeTypeChange,
        //selectOnNavigation:$(this).is(':checked'),
        onLoadSuccess: function () { //数据加载完毕事件
            //$("#In_CodeType").combobox('setValue', '住院号');
            if (In_CodeType) {
                $('#In_CodeType').combobox('setValue', In_CodeType);
                //绑定数据到页面
                if (In_CodeType == "1") {
                    //给门诊流水号输入框绑定值
                }
            }
        }
    })
})
//重写In_CodeType COOKIE
function In_CodeTypeChange() {
    var username = $.cookie('username');
    var In_CodeType = $('#In_CodeType').combobox('getValue');
    //清除cookie 
    $.cookie(username + "In_CodeType", null);
    //重写cookie
    $.cookie(username + 'In_CodeType', In_CodeType, { expires: 7 });
}

//给departments下拉框绑定值
$(function () {
    $('#departments').combobox({
        editable: false,
        method: 'get',
        valueField: 'value',
        textField: 'text',
        url: '../Fp_Ajax/PageConData.aspx?conMarc=departments',
        panelHeight: 'auto',
        onLoadSuccess: function () { //数据加载完毕事件
            //$("#In_CodeType").combobox('setValue', '住院号');
        }
    })
})

/*------------------基本信息绑定 end--------------------------- */

/*------------------标本信息绑定--------------------------- */

//绑定信息录入人
$(function () {
    $('#_99').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=lur',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto',
        onChange: function (newValue, oldValue) {
            if (newValue != null) {
                var Num = MathRand();
                var Newurl = '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=lur&num=' + Num;
                $('#_99').combobox('reload', Newurl);
            }
        }
    });
})
//绑定采集目的
$(function () {
    $('#_100').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=cjmd',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto',
        onChange: function (newValue, oldValue) {
            if (newValue != null) {
                var Num = MathRand();
                var Newurl = '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=cjmd&num=' + Num;
                $('#_100').combobox('reload', Newurl);
            }
        }
    });
})
//绑定取材医护
$(function () {
    $('#_109').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=qcyh',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto',
        onChange: function (newValue, oldValue) {
            if (newValue != null) {
                var Num = MathRand();
                var Newurl = '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=qcyh&num=' + Num;
                $('#_109').combobox('reload', Newurl);
            }
        }
    });
})
//研究方案
$(function () {
    $('#_102').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=yjfa',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto',
        onChange: function (newValue, oldValue) {
            if (newValue != null) {
                var Num = MathRand();
                var Newurl = '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=yjfa&num=' + Num;
                $('#_102').combobox('reload', Newurl);
            }
        }
    });
})
//取材时段
$(function () {
    $('#_113').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=qcsd',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto',
        onChange: function (newValue, oldValue) {
            if (newValue != null) {
                var Num = MathRand();
                var Newurl = '../Fp_Ajax/PageConData.aspx?conMarc=QuerySetting&valueType=qcsd&num=' + Num;
                $('#_113').combobox('reload', Newurl);
            }
        }
    });
})

/*------------------标本信息绑定 end--------------------------- */

/*------------------临床信息添加框--------------------------- */
//诊断类型
$(function () {
    $('#diagnoseTypeFlag').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=DiagnoseTypeFlag',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto'
    });
})
//ICD码
$(function () {
    $('#icdcode').combobox({
        editable: true,
        panelHeight: '200px',
        delay: '600',
        valueField: 'ICDCode',
        textField: 'ICDCode',
        onChange: function (newVal, oldVal) {
           var faultAddr = encodeURI(newVal);
            if (newVal == "" || newVal == oldVal) {
                $('#icdcode').combobox('clear');
                return;
            }
            else {
                var url = '../Fp_Ajax/PageConData.aspx?conMarc=ICDCode&com=' + faultAddr;
                $('#icdcode').combobox('reload', url);
            }
        },
        onHidePanel: function () {
            //将ICD码的中文名称读取到界面上
            //清空原有值
            $('#diseaseName').textbox('setText',"");
            var o = $('#icdcode').combobox('getValue');//获取ICD码
            var faultAddr = encodeURIComponent(o);//转码处理特殊字符
            var url = '../Fp_Ajax/PageConData.aspx?conMarc=ICDName&com=' + faultAddr;
            $.ajax({
                type:'get',
                url:url,
                dataType:'text',
                success:function(data)
                {
                    //重新赋值
                    if (data != "")
                    {
                        $('#diseaseName').textbox('setText', data);
                    }
                }
            });
        }
    })  
});

/*------------------临床信息添加框 end--------------------------- */

/*------------------样品信息添加框--------------------------- */
//样品类型
$(function () {
    $('#sampleTypeE').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SampleType',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto',
        onSelect: function (rec) {
            var text = $('#sampleTypeE').combobox('getValue');
            $('#volumeE').textbox('clear');
            $('#volumeE').textbox('setValue', '0');
        }
    });
})
//体积
$(function () {
    $('#volumeE').combobox({
        valueField: 'value',
        textField: 'text',
        multiple:false,
        data: [{
            value: '500',
            text: '500'
        },{
            value: '400',
            text: '400'
        },{
            value: '300',
            text: '300'
        }, {
            value: '200',
            text: '200'
        }, {
            value: '100',
            text: '100'
        }],
        panelHeight: 'auto'
    });
})
//管数
$(function () {
    $('#ScountE').combobox({
        valueField: 'value',
        textField: 'text',
        multiple: false,
        data: [{
            value: '5',
            text: '5'
        }, {
            value: '4',
            text: '4'
        }, {
            value: '3',
            text: '3'
        }, {
            value: '2',
            text: '2'
        }, {
            value: '1',
            text: '1'
        }],
        panelHeight: 'auto'
    });
})
//样品来源
$(function () {
    $('#sampleType_S').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SampleType_S',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto'
    });
})
//用途
$(function () {
    $('#sampleType_U').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SampleType_U',
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto'
    });
})
//样品课题组
$(function () {
    var username = $.cookie('username');
    var keshi = $.cookie(username + 'department');

    $('#SampleGroupE').combobox({
        url: '../Fp_Ajax/PageConData.aspx?conMarc=SampleType_keti&keti=' + keshi,
        method: 'get',
        valueField: 'text',
        textField: 'text',
        panelHeight: 'auto'
    });
    //$.ajax({
    //            type: 'get',
    //            url: '../Fp_Ajax/PageConData.aspx?conMarc=SampleType_keti&keti=' + keshi,
    //            method: 'get',
    //            //async: false,
    //            //success: function (data)
    //            //{
    //            //    $('#SampleGroupE').combobox('setValue',data);
    //            //}
    //        });
})
/*------------------样品信息添加框 end--------------------------- */

/*------------------辅助--------------------------- */
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
//初始化面板DiagnoseTypeFlagCOMBOBOX
function getDiagnoseTypeFlagJsonurl(Diagnoseurl) {
    var temp;
    $.ajax({
        type: 'get',
        url: Diagnoseurl,
        async: false,
        datatype: 'json',
        success: function (responseData) { temp = responseData; }
    });
    return temp;
}
var Diagnoseurl = '../Fp_Ajax/PageConData.aspx?conMarc=DiagnoseTypeFlag';
var getDiagnoseTypeFlagData = getDiagnoseTypeFlagJsonurl(Diagnoseurl);
var getDtaJsonDiagnoseTypeFlag = JSON.parse(getDiagnoseTypeFlagData);
//生成随机数
function MathRand() {
    var Num = "";
    for (var i = 0; i < 6; i++) {
        Num += Math.floor(Math.random() * 10);
    }
    return Num;
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












//注释掉的方法，暂未启用

//function getEmployee(Employeeurl) {
//    var temp;
//    $.ajax({
//        type: 'get',
//        url: Employeeurl,
//        async: false,
//        datatype: 'json',
//        success: function (responseData) {
//            temp = responseData;
//        }
//    });
//    return temp;
//}
////样品组
//$(function () {
//    var url = '../Fp_Ajax/PageConData.aspx?conMarc=SampleGroups';
//    var dataJson = getSampleGroups(url);
//    if (dataJson == "]") {

//    }
//    else
//    {
//        $('#SampleGroupE').combobox({
//            url: '../Fp_Ajax/PageConData.aspx?conMarc=SampleGroups',
//            method: 'get',
//            valueField: 'text',
//            textField: 'text',
//            panelHeight: 'auto'
//        });
//    }
//})
//function getSampleGroups(url) {
//    var temp;
//    $.ajax({
//        type: 'get',
//        url: url,
//        async: false,
//        datatype: 'json',
//        success: function (responseData) { temp = responseData; }
//    });
//    return temp;
//}


////脏器和脏器细分
//$(function () {
//    $('#organE').combobox({
//        data: getDtaJsonLinkage,
//        method: 'get',
//        valueField: 'NAME',
//        textField: 'NAME',
//        panelHeight: 'auto',
//        onSelect: function (rec)
//        {
//            var linkagefromurl = '../Fp_Ajax/PageConData.aspx?conMarc=linkagefrom&id=' + rec.ID;
//            var getlinkagefrom;
//            var getDtaJsonLinkagefrom;
//            var getlinkageFromData = getlinkagefromJson(linkagefromurl);
//            getlinkagefrom = JSON.parse(getlinkageFromData);
//            getDtaJsonLinkagefrom = getlinkagefrom.ds;
//            $('#organsubdivisionE').combobox({
//                data: getDtaJsonLinkagefrom,
//                method: 'get',
//                valueField: 'NAME',
//                textField: 'NAME',
//                panelHeight: 'auto'
//            });
//        }
//    });
//})
////脏器绑定值
//var linkageurl = '../Fp_Ajax/PageConData.aspx?conMarc=linkage';
//var getlinkage;
//var getDtaJsonLinkage;
//function getlinkageJson(linkageurl) {
//    var temp;
//    $.ajax({
//        type: 'get',
//        url: linkageurl,
//        async: false,
//        datatype: 'json',
//        success: function (responseData) { temp = responseData; }
//    });
//    return temp;
//}
//var getlinkageData = getlinkageJson(linkageurl);
//getlinkage = JSON.parse(getlinkageData);
//getDtaJsonLinkage = getlinkage.ds;
////读取脏器细分
//function getlinkagefromJson(linkagefromurl) {
//    var temp;
//    $.ajax({
//        type: 'get',
//        url: linkagefromurl,
//        async: false,
//        datatype: 'json',
//        success: function (responseData) { temp = responseData; }
//    });
//    return temp;  
//}


////绑定采集人
//$(function () {
//    $('#_99').combobox({
//        editable: true,
//        panelHeight: '200px',
//        delay: '600',
//        valueField: 'EmployeeNo',
//        textField: 'EmployeeName',
//        onChange: function (newVal, oldVal) {
//            var faultAddr = encodeURI(newVal);
//            //faultAddr = encodeURI(faultAddr);  //需要通过两次编码
//            if (newVal == "" || newVal == oldVal) {
//                $('#_99').combobox('clear');
//                return;
//            }
//            else {
//                var url = '../Fp_Ajax/PageConData.aspx?conMarc=Employee&com=' + faultAddr;
//                $('#_99').combobox('reload', url);
//            }
//        },
//        onHidePanel: function () {
//            var o = $('#_99').combobox('getValue');//获取采集人的EmployeeNo
//            var url = '../Fp_Ajax/PageConData.aspx?conMarc=Employee&com=' + o;
//            var temp = getEmployee(url);
//            if (temp) {
//                var tempjson = JSON.parse(temp);
//                $('#_109').combobox({
//                    editable: true,
//                    data: tempjson,
//                    valueField: 'EmployeeNo',
//                    textField: 'EmployeeName'
//                });
//                $('#_109').combobox('setValue', tempjson.EmployeeName);
//            }
//        }
//    });
//})


