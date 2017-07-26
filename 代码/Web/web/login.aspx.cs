using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string userid = TextBox1.Text;
        string userpwrd = TextBox2.Text;
        Business.users us = new Business.users();
        Business.usersData ud = new Business.usersData();
        bool b = us.Login(userid, userpwrd);
        if (b)
        {
            Session["UserId"] = userid;
            Session["UserName"] = us.UserName;
            Response.Redirect("Default.aspx");
        }
        else
        {
            lblInfo.InnerHtml = us.ErrMsg;
        }
    }
}
