<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adm_Left.aspx.cs" Inherits="Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />

    <script src="js/ddaccordion.js" type="text/javascript"></script>

    <script src="js/jquery.js" type="text/javascript"></script>

    <script type="text/javascript">
        ddaccordion.init({
            headerclass: "silverheader", //Shared CSS class name of headers group
            contentclass: "submenu", //Shared CSS class name of contents group
            revealtype: "mouseover", //Reveal content when user clicks or onmouseover the header? Valid value: "click", "clickgo", or "mouseover"
            mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
            collapseprev: true, //Collapse previous content (so only one open at any time)? true/false
            defaultexpanded: [0], //index of content(s) open by default [index1, index2, etc] [] denotes no content
            onemustopen: true, //Specify whether at least one header should be open always (so never all headers closed)
            animatedefault: false, //Should contents open by default be animated into view?
            persiststate: true, //persist state of opened contents within browser session?
            toggleclass: ["", "on"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
            togglehtml: ["", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
            animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
            oninit: function(headers, expandedindices) { //custom code to run when headers have initalized
                //do nothing
            },
            onopenclose: function(header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
                //do nothing
            }    //运用javascript实现当鼠标悬浮在菜单栏时展开相应的子菜单
        })
    </script>

</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <div id="Left">
        <div class="main">
            <div class="m_box">
                <div class="m">
                    <p class="list_tt" thisorder="1">
                        <a href="javascript:void(0);" class="silverheader">账号管理</a></p>
                    <ul class="list submenu">
                        <li><a href="update.aspx" target="mainFrame">修改密码</a></li>
                    </ul>
                    <p class="list_tt" thisorder="1">
                        <a href="javascript:void(0);" class="silverheader">用户管理</a></p>
                    <ul class="list submenu">
                        <li><a href="adm_users.aspx" target="mainFrame">新增</a></li>
                        <li><a href="adm_userstb.aspx" target="mainFrame">维护</a></li>
                    </ul>
                    <p class="list_tt" thisorder="1">
                        <a href="javascript:void(0);" class="silverheader">法规题库管理</a></p>
                    <ul class="list submenu">
                        <li><a href="title_1.aspx" target="mainFrame">新增</a></li>
                        <li><a href="title_1tb.aspx" target="mainFrame">维护</a></li>
                    </ul>
                    <p class="list_tt" thisorder="1">
                        <a href="javascript:void(0);" class="silverheader">交通信号题库管理</a></p>
                    <ul class="list submenu">
                        <li><a href="title_2.aspx" target="mainFrame">新增</a></li>
                        <li><a href="title_2tb.aspx" target="mainFrame">维护</a></li>
                    </ul>
                    <p class="list_tt" thisorder="1">
                        <a href="javascript:void(0);" class="silverheader">基础知识题库管理</a></p>
                    <ul class="list submenu">
                        <li><a href="title_3.aspx" target="mainFrame">新增</a></li>
                        <li><a href="title_3tb.aspx" target="mainFrame">维护</a></li>
                    </ul>
                    <p class="list_tt" thisorder="1">
                        <a href="javascript:void(0);" class="silverheader">操作知识题库管理</a></p>
                    <ul class="list submenu">
                        <li><a href="title_4.aspx" target="mainFrame">新增</a></li>
                        <li><a href="title_4tb.aspx" target="mainFrame">维护</a></li>
                    </ul>
                     <p class="list_tt" thisorder="1">
                        <a href="javascript:void(0);" class="silverheader">考试管理</a></p>
                    <ul class="list submenu">
                        <li><a href="paper.aspx" target="mainFrame">新增</a></li>
                        <li><a href="papertb.aspx" target="mainFrame">维护</a></li>
                    </ul>
                    <p class="list_tt" thisorder="1">
                        <a href="javascript:void(0);" class="silverheader">成绩查看</a></p>
                    <ul class="list submenu">
                        <li><a href="scorestb.aspx" target="mainFrame">查看</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
