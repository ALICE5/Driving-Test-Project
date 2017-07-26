<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true"
    CodeFile="regsis.aspx.cs" Inherits="regsis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/css_login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="findpwd">
            <div class="right">
                <div class="title">
                    <div class="bg">
                        <h2>
                            用户注册<span class="jiantou"></span></h2>
                    </div>
                </div>
                <div class="content">
                    <div class="bg">
                        <h3>
                            请输入用户基本信息</h3>
                        <form action="/findpwd" method="post" onsubmit="return checkfindfrm(this)">
                        <ul>
                            <li style="height: 30px; width: 500px; padding-left: 90px; color: #ff0000"></li>
                            <li class="sub" style="clear: both">帐号：</li><li class="input">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="inputtxt2"></asp:TextBox>
                            </li>
                            <li class="info"><span class="rightinfo" id="sp_error_email"></span>
                                <label style="color:red">*</label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                     ForeColor="Red" text="账号不能为空" ControlToValidate ="TextBox1" Display="Dynamic"  ></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator id="RegularExpressionValidator1" RunAt="Server" ControlToValidate="TextBox1"
                                    ValidationExpression="([a-zA-Z0-9]){6,}" errorMessage="账号不能少于6位" display="Dynamic"></asp:RegularExpressionValidator>                              
                            </li>
                            <li class="sub" style="clear: both">密码：</li><li class="input">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="inputtxt2" TextMode="Password"></asp:TextBox>
                            </li>
                            <li class="info"><span class="rightinfo" id="Span1"></span>
                                <label style="color:red">*</label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                     ForeColor="Red" text="密码不能为空" ControlToValidate ="TextBox2" Display="Dynamic"  ></asp:RequiredFieldValidator>  
                               <asp:RegularExpressionValidator id="RegularExpressionValidator2" RunAt="Server" ControlToValidate="TextBox2"
                                    ValidationExpression="^\d{6,}$" errorMessage="密码不能少于6位" display="Dynamic"></asp:RegularExpressionValidator> 
                               <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="NotEqual" Type="String" ForeColor="Red" 
                                   ErrorMessage="账号密码不能一致！" ControlToValidate="TextBox2" ControlToCompare="TextBox1" Display="Dynamic"></asp:CompareValidator>                             
                            </li>
                            <li class="sub" style="clear: both">用户名：</li><li class="input">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="inputtxt2" ></asp:TextBox>
                            </li>
                            <li class="info"><span class="rightinfo" id="Span2"></span>
                                <label style="color:red">*</label>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                     ForeColor="Red" text="用户名不能为空" ControlToValidate ="TextBox3" Display="Dynamic"  ></asp:RequiredFieldValidator>  
                              <asp:RegularExpressionValidator id="RegularExpressionValidator3" RunAt="Server" ControlToValidate="TextBox3"
                                    ValidationExpression="^[\u4e00-\u9fa5]{0,}$"  errorMessage="用户名必须保证是汉字" display="Dynamic"></asp:RegularExpressionValidator>                              
                            </li>
                            <li class="sub"></li>
                            <li class="submit">
                                <asp:Button ID="Button1" runat="server" Text="注册" OnClick="Button1_Click" CssClass="btn" />
                                <li class="sub"></li>
                                <li class="input"></li>
                                <br />
                                <li class="info"></li>
                        </ul>
                        </form>
                        <div class="clear">
                        </div>
                        <span id="lblInfo" runat="server" style="color: Red; font-size: 12px;"></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
