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

public partial class Top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["USERINFO"] == null)
        //{
        //    // Response.Redirect("Login.aspx");
        //}
        //if (Session["userid"] == null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
        //else
        //{
        //    //string un = Request.Cookies["USERINFO"]["UserName"].ToString();
        //    if (!Page.IsPostBack)
        //    {
        //        this.lblInfo.Text = "欢迎你，" + (string)Session["UserName"] + "。";
        //    }
        //}
        this.lblInfo.Text = "当前用户，" + (string)Session["UserName"] + "。";
    }
}
