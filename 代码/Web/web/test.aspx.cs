using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    public static int i = 0; public string gettime;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["UserId"] == null)
        {
            Response.Redirect("login.aspx");
        }

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
                lbinfo.Text = "欢迎回来！" + (string)Session["UserName"];
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            Business.title_1 title = new Business.title_1();
            Repeater1.DataSource = title.GetRandom();
            Repeater1.DataBind();
            title = null;
            i = 0;
            gettime = DateTime.Now.AddSeconds(30).ToString();
        }



    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int mysco = 0;//记录答对的题目数量
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            string mychose = "";
            RadioButton rb1 = (RadioButton)ri.FindControl("A");
            RadioButton rb2 = (RadioButton)ri.FindControl("B");
            RadioButton rb3 = (RadioButton)ri.FindControl("C");
            RadioButton rb4 = (RadioButton)ri.FindControl("D");

            if (rb1.Checked == true) { mychose = "A"; }
            if (rb2.Checked == true) { mychose = "B"; }
            if (rb3.Checked == true) { mychose = "C"; }
            if (rb4.Checked == true) { mychose = "D"; }

            Label lbanswer = (Label)ri.FindControl("lbanswer");
            Label lbtishi = (Label)ri.FindControl("lbtishi");
            Label pparsing = (Label)ri.FindControl("pparsing");
            Label lbanalysis = (Label)ri.FindControl("lbanalysis");
            if (mychose == lbanswer.Text)
            {
                mysco += 1;
                lbtishi.Text = "<div class='mtb8'>您的答案：<b>" + mychose + "</b><img class='imgclear' align='absmiddle' src='images/key_right.gif'></div>";
            }
            else
            {
                lbtishi.Text = "<div class='mtb8'>您的答案：<b>" + mychose + "</b><img class='imgclear' align='absmiddle' src='images/key_error.gif'><span class='14px'>正确答案：</span> <b>" + lbanswer.Text + "</b></div>";
            }
            //lbanalysis.Text = "<div class='Answer'>" + "答案解析：" + pparsing.Text + "</div>";
        }
        int score = mysco * 2;
        string str = "<script>alert('你一共答对了" + mysco + "题，你的最终得分是" + score + "分')</script>";
        Response.Write(str);
        //Label1.Visible = true;
        //Label1.Text = "一共答对" + mysco.ToString() + "题" + "    得分：" + mysco * 10;
        //Business.scores scores = new Business.scores();
        //Business.scoresData sd = new Business.scoresData();
        //sd.userid = (string)Session["UserId"];
        //sd.username = (string)Session["UserName"];
        //sd.stime = DateTime.Now.ToString();
        //sd.scores = score + "分";
        //scores.Insert(sd);
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

    public static string GetNum()
    {
        i += 1;
        return i.ToString();
    }

    public static string GetJavascript()
    {
        string str = "rightchose(" + i + ");";
        return str;
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Server.Transfer("Default.aspx?is=0");
    }
}
