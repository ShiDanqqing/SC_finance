<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="财务报账系统.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="js/jquery-2.1.4.min.js"></script>
<script src="js/jqueryui/jquery-ui.min.js"></script>
<link rel="stylesheet" href="js/jqueryui/jquery-ui.css"/>
<!-- 最新版本的 Bootstrap 核心 CSS 文件 -->
<link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
<!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
<script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <title>财务报账系统管理界面</title>
<style type="text/css">
    #all {
        width:1500px;
        height:600px;
    }
    #top {
        width:1500px;
        height:100px;
        /*background-color:gray;*/
        /*color:white;*/
        text-align:center;
    }
    #welcome {
        margin-top:20px;
        width:200px;
        height:60px;
        float:left;
        text-align:right;
    }
    #title {
        width:1060px;
        height:100px;
        float:left;
    }
    #mid {
        width:1500px;
        height:600px;
    }
    #daohanglan {
        width:300px;
        height:600px;
        /*background-color:lightgoldenrodyellow;*/
        font-size:50px;
        float:left;
    }
    #daohanglan ul {
        list-style-type:none;
    }
    #daohanglan li {
        margin-top:100px;
        margin-left:50px;
    }
    #neirong {
        width:1200px;
        height:600px;
        float:left;
        /*background-color:lightsalmon;*/
     }

    .tablewaibu {
	border: 2px solid #000;
}
    .tableneibu {
	border-right-width: 1px;
	border-bottom-width: 1px;
	border-left-width: 1px;
	border-right-style: solid;
	border-bottom-style: solid;
	border-left-style: solid;
	border-right-color: #666;
	border-bottom-color: #666;
	border-left-color: #666;
}
    .auto-style1 {
        height: 49px;
    }
    .auto-style3 {
        height: 97px;
    }
</style>
<script type="text/javascript">
    $(function () {
        $("#<%= txtStatsTime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        $("#<%= txtStopTime.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
    });
</script> 


</head>
<body>
    <form id="form1" runat="server">
    <div id="all">
    <div id="top">
        <div id="welcome">
            <p>欢迎<asp:Label ID="labName" runat="server" Text="Label"></asp:Label>登陆！！</p>
            <asp:LinkButton ID="linkbtnOut" runat="server">退出</asp:LinkButton>
                </div>
        <div id="title">
            <h1>财务报账系统</h1>

    </div>
        </div>
                <hr />
    <div id="mid">
        <div id="daohanglan">
            <ul>
                <li><asp:LinkButton ID="linkbtnBaoxiao" runat="server" OnClick="linkbtnBaoxiao_Click">报销</asp:LinkButton></li>
                <li><asp:LinkButton ID="linkbtnSelect" runat="server" OnClick="linkbtnSelect_Click">查询</asp:LinkButton></li>
                <li><asp:LinkButton ID="linkbtnRuzhang" runat="server" OnClick="linkbtnRuzhang_Click">入账</asp:LinkButton></li>
            </ul>
        </div>
        <div id="neirong">
            <!--报销这块-->
            <asp:Panel ID="panelBaoxiao" runat="server" Visible="false">
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
                               <td colspan="3" style=" height:50px; border-bottom: 1px solid #666; border-right: 1px solid #666;">
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
            </Columns>
                           </asp:GridView>
                       </td>
                    </tr>
                    <tr>
                       <td style=" text-align:center; border-right: 1px solid #666;" class="auto-style3">填单人：<asp:Label ID="lbWriteName" runat="server" Text="Label"></asp:Label>
                        </td>
                       <td colspan="3" style=" text-align:center;" class="auto-style3">
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

                <asp:Button ID="btnAddRow" runat="server"  Text="增加一行" OnClick="btnAddRow_Click" class="btn btn-default"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnReadyInput" runat="server"  Text="保存" OnClick="btnReadyInput_Click" class="btn btn-default"/>
            </asp:Panel>
            
            <!--查询这块-->
            <asp:Panel ID="PanelSelect" runat="server" Visible="false">
                <div id="shurukuang">
                    日期<asp:TextBox ID="txtStatsTime" runat="server" Width="96px"></asp:TextBox>
                    &nbsp;到 
                    <asp:TextBox ID="txtStopTime" runat="server" Width="128px"></asp:TextBox>
                    &nbsp;付款单位/个人 
                    <asp:TextBox ID="txtPayWho" runat="server" Width="238px"></asp:TextBox>
                    &nbsp;金额<asp:TextBox ID="txtMoneyStats" runat="server" Width="87px"></asp:TextBox>
                    到<asp:TextBox ID="txtMoneyStop" runat="server" Width="87px"></asp:TextBox>
                    &nbsp;分类<asp:DropDownList ID="ddlClass" runat="server">
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
                    <br />
                    银行名称 
                    <asp:TextBox ID="txtBank" runat="server" Width="270px"></asp:TextBox>
                    &nbsp; 支付账号 
                    <asp:TextBox ID="txtPayAccount" runat="server" Width="289px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSelect" runat="server" Text="查询" OnClick="btnSelect_Click" class="btn btn-default"/>
                    <br />
                    <br />
                    <div style="text-align:right;">
                        <asp:Button ID="btnEditMode" runat="server" Text="编辑模式" OnClick="btnEditMode_Click" class="btn btn-default"/>
                        <asp:Button ID="btnEscEditMode" runat="server" Text="退出编辑模式"  Visible="false" Enabled="false" OnClick="btnEscEditMode_Click"  class="btn btn-default" />
                    </div>
                </div>
                <div id="gv">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="250px" Width="1171px" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                            <asp:BoundField HeaderText="填单时间" DataField="addTime" />
                            <asp:BoundField HeaderText="填单人" DataField="writename" />
                            <asp:BoundField HeaderText="付款单位/个人" DataField="payname" />
                            <asp:BoundField HeaderText="支付账号" DataField="banknumber" />
                            <asp:BoundField HeaderText="银行名称" DataField="bankname" />
                            <asp:TemplateField HeaderText="-">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text="-"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="开户行" DataField="bankname_two" />
                            <asp:BoundField HeaderText="用途" DataField="application" />
                            <asp:BoundField HeaderText="分类" DataField="class" />
                            <asp:BoundField HeaderText="明细" DataField="details" />
                            <asp:BoundField HeaderText="金额" DataField="money" />
                            <asp:BoundField DataField="contract" HeaderText="是否有合同号" />
                            <asp:BoundField HeaderText="合同号" DataField="contract_no" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <br />
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="250px" Width="1171px" AllowPaging="True" OnPageIndexChanging="GridView3_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="勾选">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbChoosed" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IN_ID" HeaderText="IN_ID" Visible="False" />
                            <asp:BoundField DataField="addTime" HeaderText="填单时间" />
                            <asp:BoundField DataField="writename" HeaderText="填单人" />
                            <asp:BoundField DataField="payname" HeaderText="付款单位/个人" />
                            <asp:BoundField DataField="banknumber" HeaderText="支付账号" />
                            <asp:BoundField DataField="bankname" HeaderText="银行名称" />
                            <asp:TemplateField HeaderText="-">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text="-"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="bankname_two" HeaderText="开户行" />
                            <asp:BoundField DataField="contract" HeaderText="是否有合同号" />
                            <asp:BoundField DataField="contract_no" HeaderText="合同号" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
                <div id="btnfive">
                    <asp:Button ID="btnEdit" runat="server" Text="编辑" OnClick="btnEdit_Click" Visible="False" class="btn btn-default"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnDel" runat="server" Text="删除" OnClick="btnDel_Click" Visible="False" class="btn btn-default"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSee" runat="server" Text="预览" Visible="False" class="btn btn-default"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnPrint" runat="server" Text="打印" Visible="False" class="btn btn-default"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnDownLoad" runat="server" Text="下载" Visible="False" class="btn btn-default"/>
                </div>
            </asp:Panel>

            <!--入账这块-->
            <asp:Panel ID="PanelRuzhang" runat="server" Visible="false">

            </asp:Panel>
             </div>
        </div>
    <div id="footer">
        <p>Copyright 上海城建职业技术学院</p>
    </div>

    </form>
</body>
</html>
