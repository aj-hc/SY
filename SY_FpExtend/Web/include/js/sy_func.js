//输入框默认值
$(function () {
    //设置时间
    var begindate = new Date();
    //采集日期
    $('#_103').textbox('setValue', myformatter(begindate))
    var time = begindate.getHours() + ":" + begindate.getMinutes()
    $('#_104').textbox('setValue', time);
});

function beforeSubmit() {
    var clinicinfoarr;
    //获取临床信息选择的行，并将数据组成数组
    var row = $('#ClinicalInfoDg').datagrid('', '')
    //获取样本添加的行，并将数据组成数组
}

//格式化日期控件
function myformatter(date) {
    var y = date.getFullYear();
    var m = date.getMonth() + 1;
    var d = date.getDate();
    return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
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

function myparser(s) {
    if (!s) return new Date();
    var ss = (s.split('-'));
    var y = parseInt(ss[0], 10);
    var m = parseInt(ss[1], 10);
    var d = parseInt(ss[2], 10);
    if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
        return new Date(y, m - 1, d);
    } else {
        return new Date();
    }
}
//绑定数据
function querybycode() {
    var In_CodeType = $('#In_CodeType').combobox('getValue');
    var In_Code = $('#In_Code').textbox('getValue');//获取数据源
    if (isEmptyStr(In_CodeType) || isEmptyStr(In_Code)) {
        $.messager.alert('提示', '请检查条码类型和条码号', 'error');
    }
    else {
        $.ajax({
            type: 'GET',
            url: '/Fp_Ajax/GetData.aspx?action=gethisdata&In_CodeType=' + In_CodeType + '&In_Code=' + In_Code,
            onSubmit: function () {
            },
            success: function (data) {
                clearForm();
                if (!data) {
                    $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error');
                }
                else {
                    //测试代码
                    //var obj = $.parseJSON(data);
                    //if (obj._BaseInfo)
                    //{
                    //    if (obj._BaseInfo.ds)
                    //    {
                    //        var ds = obj._BaseInfo.ds;
                    //        //$("#BaseInfoForm").form("load", ds[0]);
                    //        AddBaseInfoToForm(ds[0]);
                    //    }
                    //}
                    //if (obj._ClinicalInfo)
                    //{
                    //    if (obj._ClinicalInfo.ds)
                    //    {
                    //        for (var i = 0; i < obj._ClinicalInfo.ds.length ; i++)
                    //        {
                    //            var text = obj._ClinicalInfo.ds[i].DiagnoseDateTime.substring(0,10);
                    //            obj._ClinicalInfo.ds[i].DiagnoseDateTime = text
                    //        }
                    //        var ds = obj._ClinicalInfo.ds
                    //        $('#ClinicalInfoDg').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', ds).datagrid('reload');
                    //    }
                    //}
                    //测试end
                    //将数据转换成json对象 正式
                    var obj=$.parseJSON(data);
                    if (obj._BaseInfo)
                    {
                        var _BaseInfo = $.parseJSON(obj._BaseInfo);
                        if (_BaseInfo.ds)
                        {
                            var ds = _BaseInfo.ds;
                            AddBaseInfoToForm(ds[0]);
                        }
                    }
                    if (obj._ClinicalInfo)
                    { 
                        var _ClinicalInfo = $.parseJSON(obj._ClinicalInfo);
                        if (_ClinicalInfo.ds)
                        { 
                            var ds = _ClinicalInfo.ds
                            for (var i = 0; i < ds.length; i++)
                            {
                                var text = _ClinicalInfo.ds[i].DiagnoseDateTime.substring(0,10);
                                _ClinicalInfo.ds[i].DiagnoseDateTime = text;
                            }
                            $('#ClinicalInfoDg').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', ds).datagrid('reload');
                        }
                    }
                    //正式END
                }
            }
        })
    }
}
//清除控件值
function clearForm() {
    $('#BaseInfoForm').form('clear');
    $('#ClinicalInfoDg').datagrid('loadData', { total: 0, rows: [] });
}
//绑定数据到基本信息数据框
function AddBaseInfoToForm(_BaseInfo)
{
    if (_BaseInfo=="SEE")
    {
        $("#_80").textbox('readonly', false);
        $("#_81").textbox('readonly',false);
        $("#_82").textbox('readonly',false);
        $("#_115").textbox('readonly',false);
        $("#_84").textbox('readonly', false);
        $("#_116").textbox('readonly', false);
        $("#_86").textbox('readonly', false);
        $("#_87").textbox('readonly', false);
        $("#_88").textbox('readonly', false);
        $("#_89").textbox('readonly', false);
        $("#_90").textbox('readonly', false);
        $("#_91").textbox('readonly', false);
        $("#_92").textbox('readonly', false);
        $("#_93").textbox('readonly', false);
    }
    if (_BaseInfo)
    {
        if (_BaseInfo['PatientName'] && _BaseInfo['PatientName']!="")
        {
                $("#_80").textbox('setValue', $.trim(_BaseInfo['PatientName']));
            $("#_80").textbox('readonly');
        }
        if (_BaseInfo['IPSeqNoText'])
        {
            $("#_81").textbox('setValue', $.trim(_BaseInfo['IPSeqNoText']));
            $("#_81").textbox('readonly');
        }
        if (_BaseInfo['PatientCardNo'])
        {
            $("#_82").textbox('setValue', $.trim(_BaseInfo['PatientCardNo']));
            $("#_82").textbox('readonly');
        }
        if (_BaseInfo['SexFlag'] || _BaseInfo['SexFlag']==0)
        {
            var data = $('#_115').combobox('getData');
            var SexFlag = _BaseInfo['SexFlag'];
            if (data.length > 0)
            {
                for (var tem in data)
                {
                    if (data[tem].SexFlag == SexFlag) { $("#_115").combobox('select', data[tem].text); }
                }
            }
            $("#_115").textbox('readonly');
        }
        if (_BaseInfo['BirthDay'])
        {
            var Birthday = _BaseInfo['BirthDay'].substring(0, 10);
            $("#_84").datebox('setValue', Birthday);
            $("#_84").textbox('readonly');
        }
        if (_BaseInfo['BloodTypeFlag'] || _BaseInfo['BloodTypeFlag']==0)
        {
            var BloodTypeFlag = _BaseInfo['BloodTypeFlag'];
            if (BloodTypeFlag==0){BloodTypeFlag = 6;}
            var data = $('#_116').combobox('getData');
            if (data.length > 0)
            {
                for (var tem in data)
                {
                    if (data[tem].BloodTypeFlag == BloodTypeFlag) { $("#_116").combobox('select', data[tem].text); }
                    
                }
                $("#_116").textbox('readonly');
            }
        }
        if (_BaseInfo['Phone'])
        {
            $("#_86").textbox('setValue', $.trim(_BaseInfo['Phone']));
            $("#_86").textbox('readonly');
        }
        if (_BaseInfo['ContactPhone'])
        {
            $("#_87").textbox('setValue', $.trim(_BaseInfo['ContactPhone']));
            $("#_87").textbox('readonly');
        }
        if (_BaseInfo['ContactPerson'])
        {
            $("#_88").textbox('setValue', $.trim(_BaseInfo['ContactPerson']));
            $("#_88").textbox('readonly');
        }
        if (_BaseInfo['NativePlace'])
        {
            $("#_89").textbox('setValue', $.trim(_BaseInfo['NativePlace']));
            $("#_89").textbox('readonly');
        }
        if (_BaseInfo['RegisterSeqNO'])
        {
            $("#_90").textbox('setValue', $.trim(_BaseInfo['RegisterSeqNO']));
            $("#_90").textbox('readonly');
        }
        if (_BaseInfo['PatientID'])
        {
            $("#_91").textbox('setValue', $.trim(_BaseInfo['PatientID']));
            $("#_91").textbox('readonly');
        }
        if (_BaseInfo['RegisterID'])
        {
            $("#_92").textbox('setValue', $.trim(_BaseInfo['RegisterID']));
            $("#_92").textbox('readonly');
        }
        if (_BaseInfo['InPatientID'])
        {
            $("#_93").textbox('setValue', $.trim(_BaseInfo['InPatientID']));
            $("#_93").textbox('readonly');
        }
    }
    else {$.messager.alert('提示', '这个编号没有数据', 'error'); }
}

//条码框按钮回车事件
$(function () {
    $("input", $("#In_Code").next("span")).keydown(function (e) {
        if (e.keyCode == 13) {
            querybycode();
        }
    });
})

//点击确定按钮提交请求
function getdatabybarcode() {
    var code = $('#barcodebox').textbox('getValue');
    if ($.trim(code)) {
        barcode(code);
        var code = $('#barcodebox').textbox('clear');
    }
    var code = $('#barcodebox').textbox('clear');
}

//POST数据
function postPatientInfo() {
    var name = $('#_80').textbox('getText');
    var hzid = $('#_91').textbox('getText');
    var departments = $('#departments').combobox('getText')
    if (!departments) { $.messager.alert('提示', '必须选择科室', 'error'); return; }
    if (name == "" || hzid == "") { $.messager.alert('提示', '必须输入姓名以及患者ID', 'error'); return; }
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
                departments: departments,
                baseinfo: _baseinfo,
                clinicalInfoDg: rowClinicalInfoDg
            },
            onSubmit: function () {

            },
            success: function (data) {
                if (data) {
                    if (data.success == "True") {
                        $.messager.show({ title: '提示！', msg: '导入成功：' + data.msg, showType: 'show' });
                        AddBaseInfoToForm("SEE");
                        return;
                    }
                    else if (data.success == "False") {
                        $.messager.show({ title: '提示！', msg: '导入失败：' + data.msg, showType: 'show' });
                        AddBaseInfoToForm("SEE");
                        return;
                    }
                }
                else {
                    $.messager.alert('提示', '服务器未响应', 'error');
                    return;
                }
            }
        });
    }
}

function getBaseInfoFormData() {
    var sampleinfo = $("#BaseInfoForm").serializeArray();
    var ii = $("#_116").combobox('getText');
    var base;
    if (sampleinfo) {
        base = JSON.stringify(sampleinfo);
    }
    return base;
}




