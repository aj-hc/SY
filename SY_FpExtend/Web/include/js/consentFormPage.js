$(function () {
    var pname = $.cookie('pname');
    var puid = $.cookie('uid');
    var getname = decodeURI(pname);
    if (pname == undefined ) { }
    else
    {
        if (puid == undefined) { $.messager.alert('提示', '该患者没有唯一标识，请确认是否正确', 'error'); return; }
        else
        {
            $('#_80').textbox('setValue', getname);
            $('#_91').textbox('setValue', puid);
        }
    }
})
function getImg()
{
    var imgpath = document.getElementById("idFile").value;
    var name = "";
    var uid = "";
    name = encodeURI($('#_80').textbox('getText'));
    uid = $('#_91').textbox('getText');
    var date = $('#fromdate').datebox('getText');
    //检测上传信息
    if (uid=="") {$.messager.alert('提示', '患者唯一标识为空', 'error'); return;}
    if (date=="") {$.messager.alert('提示', '日期为空', 'error'); return;}
    if (imgpath == "") { $.messager.alert('提示', '图片格式为空', 'error'); return; }
    if (name == "") { $.messager.alert('提示', '患者姓名为空', 'error'); return; }
    else
    {
        if (imgpath.indexOf("jpg") > 0 || imgpath.indexOf("jpeg") > 0) {
            ajaxLoading();
            $.ajax({
                type: "POST",
                url: "/Fp_Ajax/getImg.ashx?suid=" + uid + "&timedate=" + date+"&spname="+name,
                data: { imgPath: imgpath },
                cache: false,
                success: function (data)
                {
                    ajaxLoadEnd();
                    $.messager.alert('提示', data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown)
                {
                    $.messager.alert('提示', '上传失败，请检查网络后重试', 'error'); return;
                }
            });
        }
        else {$.messager.alert('提示', '只支持格式为JPG或JPEG的图片格式', 'error'); return;}
    }
}

function dowImga()
{
    $.ajax({
        type: "POST",
        url: "/Fp_Ajax/DowImg.ashx?imgname=100065631620151111.jpg&imgdate=2015-11-01",
        //data: { imgname: imgdate },
        cache: false,
        success: function (data) {
            $.messager.alert('提示', data);
           
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $.messager.alert('提示', '上传失败，请检查网络后重试', 'error'); return;
        }
    });
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

                 