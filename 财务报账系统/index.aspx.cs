using DataBase.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 财务报账系统
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////时间开端输入
            //txtTimeStart.Attributes.Add("Value", "请输入用户名");
            //txtTimeStart.Attributes.Add("OnFocus", "if(this.value=='请输入用户名') {this.value=''}");
            //txtTimeStart.Attributes.Add("OnBlur", "if(this.value==''){this.value='请输入用户名'}");
            ////密码输入
            //txtPwd.Attributes.Add("Value", "请输入密码");
            //txtPwd.Attributes.Add("OnFocus", "if(this.value=='请输入密码'){this.value=''}");
            //txtPwd.Attributes.Add("OnBlur", "if(this.value==''){this.value='请输入密码'}");
            //
            if (!IsPostBack)
            {
                dtrow(1);

                labName.Text = Session["LoginName"].ToString();

                //当前时间=入库时间
                labTime_baoxiao.Text = DateTime.Now.ToString();
                labTime_baoxiao.Enabled = false;

                //填单人=登陆人
                lbWriteName.Text = labName.Text;
                lbWriteName.Enabled = false;
            }
        }

        static int row = 1;
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

        protected void linkbtnSelect_Click(object sender, EventArgs e)
        {
            //打开自己对应的panel，关闭别的panel
            PanelSelect.Visible = true;
            panelBaoxiao.Visible = false;
            PanelRuzhang.Visible = false;
        }

        protected void linkbtnBaoxiao_Click(object sender, EventArgs e)
        {
            //打开自己对应的panel，关闭别的panel
            panelBaoxiao.Visible = true;
            PanelRuzhang.Visible = false;
            PanelSelect.Visible = false;
        }

        protected void linkbtnRuzhang_Click(object sender, EventArgs e)
        {
            //打开自己对应的panel，关闭别的panel
            PanelRuzhang.Visible = true;
            panelBaoxiao.Visible = false;
            PanelSelect.Visible = false;
        }

        protected void txtTimeStart_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            row++;
            dtrow(row);
        }

        protected void btnReadyInput_Click(object sender, EventArgs e)
        {
            //取值
            string txtPayName = txtPayName_baoxiao.Text.Trim();
            string txtBankNumber = txtBankNumber_baoxiao.Text.Trim();
            string txtBankName = txtBankName_baoxiao.Text.Trim();
            string txtBankname_two = txtBankname_two_baoxiao.Text.Trim();
            string rbHeTong;
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
            string Insql = "exec insertIn '" + labTime_baoxiao.Text + "';select @@identity";
            //int idInWare = SqlHelper.ExecuteNonQuery(Insql);
            int idInWare = SqlHelper.InsertGetNewID(Insql);

            //进行插入动作
            string NowTime = labTime_baoxiao.Text;//入库时间
            DateTime datelabTime_baoxiao = DateTime.Now;
            DateTime.TryParse(NowTime, out datelabTime_baoxiao);

            string sql;

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                ddlClass = ((DropDownList)GridView2.Rows[i].Cells[0].FindControl("ddlClass_baoxiao")).Text.Trim();
                txtApplication = ((TextBox)GridView2.Rows[i].Cells[1].FindControl("txtApplication_baoxiao")).Text.Trim();
                txtDetail = ((TextBox)GridView2.Rows[i].Cells[2].FindControl("txtDetail_baoxiao")).Text.Trim();
                txtMoney = float.Parse(((TextBox)GridView2.Rows[i].Cells[3].FindControl("txtMoney_baoxiao")).Text.Trim());

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

                sql = "exec insertinfo '" + WriteName + "','"+txtPayName+"','"+txtBankNumber+"','"
                + txtBankName + "','" + txtBankname_two + "','" + txtApplication + "','" + ddlClass
                + "','" + txtDetail + "','" + txtMoney + "','" + rbHeTong + "','" + txtHeTongNumber + "','" + NowTime + "','" + idInWare+"'";

                SqlHelper.ExecuteNonQuery(sql);
            }


            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('报销单成功保存！');</script>");
            panelBaoxiao.Visible = false;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string StatsTime = txtStatsTime.Text.Trim();
            string StopTime = txtStopTime.Text.Trim();
            string PayWho = txtPayWho.Text.Trim() ;
            string StatsMoney = txtMoneyStats.Text.Trim();
            string StopMoney = txtMoneyStop.Text.Trim();
            string Class = ddlClass.Text.Trim();
            string Bank = txtBank.Text.Trim();
            string PayAccount = txtPayAccount.Text.Trim();
            //检查数据类型是否正确，时间的前后，金钱是否为float，银行账户是否为整型
            //时间
            if (txtStatsTime.Text.Trim() != "" && txtStopTime.Text.Trim() == "")
            {
                int YearCha = int.Parse(StopTime.Substring(0, 4)) - int.Parse(StatsTime.Substring(0, 4));
                int MonthCha = int.Parse(StopTime.Substring(4, 2)) - int.Parse(StatsTime.Substring(4, 2));
                int DayCha = int.Parse(StopTime.Substring(8, 2)) - int.Parse(StatsTime.Substring(8, 2));
                if (YearCha < 0 || MonthCha < 0 || DayCha < 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请检查填写日期的前后顺序！');</script>");
                    return;
                }
            }
            //金额
            if (txtMoneyStats.Text.Trim() != "" && txtMoneyStop.Text.Trim() != "")
            {
                float itxtMoneyStats;
                float.TryParse(txtMoneyStats.Text.Trim(), out itxtMoneyStats); //异常给0
                if (itxtMoneyStats <= 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('金额必须为大于零，请重新填写！');</script>");
                    return;
                }

                float itxtMoneyStop;
                float.TryParse(txtMoneyStop.Text.Trim(), out itxtMoneyStop); //异常给0
                if (itxtMoneyStop <= 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('金额必须为大于零，请重新填写！');</script>");
                    return;
                }

                float cha = float.Parse(StopMoney) - float.Parse(StatsMoney);
                if (cha < 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('请检查填写金额的前后顺序！');</script>");
                    return;
                }
            }
            //银行账户
            if (txtPayAccount.Text.Trim() != "")
            {
                if (txtPayAccount.Text.Trim().Length != 16 || txtPayAccount.Text.Trim().Length != 19)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('银行卡账号长度为16位或是19位，请重新填写！');</script>");
                    return;
                }
            }
            //分类
            if (Class == "—请选择—")
            {
                Class = "";
            }

            if (GridView1.Visible == true)
            {
                //exec selectAllOrSingle '2017-05-06','2017-05-07','',null,'','办公费','190','2000'
                string sql = "exec selectAllOrSingle '" + StatsTime + "','" + StopTime + "','" + PayWho + "','"
                          + PayAccount + "','" + Bank + "','" + Class + "','" + StatsMoney
                          + "','" + StopMoney + "'";
                DataTable dt = SqlHelper.GetDataTable(sql);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                //exec selectAllOrSingleAboutEditMode '2017-05-06','2017-10-07','',null,''
                string sql = "exec selectAllOrSingleAboutEditMode '" + StatsTime + "','" + StopTime + "','" + PayWho + "','" + PayAccount + "','" + Bank + "'";
                DataTable dt2 = SqlHelper.GetDataTable(sql);
                GridView3.DataSource = dt2;
                GridView3.DataKeyNames = new String[] { "IN_ID" };
                GridView3.DataBind();
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int cntChoosed = 0;
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                CheckBox cbChoosed = (CheckBox)GridView3.Rows[i].FindControl("cbChoosed");
                if (cbChoosed.Checked)
                {
                    if (++cntChoosed > 1)
                    {
                        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('只能选择单行编辑');</script>");
                        return;
                    }
                    //string id = (gvStu.Rows[i].RowIndex+2).ToString();
                    //this.Session["id"] = id;
                    //this.Response.Redirect("Edit.aspx");
                }
            }
            if (cntChoosed == 0)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('必须选择一行进行编辑');</script>");
                return;
            }
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                CheckBox cbChoosed = (CheckBox)GridView3.Rows[i].FindControl("cbChoosed");
                if (cbChoosed.Checked)
                {
                    Server.Transfer("Edit.aspx?IN_ID=" + GridView3.DataKeys[i].Value.ToString());
                    //Server.Transfer("Edit.aspx");
                    //this.Response.Redirect("Edit.aspx");
                    return;
                }
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            //int cntChoosed = 0;
            //string ids = "";
            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    CheckBox cbChoosed = (CheckBox)GridView1.Rows[i].FindControl("cbChoosed");
            //    if (cbChoosed.Checked)
            //    {
            //        ids += GridView1.DataKeys[i].Value.ToString() + ",";//ids += (gvStu.Rows[i].RowIndex + 2).ToString()+",";
            //        ++cntChoosed;
            //    }
            //}
            //if (cntChoosed == 0)
            //{
            //    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('必须选择一行进行编辑');</script>");
            //    return;
            //}
            //ids = ids.Substring(0, ids.Length - 1);
            //string sql = "delete from stuscores where id in(" + ids + ")";
            //int row = SqlHelper.ExecuteNonQuery(sql);
            //btnSelect_Click(null, null);
        }

        protected void btnEditMode_Click(object sender, EventArgs e)
        {
            btnEscEditMode.Visible = true;
            btnEscEditMode.Enabled = true;
            btnEditMode.Enabled = false;
            GridView3.Visible = true;
            GridView1.Visible = false;

            btnEdit.Visible = true;
            btnDel.Visible = true;
            btnSee.Visible = true;
            btnPrint.Visible = true;
            btnDownLoad.Visible = true;

            txtMoneyStats.Enabled = false;
            txtMoneyStop.Enabled = false;
            ddlClass.Enabled = false;
        }

        protected void btnEscEditMode_Click(object sender, EventArgs e)
        {
            btnEscEditMode.Visible = false;
            btnEscEditMode.Enabled = false;
            btnEditMode.Enabled = true;
            GridView3.Visible = false;
            GridView1.Visible = true;

            btnEdit.Visible = false;
            btnDel.Visible = false;
            btnSee.Visible = false;
            btnPrint.Visible = false;
            btnDownLoad.Visible = false;

            txtMoneyStats.Enabled = true;
            txtMoneyStop.Enabled = true;
            ddlClass.Enabled = true;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            btnSelect_Click(null, null);
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            btnSelect_Click(null, null);
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




    }
}