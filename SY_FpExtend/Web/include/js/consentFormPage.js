//验证图片为IMG文件
$(function () {
    $('#file1').filebox({
        onChange: function ()
        {
            var text = $('#file1').filebox('getText');
            if (text.indexOf(".jpg") > 0 || text.indexOf(".JPG") > 0 || text.indexOf(".JPEG") > 0 || text.indexOf(".jpeg") > 0)
            {
                //document.write("<img src='" + text + "'/>");
            }
            else
            {
                $.messager.alert('错误', '图片格式必须为jpg', 'error');
                $('#file1').filebox('setText','');
            }
            text = "";
        }
    });
})
