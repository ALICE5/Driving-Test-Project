using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{
    public class titleData
    {
        private string m_Id;
        private string m_tittype;
        private string m_tits;
        private string m_titimg;
        private string m_titchose;
        private string m_titanswer;
        private string m_titparsing;
        private string m_level;

        public string Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }
        public string tittype
        {
            get { return this.m_tittype; }
            set { this.m_tittype = value; }
        }
        public string tits
        {
            get { return this.m_tits; }
            set { this.m_tits = value; }
        }
        public string titimg
        {
            get { return this.m_titimg; }
            set { this.m_titimg = value; }
        }
        public string titchose
        {
            get { return this.m_titchose; }
            set { this.m_titchose = value; }
        }
        public string titanswer
        {
            get { return this.m_titanswer; }
            set { this.m_titanswer = value; }
        }
        public string titparsing
        {
            get { return this.m_titparsing; }
            set { this.m_titparsing = value; }
        }
        public string titlevel
        {
            get { return this.m_level; }
            set { this.m_level = value; }
        }
    }
    public class title_1
    {
        public static string titimg = "";
        public bool Insert(titleData dattitle_1)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = " insert into title_1 (tittype,tits,titimg,titchose,titanswer,titparsing,titlevel)  values (@tittype,@tits,@titimg,@titchose,@titanswer,@titparsing,@titlevel) ";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@tittype", dattitle_1.tittype);
                objDB.Command.Parameters.AddWithValue("@tits", dattitle_1.tits);
                objDB.Command.Parameters.AddWithValue("@titimg", dattitle_1.titimg);
                objDB.Command.Parameters.AddWithValue("@titchose", dattitle_1.titchose);
                objDB.Command.Parameters.AddWithValue("@titanswer", dattitle_1.titanswer);
                objDB.Command.Parameters.AddWithValue("@titparsing", dattitle_1.titparsing);
                objDB.Command.Parameters.AddWithValue("@titlevel", dattitle_1.titlevel);
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
        public bool Modify(titleData dattitle_1)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = "update title_1 set tittype=@tittype,tits=@tits,titimg=@titimg,titchose=@titchose,titanswer=@titanswer,titparsing=@titparsing,titlevel=@titlevel where Id = @Id";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@tittype", dattitle_1.tittype);
                objDB.Command.Parameters.AddWithValue("@tits", dattitle_1.tits);
                objDB.Command.Parameters.AddWithValue("@titimg", dattitle_1.titimg);
                objDB.Command.Parameters.AddWithValue("@titchose", dattitle_1.titchose);
                objDB.Command.Parameters.AddWithValue("@titanswer", dattitle_1.titanswer);
                objDB.Command.Parameters.AddWithValue("@titparsing", dattitle_1.titparsing);
                objDB.Command.Parameters.AddWithValue("@titlevel", dattitle_1.titlevel);
                objDB.Command.Parameters.AddWithValue("@Id", dattitle_1.Id);
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
                string strSql = "delete from title_1 where Id=" + Id + "";
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

        public titleData[] Select(string Id)
        {
            int iRel = -1;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            titleData[] dattitle_1 = new titleData[1];
            string sql = "select * from title_1 where Id= " + Id + " ";
            try
            {
                objDB.OpenConnection();
                DataSet ds = objDB.QueryData(sql, "departmentinfo");
                if (ds.Tables.Count > 0)
                {
                    long nRow = ds.Tables[0].Rows.Count;
                    if (nRow > 0)
                    {
                        dattitle_1 = new titleData[nRow];
                        for (int i = 0; i < nRow; i++)
                        {
                            dattitle_1[i] = new titleData();
                            dattitle_1[i].tittype = ds.Tables[0].Rows[i]["tittype"].ToString();
                            dattitle_1[i].tits = ds.Tables[0].Rows[i]["tits"].ToString();
                            dattitle_1[i].titimg = ds.Tables[0].Rows[i]["titimg"].ToString();
                            dattitle_1[i].titchose = ds.Tables[0].Rows[i]["titchose"].ToString();
                            dattitle_1[i].titanswer = ds.Tables[0].Rows[i]["titanswer"].ToString();
                            dattitle_1[i].titparsing = ds.Tables[0].Rows[i]["titparsing"].ToString();
                            dattitle_1[i].titlevel = ds.Tables[0].Rows[i]["titlevel"].ToString();
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
            return dattitle_1;
        }

        public titleData[] Put(string tittype, string id, string type)
        {
            int iRel = -1;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            titleData[] dattitle_1 = new titleData[1];
            string sql = "";
            if (id == "")
            {
                sql = "select top 1 * from title_1 where tittype ='" + tittype + "' ";
            }
            else if (type == "next")
            {
                sql = "select top 1 * from title_1 where tittype ='" + tittype + "' and id >'" + id + "' ";
            }
            else if (type == "last")
            {
                sql = "select top 1 * from title_1 where tittype ='" + tittype + "' and id <'" + id + "' ";
            }
            try
            {
                objDB.OpenConnection();
                DataSet ds = objDB.QueryData(sql, "departmentinfo");
                if (ds.Tables.Count > 0)
                {
                    long nRow = ds.Tables[0].Rows.Count;
                    if (nRow > 0)
                    {
                        dattitle_1 = new titleData[nRow];
                        for (int i = 0; i < nRow; i++)
                        {
                            dattitle_1[i] = new titleData();
                            dattitle_1[i].Id = ds.Tables[0].Rows[i]["Id"].ToString();
                            dattitle_1[i].tittype = ds.Tables[0].Rows[i]["tittype"].ToString();
                            dattitle_1[i].tits = ds.Tables[0].Rows[i]["tits"].ToString();
                            dattitle_1[i].titimg = ds.Tables[0].Rows[i]["titimg"].ToString();
                            dattitle_1[i].titchose = ds.Tables[0].Rows[i]["titchose"].ToString();
                            dattitle_1[i].titanswer = ds.Tables[0].Rows[i]["titanswer"].ToString();
                            dattitle_1[i].titparsing = ds.Tables[0].Rows[i]["titparsing"].ToString();
                            dattitle_1[i].titlevel = ds.Tables[0].Rows[i]["titlevel"].ToString();
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
            return dattitle_1;
        }

        public titleData[] PutMyError(string id, string type, string userid)
        {
            int iRel = -1;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            titleData[] dattitle_1 = new titleData[1];
            string sql = "";
            if (id == "")
            {
                sql = "select top 1 * from title_1 where id in (select errorid from errortit where userid ='" + userid + "')";
            }
            else if (type == "next")
            {
                sql = "select top 1 * from title_1 where id >'" + id + "'  and id in (select errorid from errortit where userid ='" + userid + "')";
            }
            else if (type == "last")
            {
                sql = "select top 1 * from title_1 where id <'" + id + "' and id in (select errorid from errortit where userid ='" + userid + "')";
            }
            try
            {
                objDB.OpenConnection();
                DataSet ds = objDB.QueryData(sql, "departmentinfo");
                if (ds.Tables.Count > 0)
                {
                    long nRow = ds.Tables[0].Rows.Count;
                    if (nRow > 0)
                    {
                        dattitle_1 = new titleData[nRow];
                        for (int i = 0; i < nRow; i++)
                        {
                            dattitle_1[i] = new titleData();
                            dattitle_1[i].Id = ds.Tables[0].Rows[i]["Id"].ToString();
                            dattitle_1[i].tittype = ds.Tables[0].Rows[i]["tittype"].ToString();
                            dattitle_1[i].tits = ds.Tables[0].Rows[i]["tits"].ToString();
                            dattitle_1[i].titimg = ds.Tables[0].Rows[i]["titimg"].ToString();
                            dattitle_1[i].titchose = ds.Tables[0].Rows[i]["titchose"].ToString();
                            dattitle_1[i].titanswer = ds.Tables[0].Rows[i]["titanswer"].ToString();
                            dattitle_1[i].titparsing = ds.Tables[0].Rows[i]["titparsing"].ToString();
                            dattitle_1[i].titlevel = ds.Tables[0].Rows[i]["titlevel"].ToString();
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
            return dattitle_1;
        }

        public DataTable Get()
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select * from title_1";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable GetRandom()
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int intRandomNumber = rnd.Next();
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            //string sql = "select top 10 * from title_1 Order By Rnd(" + (-1 * intRandomNumber) + "*id) union all (select top 10 * from title_2 Order By Rnd(" + (-1 * intRandomNumber) + "*id)) union all (select top 15 * from title_3 Order By Rnd(" + (-1 * intRandomNumber) + "*id)) union all (select top 15 * from title_4 Order By Rnd(" + (-1 * intRandomNumber) + "*id))";
            string sql = "select top 100 * from (SELECT * FROM title_1 UNION SELECT *FROM title_2 UNION SELECT *FROM title_3 UNION SELECT *FROM title_4) T Order By NewID()";
           
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable GetRandomModel(string titlevel)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int intRandomNumber = rnd.Next();
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select top 100 * from (SELECT * FROM title_1 UNION SELECT *FROM title_2 UNION SELECT *FROM title_3 UNION SELECT *FROM title_4) T Order By NewID()";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable GetRd()
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int intRandomNumber = rnd.Next();
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "SELECT TOP 50 * FROM title_1 ORDER BY Rnd(id) ";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable Out(string id)
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select * from title_1 where id ='" + id + "'";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable Frist(string tittype)
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select top 1 * from title_1 where tittype ='" + tittype + "'";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable Next(string tittype, string id)
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select top 1 * from title_1 where tittype ='" + tittype + "' and id >'" + id + "'";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable Last(string tittype, string id)
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select top 1 * from title_1 where tittype ='" + tittype + "' and id <'" + id + "'";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable MyFrist(string tittype, string userid)
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select top 1 * from title_1 where  id in (select errorid from errortit where userid ='" + userid + "')";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable MyNext(string tittype, string id, string userid)
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select top 1 * from title_1 where  id >'" + id + "' and id in (select errorid from errortit where userid ='" + userid + "')";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable MyLast(string tittype, string id, string userid)
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select top 1 * from title_1 where id <'" + id + "' and id in (select errorid from errortit where userid ='" + userid + "')";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }
    }
}
