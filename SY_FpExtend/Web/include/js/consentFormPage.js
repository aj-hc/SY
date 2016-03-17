
//修改为先上传图片，返回图片路径之后再上传数据
function getImg() {
    var imgpath = encodeURI(document.getElementById("idFile").value);
    var name = "";
    var uid = "";
    name = encodeURI($('#txtname').textbox('getText'));
    uid = $('#txtPatientID').textbox('getText');
    var date = $('#fromdate').datebox('getText');
    //检测上传信息
    if (uid == "") { $.messager.alert('提示', '患者唯一标识为空', 'error'); return; }
    if (date == "") { $.messager.alert('提示', '日期为空', 'error'); return; }
    if (imgpath == "") { $.messager.alert('提示', '图片格式为空', 'error'); return; }
    if (name == "") { $.messager.alert('提示', '患者姓名为空', 'error'); return; }
    else
    {
        if (imgpath.indexOf("jpg") >= 0 || imgpath.indexOf("jpeg") >= 0) {
            ajaxLoading();
            $.ajax({});//上传图片到服务器
            //后台判断
            $.ajax({
                type: "POST",
                url: "/Fp_Ajax/DownImg.aspx?suid=" + uid + "&timedate=" + date + "&spname=" + name,
                data: {
                    suid: uid,
                    spname: name,
                    timedate: date,
                    imgPath: imgpath
                },
                cache: false,
                success: function (data) {
                    ajaxLoadEnd();
                    $.messager.alert('提示', data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.alert('提示', '上传失败，请检查网络后重试', 'error'); return;
                }
            });
        }
        else { $.messager.alert('提示', '只支持格式为JPG或JPEG的图片格式', 'error'); return; }
    }
}

function ajaxFileUpload() {
    //获取上传日期数据
    var name = "";
    var uid = "";
    name = encodeURI($('#txtname').textbox('getText'));
    uid = $('#txtPatientID').textbox('getText');
    var date = $('#fromdate').datebox('getText');
    //检测上传信息
    if (uid == "") { $.messager.alert('提示', '患者唯一标识为空', 'error'); return; }
    if (date == "") { $.messager.alert('提示', '日期为空', 'error'); return; }
    if (name == "") { $.messager.alert('提示', '患者姓名为空', 'error'); return; }
    else
    {
        //上传图片,返回地址之后再上传数据
        $.ajaxFileUpload({
            url: '/Fp_Ajax/UploadHandler.ashx?action=postimg&Iuid=' + uid + '&Iname=' + name + '&Idate=' + date,
            secureuri: false, //是否需要安全协议，一般设置为false
            fileElementId: 'IdFile', //文件上传域的ID
            dataType: 'json', //返回值类型 一般设置为json
            success: function (data, status)  //服务器成功响应处理函数
            {
                if (data.indexOf("Consentimg") >= 0) { $.messager.alert('提示', '导入成功，地址：' + data); return; }
                else { $.messager.alert('提示', data, 'error'); return; }
            },
            error: function (data, status, e)//服务器响应失败处理函数
            {
                $.messager.alert(e);
            }
        });
    }
    return false;
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

