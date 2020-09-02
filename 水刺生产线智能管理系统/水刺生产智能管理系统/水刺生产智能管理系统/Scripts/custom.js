function ImgWH(){
    //获取显示器的宽高，改变body背景图片的大小
    var bodyHeight = screen.availHeight;
    var bodyWidth = screen.availWidth;
    window.onload= function () {
        var body = document.getElementById('body');
        body.style.backgroundSize = bodyWidth + "px " + bodyHeight + "px";
    }
}
