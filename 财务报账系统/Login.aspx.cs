using DataBase.Tools;
using ScoresSys2.CommonTools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 财务报账系统
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //用户名、密码
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            //数据库判断正误,正确就关闭原来登录界面
            Boolean isValid = IsValid(username, password);
            if (isValid)
            {
                //登陆成功
                Session["LoginName"] = username;
                Server.Transfer("index.aspx");
            }
            else
            {
                //提示登陆失败，密码或有用户有误！
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('用户名或密码有误！');</script>");
            }
        }

        private bool IsValid(string name, string pass)
        {
            //假的，可以直接登录，不要密码
            //return true;

            //加密登录，很吊的。客户这边还是输入自己的密码，我后台这里加了密和数据库里已经加密的比较，（算法一样的，所以一样的东西加密出来的一定会一样），正确就密码正确。
            string md5Pass = Encrypter.GetMD5(pass);
            object record = SqlHelper.GetScaler("exec loginpwd '" + name + "','" + md5Pass + "'");
            if (record != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}