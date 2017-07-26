using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{
    public class errortitData
    {
        private string m_Id;
        private string m_userid;
        private string m_errorid;

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
        public string errorid
        {
            get { return this.m_errorid; }
            set { this.m_errorid = value; }
        }
    }
    public class errortit
    {
        public bool MD5(string userid, string errorid)
        {
            bool flag = false;
            string sql = "select * from errortit where userid='"+userid+"'";
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            DataTable dt = objDB.QueryDataTable(sql, "Users");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow tempRow in dt.Rows)
                {
                    if (tempRow["errorid"].ToString().Trim().Equals(errorid))
                    {
                        flag = true;
                    }
                    else
                    {
                         
                    }
                }
            }
            else
            {
 
            }
            dt = null;
            return flag;
        }

        public bool Insert(errortitData daterrortit)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = " insert into errortit (userid,errorid)  values (@userid,@errorid) ";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@userid", daterrortit.userid);
                objDB.Command.Parameters.AddWithValue("@errorid", daterrortit.errorid);
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
        public bool Modify(errortitData daterrortit)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = "update errortit set userid=@userid,errorid=@errorid where Id = @Id";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@userid", daterrortit.userid);
                objDB.Command.Parameters.AddWithValue("@errorid", daterrortit.errorid);
                objDB.Command.Parameters.AddWithValue("@Id", daterrortit.Id);
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
                string strSql = "delete from errortit where Id=" + Id + "";
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

        public errortitData[] Select(string Id)
        {
            int iRel = -1;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            errortitData[] daterrortit = new errortitData[1];
            string sql = "select * from errortit where Id= " + Id + " ";
            try
            {
                objDB.OpenConnection();
                DataSet ds = objDB.QueryData(sql, "departmentinfo");
                if (ds.Tables.Count > 0)
                {
                    long nRow = ds.Tables[0].Rows.Count;
                    if (nRow > 0)
                    {
                        daterrortit = new errortitData[nRow];
                        for (int i = 0; i < nRow; i++)
                        {
                            daterrortit[i] = new errortitData();
                            daterrortit[i].userid = ds.Tables[0].Rows[i]["userid"].ToString();
                            daterrortit[i].errorid = ds.Tables[0].Rows[i]["errorid"].ToString();
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
            return daterrortit;
        }
        public DataTable Get()
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select * from errortit";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }
    }
}
