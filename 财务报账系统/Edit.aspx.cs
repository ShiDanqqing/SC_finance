using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBase.Tools;
using System.Data;

namespace 财务报账系统
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string selectsql = "exec selectAllId '3' ";//+ Request["IN_ID"] + "'";
                string selectsql = "exec selectAllId '"+ Request["IN_ID"] + "'";
                DataTable dt = SqlHelper.GetDataTable(selectsql);
                dtrow(dt.Rows.Count);

                string txtPayName = dt.Rows[0][2].ToString().Trim();
                string txtBankNumber = dt.Rows[0][3].ToString().Trim();
                string txtBankName = dt.Rows[0][4].ToString().Trim();
                string txtBankname_two = dt.Rows[0][5].ToString().Trim();
                string rbHeTong = dt.Rows[0][10].ToString().Trim();
                string txtHeTongNumber = dt.Rows[0][11].ToString().Trim();
                string WriteName = dt.Rows[0][1].ToString().Trim();
                string OldTime = dt.Rows[0][12].ToString().Trim();

                txtPayName_baoxiao.Text = txtPayName;
                txtBankNumber_baoxiao.Text = txtBankNumber;
                txtBankName_baoxiao.Text = txtBankName;
                txtBankname_two_baoxiao.Text = txtBankname_two;
                if (rbHeTong == "有")
                {
                    rblIsTrue.SelectedValue = "1";
                    txtHeTongNumber_baoxiao.Enabled = true;
                }
                else
                {
                    rblIsTrue.SelectedValue = "0";
                    txtHeTongNumber_baoxiao.Enabled = false;
                }
                txtHeTongNumber_baoxiao.Text = txtHeTongNumber;
                lbWriteName.Text = WriteName;
                labTime_baoxiao.Text = OldTime;


                //string selectPartsql = "exec selectPartInfo '3' ";
                string selectPartsql = "exec selectPartInfo '" + Request["IN_ID"] + "'";
                DataTable dt2 = SqlHelper.GetDataTable(selectPartsql);
                //id,application,class,details,money
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    string Class = dt2.Rows[i][2].ToString();
                    string Application = dt2.Rows[i][1].ToString();
                    string Detail = dt2.Rows[i][3].ToString();
                    string Money = dt2.Rows[i][4].ToString();
                    string id = dt2.Rows[i][0].ToString();

                    ((DropDownList)GridView2.Rows[i].Cells[0].FindControl("ddlClass_baoxiao")).Text = Class;
                    ((TextBox)GridView2.Rows[i].Cells[1].FindControl("txtApplication_baoxiao")).Text =Application;
                    ((TextBox)GridView2.Rows[i].Cells[2].FindControl("txtDetail_baoxiao")).Text = Detail;
                    (((TextBox)GridView2.Rows[i].Cells[3].FindControl("txtMoney_baoxiao")).Text) = Money;
                    (((Label)GridView2.Rows[i].Cells[4].FindControl("labId_baoxiao")).Text) = id;

                }
            }
        }

        private void dtrow(int row2)
        {
            int row = row2;
            DataTable dt = new DataTable();
            dt.Columns.Add("分类");
            for (int i = 0; i < row; i++)
            {
                DataRow dr = dt.NewRow();
                dr["分类"] = "";
                dt.Rows.Add(dr);
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void rblIsTrue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblIsTrue.SelectedValue == "1")
            {
                txtHeTongNumber_baoxiao.Enabled = true;
            }
            else
            {
                txtHeTongNumber_baoxiao.Enabled = false;
                txtHeTongNumber_baoxiao.Text = "";
            }
        }

        protected void btnReadyInput_Click(object sender, EventArgs e)
        {
            //取值
            string txtPayName = txtPayName_baoxiao.Text.Trim();
            string txtBankNumber = txtBankNumber_baoxiao.Text.Trim();
            string txtBankName = txtBankName_baoxiao.Text.Trim();
            string txtBankname_two = txtBankname_two_baoxiao.Text.Trim();
            string rbHeTong;
            int txtid;
            if (rblIsTrue.SelectedValue == "1")
            {
                rbHeTong = "有";
            }
            else
            {
                rbHeTong = "无";
            }
            string txtHeTongNumber = txtHeTongNumber_baoxiao.Text.Trim();
            string WriteName = lbWriteName.Text.Trim();

            //检查是否为空，外面的值也要填。
            if (txtPayName_baoxiao.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请填写“付款单位/个人”！');</script>");
                return;
            }
            if (txtBankNumber_baoxiao.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请填写“支付账号”！');</script>");
                return;
            }
            else
            {
                int length16 = 16, length19 = 19;
                int txtBankNumber_baoxiao_length = txtBankNumber_baoxiao.Text.Trim().Length;
                if (txtBankNumber_baoxiao_length != length16 && txtBankNumber_baoxiao_length != length19)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('银行卡账号长度为16位或是19位，请重新填写！');</script>");
                    return;
                }
            }
            if (txtBankName_baoxiao.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请填写“银行名称”！');</script>");
                return;
            }

            //遍历取GridView中的数值。
            string ddlClass, txtApplication, txtDetail;
            float txtMoney;
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                ddlClass = ((DropDownList)GridView2.Rows[i].Cells[0].FindControl("ddlClass_baoxiao")).Text.Trim();
                txtApplication = ((TextBox)GridView2.Rows[i].Cells[1].FindControl("txtApplication_baoxiao")).Text.Trim();
                txtDetail = ((TextBox)GridView2.Rows[i].Cells[2].FindControl("txtDetail_baoxiao")).Text.Trim();
                txtMoney = float.Parse(((TextBox)GridView2.Rows[i].Cells[3].FindControl("txtMoney_baoxiao")).Text.Trim());
                txtid = int.Parse((((Label)GridView2.Rows[i].Cells[4].FindControl("labId_baoxiao")).Text).Trim());

                //检查是否为空，因为都是必填项，一项一项走
                if (ddlClass.Trim() == "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请选择分类！');</script>");
                    return;
                }
                if (txtApplication.Trim() == "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('用途不能为空，请仔细填写！');</script>");
                    return;
                }
                if (txtDetail.Trim() == "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('明细不能为空，请仔细填写！');</script>");
                    return;
                }
                if (txtMoney.ToString().Trim() == "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('金额不能为空，请仔细填写！');</script>");
                    return;
                }
                if (txtMoney <= 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert(''第" + (i + 1) + "行金额必须大于零，请仔细填写！');</script>");
                    return;
                }
            }

            //比较特别的两个数据，是否有合同号以及合同号。rbHeTong、rbHeTongNumber
            if (rbHeTong == "有" && txtHeTongNumber_baoxiao.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请仔细填写合同号，若无，请选择“无”！');</script>");
                return;
            }

            //进行插入动作
            //string NowTime = labTime_baoxiao.Text;//入库时间
            DateTime datelabTime_baoxiao = DateTime.Now;
            //DateTime.TryParse(NowTime, out datelabTime_baoxiao);

            string Insql = "exec insertEdit '" + datelabTime_baoxiao + "','" + Request["IN_ID"] + "';select @@identity";
            int idInWare = SqlHelper.InsertGetNewID(Insql);

            string sql;

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                ddlClass = ((DropDownList)GridView2.Rows[i].Cells[0].FindControl("ddlClass_baoxiao")).Text.Trim();
                txtApplication = ((TextBox)GridView2.Rows[i].Cells[1].FindControl("txtApplication_baoxiao")).Text.Trim();
                txtDetail = ((TextBox)GridView2.Rows[i].Cells[2].FindControl("txtDetail_baoxiao")).Text.Trim();
                txtMoney = float.Parse(((TextBox)GridView2.Rows[i].Cells[3].FindControl("txtMoney_baoxiao")).Text.Trim());
                txtid = int.Parse((((Label)GridView2.Rows[i].Cells[4].FindControl("labId_baoxiao")).Text).Trim());

                //检查是否为空，因为都是必填项，一项一项走
                if (ddlClass.Trim() == "—请选择—")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请选择分类！');</script>");
                    return;
                }
                if (txtApplication.Trim() == "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('用途不能为空，请仔细填写！');</script>");
                    return;
                }
                if (txtDetail.Trim() == "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('明细不能为空，请仔细填写！');</script>");
                    return;
                }
                if (txtMoney.ToString().Trim() == "")
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('金额不能为空，请仔细填写！');</script>");
                    return;
                }
                //特别注意金额这里，浮点型，大于0
                if (txtMoney <= 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert(''第" + (i + 1) + "行金额必须大于零，请仔细填写！');</script>");
                    return;
                }

                //update dbo.pay_page
                //set payname=@payname,banknumber=@banknumber,
                //bankname=@bankname,bankname_two=@bankname_two,
                //class=@class,application=@application ,details=@details,money=@money,
                //contract=@contract,contract_no=@contract_no ,
                //EditTime=@EditTime,EDIT_ID=@EDIT_ID
                //where id =@id;

                sql = "exec updateinfo '"+ txtPayName + "','" + txtBankNumber + "','"
                + txtBankName + "','" + txtBankname_two + "','"
                + ddlClass + "','" + txtApplication+ "','" + txtDetail + "','" + txtMoney + "','" 
                + rbHeTong + "','" + txtHeTongNumber + "','"
                + datelabTime_baoxiao + "','" + idInWare + "','"
                + txtid + "'";

                SqlHelper.ExecuteNonQuery(sql);
            }


            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('报销单成功修改！<br/>报销日期已经更改为当前时间。');</script>");
            //Server.Transfer("index.aspx");
              ClientScript.RegisterStartupScript(ClientScript.GetType(),
                        "myscript", "<script>alert('报销单成功修改！报销日期已经更改为当前时间。');window.location='index.aspx'; </script>");
        }
    }
}