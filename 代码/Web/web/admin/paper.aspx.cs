using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["id"] != null)//判断是否为修改操作
            {
                Business.paper paper = new Business.paper();
                Business.paperData[] paperdata = paper.Select(Request.QueryString["id"]);
                TextBox1.Text = paperdata[0].ptit;
                //TextBox2.Text = paperdata[0].ptime;
                TextBox3.Text = paperdata[0].memos;
                TextBox4.Text = paperdata[0].t1;
                TextBox5.Text = paperdata[0].t2;
                TextBox6.Text = paperdata[0].t3;
                TextBox7.Text = paperdata[0].t4;
                DropDownList1.SelectedValue = paperdata[0].plevel;
                paper = null;
                paperdata = null;
            }
        }
    }

    protected void BtnOk_Click(object sender, EventArgs e)
    {
        Business.paper paper = new Business.paper();
        Business.paperData paperdata = new Business.paperData();
        paperdata.ptit = TextBox1.Text.Trim();
        paperdata.ptime = DateTime.Now.ToString();
        paperdata.memos = TextBox3.Text.Trim();
        paperdata.t1 = TextBox4.Text.Trim();
        paperdata.t2 = TextBox5.Text.Trim();
        paperdata.t3 = TextBox6.Text.Trim();
        paperdata.t4 = TextBox7.Text.Trim();
        paperdata.plevel = DropDownList1.SelectedValue;
        if (Request.QueryString["id"] != null)
        {
            paperdata.Id = Request.QueryString["id"];
            paper.Modify(paperdata);
        }
        else
        {
            int i = Convert.ToInt32(paperdata.t1) + Convert.ToInt32(paperdata.t2) + Convert.ToInt32(paperdata.t3) + Convert.ToInt32(paperdata.t4);
            Business.banks bank = new Business.banks();
            bank.Insert100(paperdata.ptit,i.ToString());
            paper.Insert(paperdata);
        }
        paper = null;
        paperdata = null;
        Response.Redirect("papertb.aspx");//试卷管理列表页面
    }

}
