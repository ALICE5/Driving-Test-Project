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
            if (Request.QueryString["id"] != null)//判断是否为修改操作，若为修改则显示当前id的用户信息
            {
                Business.users ey = new Business.users();
                Business.usersData[] ed = ey.Select(Request.QueryString["id"]);
                TextBox1.Text = ed[0].userid;
                TextBox2.Text = ed[0].userpwrd;
                TextBox3.Text = ed[0].username;
                DropDownList1.SelectedValue = ed[0].usertype;
                ey = null;
                ed = null;
            }
        }
    }

    protected void BtnOk_Click(object sender, EventArgs e)
    {
        Business.users ey = new Business.users();
        Business.usersData ed = new Business.usersData();

        ed.userid = TextBox1.Text;
        ed.userpwrd = TextBox2.Text;
        ed.username = TextBox3.Text;
        ed.usertype = DropDownList1.SelectedValue;//将文本框中的信息保存到usersData中

        if (Request.QueryString["id"] != null)
        {
            ed.Id = Request.QueryString["id"];
            ey.Modify(ed);
        }
        else
        {
            ey.Insert(ed);
        }

        Response.Redirect("adm_userstb.aspx");//用户管理列表页面

        ey = null;
        ed = null;
    }
}
