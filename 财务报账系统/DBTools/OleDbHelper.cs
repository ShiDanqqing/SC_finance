using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace DataBase.Tools
{
    class OleDbHelper_dep
    {
        //(1) DDL（动态链接库--namespace 类）引用（程序集-框架-system.configuration）
        //(2) App.config (最好加个datagridview 用向导导入数据库，会生成如下配置)
        //<configuration> 
        //  ...
        //  <connectionStrings>
        //      <add name="AccessDbConnString" connectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\itcast.accdb"
        //          providerName="System.Data.OleDb" />
        //</connectionStrings>
        static string connString = //ConfigurationManager.ConnectionStrings["AccessDbConnString"].ConnectionString;
                          @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\studb.accdb";

         
        /// <summary>
        /// 输入查询SQL，返回一个dataTable.
        /// string sql = "select distinct subject from student";
        /// DataTable dt = OleDbHelper.GetDataTable(sql);
        /// </summary>
        /// <param name="sql">输入查询SQL</param>
        /// <returns>返回一个含有查询结果的dataTable</returns>
 
        public static DataTable GetDataTable(string sql)
        {           
            return  GetDataTable(sql,null);
            //OleDbConnection conn = new OleDbConnection(connString);

            //OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            //DataTable dt = new DataTable(); //memory            
            //adapter.Fill(dt);
            //return dt;
        }
        /// <summary>
        /// 输入查询SQL，返回一个dataTable.
        /// string sql = "select * from student where name=@name and class=@class";
        /// DataTable dt = OleDbHelper.GetDataTable(sql, new OleDbParameter("@name","ada"),new OleDbParameter("@class","IOS(2)") );
        /// </summary>
        /// <param name="sql">输入查询SQL</param>
        /// <returns>返回一个含有查询结果的dataTable</returns>
        public static DataTable GetDataTable(string sql,params OleDbParameter[] sqlParams)
        {   
            OleDbConnection conn = new OleDbConnection(connString);

            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);

            DataTable dt = new DataTable(); //memory     

            if (sqlParams != null)
            {
                adapter.SelectCommand.Parameters.AddRange(sqlParams);
            }
            adapter.Fill(dt);
            adapter.SelectCommand.Parameters.Clear();//防止 异常“另一个 OleDbParameterCollection 中已包含 OleDbParameter
            
            return dt;
        }

        /// <summary>
        /// 获取SQL查询的0行0列数据，一般用在统计查询SQL
        /// string sqlTotal = "select count(id) from student";
        /// object total=OleDbHelper.GetScaler(sqlTotal);
        /// lblStatics.Text = "Total:" + total;
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetScaler(string sql) 
        {
            //方法一：
            OleDbConnection conn = new OleDbConnection(connString);

            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn); //reader更加轻量

            DataTable dt = new DataTable(); //memory            
            adapter.Fill(dt);
            adapter.SelectCommand.Parameters.Clear();//防止 异常“另一个 OleDbParameterCollection 中已包含 OleDbParameter
            
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt.Rows[0][0];

            //方法二：
            //object rtn=null;
            //OleDbConnection conn = null;
            //OleDbDataReader reader = null;
            //try
            //{
            //     conn = new OleDbConnection(connString);

            //    conn.Open();

            //    OleDbCommand cmd = new OleDbCommand(sql, conn);

            //    reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        rtn=reader.GetValue(0);
            //    }
                 
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());//write log
            //}
            //finally
            //{
            //    if (reader != null)
            //    {
            //        reader.Close();
            //    }
            //    if (conn != null)
            //    {
            //        conn.Close();
            //    }
            //}
            //return rtn;
        }
        /// <summary>
        ///  string sql = "select ID from t_user where name=@name and pass=@pass";
        ///    object id=OleDbHelper.GetScaler(sql, 
        ///                         new OleDbParameter("@name", name), 
        ///                         new OleDbParameter("@pass", pass) );
        /// if (id != null) {
        ///     this.Hide();  new MainFrame().Show(); 
        ///  }
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns>若返回null，说明没有查询到任何值</returns>
        public static object GetScaler(string sql, params OleDbParameter[] sqlParams)
        {
            //方法一：
            OleDbConnection conn = new OleDbConnection(connString);

            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn); //reader更加轻量

            DataTable dt = new DataTable(); //memory        
            if (sqlParams != null)
            {
                adapter.SelectCommand.Parameters.AddRange(sqlParams);
            }
            adapter.Fill(dt);
            adapter.SelectCommand.Parameters.Clear();//防止 异常“另一个 OleDbParameterCollection 中已包含 OleDbParameter
            if (dt.Rows.Count == 0) 
            { 
                return null;
            }
            return dt.Rows[0][0];
        }

        ///// <summary>
        ///// 将SQL查询结果，填入下拉框cb中。
        ///// cbSubject.Items.Add("--全选--"); //首行加全选
        ///// cbSubject.SelectedIndex = 0;
        ///// string sql = "select distinct subject from student";
        ///// OleDbHelper.Fill(cbSubject, sql); 
        ///// </summary>
        ///// <param name="cb"></param>
        ///// <param name="sql"></param>
        //public static void Fill(ComboBox cb, string sql)
        //{
        //    OleDbConnection conn = null;
        //    OleDbDataReader reader = null;
        //    try
        //    {
        //        //string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\itcast.accdb";
        //        conn = new OleDbConnection(connString);

        //        conn.Open();

        //        OleDbCommand cmd = new OleDbCommand(sql, conn);

        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            cb.Items.Add(reader.GetString(0));
        //        }
        //        //reader.Close(); //try catch finally*
        //        // conn.Close(); //try catch finally*
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());//write log
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //        {
        //            reader.Close();
        //        }
        //        if (conn != null)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}

        /// <summary>
        /// 填删改SQL输入（insert update delete），返回影响行数
        ///  string sql = "delete from student where id="+id;
        ///  int row = OleDbHelper.ExecuteNonQuery(sql);
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            int row = 0;

            OleDbConnection conn = null;
            try
            {
                //string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\itcast.accdb";
                conn = new OleDbConnection(connString);

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
               
                row = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();//防止 异常“另一个 OleDbParameterCollection 中已包含 OleDbParameter
            
            }
            catch (Exception ex)
            {
                throw ex;
                row = -1;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return row;
        }
        /// <summary>
        ///  处理添删改SQL，带参数方式。 返回影响行数
        ///  string sql = "insert into student(sNum,sName,sSex,sAge,sClass,sSubject,sTel) "
        ///                          +"values(@sNum,@sName,@sSex,@sAge,@sClass,@sSubject,@sTel)";
        ///  int rows= OleDbHelper.ExecuteNonQuery(sql,  new OleDbParameter("@sNum",sNum),
        ///                                               new OleDbParameter("@sName",sName),
        ///                                                new OleDbParameter("@sSex",sSex),    
        ///                                                new OleDbParameter("@sAge",sAge),
        ///                                                new OleDbParameter("@sClass", sClass),
        ///                                                new OleDbParameter("@sSubject", sSubject),
        ///                                                new OleDbParameter("@sTel", sTel)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params OleDbParameter[] sqlParams)
        {
            int row = 0;

            OleDbConnection conn = null;
            try
            {
                //string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\itcast.accdb";
                conn = new OleDbConnection(connString);

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                if (sqlParams != null)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }
                row = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();//防止 异常“另一个 OleDbParameterCollection 中已包含 OleDbParameter
            
            }
            catch (Exception ex)
            {
                throw ex;
                row = -1;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return row;
        }

        
     
    }
}
