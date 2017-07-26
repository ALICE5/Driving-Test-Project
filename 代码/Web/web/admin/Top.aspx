<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/base.css" rel="stylesheet" type="text/css" />
    <link href="css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="top">
        <div class="header">
            <div style="font-family: Microsoft Yahei; padding-top: 20px; padding-left: 30px; font-size: 30px;
                color: White; font-weight: bold;">
                驾考题库后台管理</div>
            <div class="right-nav">
                <div class="l-bg fl">
                </div>
                <div class="r-bg">
                    <a href="Login.aspx" target="_top">
                        <img src="images/quit.gif" width="69" height="17" /></a></div>
            </div>
        </div>
    </div>
    <div class="hd1">
    </div>
    <div class="clear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="30" background="images/main_31.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="8" height="30">
                            <img src="images/main_28.gif" width="8" height="30" />
                        </td>
                        <td width="147" background="images/main_29.gif">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="24%">
                                        &nbsp;
                                    </td>
                                    <td width="43%" height="20" valign="bottom" class="STYLE1">
                                    </td>
                                    <td width="33%">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="39">
                            <img src="images/main_30.gif" width="39" height="30" />
                        </td>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="20" valign="bottom">
                                        <asp:Label ID="lblInfo" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="lbname" runat="server" Text=""></asp:Label>
                                    &nbsp;&nbsp;
                                        今天是

                                        <script type="text/javascript" language="javascript">
                                            today = new Date();
                                            function initArray() {
                                                this.length = initArray.arguments.length
                                                for (var i = 0; i < this.length; i++)
                                                    this[i + 1] = initArray.arguments[i]
                                            }
                                            var d = new initArray(
' 星期日',
' 星期一',
' 星期二',
' 星期三',
' 星期四',
' 星期五',
' 星期六');
                                            document.write(
'',
today.getFullYear(), '年',
today.getMonth() + 1, '月',
today.getDate(), '日',
d[today.getDay() + 1],//getDay() 方法可返回表示星期的某一天的数字
'');
                                        </script>

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="17">
                            <img src="images/main_32.gif" width="17" height="30" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
