using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Card : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //TextBox5.Text = Request.QueryString["babyname"];
            //if (Request.QueryString["id"] != null)
            //{
            //    Business.users ey = new Business.users();
            //    Business.usersData[] ed = ey.Select(Request.QueryString["id"]);
            //    TextBox1.Text = ed[0].userid;
            //    TextBox2.Text = ed[0].userpwrd;
            //    TextBox3.Text = ed[0].username;
            //    TextBox4.Text = ed[0].usertype;
            //    ey = null;
            //    ed = null;
            //}
        }
    }

    protected void BtnOk_Click(object sender, EventArgs e)
    {
        Business.users us = new Business.users();
        if (TextBox1.Text == TextBox2.Text)//密码和确认密码输入相同
        {
            bool b = us.Po((string)Session["UserId"], TextBox1.Text);
            if (b)
            {
                lblInfo.Visible = true;
                lblInfo.Text = "修改成功！";
            }
        }
        else
        {
            lblInfo.Visible = true;
            lblInfo.Text = "两次输入不一致！";
        }

    }
}
