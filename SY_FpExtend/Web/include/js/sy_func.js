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
    var row = $('#dg_ClinicInfo').datagrid('', '')
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
    var In_CodeType = $('#In_CodeType').textbox('getValue');
    var In_Code = $('#In_Code').textbox('getValue');//获取数据源
    $.ajax({
        type: 'GET',
        url: '/Fp_Ajax/GetData.aspx?action=gethisdata&In_CodeType=' + In_CodeType + '&In_Code=' + In_Code,
        success: function (data) {
            clearForm();
            alert(data);
            if (data == "" || data == null) {
                alert("无数据，查询超时");
            }
            else {
                var datastr = eval("(" + data + ")");
                if (datastr._BaseInfo) {
                    alert(datastr._BaseInfo);
                    var _BaseInfo = eval("(" + datastr._BaseInfo + ")")
                    if (_BaseInfo.ds) {
                        var ds = _BaseInfo.ds;
                        AddBaseInfoToForm(ds[0]);
                    }
                    //格式需要更改
                }
                if (datastr._ClinicalInfo) {
                    alert(datastr._ClinicalInfo);
                    var _ClinicalInfo = eval("(" + datastr._ClinicalInfo + ")")
                    if (_ClinicalInfo.ds) {
                        var ds = _ClinicalInfo.ds;
                        //alert(ds.length);
                        //for (var i = 0; i < ds.length; i++) {
                        //    var data = ds[i];
                        //   // $('#ClinicalInfoDg').datagrid('loadData', data);
                        //    $('#ClinicalInfoDg').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', data);
                        //}


                        $('#ClinicalInfoDg').datagrid({ loadFilter: pagerFilter }).datagrid('loadData', ds);

                    }
                }
            }
        }
    })
}
//AJAX提交方式，TYPE提交方式，URL路径，success返回是否成功

//清除控件值
function clearForm() {
    $("#_80").textbox('clear');
    $("#_81").textbox('clear');
    $("#_82").textbox('clear');
    $("#_83").textbox('clear');
    $("#_84").textbox('clear');
    $("#_85").textbox('clear');
    $("#_86").textbox('clear');
    $("#_87").textbox('clear');
    $("#_88").textbox('clear');
    $("#_89").textbox('clear');
    $("#_90").textbox('clear');
    $("#_91").textbox('clear');
    $("#_92").textbox('clear');
    $("#_93").textbox('clear');
    $('#dg_ClinicInfo').datagrid('loadData', { total: 0, rows: [] });
}


function trimdata(trime)
{
    $.trim("")
}
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
        switch (_BaseInfo['SexFlag'])
        {
            case '0':
                $("#_115").textbox('setValue', "未知");
                break;
            case '1':
                $("#_115").textbox('setValue', "男");
                break;
            case '2':
                $("#_115").textbox('setValue', "女");
            default:
                $("#_115").textbox('setValue', "未知");
                break;
        }
    }
    if (_BaseInfo['Birthday']) {
        var Birthday = _BaseInfo['Birthday'].substring(0, 10);
        $("#_84").textbox('setValue', Birthday);
    }
    if (_BaseInfo['BloodTypeFlag']) {
        switch (_BaseInfo['BloodTypeFlag']) {
            case 1:
                $("#_116").textbox('setValue', "A");
                break;
            case 2:
                $("#_116").textbox('setValue', "B");
                break;
            case 3:
                $("#_116").textbox('setValue', "AB");
            case 4:
                $("#_116").textbox('setValue', "O");
            case 5:
                $("#_116").textbox('setValue', "其他");
            case 6:
                $("#_116").textbox('setValue', "未查");
            default:
                $("#_116").textbox('setValue', "未查");
                break;
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

////页面加载时访问
function displayToolbar() {
    $.ajax({
        type: 'POST',
        url: 'Login.ashx',
        data: { type: 'checklogin' },
        success: function (data) {
            $('#MenuBar').html(data);
        },
        dataType: "text"
    });
}
//打开登陆框
function dologin() {
    $('#frmLogin').form("clear");
    $('#Login').dialog('open');
}

$(function () {
    $("input", $("#password").next("span")).keydown(function (e) {
        if (e.keyCode == 13) {
            login();
        }
    });
})
//登陆
function login() {
    $('#frmLogin').form({
        type: 'POST',
        url: "Login.ashx?type=login",
        onSubmit: function () {
            // 做某些检查 
            // 返回 false 来阻止提交 
        },
        success: function (data) {
            if (data == "恭喜你,登录成功,欢迎使用FreezerPro协同助手！") {
                $('#Login').dialog('close');
                displayToolbar();
            }
            else if (data == "对不起,用户名或密码错误,请重新输入！") {
                $.messager.alert('提示', data, 'info');
            }
        }
    });
    $('#frmLogin').submit();
}

//注销登陆
function logout() {
    $.messager.confirm('询问', '确定要注销当前登录用户么？', function (ok) {
        if (ok) {
            $.ajax({
                type: 'POST',
                url: 'Login.ashx?type=logout',
                success: function (data) {
                    $('#MenuBar').html(data);
                },
                dataType: "text",
            });
        }
    });
}
