<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="REW_Cloud_Drive.ProtectedPages.Account" Theme="Theme_main" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBox_pwd").hide();

            $("#div_textboxhidden").mouseenter(function () {
                $("#TextBox_pwd").fadeIn();
            });
            $("#div_textboxhidden").mouseleave(function () {
                $("#TextBox_pwd").fadeOut();
            });

        });
    </script>

    <style type="text/css">
        #div_pic
        {
            border:solid 3px;
        }
        #div_usermenu
        {
            margin:0 30px;
        }
        #div_picupload_hidden
        {
            display:none;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="div_pic" class="floatleft" style="width: 300px; height: 300px;">
            <asp:ImageButton ID="ImageButton_profilePic" runat="server" Height="300px" Width="300px" ImageUrl="~/ProfilePictures/DefaultPic.png" />
        </div>
        <div id="div_usermenu" class="floatleft">
            <asp:Button ID="Button_deleteaccount" runat="server" Text="删除账户" OnClick="Button_deleteaccount_Click" />
            <br />
            <br />
            <div id="div_textboxhidden" style="height: 50px; width: 300px;">
                <asp:Button ID="Button_changeword" runat="server" Text="更改密码" OnClick="Button_changeword_Click" />&nbsp; <asp:TextBox ID="TextBox_pwd" ClientIDMode="Static" runat="server"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="Button_clearall" runat="server" Text="清空文件" OnClick="Button_clearall_Click" />
            <br />

            <asp:Panel ID="Panel_popup" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" BackColor="Gray">
                <br />
                <p>上传头像（仅支持PNG格式）</p>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Button ID="Button_upload" runat="server" Text="确定" OnClick="Button_upload_Click" />
                <asp:Button ID="Button_cancel" runat="server" Text="取消" />
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                CancelControlID="Button_cancel"
                PopupControlID="Panel_popup"
                TargetControlID="ImageButton_profilePic">
            </ajaxToolkit:ModalPopupExtender>
        </div>
        <div class="clearfloat"></div>
    </div>



    <div>
        <p style="font-size:24px;color:gray;margin:0 50px;">
            <b>点击图片更换头像</b>
        </p>
    </div>
</asp:Content>
