<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="REW_Cloud_Drive.ProtectedPages.Upload" Theme="Theme_main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="margin:60px 200px;">
        <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Solid" BackColor="White" BorderWidth="2px" EnableTheming="true" Width="400px" Height="50px" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传" />
    </div>

</asp:Content>
