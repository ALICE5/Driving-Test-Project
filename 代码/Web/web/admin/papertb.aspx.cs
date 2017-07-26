using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class papertb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Business.paper paper = new Business.paper();
            Repeater1.DataSource = paper.Get();
            Repeater1.DataBind();
            paper = null;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandName;
        Business.paper paper = new Business.paper();
        paper.Delete(id);
        Repeater1.DataSource = paper.Get();//删除完成后，重新绑定Repeater，重新读取paper表里的数据
        Repeater1.DataBind();
        paper = null;
    }
}
