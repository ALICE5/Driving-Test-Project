<%@ Page Language="C#" AutoEventWireup="true" CodeFile="unit_2.aspx.cs" Inherits="unit_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <title>��У�������ۿ������</title>
    <link href="images/ShowDialog.css" rel="stylesheet" type="text/css" />
    <link href="images/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="nHead1Bg">
        <div class="nHead1Box">
            <div class="nHead1Right">
            </div>
            <div class="nHead1Left">
                <span>��ӭ���� �ݿ���⣡</span> <span>
                    <asp:Panel ID="Panel1" runat="server">
                        <a href="Regsis.aspx" class="lashou" style="font-family: ΢���ź�; font-weight: normal;">
                            <span>ע��</span></a> <a href="Login.aspx" class="lashou"><span style="font-family: ΢���ź�;
                                font-weight: normal;">��¼</span></a>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <asp:Label ID="yrxlbinfo" runat="server" Text=""></asp:Label>
                        <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">ע��</asp:LinkButton>
                    </asp:Panel>
                </span>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <div style='width: 760px; height: 40px; margin: 10px auto'>
    </div>
    <div class="ksmaindiv">
        <div class="topbar">
           ��·��ͨ�ź�</div>
        <div class="top">
            <div class="logo">
            </div>
            <div class="select">
                <div class="selecttop">
                </div>
                <ul>
                    <li><a class="on" href="Default.aspx">�½���ϰ</a></li>
                    <li><a href="error.aspx" target="_blank">������ϰ</a></li>
                    <li><a href="test.aspx" target="_blank">ģ�⿼��</a></li>
                                        <li><a href="paperlist.aspx" target="_blank">�μӿ���</a></li>
                </ul>
            </div>
            <div class="topbarbtns topbarbtnsl">
            </div>
        </div>
        <div class="hidder">
        </div>
        <div class="examone" id="main_M">
            <div id="msgshowbox" style="display: none">
                <div class="msgtitle">
                </div>
                <div class="msgcontent">
                    �޴����¼��������˳����ϰ/�����ϰ��</div>
                <div class="msgbtn">
                    <input type="button" value=" ȷ�� " id="yesgo" /></div>
            </div>
            <div class="ajshow" id="frm_main" style="display: block;">
                <div class="title">
                    <span id="t">
                        <asp:Label ID="lbnum" runat="server" Text=""></asp:Label>
                        ��<asp:Label ID="lbtit" runat="server" Text=""></asp:Label></span>
                    <input id="TrueRe" type="hidden" name="TrueRe">
                    <input id="web_note_id" type="hidden" name="web_note_id">
                </div>
                <div class="item">
                    <div id="qustionpic" class="right">
                        <asp:Label ID="lbimg" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="left">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <ul id="ul1">
                                    <li>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="A" CommandArgument='<%#Eval("id")%>'>
                                            <asp:RadioButton ID="A" runat="server" GroupName='<%#Eval("id")%>' OnCheckedChanged="rdbtnA_CheckedChanged" AutoPostBack="true"/></asp:LinkButton>
                                        <%# StringTruncat(Eval("titchose").ToString(), 0)%>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="B" CommandArgument='<%#Eval("id")%>'>
                                            <asp:RadioButton ID="B" runat="server" GroupName='<%#Eval("id")%>' OnCheckedChanged="rdbtnB_CheckedChanged" AutoPostBack="true"/></asp:LinkButton>
                                        <%# StringTruncat(Eval("titchose").ToString(), 1)%>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="C" CommandArgument='<%#Eval("id")%>'>
                                            <asp:RadioButton ID="C" runat="server" GroupName='<%#Eval("id")%>' OnCheckedChanged="rdbtnC_CheckedChanged" AutoPostBack="true"/></asp:LinkButton>
                                        <%# StringTruncat(Eval("titchose").ToString(), 2)%>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="D" CommandArgument='<%#Eval("id")%>'>
                                            <asp:RadioButton ID="D" runat="server" GroupName='<%#Eval("id")%>' OnCheckedChanged="rdbtnD_CheckedChanged" AutoPostBack="true"/></asp:LinkButton>
                                        <%# StringTruncat(Eval("titchose").ToString(), 3)%>
                                    </li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Label ID="lbinfo" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="item">
                    <div class="right" id="qustionpic">
                    </div>
                    <div class="left">
                        <ul id="ul_answers">
                        </ul>
                        <span id="rightanswer"></span>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="foothidder" id="foothidder">
            </div>
            <div class="tieba" id="div_js_btns">
                <asp:LinkButton ID="LinkButton5" runat="server" CssClass="inp l" OnClick="next_click">��һ��</asp:LinkButton>
                <asp:LinkButton ID="LinkButton6" runat="server" CssClass="inp" OnClick="last_click">��һ��</asp:LinkButton>
            </div>
        </div>
        <div class="userinfo">
            <div class="left">

            </div>
            <div class="right">
            </div>
            <div class="rightr">

            </div>
        </div>
        <div class="bottombar">
        </div>
    </div>
        <asp:Label ID="lbid" runat="server" Text="" Visible="false"></asp:Label>
    </form>
</body>
</html>
