<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paperlist.aspx.cs" Inherits="paperlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>驾校在线理论考试题库</title>
<link href="css/css.css" rel="stylesheet" type="text/css" />
<link href="css/css300.css" type="text/css" rel="stylesheet" />
<link href="css/ShowDialog.css" type="text/css" rel="stylesheet" />

<script src="js/jquery-1.3.2.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function() {
        /*需要实现的功能
        1.点击题目时会自动左边的菜单会自动记录
        2.点击标记时左边的菜单会自动记录
        3.点击右边标记 页面会自动移动
    
    找到IMG的ID 如果这个ID不存在的话 就让IMG的不显示
        */

        $("#imgnone").hide(); //如果图片的Id为Imgnone 那这张图片就不显示
    });
</script>

<script type="text/javascript">

    function rightchose(id) {
        var choseid = "#EOV" + id;
        $(choseid).removeClass().addClass("ExamOrderViewVisited");
    }

    function getid() {
        document.getElementById("num").innerHTML = "1";
    }

</script>

<script type="text/javascript">
</script>

</head>
<body onload="getid();">
    <form id="form1" runat="server">
    <div class="top_nav">
        <div class="w970">
            <asp:Panel ID="Panel1" runat="server">
                <a href="Regsis.aspx" class="lashou" style="font-family: 微软雅黑; font-weight: normal;">
                    <span>注册</span></a> <a href="Login.aspx" class="lashou"><span style="font-family: 微软雅黑;
                        font-weight: normal;">登录</span></a>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <asp:Label ID="lbinfo" runat="server" Text=""></asp:Label>
                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">注销</asp:LinkButton>
            </asp:Panel>
        </div>
    </div>
    <div class="main_nav">
        <div class="left">
        </div>
        <div class="links">
            <a href="Default.aspx">章节练习</a> <a href="error.aspx" target="_blank">错题练习</a> <a
                href="test.aspx" target="_blank">模拟考试</a><a href="paperlist.aspx" target="_blank">
                参加考试</a>
        </div>
        <div class="right">
        </div>
    </div>
    <div class="sub_nav">
        <div class="left">
        </div>
        <div class="middle">
        </div>
        <div class="right">
        </div>
    </div>
    <div class="clear">
    </div>
    <div class="main">
        <div class="right fleft">
        <div class="rightcon" style="height: auto">
            <div class="righttllllluu">
                <div class="bgbg">
                    <span class="mnkstttt"><span class="mnkstkl">小车科目一理论知识考试</span>
                    </span>
                    <br>
                    <div class="ttttsdsds">
                        <span class="tlll"><span class="tl111">试卷查看</span><br>
                            <div class="h11">
                            </div>
                        </span>
                    </div>
                </div>
            </div>
            <div class="rightmain">
                <input type="hidden" id="EOVal" value="0" />
                <div class="rightmainleft">
                    <ul>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <li style="padding:5px;"><a href="paper.aspx?ptit=<%#Eval("ptit")%>">
                                    <%#Eval("ptit")%></a>
                                    <span style="float:right;"><%#Eval("ptime")%></span>
                                    </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div id="defen" class="defen" style="margin-top: 0px;">
                    </div>
                    <a name="Bottom"></a>
                </div>
                <div class="rightmainright">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="rightshare">
            <div class="shareleft" style="position: relative; border: 1px solid #a4c9ee; border-top: none;
                background: #f2f6fa; width: 658px; margin-left: -1px; *border-bottom: none; _height: 28px;
                _overflow: hidden; _width: 654px;">
                <div style="word-break: break-all; position: absolute; right: 60px; top: 4px; _top: 2px;
                    display: block">
                </div>
                <span id="ctitle"></span><span id="ccontent"></span>
                <style>
                    #newbdshare
                    {
                        padding-top: 6px;
                        padding-bottom: 3px;
                        width: 100%;
                    }
                    #newbdshare a, #newbdshare span
                    {
                        height: 20px;
                        margin-left: 4px;
                        margin-right: 4px;
                    }
                </style>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    </div>
    
    </div>
    <div class="clear">
    </div>
    <div id="footposdiv">
    </div>
    <div class="clear">
    </div>
    <div class="foot">
        <div class="line">
        </div>
        <div class="ourpingtai">
            <a href="admin/Login.aspx">后台登录</a>
        </div>
    </div>
    <div style="display: none">
    </div>
    </form>
</body>
</html>
