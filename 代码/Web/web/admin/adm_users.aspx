<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adm_users.aspx.cs" Inherits="Card" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/base.css" rel="stylesheet" type="text/css" />
    <link href="css/default.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="js/slotmachine.js"></script>

    <link type="text/css" href="css/lrtk.css" rel="stylesheet" />

<%--    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>--%>

</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
        <div class="hd">
            <span class="fr"></span>用户管理
        </div>
        <div class="bd">
            <ul class="section">
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            帐号:</label>
                        <asp:TextBox ID="TextBox1" runat="server" class="inputtext input-long" MaxLength="30"
                            Width="200"></asp:TextBox>
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            密码:</label>
                        <asp:TextBox ID="TextBox2" runat="server" class="inputtext input-long" MaxLength="30"
                            Width="200"></asp:TextBox>
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            姓名:</label>
                        <asp:TextBox ID="TextBox3" runat="server" class="inputtext input-long" MaxLength="30"
                            Width="200"></asp:TextBox>
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            权限:</label>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>系统管理员</asp:ListItem>
                            <asp:ListItem>普通用户</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
            </ul>
        </div>
        <ul class="section">
            <li>
                <asp:Button ID="Button1" runat="server" Text="保存" type="submit" name="btnEnter" Style="cursor: pointer"
                    class="btn_gray" OnClientClick="return check();" OnClick="BtnOk_Click" />
            </li>
            <li>
                <asp:Label ID="lblInfo" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </li>
        </ul>
    </form>
</body>
</html>
