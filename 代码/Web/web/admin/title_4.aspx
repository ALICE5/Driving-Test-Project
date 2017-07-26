<%@ Page Language="C#" AutoEventWireup="true" CodeFile="title_4.aspx.cs" Inherits="title_4" %>

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

    <link href="Uploadify/uploadify.css" rel="stylesheet" type="text/css" />

    <script src="Uploadify/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="Uploadify/jquery.uploadify.v2.1.4.min.js" type="text/javascript"></script>

    <script src="Uploadify/swfobject.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('#uploadify').uploadify({
                'uploader': 'Uploadify/uploadify.swf',
                'script': 'Uploadify.ashx',
                'cancelImg': 'Uploadify/cancel.png',
                'folder': 'uploads',
                'auto': true,
                'buttonText': '',
                'multi': false,
                'buttonImg': 'Uploadify/browse.jpg',
                'fileSizeLimit': '200000000',
                'scriptData': { 'methed': 'uploadFile', 'arg1': 'value1' },
                'onComplete': function(event, queueID, file, serverData, data) {
                    //serverData为服务器端返回的字符串值
                    document.getElementById("rel").innerHTML = document.getElementById("rel").innerHTML + "</br>" + file.name + "文件上传成功。";
                    //alert(file.name + "文件上传成功。");
                }
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
        <div class="hd">
            <span class="fr"></span>题库管理
        </div>
        <div class="bd">
            <ul class="section">
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            题目:</label>
                        <asp:TextBox ID="TextBox2" runat="server" class="inputtext input-long" MaxLength="30"
                            Width="400"></asp:TextBox>
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            图片:</label>
                        <div id="fileQueue">
                        </div>
                        <input type="file" name="uploadify" id="uploadify" />
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            选项:</label>
                        A：<asp:TextBox ID="TextBoxA" runat="server" class="inputtext input-long" MaxLength="30"
                            Width="400"></asp:TextBox><br />
                        B：<asp:TextBox ID="TextBoxB" runat="server" class="inputtext input-long" MaxLength="30"
                            Width="400"></asp:TextBox><br />
                        C：<asp:TextBox ID="TextBoxC" runat="server" class="inputtext input-long" MaxLength="30"
                            Width="400"></asp:TextBox><br />
                        D：<asp:TextBox ID="TextBoxD" runat="server" class="inputtext input-long" MaxLength="30"
                            Width="400"></asp:TextBox><br />
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            选项:</label>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>D</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            答案解析:</label>
                        <asp:TextBox ID="TextBox4" runat="server" class="inputtext input-long" MaxLength="30"
                            TextMode="MultiLine" Width="400" Height="50"></asp:TextBox>
                    </div>
                    <div style="clear: both;">
                    </div>
                </li>
                <li>
                    <div style="width: 100%; float: left;">
                        <label class="label-like">
                            难度系数:</label>
                        <select name="select" id="select1" class="code" runat="server">
                            <option value="1">简单</option>
                            <option value="2">中等</option>
                            <option value="3">复杂</option>
                        </select>
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
