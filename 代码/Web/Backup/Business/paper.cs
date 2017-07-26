using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{
    public class paperData
    {
        private string m_Id;
        private string m_ptit;
        private string m_ptime;
        private string m_memos;
        private string m_t1;
        private string m_t2;
        private string m_t3;
        private string m_t4;
        private string m_plevel;

        public string Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }
        public string ptit
        {
            get { return this.m_ptit; }
            set { this.m_ptit = value; }
        }
        public string ptime
        {
            get { return this.m_ptime; }
            set { this.m_ptime = value; }
        }
        public string memos
        {
            get { return this.m_memos; }
            set { this.m_memos = value; }
        }
        public string t1
        {
            get { return this.m_t1; }
            set { this.m_t1 = value; }
        }
        public string t2
        {
            get { return this.m_t2; }
            set { this.m_t2 = value; }
        }
        public string t3
        {
            get { return this.m_t3; }
            set { this.m_t3 = value; }
        }
        public string t4
        {
            get { return this.m_t4; }
            set { this.m_t4 = value; }
        }
        public string plevel
        {
            get { return this.m_plevel; }
            set { this.m_plevel = value; }
        }
    }
    public class paper
    {
        public bool Insert(paperData datpaper)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = " insert into paper (ptit,ptime,memos,t1,t2,t3,t4,plevel)  values (@ptit,@ptime,@memos,@t1,@t2,@t3,@t4,@plevel) ";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@ptit", datpaper.ptit);
                objDB.Command.Parameters.AddWithValue("@ptime", datpaper.ptime);
                objDB.Command.Parameters.AddWithValue("@memos", datpaper.memos);
                objDB.Command.Parameters.AddWithValue("@t1", datpaper.t1);
                objDB.Command.Parameters.AddWithValue("@t2", datpaper.t2);
                objDB.Command.Parameters.AddWithValue("@t3", datpaper.t3);
                objDB.Command.Parameters.AddWithValue("@t4", datpaper.t4);
                objDB.Command.Parameters.AddWithValue("@plevel", datpaper.plevel);
                iRel = objDB.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                iRel = -1;
            }
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            bRel = (iRel.Equals(1) ? true : false);
            return bRel;
        }
        public bool Modify(paperData datpaper)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = "update paper set ptit=@ptit,ptime=@ptime,memos=@memos,t1=@t1,t2=@t2,t3=@t3,t4=@t4,plevel=@plevel where Id = @Id";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@ptit", datpaper.ptit);
                objDB.Command.Parameters.AddWithValue("@ptime", datpaper.ptime);
                objDB.Command.Parameters.AddWithValue("@memos", datpaper.memos);
                objDB.Command.Parameters.AddWithValue("@t1", datpaper.t1);
                objDB.Command.Parameters.AddWithValue("@t2", datpaper.t2);
                objDB.Command.Parameters.AddWithValue("@t3", datpaper.t3);
                objDB.Command.Parameters.AddWithValue("@t4", datpaper.t4);
                objDB.Command.Parameters.AddWithValue("@plevel", datpaper.plevel);
                objDB.Command.Parameters.AddWithValue("@Id", datpaper.Id);
                iRel = objDB.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            { iRel = -1; }
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            bRel = (iRel.Equals(1) ? true : false); return bRel;
        }
        public bool Delete(string Id)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = "delete from paper where Id=" + Id + "";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                iRel = objDB.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                iRel = -1;
            }
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            bRel = (iRel.Equals(1) ? true : false);
            return bRel;
        }

        public paperData[] Select(string Id)
        {
            int iRel = -1;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            paperData[] datpaper = new paperData[1];
            string sql = "select * from paper where Id= " + Id + " ";
            try
            {
                objDB.OpenConnection();
                DataSet ds = objDB.QueryData(sql, "departmentinfo");
                if (ds.Tables.Count > 0)
                {
                    long nRow = ds.Tables[0].Rows.Count;
                    if (nRow > 0)
                    {
                        datpaper = new paperData[nRow];
                        for (int i = 0; i < nRow; i++)
                        {
                            datpaper[i] = new paperData();
                            datpaper[i].ptit = ds.Tables[0].Rows[i]["ptit"].ToString();
                            datpaper[i].ptime = ds.Tables[0].Rows[i]["ptime"].ToString();
                            datpaper[i].memos = ds.Tables[0].Rows[i]["memos"].ToString();
                            datpaper[i].t1 = ds.Tables[0].Rows[i]["t1"].ToString();
                            datpaper[i].t2 = ds.Tables[0].Rows[i]["t2"].ToString();
                            datpaper[i].t3 = ds.Tables[0].Rows[i]["t3"].ToString();
                            datpaper[i].t4 = ds.Tables[0].Rows[i]["t4"].ToString();
                            datpaper[i].plevel = ds.Tables[0].Rows[i]["plevel"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                iRel = -1;
            }
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return datpaper;
        }
        public DataTable Get()
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select * from paper";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }
    }
}
