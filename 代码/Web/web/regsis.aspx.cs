using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class regsis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Business.users us = new Business.users();
        Business.usersData ud = new Business.usersData();
        ud.userid = TextBox1.Text;
        ud.userpwrd = TextBox2.Text;
        ud.username = TextBox3.Text;
        ud.usertype = "普通用户";
        bool b = us.Insert(ud);
        if (b)
        {
            Session["UserId"] = ud.userid;
            Session["UserName"] = ud.username;
            Response.Redirect("Default.aspx");

        }
        else
        {
            lblInfo.InnerHtml = us.ErrMsg;
        }
    }
}
