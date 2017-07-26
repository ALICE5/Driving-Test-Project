using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
public partial class crateimage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateCheckCodeImage(GenerateCheckCode());
    }

    public static string GenerateCheckCode()
    {
        int intFirst, intSec, intTemp;

        string checkCode = String.Empty;

        System.Random random = new Random();

        intFirst = random.Next(1, 10);//返回一个1-10范围内的随机数
        intSec = random.Next(1, 10);
        switch (random.Next(1, 3).ToString())
        {
            case "2"://若随机数为2则为减法，否则(1或3)为加法
                if (intFirst < intSec)
                {
                    intTemp = intFirst;
                    intFirst = intSec;
                    intSec = intTemp;
                }//使intFirst为较大值
                checkCode = intFirst + "-" + intSec + "=";
                System.Web.HttpContext.Current.Session["ValidCode"] =(intFirst - intSec).ToString() ;
                //利用Session记录验证码的正确值
                break;
            default:
                checkCode = intFirst + "+" + intSec + "=";
                System.Web.HttpContext.Current.Session["ValidCode"] = (intFirst + intSec).ToString();
                break;
        }

        //Response.Cookies.Add(new HttpCookie("ValidCode",Movie.Common.AES.EncryptAes(checkCode)));  
        return checkCode;
    }
    #region 产生波形滤镜效果
    //(改变整个图片的坐标点像素的颜色 达到整体扭曲的效果)
    private const double PI = 3.1415926535897932384626433832795;
    private const double PI2 = 6.283185307179586476925286766559;
    private static System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
    {
        System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

        // 将位图背景填充为白色  
        System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);
        graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
        //用白色填充由一对坐标、一个宽度和一个高度指定的矩形的内部
        graph.Dispose();

        double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;//true为图片的宽

        for (int i = 0; i < destBmp.Width; i++)
        {
            for (int j = 0; j < destBmp.Height; j++)
            {
                double dx = 0;
                dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                dx += dPhase;
                double dy = Math.Sin(dx);

                // 取得当前点的颜色  
                int nOldX = 0, nOldY = 0;
                nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                System.Drawing.Color color = srcBmp.GetPixel(i, j);
                if (nOldX >= 0 && nOldX < destBmp.Width
                 && nOldY >= 0 && nOldY < destBmp.Height)
                {
                    destBmp.SetPixel(nOldX, nOldY, color);//该函数将指定坐标处的像素设为指定的颜色
                }
            }
        }

        return destBmp;
    }
    #endregion

    //自定义CreateCheckCodeImage方法用来将验证码checkCode显示为噪点并显示在页面中
    public static void CreateCheckCodeImage(string checkCode)
    {
        if (checkCode == null || checkCode.Trim() == String.Empty)
            return;
        //创建一个指定大小的位图对象
        System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 15.0)), 25);
        Graphics g = Graphics.FromImage(image);
        //创建Graphics对象对验证码进行绘制噪点，FromImage()从指定的Image创建新的Graphics
        try
        {
            //生成随机生成器  
            Random random = new Random();

            //清空图片背景色  
            g.Clear(Color.White);

            //画图片的背景噪音线  
            for (int i = 0; i < 12; i++)
            {
                int x1 = random.Next(image.Width);//Next返回一个小于所指定值的随机数
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);//在两点之间绘制直线
            }

            Font font = new System.Drawing.Font("Arial", 16, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            //定义一个渐变画刷
            g.DrawString(checkCode, font, brush, 1, 1);//在指定位置并且用指定的Brush和Font对象绘制指定的文本字符串checkCode

            //画图片的前景噪音点  
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));//将指定坐标处的像素设为指定的颜色
            }

            image = TwistImage(image, true, 3, 1);//画图片的波形滤镜效果  

            //画图片的边框线  
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);//绘制由坐标对、宽度和高度指定的矩形

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);//将此图像以指定的格式保存到指定的流中
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.ContentType = "image/Gif";
            System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());//将Gif图片的二进制字符串写入到输出流
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }

    }  

}
