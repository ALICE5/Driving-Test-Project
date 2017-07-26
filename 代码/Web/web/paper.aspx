<%@ Page Language="C#" AutoEventWireup="true" CodeFile="paper.aspx.cs" Inherits="paper" %>

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
        <div style="float: right; position: relative; width: 300px;">
            <div class="boxunline">
            </div>
            <div class="clear">
            </div>
            <div id="tips" style="_width: 300px; _overflow: hidden">
                <div id="kssjCnt" style="margin: 10px 15px; width: 100%;">
                </div>
                <div id="Div1" style="margin: 10px 15px; width: 100%;">
                    <font color="gray" size="2px">剩余时间:</font> <span style="color: red; font-size: 24px; font-family: Arial;">

                        <script language="JavaScript">   

                            var maxtime = 30 * 60 //一个小时，按秒计算，自己调整!   
                            function CountDown() {
                                if (maxtime >= 0) {
                                    minutes = Math.floor(maxtime / 60);
                                    seconds = Math.floor(maxtime % 60);
                                    msg = "距离结束还有" + minutes + "分" + seconds + "秒";
                                    document.all["timer"].innerHTML = msg;
                                    if (maxtime == 5 * 60) alert('注意，还有5分钟!');
                                    --maxtime;
                                }
                                else {
                                    clearInterval(timer);
                                    alert("时间到，结束!");
                                }
                            }
                            timer = setInterval("CountDown()", 1000);   //1000毫秒=1秒
  
                        </script>

                        <div id="timer" style="color: red">
                        </div>
                    </span>
                </div>

                <table id="idboxs" class="idbox" cellspacing="1" cellpadding="2" border="0" bgcolor="#7aaee3"
                    bgcolor1="#906000">
                    <tbody>
                        <tr align="center" bgcolor="#FFFFFF">
                            <td id="EOV1" class="ExamOrderViewWait">
                                1
                            </td>
                            <td id="EOV2" class="ExamOrderViewWait">
                                2
                            </td>
                            <td id="EOV3" class="ExamOrderViewWait">
                                3
                            </td>
                            <td id="EOV4" class="ExamOrderViewWait">
                                4
                            </td>
                            <td id="EOV5" class="ExamOrderViewWait">
                                5
                            </td>
                            <td id="EOV6" class="ExamOrderViewWait">
                                6
                            </td>
                            <td id="EOV7" class="ExamOrderViewWait">
                                7
                            </td>
                            <td id="EOV8" class="ExamOrderViewWait">
                                8
                            </td>
                            <td id="EOV9" class="ExamOrderViewWait">
                                9
                            </td>
                            <td id="EOV10" class="ExamOrderViewWait">
                                10
                            </td>
                        </tr>
                        <tr align="center" bgcolor="#FFFFFF">
                            <td id="EOV11" class="ExamOrderViewWait">
                                11
                            </td>
                            <td id="EOV12" class="ExamOrderViewWait">
                                12
                            </td>
                            <td id="EOV13" class="ExamOrderViewWait">
                                13
                            </td>
                            <td id="EOV14" class="ExamOrderViewWait">
                                14
                            </td>
                            <td id="EOV15" class="ExamOrderViewWait">
                                15
                            </td>
                            <td id="EOV16" class="ExamOrderViewWait">
                                16
                            </td>
                            <td id="EOV17" class="ExamOrderViewWait">
                                17
                            </td>
                            <td id="EOV18" class="ExamOrderViewWait">
                                18
                            </td>
                            <td id="EOV19" class="ExamOrderViewWait">
                                19
                            </td>
                            <td id="EOV20" class="ExamOrderViewWait">
                                20
                            </td>
                        </tr>
                        <tr align="center" bgcolor="#FFFFFF">
                            <td id="EOV21" class="ExamOrderViewWait">
                                21
                            </td>
                            <td id="EOV22" class="ExamOrderViewWait">
                                22
                            </td>
                            <td id="EOV23" class="ExamOrderViewWait">
                                23
                            </td>
                            <td id="EOV24" class="ExamOrderViewWait">
                                24
                            </td>
                            <td id="EOV25" class="ExamOrderViewWait">
                                25
                            </td>
                            <td id="EOV26" class="ExamOrderViewWait">
                                26
                            </td>
                            <td id="EOV27" class="ExamOrderViewWait">
                                27
                            </td>
                            <td id="EOV28" class="ExamOrderViewWait">
                                28
                            </td>
                            <td id="EOV29" class="ExamOrderViewWait">
                                29
                            </td>
                            <td id="EOV30" class="ExamOrderViewWait">
                                30
                            </td>
                        </tr>
                        <tr align="center" bgcolor="#FFFFFF">
                            <td id="EOV31" class="ExamOrderViewWait">
                                31
                            </td>
                            <td id="EOV32" class="ExamOrderViewWait">
                                32
                            </td>
                            <td id="EOV33" class="ExamOrderViewWait">
                                33
                            </td>
                            <td id="EOV34" class="ExamOrderViewWait">
                                34
                            </td>
                            <td id="EOV35" class="ExamOrderViewWait">
                                35
                            </td>
                            <td id="EOV36" class="ExamOrderViewWait">
                                36
                            </td>
                            <td id="EOV37" class="ExamOrderViewWait">
                                37
                            </td>
                            <td id="EOV38" class="ExamOrderViewWait">
                                38
                            </td>
                            <td id="EOV39" class="ExamOrderViewWait">
                                39
                            </td>
                            <td id="EOV40" class="ExamOrderViewWait">
                                40
                            </td>
                        </tr>
                        <tr align="center" bgcolor="#FFFFFF">
                            <td id="EOV41" class="ExamOrderViewWait">
                                41
                            </td>
                            <td id="EOV42" class="ExamOrderViewWait">
                                42
                            </td>
                            <td id="EOV43" class="ExamOrderViewWait">
                                43
                            </td>
                            <td id="EOV44" class="ExamOrderViewWait">
                                44
                            </td>
                            <td id="EOV45" class="ExamOrderViewWait">
                                45
                            </td>
                            <td id="EOV46" class="ExamOrderViewWait">
                                46
                            </td>
                            <td id="EOV47" class="ExamOrderViewWait">
                                47
                            </td>
                            <td id="EOV48" class="ExamOrderViewWait">
                                48
                            </td>
                            <td id="EOV49" class="ExamOrderViewWait">
                                49
                            </td>
                            <td id="EOV50" class="ExamOrderViewWait">
                                50
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div style="padding: 10px 0">
                    <span class="slslw"></span> <font color="gray" size="2px">未答题</font>
                    <span class="slsly"></span> <font color="gray" size="2px">已答题</font>
                    <div style="height: 32px; padding-top: 4px; width: 300px">
                        <div style="padding-right: 22px; padding-left: 0px; width: 90px; float: left; padding-bottom: 5px;
                            padding-top: 5px">
                            <asp:Button ID="Button2" runat="server" Text="提交试卷" OnClick="Button1_Click" CssClass="btn" />
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div id="sjts" style="width: 100%; text-align: right">
            </div>
            <div style="height: 250px; clear: both; margin-top: 0px;">
            </div>
            <div class="boxunline">
            </div>
        </div>
    </div>
    <div class="right fleft">
        <div class="rightcon" style="height: auto">
            <div class="righttllllluu">
                <div class="bgbg">
                    <span class="mnkstttt"><span class="mnkstkl">驾校理论考试题库</span>
                    </span>
                    <span>
                    <asp:Label ID="lblTitle" runat="server" class="mnkstkl"></asp:Label>
                    </span>
                    <br>
                    <div class="ttttsdsds">
                        <span class="tlll"><span class="tl111">总分100分（90分过关）</span><br>
                            <div class="h11">
                            </div>
                        </span>
                    </div>
                </div>
            </div>
            <div class="rightmain">
                <input type="hidden" id="EOVal" value="0" />
                <div class="rightmainleft">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class='it bgrr'>
                                <h3>
                                    <b>
                                        <%# GetNum()%>、</b>
                                    <%#Eval("tits")%></h3>
                                <dl class="imgr">
                                    <img src="admin/uploads/<%#Eval("titimg")%>" id="imgnone<%#Eval("titimg")%>" /></dl>
                                <ul id="keySelWait1" class="i mtxzt">
                                    <li>
                                        <asp:RadioButton ID="A" runat="server" GroupName='<%#Eval("id")%>' Text='<%# StringTruncat(Eval("titchose").ToString(), 0)%>'
                                            onclick='<%# GetJavascript()%>' /></li>
                                    <li>
                                        <asp:RadioButton ID="B" runat="server" GroupName='<%#Eval("id")%>' Text='<%# StringTruncat(Eval("titchose").ToString(), 1)%>'
                                            onclick='<%# GetJavascript()%>' /></li>
                                    <li>
                                        <asp:RadioButton ID="C" runat="server" GroupName='<%#Eval("id")%>' Text='<%# StringTruncat(Eval("titchose").ToString(), 2)%>'
                                            onclick='<%# GetJavascript()%>' /></li>
                                    <li>
                                        <asp:RadioButton ID="D" runat="server" GroupName='<%#Eval("id")%>' Text='<%# StringTruncat(Eval("titchose").ToString(), 3)%>'
                                            onclick='<%# GetJavascript()%>' /></li>
                                    <asp:Label ID="lbanswer" runat="server" Text='<%#Eval("titanswer")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="pparsing" runat="server" Text='<%#Eval("titparsing")%>' Visible="false"></asp:Label>
                                    <div class="clear">
                                    </div>
                                    <asp:Label ID="lbtishi" runat="server"></asp:Label>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div id="defen" class="defen" style="margin-top: 0px;">
                    </div>
                    <a name="Bottom"></a>
                    <div id="ti_jiao" style="padding: 18px; background-color: #f7fbff;">
                        <asp:Button ID="Button1" runat="server" Text="提交试卷" OnClick="Button1_Click" CssClass="btn" />
                    </div>
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
