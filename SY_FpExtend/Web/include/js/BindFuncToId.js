//初始化绑定事件
$(function () {
    loginOut();
    btnGet();
})


//注销按钮
function loginOut() {
    $("#loginOut").click(function (e) {
        alert("点击了");
    });
}
//点击查询数据
function btnGet() {
    $("#btnGet").click(function (e) {
        querybycode();
    });
}