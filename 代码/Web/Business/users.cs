using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{
    public class usersData
    {
        private string m_Id;
        private string m_userid;
        private string m_userpwrd;
        private string m_username;
        private string m_usertype;

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
        public string userpwrd
        {
            get { return this.m_userpwrd; }
            set { this.m_userpwrd = value; }
        }
        public string username
        {
            get { return this.m_username; }
            set { this.m_username = value; }
        }
        public string usertype
        {
            get { return this.m_usertype; }
            set { this.m_usertype = value; }
        }
    }
    public class users
    {
        private string m_UserType;
        private string m_ErrMsg;
        private string m_UserName;

        public string UserType
        {
            get { return this.m_UserType; }
            set { this.m_UserType = value; }
        }
        public string ErrMsg
        {
            get { return this.m_ErrMsg; }
            set { this.m_ErrMsg = value; }
        }
        public string UserName
        {
            get { return this.m_UserName; }
            set { this.m_UserName = value; }
        }

        public bool Login(string userid, string userpwd)
        {
            bool flag = false;
            string strSql = "SELECT * FROM Users WHERE (userid = '" + userid + "')";//查找指定用户账号的记录
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            DataTable dt = objDB.QueryDataTable(strSql, "Users");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow tempRow in dt.Rows)
                {
                    if (tempRow["userpwrd"].ToString().Trim().Equals(userpwd))
                    {
                        this.UserType = tempRow["UserType"].ToString().Trim();
                        this.UserName = tempRow["UserName"].ToString().Trim();

                        flag = true;
                    }
                    else
                    {
                        this.ErrMsg = "密码不正确。";
                    }
                }
            }
            else
            {
                this.ErrMsg = "用户名不存在。";
            }
            dt = null;
            return flag;
        }

        public bool Po(string userid, string userpwrd)
        {
            //修改用户密码
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = "update users set userpwrd=" + userpwrd + " where userid ='" + userid + "'";
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

        public bool Insert(usersData datusers)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = " insert into users (userid,userpwrd,username,usertype)  values (@userid,@userpwrd,@username,@usertype) ";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@userid", datusers.userid);
                objDB.Command.Parameters.AddWithValue("@userpwrd", datusers.userpwrd);
                objDB.Command.Parameters.AddWithValue("@username", datusers.username);
                objDB.Command.Parameters.AddWithValue("@usertype", datusers.usertype);
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

        public bool Modify(usersData datusers)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = "update users set userid=@userid,userpwrd=@userpwrd,username=@username,usertype=@usertype where Id = @Id";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@userid", datusers.userid);
                objDB.Command.Parameters.AddWithValue("@userpwrd", datusers.userpwrd);
                objDB.Command.Parameters.AddWithValue("@username", datusers.username);
                objDB.Command.Parameters.AddWithValue("@usertype", datusers.usertype);
                objDB.Command.Parameters.AddWithValue("@Id", datusers.Id);
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
                string strSql = "delete from users where Id=" + Id + "";
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

        public usersData[] Select(string Id)
        {
            int iRel = -1;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            usersData[] datusers = new usersData[1];
            string sql = "select * from users where Id= " + Id + " ";
            try
            {
                objDB.OpenConnection();
                DataSet ds = objDB.QueryData(sql, "departmentinfo");
                if (ds.Tables.Count > 0)
                {
                    long nRow = ds.Tables[0].Rows.Count;
                    if (nRow > 0)
                    {
                        datusers = new usersData[nRow];
                        for (int i = 0; i < nRow; i++)
                        {
                            datusers[i] = new usersData();
                            datusers[i].userid = ds.Tables[0].Rows[i]["userid"].ToString();
                            datusers[i].userpwrd = ds.Tables[0].Rows[i]["userpwrd"].ToString();
                            datusers[i].username = ds.Tables[0].Rows[i]["username"].ToString();
                            datusers[i].usertype = ds.Tables[0].Rows[i]["usertype"].ToString();
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
            return datusers;
        }

        public DataTable Get()
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select * from users";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }
    }
}
