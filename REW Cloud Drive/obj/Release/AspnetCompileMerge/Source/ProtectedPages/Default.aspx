<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="REW_Cloud_Drive.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #div_menu
        {
            margin:50px auto;
            width:1100px;
        }
        .div_MenuItem
        {
            margin:20px;
            padding:0;
            border-style:dashed;
            border-width:10px;
            border-color:#bbbbbb;
            width:205px;
            height:205px;
            display:inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div id="div_menu">
        <div class="div_MenuItem">
            <asp:ImageButton ID="ImageButton_Account" runat="server" ImageUrl="~/Images/Account.png" OnClick="ImageButton_Account_Click" />
        </div>
        <div class="div_MenuItem">
            <asp:ImageButton ID="ImageButton_MyFiles" runat="server" ImageUrl="~/Images/MyFiles.png" OnClick="ImageButton_MyFiles_Click" />
        </div>
        <div class="div_MenuItem">
            <asp:ImageButton ID="ImageButton_Upload" runat="server" ImageUrl="~/Images/UpLoad.png" OnClick="ImageButton_Upload_Click" />
        </div>
        <div class="div_MenuItem">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cloud.png" OnClick="ImageButton1_Click" />
        </div>
    </div>
</div>
</asp:Content>
