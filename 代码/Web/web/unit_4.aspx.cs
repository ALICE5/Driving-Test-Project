using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class unit_4 : System.Web.UI.Page
{
    public static int i;
    protected void Page_Load(object sender, EventArgs e)
    {
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
                yrxlbinfo.Text = "欢迎回来！" + (string)Session["UserName"];
            }
            else
            {
                Response.Redirect("login.aspx");
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            i = 1;
            lbnum.Text = i.ToString();
            Business.title_4 tit = new Business.title_4();
            Business.titleData4[] td = tit.Put(Request.QueryString["tittype"], "", "");
            lbtit.Text = td[0].tits;
            lbid.Text = td[0].Id;
            if (td[0].titimg != "")
            {
                lbimg.Text = "<img src='admin/uploads/" + td[0].titimg + "'>";
            }
            Repeater1.DataSource = tit.Frist(Request.QueryString["tittype"]);
            Repeater1.DataBind();
            tit = null;
            td = null;
        }
    }

    public static string StringTruncat(string oldStr, int maxLength)
    {
        string[] str = oldStr.Split('|');
        if (maxLength == 0) { oldStr = " A、" + str[maxLength].ToString(); }
        if (maxLength == 1) { oldStr = " B、" + str[maxLength].ToString(); }
        if (maxLength == 2) { oldStr = " C、" + str[maxLength].ToString(); }
        if (maxLength == 3) { oldStr = " D、" + str[maxLength].ToString(); }
        return oldStr;
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
    }

    protected void next_click(object sender, EventArgs e)
    {
        try
        {
            lbinfo.Text = "";
            lbimg.Text = "";
            Business.title_4 tit = new Business.title_4();
            Business.titleData4[] td = tit.Put(Request.QueryString["tittype"], lbid.Text, "next");
            lbtit.Text = td[0].tits;
            if (td[0].titimg != "")
            {
                lbimg.Text = "<img src='admin/uploads/" + td[0].titimg + "'>";
            }
            Repeater1.DataSource = tit.Next(Request.QueryString["tittype"], lbid.Text);
            Repeater1.DataBind();
            lbid.Text = td[0].Id;
            i += 1; lbnum.Text = i.ToString();
            tit = null;
            td = null;
        }
        catch (Exception m)
        {
            Response.Write("<script>alert('这是最后一题！')</script>");
        }

    }

    protected void last_click(object sender, EventArgs e)
    {
        try
        {
            lbinfo.Text = "";
            lbimg.Text = "";
            Business.title_4 tit = new Business.title_4();
            Business.titleData4[] td = tit.Put(Request.QueryString["tittype"], lbid.Text, "last");
            lbtit.Text = td[0].tits;
            if (td[0].titimg != "")
            {
                lbimg.Text = "<img src='admin/uploads/" + td[0].titimg + "'>";
            }
            Repeater1.DataSource = tit.Last(Request.QueryString["tittype"], lbid.Text);
            Repeater1.DataBind();
            lbid.Text = td[0].Id;
            i -= 1; lbnum.Text = i.ToString();
            tit = null;
            td = null;
        }
        catch (Exception m)
        {
            Response.Write("<script>alert('这是当前第一题！')</script>");
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Server.Transfer("Default.aspx?is=0");
    }

    protected void rdbtnA_CheckedChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            LinkButton rdbtn = item.FindControl("LinkButton1") as LinkButton;
            string id = rdbtn.CommandArgument.ToString().Trim();
            Business.title_4 title = new Business.title_4();
            Business.titleData4[] td = title.Select(id);
            if (rdbtn.CommandName.ToString().Trim() == td[0].titanswer.Trim())
            {
                //回答正确
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width:auto; display:inline-block; text-align:center; background:#008800'>恭喜你，答对了！</span></span>";
            }
            else
            {
                //回答错误
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width: auto; display: inline-block; text-align: center; background: #f00'>您答错了！标准答案是：" + td[0].titanswer.Trim() + "</span><br/><span style='color:Black;'>" + td[0].titparsing + "</span></span>";
                //将这题加入到错题集
                Business.errortit errortit = new Business.errortit();
                Business.errortitData ed = new Business.errortitData();
                ed.userid = (string)Session["UserId"];
                ed.errorid = lbid.Text;
                bool b = errortit.MD5(ed.userid, ed.errorid);
                if (b) { }
                else
                {
                    errortit.Insert(ed);
                }
            }
        }
    }

    protected void rdbtnB_CheckedChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            LinkButton rdbtn = item.FindControl("LinkButton2") as LinkButton;
            string id = rdbtn.CommandArgument.ToString().Trim();
            Business.title_4 title = new Business.title_4();
            Business.titleData4[] td = title.Select(id);
            if (rdbtn.CommandName.ToString().Trim() == td[0].titanswer.Trim())
            {
                //回答正确
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width:auto; display:inline-block; text-align:center; background:#008800'>恭喜你，答对了！</span></span>";
            }
            else
            {
                //回答错误
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width: auto; display: inline-block; text-align: center; background: #f00'>您答错了！标准答案是：" + td[0].titanswer.Trim() + "</span><br/><span style='color:Black;'>" + td[0].titparsing + "</span></span>";
                //将这题加入到错题集
                Business.errortit errortit = new Business.errortit();
                Business.errortitData ed = new Business.errortitData();
                ed.userid = (string)Session["UserId"];
                ed.errorid = lbid.Text;
                bool b = errortit.MD5(ed.userid, ed.errorid);
                if (b) { }
                else
                {
                    errortit.Insert(ed);
                }
            }
        }
    }

    protected void rdbtnC_CheckedChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            LinkButton rdbtn = item.FindControl("LinkButton3") as LinkButton;
            string id = rdbtn.CommandArgument.ToString().Trim();
            Business.title_4 title = new Business.title_4();
            Business.titleData4[] td = title.Select(id);
            if (rdbtn.CommandName.ToString().Trim() == td[0].titanswer.Trim())
            {
                //回答正确
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width:auto; display:inline-block; text-align:center; background:#008800'>恭喜你，答对了！</span></span>";
            }
            else
            {
                //回答错误
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width: auto; display: inline-block; text-align: center; background: #f00'>您答错了！标准答案是：" + td[0].titanswer.Trim() + "</span><br/><span style='color:Black;'>" + td[0].titparsing + "</span></span>";
                //将这题加入到错题集
                Business.errortit errortit = new Business.errortit();
                Business.errortitData ed = new Business.errortitData();
                ed.userid = (string)Session["UserId"];
                ed.errorid = lbid.Text;
                bool b = errortit.MD5(ed.userid, ed.errorid);
                if (b) { }
                else
                {
                    errortit.Insert(ed);
                }
            }
        }
    }

    protected void rdbtnD_CheckedChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            LinkButton rdbtn = item.FindControl("LinkButton4") as LinkButton;
            string id = rdbtn.CommandArgument.ToString().Trim();
            Business.title_4 title = new Business.title_4();
            Business.titleData4[] td = title.Select(id);
            if (rdbtn.CommandName.ToString().Trim() == td[0].titanswer.Trim())
            {
                //回答正确
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width:auto; display:inline-block; text-align:center; background:#008800'>恭喜你，答对了！</span></span>";
            }
            else
            {
                //回答错误
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width: auto; display: inline-block; text-align: center; background: #f00'>您答错了！标准答案是：" + td[0].titanswer.Trim() + "</span><br/><span style='color:Black;'>" + td[0].titparsing + "</span></span>";
                //将这题加入到错题集
                Business.errortit errortit = new Business.errortit();
                Business.errortitData ed = new Business.errortitData();
                ed.userid = (string)Session["UserId"];
                ed.errorid = lbid.Text;
                bool b = errortit.MD5(ed.userid, ed.errorid);
                if (b) { }
                else
                {
                    errortit.Insert(ed);
                }
            }
        }
    }   
}
