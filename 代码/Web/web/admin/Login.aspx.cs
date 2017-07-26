using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string userid = tbAccount.Value.Trim();
        if (userid.Length.Equals(0))
        {
            lblInfo.InnerHtml = "登录出错：请输入用户名！";
            return;
        }
        string userpwrd = tbPwrd.Value.Trim();
        if (userpwrd.Length.Equals(0))
        {
            lblInfo.InnerHtml = "登录出错：请输入密码！";
            return;
        }
        if (tbRndNum.Value.Trim().Length.Equals(0))
        {
            lblInfo.InnerHtml = "登录出错：请输入验证码！";
            return;
        }
        else if (tbRndNum.Value.Trim() != (string)Session["ValidCode"])
        {
            lblInfo.InnerHtml = "登录出错：验证码错误！";
            return;
        }
        Business.users us = new Business.users();
        Business.usersData ud = new Business.usersData();
        bool b = us.Login(userid, userpwrd);
        if (b)
        {
            Session["UserId"] = userid;
            Session["UserName"] = us.UserName;
            if (us.UserType.Trim() == "系统管理员")
            {
                Response.Redirect("adm_index.htm");
            }
           
        }
        else
        {
            lblInfo.InnerHtml = us.ErrMsg;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    }
}
