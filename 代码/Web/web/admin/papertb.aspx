<%@ Page Language="C#" AutoEventWireup="true" CodeFile="papertb.aspx.cs" Inherits="papertb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理</title>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <link href="css/base.css" rel="stylesheet" type="text/css" />
    <link href="css/popDiv.css" rel="stylesheet" type="text/css" />

    <script src="js/popDiv.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
        <div class="hd">
            考试管理
        </div>
        <div class="bd">
            <div class="tb1">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tbody>
                        <tr style="font-family: Microsoft Yahei;">
                            <th width="50px">
                                序号
                            </th>
                            <th>
                                名称
                            </th>
                            <th>
                                发布时间
                            </th>
                            <th>
                                备注
                            </th>
                            <th>
                                题库1
                            </th>
                            <th>
                                题库2
                            </th>
                            <th>
                                题库3
                            </th>
                            <th>
                                题库4
                            </th>
                            <th>
                                难度系数
                            </th>
                            <th width="150px">
                                管理
                            </th>
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <tr style="font-family: Microsoft Yahei;">
                                    <td style="text-align: center;">
                                        <%#Eval("id")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <%#Eval("ptit")%> 
                                    </td>
                                    <td style="text-align: center;">
                                        <%#Eval("ptime")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <%#Eval("memos")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <%#Eval("t1")%>
                                    </td>
                                     <td style="text-align: center;">
                                        <%#Eval("t2")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <%#Eval("t3")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <%#Eval("t4")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <%#Eval("plevel")%>
                                    </td>
                                    <td style="text-align: center;">
                                        <a href='paper.aspx?id=<%#Eval("Id")%>' style="font-family: Microsoft Yahei;">修改</a>
                                        <asp:LinkButton Style="padding-left: 5px; padding-right: 5px" ID="LinkButton1" runat="server"
                                            CommandName='<%#Eval("id")%>' OnClientClick="return confirm('确认要删除该信息吗？');"><span style="font-family:Microsoft Yahei;">删除</span></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
    </form>
</body>
</html>
