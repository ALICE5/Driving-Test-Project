<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                        <asp:Label ID="lbinfo" runat="server" Text=""></asp:Label>
                        <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click">ע��</asp:LinkButton>                        
                    </asp:Panel>
                </span>
            </div>
        </div>
    </div>
    <div style='width: 760px; height: 40px; margin: 10px auto'>
    </div>
    <div class="ksmaindiv">
        <div class="topbar">
             С����Ŀһ����֪ʶ�������</div>
        <div class="top">
            <div class="logo">
            </div>
            <div class="select">
                <div class="selecttop">
                </div>
                <ul>
                    <li><a class="on">�½���ϰ</a></li>
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
            <div id="msgshowbox"  runat="server" visible="false">
                <div class="msgtitle">
                </div>
                <div class="msgcontent">
                    �޴����¼���������½���ϰ��</div>
                <div class="msgbtn">
                  <asp:Button ID="button1" runat="server" OnClick="button1_Click" Text="ȷ��"/>
                       <%-- <input type="button" value=" ȷ�� " id="yesgo" onclick=""/>--%></div>
            </div>
            <div class="ajshow" id="frm_main" style="display: block;">
                <div class="title">
                </div>
                <div class="item">
                    <div id="qustionpic" class="right">
                    </div>
                    <div class="left">
                        <ul class="chapter">
                            <li><a href="unit_1.aspx?tittype=��·��ͨ��ȫ���ɡ�����͹���">1����·��ͨ��ȫ���ɡ�����͹���</a></li>
                            <li><a href="unit_2.aspx?tittype=��·��ͨ�ź�">2����·��ͨ�ź�</a></li>
                            <li><a href="unit_3.aspx?tittype=��ȫ�г���������ʻ����֪ʶ">3����ȫ�г���������ʻ����֪ʶ</a></li>
                            <li><a href="unit_4.aspx?tittype=��������ʻ������ػ���֪ʶ">4����������ʻ������ػ���֪ʶ</a></li>
                        </ul>
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
        </div>
        <div class="userinfo">
            <div class="right">
            </div>
        </div>
        <div class="bottombar">
        </div>
    </div>
    </form>
</body>
</html>
