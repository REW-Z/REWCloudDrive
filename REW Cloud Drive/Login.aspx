<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="REW_Cloud_Drive.Login" Theme="Theme_main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        #div_main
        {
            margin:50px auto;
            width:500px;
        }
        #tb_login
        {
            margin:0 auto;
            border:solid 1px;
            width:300px;
            
            background-color:rgba(80, 80, 80, 0.50);
        }
        #tb_login tr
        {
            height:75px;
        }

        td
        {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_main">
        <table id="tb_login">
            <tr>
                <th colspan="2" style="color:white;background-color:gray;font-size:42px;">登 录</th>
            </tr>
            <tr>
                <td>用户名</td>
                <td>
                    <asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>密码</td>
                <td>
                    <asp:TextBox ID="TextBox_pwd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button_login" runat="server" Text="登录" OnClick="Button_login_Click" />
                    <asp:HyperLink ID="HyperLink_signup" runat="server" NavigateUrl="~/Signup.aspx" style="float:right;">注册</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
