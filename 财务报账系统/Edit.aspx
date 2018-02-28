<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="财务报账系统.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>财务报账系统修改界面</title>
<!-- 最新版本的 Bootstrap 核心 CSS 文件 -->
<link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
<!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
<script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <style type="text/css">

    .tablewaibu {
	border: 2px solid #000;
	font-family: "宋体";
}
    .auto-style1 {
        height: 49px;
    }
    .auto-style2 {
        height: 72px;
    }
        .auto-style3 {
            height: 50px;
            width: 268435440px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                <p>上海城建职业技术学院</p>
                <p>Shanghai CJ</p>
                <p>&nbsp;</p>
                <table style=" width:100%; border:0;" cellspacing="0" cellpadding="0">
                    <tr>
                       <td style="text-align:center;"><h3>报销单</h3></td>
                    </tr>
                    <tr>
                       <td><table style=" width:100%; border:0;" cellpadding="0" cellspacing="0" class="tablewaibu">
                    <tr>
                       <td colspan="2" style="border-bottom: 1px solid #666; border-right: 1px solid #666;" class="auto-style1">付款单位/个人
                           
                           <asp:TextBox ID="txtPayName_baoxiao" runat="server" Width="370px"></asp:TextBox>
                        </td>
                       <td colspan="2" style="border-bottom: 1px solid #666;" class="auto-style1">支付账号
                            
                           <asp:TextBox ID="txtBankNumber_baoxiao" runat="server" Width="295px"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBankNumber_baoxiao" ErrorMessage="支付账号为16或19位的整数！" ForeColor="#990033" ValidationExpression="^(\d{16}|\d{19})$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                           <tr>
                               <td colspan="3" style=" border-bottom: 1px solid #666; border-right: 1px solid #666;" class="auto-style3">
                           银行名称-开户行 
                           <asp:TextBox ID="txtBankName_baoxiao" runat="server" Width="303px"></asp:TextBox>
                           -
                           <asp:TextBox ID="txtBankname_two_baoxiao" runat="server" Width="276px"></asp:TextBox>
                               </td>
                                <td style=" text-align:left; width:18%; border-bottom: 1px solid #666;">
                           <p>填单时间:</p>
                           <p>
                               <asp:Label ID="labTime_baoxiao" runat="server" Text="Label"></asp:Label>
                           </p>
                                </td>
                    </tr>
                    <tr>
                       <td colspan="4" style="border-bottom: 1px solid #666; text-align:center;">
                           <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="90%">
                                           <Columns>
                <asp:TemplateField HeaderText="分类">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlClass_baoxiao" runat="server">
                            <asp:ListItem>—请选择—</asp:ListItem>
                            <asp:ListItem>办公费</asp:ListItem>
                            <asp:ListItem>印刷费</asp:ListItem>
                            <asp:ListItem>咨询费</asp:ListItem>
                            <asp:ListItem>手续费</asp:ListItem>
                            <asp:ListItem>水费</asp:ListItem>
                            <asp:ListItem>电费</asp:ListItem>
                            <asp:ListItem>邮电费</asp:ListItem>
                            <asp:ListItem>差旅费</asp:ListItem>
                            <asp:ListItem>维修费</asp:ListItem>
                            <asp:ListItem>租赁费</asp:ListItem>
                            <asp:ListItem>会议费</asp:ListItem>
                            <asp:ListItem>培训费</asp:ListItem>
                            <asp:ListItem>招待费</asp:ListItem>
                            <asp:ListItem>材料费</asp:ListItem>
                            <asp:ListItem>劳务费</asp:ListItem>
                            <asp:ListItem>助学金</asp:ListItem>
                            <asp:ListItem>其他</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用途">
                    <ItemTemplate>
                        <asp:TextBox ID="txtApplication_baoxiao" runat="server"  Height="60px" TextMode="MultiLine" Width="270px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="明细">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDetail_baoxiao" runat="server" Height="60px" TextMode="MultiLine" Width="270px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="金额">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMoney_baoxiao" runat="server" Width="121px"></asp:TextBox>
                           元
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="id">
                   <ItemTemplate>
                    <asp:Label ID="labId_baoxiao" runat="server" ></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
            </Columns>
                           </asp:GridView>
                       </td>
                    </tr>
                    <tr>
                       <td style=" text-align:center; border-right: 1px solid #666;" class="auto-style2">填单人：<asp:Label ID="lbWriteName" runat="server" Text="Label"></asp:Label>
                        </td>
                       <td colspan="3" style=" text-align:center;" class="auto-style2">
                           <table>
                               <tr>
                                   <td>
                           <asp:RadioButtonList ID="rblIsTrue" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblIsTrue_SelectedIndexChanged" AutoPostBack="True">
                               <asp:ListItem Selected="True" Value="0">无合同号</asp:ListItem>
                               <asp:ListItem Value="1">有合同号</asp:ListItem>
                           </asp:RadioButtonList>
                           </td>
                               </tr>
                               <tr>
                                   <td>合同号：&nbsp; <asp:TextBox ID="txtHeTongNumber_baoxiao" runat="server" Enabled="False" ></asp:TextBox></td></tr>
                               </table>
                       </td>
                    </tr>
                           </table>
                       </td>
                    </tr>
                </table>
    <asp:Button ID="btnReadyInput" runat="server"  Text="修改" OnClick="btnReadyInput_Click" />          
    </div>
    </form>
</body>
</html>
