using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class scorestb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Business.scores us = new Business.scores();
            Repeater1.DataSource = us.Get();
            Repeater1.DataBind();
            us = null;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string Id = e.CommandName;
        Business.scores us = new Business.scores();
        us.Delete(Id);
        Repeater1.DataSource = us.Get();
        Repeater1.DataBind();//删除完成后，对Repeater进行重新绑定，重新读取scores表里的数据
        us = null;
    }
}
