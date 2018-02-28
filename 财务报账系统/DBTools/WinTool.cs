using DataBase.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace DataBase.Tools.Win
{
    class WinTool
    {
        ///// <summary>
        ///// 将SQL查询结果，填入下拉框cb中。
        ///// cbSubject.Items.Add("--全选--"); //首行加全选
        ///// cbSubject.SelectedIndex = 0;
        ///// string sql = "select distinct subject from student";
        ///// WinTool.Fill(cbSubject, sql); 
        ///// </summary>
        ///// <param name="cb"></param>
        ///// <param name="sql"></param>
        //public static void Fill(ComboBox cb, string sql)
        //{
        //    DataTable dt= OleDbHelper.GetDataTable(sql);
        //    for (int i=0 ; i<dt.Rows.Count ;i++ )
        //    {
        //         cb.Items.Add(dt.Rows[i][0]);
        //    }
        //}
    }
}
