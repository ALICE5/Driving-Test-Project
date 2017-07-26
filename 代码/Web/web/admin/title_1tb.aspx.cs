using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class title_1tb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Business.title_1 us = new Business.title_1();
            Repeater1.DataSource = us.Get();
            Repeater1.DataBind();
            us = null;
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string Id = e.CommandName;
        Business.title_1 us = new Business.title_1();
        us.Delete(Id);
        Repeater1.DataSource = us.Get();
        Repeater1.DataBind();//删除完成后，重新读取title_1表中的数据，与Repeater进行绑定显示
        us = null;
    }
}
