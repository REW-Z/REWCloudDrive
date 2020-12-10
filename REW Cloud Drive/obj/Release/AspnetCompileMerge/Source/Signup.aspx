<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="REW_Cloud_Drive.Signup" Theme="Theme_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body
        {
            background-color:gray;
        }
        #div_main
        {
            margin:100px auto;
            width:500px;
        }
        #tb_signup
        {
            margin:0 auto;
            border:solid 1px;
            width:400px;
            
            background-color:#a3a3a3
        }
        #tb_signup tr
        {
            height:75px;
        }
        .td_text 
        {
            width: 88px;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="tb_signup">
                <tr>
                    <th colspan="3">用户注册</th>
                </tr>
                <tr>
                    <td class="td_text">
                        用户名

                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Name" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox_Name" runat="server" ErrorMessage="RequiredFieldValidator" Text="用户名不能为空" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td_text">密码</td>
                    <td>
                        <asp:TextBox ID="TextBox_Pwd" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox_Pwd" runat="server" ErrorMessage="RequiredFieldValidator" Text="密码不能为空" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td_text">
                        确认密码：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_PwdConfirm" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_PwdConfirm" ErrorMessage="RequiredFieldValidator" Font-Size="Smaller" ForeColor="Red">此处不能为空</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" Operator="Equal" ControlToValidate="TextBox_PwdConfirm" ControlToCompare="TextBox_Pwd" runat="server" ErrorMessage="CompareValidator" Text="两次输入不一样" Font-Size="Smaller" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button_signup" runat="server" Text="确认注册" OnClick="Button_signup_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button_Back" runat="server" Text="取消注册" OnClick="Button_Back_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
