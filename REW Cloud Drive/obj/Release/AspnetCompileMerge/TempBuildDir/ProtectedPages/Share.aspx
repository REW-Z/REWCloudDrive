<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Share.aspx.cs" Inherits="REW_Cloud_Drive.ProtectedPages.Share" Theme="Theme_main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="div_List">
            <asp:Image ID="Image2" runat="server" />
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="FileID" ItemPlaceholderID="holder1" >
                <LayoutTemplate>
                    <p id="holder1" runat="server"></p>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="div_item">
                        <div class="floatleft">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#GetImgUrl((string)Eval("FileType")) %>' Height="50px" Width="50px" />
                        </div>
                        <div class="floatleft">
                            <p><%#Eval("FileName") %></p>
                            <p><%#Eval("UploadTime") %></p>
                        </div>
                        
                        <div class="floatright">
                            <asp:Button ID="Button_Download" runat="server" Text="下载" CommandName="Download" OnCommand="Button_Download_Command" CommandArgument='<%#Eval("FileID") %>' />
                        </div>
                        <div class="floatright" style="width:300px;margin:10px 50px;">
                            <p>
                                分享用户：
                                <asp:Image ID="Image_shareUserPic" runat="server" ImageUrl='<%#GetUserPicURL((int)Eval("UserID")) %>' Height="20px" Width="20px" />
                                <b><%#GetUserName((int)Eval("UserID")) %></b>
                            </p>
                        </div>

                        <div class="clearfloat">
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <div class="clearfloat"></div>
</asp:Content>
