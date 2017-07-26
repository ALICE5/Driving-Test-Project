using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Business
{
    public class banksData
    {
        private string m_Id;
        private string m_pid;
        private string m_ptype;
        private string m_tid;

        public string Id
        {
            get { return this.m_Id; }
            set { this.m_Id = value; }
        }
        public string pid
        {
            get { return this.m_pid; }
            set { this.m_pid = value; }
        }
        public string ptype
        {
            get { return this.m_ptype; }
            set { this.m_ptype = value; }
        }
        public string tid
        {
            get { return this.m_tid; }
            set { this.m_tid = value; }
        }
    }
    public class banks
    {
        public bool Insert(banksData datbanks)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = " insert into banks (pid,ptype,tid)  values (@pid,@ptype,@tid) ";
                objDB.Command.CommandType = System.Data.CommandType.Text;//指定命令类型以优化性能
                objDB.Command.CommandText = strSql;//获取或设置要对数据源执行的 Transact-SQL 语句
                objDB.Command.Parameters.AddWithValue("@pid", datbanks.pid);
                //Transact-SQL 语句或存储过程的参数
                objDB.Command.Parameters.AddWithValue("@ptype", datbanks.ptype);
                objDB.Command.Parameters.AddWithValue("@tid", datbanks.tid);
                iRel = objDB.Command.ExecuteNonQuery();//执行一条SQL语句 返回受影响的行数
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

        public bool Insert100(string pid, string num)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = " insert into banks select '" + pid + "','分类',id from (select top " + num + " id from (select * from title_1 union select * from title_2 union select * from title_3 union select * from title_4) T Order By NewID()) as TT";
                //Order By NewID()随机查询 
                //向banks表中插入记录，从title_1等表中随机查询前num条记录的id作为id，pid是传参表示试卷标题
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

        public bool Modify(banksData datbanks)
        {
            int iRel = -1;
            bool bRel = false;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            try
            {
                objDB.OpenConnection();
                string strSql = "update banks set pid=@pid,ptype=@ptype,tid=@tid where Id = @Id";
                objDB.Command.CommandType = System.Data.CommandType.Text;
                objDB.Command.CommandText = strSql;
                objDB.Command.Parameters.AddWithValue("@pid", datbanks.pid);
                objDB.Command.Parameters.AddWithValue("@ptype", datbanks.ptype);
                objDB.Command.Parameters.AddWithValue("@tid", datbanks.tid);
                objDB.Command.Parameters.AddWithValue("@Id", datbanks.Id);
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
                string strSql = "delete from banks where Id=" + Id + "";
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

        public banksData[] Select(string Id)
        {
            int iRel = -1;
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            banksData[] datbanks = new banksData[1];
            string sql = "select * from banks where Id= " + Id + " ";
            try
            {
                objDB.OpenConnection();
                DataSet ds = objDB.QueryData(sql, "departmentinfo");
                if (ds.Tables.Count > 0)//若DataSet中的表的数目大于0
                {
                    long nRow = ds.Tables[0].Rows.Count;//若第一行张表的行数大于0
                    if (nRow > 0)
                    {
                        datbanks = new banksData[nRow];
                        for (int i = 0; i < nRow; i++)
                        {
                            datbanks[i] = new banksData();
                            datbanks[i].pid = ds.Tables[0].Rows[i]["pid"].ToString();
                            datbanks[i].ptype = ds.Tables[0].Rows[i]["ptype"].ToString();
                            datbanks[i].tid = ds.Tables[0].Rows[i]["tid"].ToString();
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
            return datbanks;
        }

        public DataTable Get()
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select * from banks";
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }

        public DataTable Out(string pid)
        {
            DataTable dt = new DataTable();
            DataAccess.CommonDB objDB = new DataAccess.CommonDB();
            string sql = "select * from (select * from title_1 union select * from title_2 union select * from title_3 union select * from title_4) as new where id in (select tid from banks where pid ='" + pid + "') Order By NewID()";
            //在题库表中查找指定试卷id里的题目，并且查找结果是随机的
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }
    }
}
