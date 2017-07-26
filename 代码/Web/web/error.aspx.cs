using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class error : System.Web.UI.Page
{
    public static int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["is"] == "0")//判断是否注销
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

            try
            {
                i = 1;
                lbnum.Text = i.ToString();
                Business.title_1 tit = new Business.title_1();
                Business.titleData1[] td = tit.PutMyError("", "", (string)Session["UserId"]);
                lbtit.Text = td[0].tits;
                lbid.Text = td[0].Id;
                if (td[0].titimg != "")
                {
                    lbimg.Text = "<img src='admin/uploads/" + td[0].titimg + "'>";
                }
                Repeater1.DataSource = tit.MyFrist(Request.QueryString["tittype"], (string)Session["UserId"]);
                Repeater1.DataBind();//使用Repeater进行数据绑定
                tit = null;
                td = null;
            }
            catch (Exception m)
            {
                Response.Redirect("Default.aspx?error=0");
                
                
            }

        }
    }

    public static string StringTruncat(string oldStr, int maxLength)
    {
        string[] str = oldStr.Split('|');//使用Split()函数将选项拆分后存到数组中
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
            Business.title_1 tit = new Business.title_1();
            Business.titleData1[] td = tit.PutMyError(lbid.Text, "next", (string)Session["UserId"]);//当前编号的下一道题目
            lbtit.Text = td[0].tits;
            if (td[0].titimg != "")
            {
                lbimg.Text = "<img src='admin/uploads/" + td[0].titimg + "'>";
            }
            Repeater1.DataSource = tit.MyNext(Request.QueryString["tittype"], lbid.Text, (string)Session["UserId"]);
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
            Business.title_1 tit = new Business.title_1();
            Business.titleData1[] td = tit.PutMyError(lbid.Text, "last", (string)Session["UserId"]);//当前编号的上一道题目
            lbtit.Text = td[0].tits;
            if (td[0].titimg != "")
            {
                lbimg.Text = "<img src='admin/uploads/" + td[0].titimg + "'>";
            }
            Repeater1.DataSource = tit.MyLast(Request.QueryString["tittype"], lbid.Text, (string)Session["UserId"]);
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

    protected void lbtnDelError_Click(object sender, EventArgs e)
    {
        Business.errortit errortit = new Business.errortit();
        Business.errortitData ed = new Business.errortitData();
        ed.userid = (string)Session["UserId"];
        ed.errorid = lbid.Text;
        errortit.Delete(ed.errorid, ed.userid);
        Response.Redirect("error.aspx");//删除完成后重新加载错题页面

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
            string answer = rdbtn.CommandArgument.ToString().Trim();
            if (rdbtn.CommandName.ToString().Trim() == rdbtn.CommandArgument.ToString().Trim())
            {
                //回答正确
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width:auto; display:inline-block; text-align:center; background:#008800'>恭喜你，答对了！</span></span>";
            }
            else
            {
                //回答错误
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width: auto; display: inline-block; text-align: center; background: #f00'>您答错了！标准答案是：" + answer + "</span></span>";
            }
        }
    }

    protected void rdbtnB_CheckedChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            LinkButton rdbtn = item.FindControl("LinkButton2") as LinkButton;
            string answer = rdbtn.CommandArgument.ToString().Trim();
            if (rdbtn.CommandName.ToString().Trim() == rdbtn.CommandArgument.ToString().Trim())
            {
                //回答正确
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width:auto; display:inline-block; text-align:center; background:#008800'>恭喜你，答对了！</span></span>";
            }
            else
            {
                //回答错误
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width: auto; display: inline-block; text-align: center; background: #f00'>您答错了！标准答案是：" + answer + "</span></span>";
            }
        }
    }

    protected void rdbtnC_CheckedChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            LinkButton rdbtn = item.FindControl("LinkButton3") as LinkButton;
            string answer = rdbtn.CommandArgument.ToString().Trim();
            if (rdbtn.CommandName.ToString().Trim() == rdbtn.CommandArgument.ToString().Trim())
            {
                //回答正确
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width:auto; display:inline-block; text-align:center; background:#008800'>恭喜你，答对了！</span></span>";
            }
            else
            {
                //回答错误
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width: auto; display: inline-block; text-align: center; background: #f00'>您答错了！标准答案是：" + answer + "</span></span>";
            }
        }
    }

    protected void rdbtnD_CheckedChanged(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            LinkButton rdbtn = item.FindControl("LinkButton4") as LinkButton;
            string answer = rdbtn.CommandArgument.ToString().Trim();
            if (rdbtn.CommandName.ToString().Trim() == rdbtn.CommandArgument.ToString().Trim())
            {
                //回答正确
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width:auto; display:inline-block; text-align:center; background:#008800'>恭喜你，答对了！</span></span>";
            }
            else
            {
                //回答错误
                lbinfo.Text = "<span id='rightanswer' style='display: block; text-align: left; width: 100%;'><span style='width: auto; display: inline-block; text-align: center; background: #f00'>您答错了！标准答案是：" + answer + "</span></span>";
            }
        }
    }   
}
