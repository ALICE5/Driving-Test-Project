<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head" runat="server">
    <title>驾校在线理论考试题库</title>
    <link rel="stylesheet" href="css/reset.css" type="text/css" />
    <link rel="stylesheet" href="css/screen.css" type="text/css" />
    <!--[if IE 7]>
	<link rel="stylesheet" type="text/css" href="css/ie7.css" />
<![endif]-->

    <script language="javascript" type="text/javascript">
        function check() {
            document.getElementById("lblInfo").innerHTML = "";
            var account = document.getElementById("tbAccount").value;
            if (account.length == 0) {
                //alert("请输入用户名。");
                document.getElementById("lblInfo").innerHTML = "请输入用户名。";
                return false;
            }

            var password = document.getElementById("tbPwrd").value;
            if (password.length == 0) {
                //alert("请输入密码。");
                document.getElementById("lblInfo").innerHTML = "请输入密码。";
                return false;
            }

            var randomnumber = document.getElementById("tbRndNum").value;
            if (randomnumber.length == 0) {
                //alert("请输入验证码。");
                document.getElementById("lblInfo").innerHTML = "请输入验证码。";
                return false;
            }
            return true;
        }
    </script>

</head>
<body class="no-side">
    <div class="login-box">
        <div class="login-border">
            <div class="login-style">
                <div class="login-header">
                    <div class="logo clear">
                        <span class="title">驾考题库后台系统</span>
                    </div>
                </div>
                <form id="Form1" action="#" method="post" runat="server">
                <div class="login-inside">
                    <div class="login-data">
                        <div class="row clear">
                            <label for="user" style="font-family: Microsoft Yahei;">
                                账号:</label>
                            <input type="text" size="25" class="text" id="tbAccount" runat="server" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                     ForeColor="Red" text="账号不能为空" ControlToValidate ="tbAccount" Display="Dynamic"  ></asp:RequiredFieldValidator>
                        </div>
                        <div class="row clear">
                            <label for="password" style="font-family: Microsoft Yahei;">
                                密码:</label>
                            <input type="password" size="25" class="text" id="tbPwrd" runat="server" />
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                     ForeColor="Red" text="密码不能为空" ControlToValidate ="tbPwrd" Display="Dynamic"  ></asp:RequiredFieldValidator>
                        </div>
                        <div class="row clear">
                            <label for="user" style="font-family: Microsoft Yahei;">
                                验证码:</label>
                            <input type="text" size="25" class="text" id="tbRndNum" runat="server" style="width: 50px;" />
                            <img src="crateimage.aspx" align="middle" alt=""/>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">换一个</asp:LinkButton>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                     ForeColor="Red" text="验证码不能为空" ControlToValidate ="tbRndNum" Display="Dynamic"  ></asp:RequiredFieldValidator>
                        </div>
                        <asp:Button ID="Button1" class="submit" runat="server" Text="登陆" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;
                    </div>
                    <p>
                        <span id="lblInfo" runat="server" style="color: Red; font-size: 14px;"></span>
                </div>
                <div class="login-footer clear">
                </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
