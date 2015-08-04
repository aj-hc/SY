
$(function () {
    var pname = $.cookie('pname');
    var puid = $.cookie('uid');
    if (pname == undefined ) { }
    else
    {
        if (puid == undefined) { $.messager.alert('提示', '该患者没有唯一标识，请确认是否正确', 'error'); return; }
        else
        {
            $('#_80').textbox('setValue', getname);
            $('#_91').textbox('setValue', getuid);
        }
    }
})

