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
function getImg()
{
    var imgpath = document.getElementById("idFile").value;
    var name = $('#_80').textbox('getText');
    var uid = $('#_91').textbox('getText');
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
                url: "/Fp_Ajax/getImg.ashx?uid=" + uid + "&timedate=" + date,
                data: { imgPath: imgpath },
                cache: false,
                success: function (data) {
                    $.messager.alert('提示', '上传成功');
                    $("#imgDiv").empty();
                    $("#imgDiv").html(data);
                    $("#imgDiv").show();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown)
                {
                    $.messager.alert('提示', '上传失败，请检查网络后重试', 'error'); return;
                }
            });
        }
        else {
            $.messager.alert('提示', '只支持格式为JPG或JPEG的图片格式', 'error'); return;
        }
    }
}



var maxsize = 1024*900;//2M  
var errMsg = "上传的附件文件不能超过1M！！！";  
var tipMsg = "您的浏览器暂不支持计算上传文件的大小，确保上传文件不要超过2M，建议使用IE、FireFox、Chrome浏览器。";  
var  browserCfg = {};  
var ua = window.navigator.userAgent;  
if (ua.indexOf("MSIE") >= 1) { browserCfg.ie = true; }
else if (ua.indexOf("Firefox") >= 1) { browserCfg.firefox = true; }
else if (ua.indexOf("Chrome") >= 1) {browserCfg.chrome = true;  }  
function checkfile()
{
    try
    {
        var obj_file = document.getElementById("idFile");
        if(obj_file.value==""){  alert("请先选择上传文件");  return;  }  
        var filesize = 0;  
        if (browserCfg.firefox || browserCfg.chrome) { filesize = obj_file.files[0].size; }
        else if (browserCfg.ie) {
            var obj_img = document.getElementById('tempimg');  
            obj_img.src = obj_file.value;
            filesize = obj_img.fileSize;  
        }else{  
            alert(tipMsg);  
            return;  
        }  
        if (filesize == -1) { alert(tipMsg); return; }
        else if (filesize > maxsize) { alert(errMsg); return; }
        else { alert("文件大小符合要求");  return;  }  
    }catch(e){  alert(e);  }  
}
 var ImgObj=new Image();      //建立一个图像对象 
 var AllImgExt=".jpg|.jpeg|.gif|.bmp|.png|"//全部图片格式类型 
 var FileObj,ImgFileSize,ImgWidth,ImgHeight,FileExt,ErrMsg,FileMsg,HasCheked,IsImg//全局变量 图片相关属性 
 //以下为限制变量 
 var AllowExt=".jpg|.gif|.doc|.txt|" //允许上传的文件类型 ?为无限制 每个扩展名后边要加一个"|" 小写字母表示 
 //var AllowExt=0 
 var AllowImgFileSize=70;    //允许上传图片文件的大小 0为无限制 单位：KB 
 var AllowImgWidth=500;      //允许上传的图片的宽度 ?为无限制 单位：px(像素) 
 var AllowImgHeight=500;      //允许上传的图片的高度 ?为无限制 单位：px(像素) 
 HasChecked=false; 
 function CheckProperty(obj)    //检测图像属性 
 {      
     FileObj=obj; 
     if(ErrMsg!="")      //检测是否为正确的图像文件 返回出错信息并重置 
             { 
                     ShowMsg(ErrMsg,false); 
                    return false;      //返回 
                 } 
        
        if(ImgObj.readyState!="complete") //如果图像是未加载完成进行循环检测 
            { 
                    setTimeout("CheckProperty(FileObj)",500); 
                     return false; 
                 } 
        
         ImgFileSize=Math.round(ImgObj.fileSize/1024*100)/100;//取得图片文件的大小 
         ImgWidth=ImgObj.width      //取得图片的宽度 
         ImgHeight=ImgObj.height;    //取得图片的高度 
         FileMsg="\n图片大小:"+ImgWidth+"*"+ImgHeight+"px"; 
         FileMsg=FileMsg+"\n图片文件大小:"+ImgFileSize+"Kb"; 
         FileMsg=FileMsg+"\n图片文件扩展名:"+FileExt; 
         
        if(AllowImgWidth!=0&&AllowImgWidth<ImgWidth) 
                 ErrMsg=ErrMsg+"\n图片宽度超过限制。请上传宽度小于"+AllowImgWidth+"px的文件，当前图片宽度为"+ImgWidth+"px"; 
         
         if(AllowImgHeight!=0&&AllowImgHeight<ImgHeight) 
                 ErrMsg=ErrMsg+"\n图片高度超过限制。请上传高度小于"+AllowImgHeight+"px的文件，当前图片高度为"+ImgHeight+"px"; 
        
        if(AllowImgFileSize!=0&&AllowImgFileSize<ImgFileSize) 
                 ErrMsg=ErrMsg+"\n图片文件大小超过限制。请上传小于"+AllowImgFileSize+"KB的文件，当前文件大小为"+ImgFileSize+"KB"; 
         
         if(ErrMsg!="") 
                 ShowMsg(ErrMsg,false); 
         else 
             ShowMsg(FileMsg,true); 
         } 
ImgObj.onerror=function(){ErrMsg='\n图片格式不正确或者图片已损坏!'} 
     
function ShowMsg(msg,tf) //显示提示信息 tf=true 显示文件信息 tf=false 显示错误信息 msg-信息内容 
         { 
             msg=msg.replace("\n","<li>"); 
             msg=msg.replace(/\n/gi,"<li>"); 
             if(!tf) 
                 { 
                         document.all.UploadButton.disabled=true; 
                         FileObj.outerHTML=FileObj.outerHTML; 
                         MsgList.innerHTML=msg; 
                         HasChecked=false; 
                     } 
             else 
             { 
                     document.all.UploadButton.disabled=false; 
                     if(IsImg) 
                           PreviewImg.innerHTML="<img src='"+ImgObj.src+"' width='60' height='60'>" 
                     else 
                       PreviewImg.innerHTML="非图片文件"; 
                     MsgList.innerHTML=msg; 
                     HasChecked=true; 
                 } 
             } 
         
function CheckExt(obj) 
             { 
                 ErrMsg=""; 
                 FileMsg=""; 
                 FileObj=obj; 
                 IsImg=false; 
                 HasChecked=false; 
                 PreviewImg.innerHTML="预览区"; 
                 if(obj.value=="")return false; 
                 MsgList.innerHTML="文件信息处理中..."; 
                 document.all.UploadButton.disabled=true; 
                 FileExt=obj.value.substr(obj.value.lastIndexOf(".")).toLowerCase(); 
                 if(AllowExt!=0&&AllowExt.indexOf(FileExt+"|")==-1) //判断文件类型是否允许上传 
                     { 
                             ErrMsg="\n该文件类型不允许上传。请上传 "+AllowExt+" 类型的文件，当前文件类型为"+FileExt; 
                             ShowMsg(ErrMsg,false); 
                             return false; 
                         } 
                 
                 if(AllImgExt.indexOf(FileExt+"|")!=-1)    //如果图片文件，则进行图片信息处理 
                     { 
                             IsImg=true; 
                             ImgObj.src=obj.value; 
                             CheckProperty(obj); 
                             return false; 
                         } 
                 else 
                 { 
                         FileMsg="\n文件扩展名:"+FileExt; 
                         ShowMsg(FileMsg,true); 
                     } 
                 
                 } 
             
function SwitchUpType(tf) 
{ 
    if(tf) str='<input type="file" name="file1" onchange="CheckExt(this)" style="width:180px;">' 
    else 
        str='<input type="text" name="file1" onblur="CheckExt(this)" style="width:180px;">' 
        document.all.file1.outerHTML=str; 
        document.all.UploadButton.disabled=true; 
        MsgList.innerHTML=""; 
} 
                 