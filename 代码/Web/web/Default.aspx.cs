using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["is"] == "0")//判断是否注销
            {
                Session["UserName"] = null;
            }
            if ((string)Session["UserName"] != null)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                lbinfo.Text = "欢迎回来！" + (string)Session["UserName"];
                if (Request.QueryString["error"] == "0")//判断是否从错题页面转来且错题数为0
                {
                    this.msgshowbox.Visible = true;
                }
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }

        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Server.Transfer("Default.aspx?is=0");
    }

    protected void button1_Click(object sender, EventArgs e)
    {
        this.msgshowbox.Visible = false;
    }
}
