<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="MyFiles.aspx.cs" Inherits="REW_Cloud_Drive.ProtectedPages.MyFiles" Theme="Theme_main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="div_List">
            <asp:Image ID="Image2" runat="server" />
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="FileID" ItemPlaceholderID="holder1" OnItemDeleting="ListView1_ItemDeleting" OnItemCommand="ListView1_ItemCommand">
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
                            <asp:Button ID="Button_Share" runat="server" Text='<%#((bool)Eval("IsShared")?"取消分享":"分享") %>' CommandName="Share" OnCommand="Button_Share_Command" CommandArgument='<%#Eval("FileID") %>' />
                            <asp:Button ID="Button_Delete" runat="server" Text="删除" CommandName="Delete" />
                        </div>
                        <div class="clearfloat"></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
