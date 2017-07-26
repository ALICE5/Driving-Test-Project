using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CardTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Business.users us = new Business.users();
            Repeater1.DataSource = us.Get();
            Repeater1.DataBind();
            us = null;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string Id = e.CommandName;
        Business.users us = new Business.users();
        us.Delete(Id);
        Repeater1.DataSource = us.Get();//Repeater重新绑定删除后的用户表
        Repeater1.DataBind();
        us = null;
    }
}
