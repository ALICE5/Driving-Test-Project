using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paperlist : System.Web.UI.Page
{
    public static int i = 0; public string gettime;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["UserId"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["is"] == "0")
            {
                Session["UserName"] = null;
            }
            if ((string)Session["UserName"] != null)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                lbinfo.Text = "欢迎回来！" + (string)Session["UserName"];
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            Business.paper title = new Business.paper();
            Repeater1.DataSource = title.Get();
            Repeater1.DataBind();
            title = null;

        }



    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Server.Transfer("Default.aspx?is=0");
    }
}
