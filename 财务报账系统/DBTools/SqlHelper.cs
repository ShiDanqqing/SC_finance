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
    class SqlHelper
    {
        //(1) DDL（动态链接库--namespace 类）引用（程序集-框架-system.configuration）
        //(2) App.config / Web.config (最好加个datagridview 用向导导入数据库，会生成如下配置)
        //<configuration> 
        //  ...
        //  <connectionStrings>
        //       <add name="SQLDBConnectionString" connectionString="Data Source=.;Initial Catalog=studb;Integrated Security=True"
        //          providerName="System.Data.SqlClient" />
        //</connectionStrings>
        static string connString = ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ConnectionString; 

         
        /// <summary>
        /// 输入查询SQL，返回一个dataTable.
        /// string sql = "select distinct subject from student";
        /// DataTable dt = SQLDbHelper.GetDataTable(sql);
        /// </summary>
        /// <param name="sql">输入查询SQL</param>
        /// <returns>返回一个含有查询结果的dataTable</returns>
 
        public static DataTable GetDataTable(string sql)
        {           
            return  GetDataTable(sql,null);
            //SqlConnection conn = new SqlConnection(connString);

            //SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

            //DataTable dt = new DataTable(); //memory            
            //adapter.Fill(dt);
            //return dt;
        }
        /// <summary>
        /// 输入查询SQL，返回一个dataTable.
        /// string sql = "select * from student where name=@name and class=@class";
        /// DataTable dt = SQLDbHelper.GetDataTable(sql, new SqlParameter("@name","ada"),new SqlParameter("@class","IOS(2)") );
        /// </summary>
        /// <param name="sql">输入查询SQL</param>
        /// <returns>返回一个含有查询结果的dataTable</returns>
        public static DataTable GetDataTable(string sql,params SqlParameter[] sqlParams)
        {   
            
            SqlConnection conn = new SqlConnection(connString);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn); 

            DataTable dt = new DataTable(); //memory     

            if (sqlParams != null)
            {
                adapter.SelectCommand.Parameters.AddRange(sqlParams);
            }
            adapter.Fill(dt);
            adapter.SelectCommand.Parameters.Clear();//防止 异常“另一个 SqlParameterCollection 中已包含 SqlParameter
            
            return dt;
        }

        /// <summary>
        /// 获取SQL查询的0行0列数据，一般用在统计查询SQL
        /// string sqlTotal = "select count(id) from student";
        /// object total=SQLDbHelper.GetScaler(sqlTotal);
        /// lblStatics.Text = "Total:" + total;
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>

        public static int InsertGetNewID(string sql, params SqlParameter[] sqlParams)
        {
            object objIDInWare = SqlHelper.GetScaler(sql, sqlParams);
            int idInWare = -1;
            int.TryParse(objIDInWare.ToString(), out idInWare);
            return idInWare;
        }
        public static object GetScaler(string sql) 
        {
            //方法一：
            SqlConnection conn = new SqlConnection(connString);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn); //reader更加轻量

            DataTable dt = new DataTable(); //memory            
            adapter.Fill(dt);
            adapter.SelectCommand.Parameters.Clear();//防止 异常“另一个 SqlParameterCollection 中已包含 SqlParameter
            
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt.Rows[0][0];

           
            //方法二：
            //object rtn=null;
            //SqlConnection conn = null;
            //SqlDataReader reader = null;
            //try
            //{
            //     conn = new SqlConnection(connString);

            //    conn.Open();

            //    SqlCommand cmd = new SqlCommand(sql, conn);

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
        ///    object id=SQLDbHelper.GetScaler(sql, 
        ///                         new SqlParameter("@name", name), 
        ///                         new SqlParameter("@pass", pass) );
        /// if (id != null) {
        ///     this.Hide();  new MainFrame().Show(); 
        ///  }
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns>若返回null，说明没有查询到任何值</returns>
        public static object GetScaler(string sql, params SqlParameter[] sqlParams)
        {
            //方法一：
            SqlConnection conn = new SqlConnection(connString);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn); //reader更加轻量

            DataTable dt = new DataTable(); //memory        
            if (sqlParams != null)
            {
                adapter.SelectCommand.Parameters.AddRange(sqlParams);
            }
            adapter.Fill(dt);
            adapter.SelectCommand.Parameters.Clear();//防止 异常“另一个 SqlParameterCollection 中已包含 SqlParameter
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
        ///// SQLDbHelper.Fill(cbSubject, sql); 
        ///// </summary>
        ///// <param name="cb"></param>
        ///// <param name="sql"></param>
        //public static void Fill(ComboBox cb, string sql)
        //{
        //    SqlConnection conn = null;
        //    SqlDataReader reader = null;
        //    try
        //    {
        //         
        //        conn = new SqlConnection(connString);

        //        conn.Open();

        //        SqlCommand cmd = new SqlCommand(sql, conn);

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
        ///  int row = SQLDbHelper.ExecuteNonQuery(sql);
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            int row = 0;

            SqlConnection conn = null;
            try
            {
                //string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\itcast.accdb";
                conn = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
               
                row = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();//防止 异常“另一个 SqlParameterCollection 中已包含 SqlParameter
            
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
        ///  int rows= SQLDbHelper.ExecuteNonQuery(sql,  new SqlParameter("@sNum",sNum),
        ///                                               new SqlParameter("@sName",sName),
        ///                                                new SqlParameter("@sSex",sSex),    
        ///                                                new SqlParameter("@sAge",sAge),
        ///                                                new SqlParameter("@sClass", sClass),
        ///                                                new SqlParameter("@sSubject", sSubject),
        ///                                                new SqlParameter("@sTel", sTel)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] sqlParams)
        {
            int row = 0;

            SqlConnection conn = null;
            try
            {
                
                conn = new SqlConnection(connString); 

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                if (sqlParams != null)
                {
                    cmd.Parameters.AddRange(sqlParams);
                }
                row = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();//防止 异常“另一个 SqlParameterCollection 中已包含 SqlParameter
            
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
        /// 请先在数据库中加分页存储过程utilPage
        /// int totalRowCount=0;//总行数
        /// DataTable dt = SqlHelper.QueryPaging("入库", "id desc", "ID,订单号,入库单号,入库时间,状态",
        ///                   "1=1", AspNetPagerInList.CurrentPageIndex, AspNetPagerInList.PageSize, ref totalRowCount);
        /// AspNetPagerInList.RecordCount = totalRowCount;
        ///
        /// GridViewInList.DataSource = dt;  //11-20  
        /// GridViewInList.DataBind();
        /// </summary>
        /// <param name="dataSrc"></param>
        /// <param name="orderBy"></param>
        /// <param name="fieldList"></param>
        /// <param name="filterWhere"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRowCount"></param>
        /// <returns></returns>
        public static DataTable QueryPaging(string dataSrc, string orderBy, string fieldList,
                              string filterWhere, int pageNum, int pageSize, ref int totalRowCount)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connString);//conn = new SqlConnection(dbConnUrl);
                if (string.IsNullOrEmpty(filterWhere)) //条件 过滤
                    filterWhere = "1=1";
                //为调用分页存储过程utilPAGE，添加6(7)参数给sqlCmd
                SqlCommand sqlCmd = new SqlCommand("utilPAGE", conn);//必须：已经在数据库上创建了
                sqlCmd.CommandType = CommandType.StoredProcedure;//不是SQL语句，是SP存储过程
                sqlCmd.Parameters.Add(new SqlParameter("@datasrc", dataSrc));//sp中参数名，方法传入参数变量
                sqlCmd.Parameters.Add(new SqlParameter("@orderBy", orderBy));
                sqlCmd.Parameters.Add(new SqlParameter("@fieldlist", fieldList));
                sqlCmd.Parameters.Add(new SqlParameter("@filter", filterWhere));
                sqlCmd.Parameters.Add(new SqlParameter("@pageNum", pageNum));
                sqlCmd.Parameters.Add(new SqlParameter("@pageSize", pageSize));
                //输出参数(总行数)
                sqlCmd.Parameters.Add(new SqlParameter("@recct", SqlDbType.Int));
                sqlCmd.Parameters["@recct"].Direction = ParameterDirection.Output;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                adapter.Fill(dataTable); //会conn.Open(); ....会conn.Close();
                totalRowCount = Convert.ToInt32(sqlCmd.Parameters["@recct"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (conn != null & conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return dataTable;
        }
        
     
    }
}
