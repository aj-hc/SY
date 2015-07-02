//输入框默认值
$(function () {
    //设置时间
    var begindate = new Date();
    //采集日期
    $('#_103').textbox('setValue', myformatter(begindate))
    var time = begindate.getHours() + ":" + begindate.getMinutes()
    $('#_104').textbox('setValue', time);
});

function postData() {
    $('#mainform').form({
        type: 'POST',
        url: "/Fp_Ajax/SubmitData.ashx",
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
                alert(data);
                if (data == "" || data == null) {
                    alert("无数据，查询超时");
                }
                else {

                    //var obj = $.parseJSON(data);
                    //if (obj._BaseInfo)
                    //{
                    //    if (obj._BaseInfo.ds)
                    //    {
                    //        var ds = obj._BaseInfo.ds;
                    //        AddBaseInfoToForm(ds[0]);
                    //    }
                    //}
                    //if (obj._ClinicalInfo)
                    //{
                    //    if (obj._ClinicalInfo.ds)
                    //    {
                    //        for (var i = 0; i < obj._ClinicalInfo.ds.length - 1; i++)
                    //        {
                    //            obj._ClinicalInfo.ds[i].DiagnoseDateTime.substring(0.10);
                    //        }
                    //        var ds = obj._ClinicalInfo.ds
                    //        $('#ClinicalInfoDg').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', ds).datagrid('reload');
                    //        //var ed = $('#ClinicalInfoDg').datagrid('getEditor', { index: i, field: 'DiagnoseTypeFlag' });
                    //        //alert('a');
                    //        //alert($(ed.target).combobox('getText'));
                    //    }
                    //}
                    ////将数据转换成json对象 正式
                    var obj = $.parseJSON(data);
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

function trimdata(trime) {
    $.trim("")
}
//绑定数据到基本信息数据框
function AddBaseInfoToForm(_BaseInfo) {

    if (_BaseInfo['PatientName']) {
        $("#_80").textbox('setValue', $.trim(_BaseInfo['PatientName']));
    }
    if (_BaseInfo['IPSeqNoText']) {
        $("#_81").textbox('setValue', $.trim(_BaseInfo['IPSeqNoText']));
    }
    if (_BaseInfo['PatientCardNo']) {
        $("#_82").textbox('setValue', $.trim(_BaseInfo['PatientCardNo']));
    }
    if (_BaseInfo['SexFlag']) {
        var data = $('#_115').combobox('getData')
        var SexFlag = _BaseInfo['SexFlag'];
        if (data.length > 0) {
            for (var tem in data) {
                if (data[tem].SexFlag == SexFlag);
                $("#_115").combobox('select', data[tem].text);
            }
        }
    }
    if (_BaseInfo['BirthDay']) {
        var Birthday = _BaseInfo['BirthDay'].substring(0, 10);
        //replace(/-/gm, '');
        $("#_84").datebox('setValue', Birthday);
    }
    if (_BaseInfo['BloodTypeFlag']) {
        var BloodTypeFlag = _BaseInfo['BloodTypeFlag']
        var data = $('#_116').combobox('getData')
        if (data.length > 0) {
            for (var tem in data) {
                if (data[tem].BloodTypeFlag == BloodTypeFlag);
                $("#_116").combobox('select', data[tem].text);
            }
        }
    }
    if (_BaseInfo['Phone']) {
        $("#_86").textbox('setValue', $.trim(_BaseInfo['Phone']));
    }
    if (_BaseInfo['ContactPhone']) {
        $("#_87").textbox('setValue', $.trim(_BaseInfo['ContactPhone']));
    }
    if (_BaseInfo['ContactPerson']) {
        $("#_88").textbox('setValue', $.trim(_BaseInfo['ContactPerson']));
    }
    if (_BaseInfo['NativePlace']) {
        $("#_89").textbox('setValue', $.trim(_BaseInfo['NativePlace']));
    }
    if (_BaseInfo['RegisterSeqNO']) {
        $("#_90").textbox('setValue', $.trim(_BaseInfo['RegisterSeqNO']));
    }
    if (_BaseInfo['PatientID']) {
        $("#_91").textbox('setValue', $.trim(_BaseInfo['PatientID']));
    }
    if (_BaseInfo['RegisterID']) {
        $("#_92").textbox('setValue', $.trim(_BaseInfo['RegisterID']));
    }
    if (_BaseInfo['InPatientID']) {
        $("#_93").textbox('setValue', $.trim(_BaseInfo['InPatientID']));
    }
}

//条码框按钮回车事件
$(function () {
    $("input", $("#barcodebox").next("span")).keydown(function (e) {
        if (e.keyCode == 13) {
            var code = $('#barcodebox').textbox('getValue');
            if ($.trim(code)) {
                barcode(code);
                var code = $('#barcodebox').textbox('clear');
            }
            var code = $('#barcodebox').textbox('clear');
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

