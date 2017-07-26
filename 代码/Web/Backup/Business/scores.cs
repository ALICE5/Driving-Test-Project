using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{
    public class scoresData
    {
        private string m_Id;
        private string m_userid;
        private string m_username;
        private string m_stime;
        private string m_scores;

        public string Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }
        public string userid
        {
            get { return this.m_userid; }
            set { this.m_userid = value; }
        }
        public string username
        {
            get { return this.m_username; }
            set { this.m_username = value; }
        }
        public string stime
        {
            get { return this.m_stime; }
            set { this.m_stime = value; }
        }
        public string scores
        {
            get { return this.m_scores; }
            set { this.m_scores = value; }
        }
    }
    public class scores
    {
        public bool Insert(scoresData datscores)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = " insert into scores (userid,username,stime,scores)  values (@userid,@username,@stime,@scores) ";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@userid", datscores.userid);
                objDB.Command.Parameters.AddWithValue("@username", datscores.username);
                objDB.Command.Parameters.AddWithValue("@stime", datscores.stime);
                objDB.Command.Parameters.AddWithValue("@scores", datscores.scores);
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
        public bool Modify(scoresData datscores)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = "update scores set userid=@userid,username=@username,stime=@stime,scores=@scores where Id = @Id";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@userid", datscores.userid);
                objDB.Command.Parameters.AddWithValue("@username", datscores.username);
                objDB.Command.Parameters.AddWithValue("@stime", datscores.stime);
                objDB.Command.Parameters.AddWithValue("@scores", datscores.scores);
                objDB.Command.Parameters.AddWithValue("@Id", datscores.Id);
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
                string strSql = "delete from scores where Id=" + Id + "";
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

        public scoresData[] Select(string Id)
        {
            int iRel = -1;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            scoresData[] datscores = new scoresData[1];
            string sql = "select * from scores where Id= " + Id + " ";
            try
            {
                objDB.OpenConnection();
                DataSet ds = objDB.QueryData(sql, "departmentinfo");
                if (ds.Tables.Count > 0)
                {
                    long nRow = ds.Tables[0].Rows.Count;
                    if (nRow > 0)
                    {
                        datscores = new scoresData[nRow];
                        for (int i = 0; i < nRow; i++)
                        {
                            datscores[i] = new scoresData();
                            datscores[i].userid = ds.Tables[0].Rows[i]["userid"].ToString();
                            datscores[i].username = ds.Tables[0].Rows[i]["username"].ToString();
                            datscores[i].stime = ds.Tables[0].Rows[i]["stime"].ToString();
                            datscores[i].scores = ds.Tables[0].Rows[i]["scores"].ToString();
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
            return datscores;
        }
        public DataTable Get()
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select * from scores";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }
    }
}
