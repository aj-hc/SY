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
    var pname = $.cookie('pname');
    var puid = $.cookie('uid');
    var name = "";
    var uid = "";
    if (pname == null | pname == "")
    {
        name = encodeURI($('#_80').textbox('getText'));
    }
    else
    {
        name = pname;
    }
    if (puid == null | puid == "") {uid = $('#_91').textbox('getText'); }else {uid = puid}
    var date = $('#fromdate').datebox('getText');
    //检测上传信息
    if (uid=="") {$.messager.alert('提示', '患者唯一标识为空', 'error'); return;}
    if (date=="") {$.messager.alert('提示', '日期为空', 'error'); return;}
    if (imgpath == "") { $.messager.alert('提示', '图片格式为空', 'error'); return; }
    if (name == "") { $.messager.alert('提示', '患者姓名为空', 'error'); return; }
    else
    {
        if (imgpath.indexOf("jpg") > 0 || imgpath.indexOf("jpeg") > 0) {
            $.ajax({
                type: "POST",
                url: "/Fp_Ajax/getImg.ashx?suid=" + uid + "&timedate=" + date+"&spname="+name,
                data: { imgPath: imgpath },
                cache: false,
                success: function (data)
                {
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
                 