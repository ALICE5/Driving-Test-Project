using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class title_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["id"] != null)//判断是否为修改操作
            {
                //tittype|tits|titchose|titanswer|titparsing
                Business.title_1 ey = new Business.title_1();
                Business.titleData1[] ed = ey.Select(Request.QueryString["id"]);
                //DropDownList2.SelectedValue = ed[0].tittype;
                TextBox2.Text = ed[0].tits;
                string[] str = ed[0].titchose.Split('|');
                TextBoxA.Text = str[0].Trim();
                TextBoxB.Text = str[1].Trim();
                TextBoxC.Text = str[2].Trim();
                TextBoxD.Text = str[3].Trim();
                DropDownList1.SelectedValue = ed[0].titanswer;
                TextBox4.Text = ed[0].titparsing;
                Business.title_1.titimg = ed[0].titimg;
                select1.Value = ed[0].titlevel;
                ey = null;
                ed = null;
            }
        }
    }

    protected void BtnOk_Click(object sender, EventArgs e)
    {
        Business.title_1 ey = new Business.title_1();
        Business.titleData1 ed = new Business.titleData1();

        ed.tittype = "道路交通安全法律、法规和规章";
        ed.tits = TextBox2.Text;
        ed.titimg = Business.title_1.titimg;
        ed.titchose = TextBoxA.Text.Trim() + "|" + TextBoxB.Text.Trim() + "|" + TextBoxC.Text.Trim() + "|" + TextBoxD.Text.Trim();
        ed.titanswer = DropDownList1.SelectedValue;
        ed.titparsing = TextBox4.Text;
        ed.titlevel = select1.Value;
        if (Request.QueryString["id"] != null)
        {
            ed.Id = Request.QueryString["id"];
            ey.Modify(ed);
        }
        else
        {
            ey.Insert(ed);
        }

        Response.Redirect("title_1tb.aspx");

        ey = null;
        ed = null;
    }
}
