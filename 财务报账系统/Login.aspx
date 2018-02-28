<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="财务报账系统.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>财务报账系统登陆界面</title>
<!-- 最新版本的 Bootstrap 核心 CSS 文件 -->
<link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
<!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
<script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
<style>
    #Login {
        width: 527px;
        height: 300px;
        margin: auto auto;
        text-align: center;
    }
    #form1 {
        width:100%;
        height:603px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
    <div id="Login">
    <br /><br /><br /><br /><br /><br />
    <h1 style="text-align:center;">财务报账系统</h1>
    <br /><br /><br /><br /><br /><br />
    <p><h3>用户名</h3> <asp:TextBox ID="txtUsername" runat="server" style="margin-left: 0px" class="form-control"></asp:TextBox></p>
    <p><h3>&nbsp; 密 码&nbsp;</h3> <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox></p>
    <asp:Button ID="btnLogin" Text="登陆" runat="server" OnClick="btnLogin_Click" class="btn btn-default"/>
    </div>
    </form>
</body>
</html>
