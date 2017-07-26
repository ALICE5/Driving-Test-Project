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
                objDB.Command.CommandType = System.Data.CommandType.Text;//ָ�������������Ż�����
                objDB.Command.CommandText = strSql;//��ȡ������Ҫ������Դִ�е� Transact-SQL ���
                objDB.Command.Parameters.AddWithValue("@pid", datbanks.pid);
                //Transact-SQL ����洢���̵Ĳ���
                objDB.Command.Parameters.AddWithValue("@ptype", datbanks.ptype);
                objDB.Command.Parameters.AddWithValue("@tid", datbanks.tid);
                iRel = objDB.Command.ExecuteNonQuery();//ִ��һ��SQL��� ������Ӱ�������
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
                string strSql = " insert into banks select '" + pid + "','����',id from (select top " + num + " id from (select * from title_1 union select * from title_2 union select * from title_3 union select * from title_4) T Order By NewID()) as TT";
                //Order By NewID()�����ѯ 
                //��banks���в����¼����title_1�ȱ��������ѯǰnum����¼��id��Ϊid��pid�Ǵ��α�ʾ�Ծ����
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
                if (ds.Tables.Count > 0)//��DataSet�еı����Ŀ����0
                {
                    long nRow = ds.Tables[0].Rows.Count;//����һ���ű����������0
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
            //�������в���ָ���Ծ�id�����Ŀ�����Ҳ��ҽ���������
            objDB.OpenConnection();
            dt = objDB.QueryDataTable(sql, "tabname");
            objDB.CloseConnection();
            objDB.Dispose();
            objDB = null;
            return dt;
        }
    }
}
