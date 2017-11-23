<%@ Page Title="Leaderboards" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="Site.Leaderboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Leaderboards    </h2>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="ListView1_SelectedIndexChanged1">
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="UNameLabel" runat="server" Text='<%# Eval("UName") %>' />
                </td>
                <td>
                    <asp:Label ID="ScoreLabel" runat="server" Text='<%# Eval("Score") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="UNameTextBox" runat="server" Text='<%# Bind("UName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ScoreTextBox" runat="server" Text='<%# Bind("Score") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="UNameTextBox" runat="server" Text='<%# Bind("UName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ScoreTextBox" runat="server" Text='<%# Bind("Score") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="UNameLabel" runat="server" Text='<%# Eval("UName") %>' />
                </td>
                <td style="text-align:center">......
                </td>
                <td>
                    <asp:Label ID="ScoreLabel" runat="server" Text='<%# Eval("Score") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style=""></td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="UNameLabel" runat="server" Text='<%# Eval("UName") %>' />
                </td>
                <td>
                    <asp:Label ID="ScoreLabel" runat="server" Text='<%# Eval("Score") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GameDBConnectionString %>" ProviderName="<%$ ConnectionStrings:GameDBConnectionString.ProviderName %>" SelectCommand="SELECT u.UName, s.Score FROM ((Users u INNER JOIN UserToSaveFile uts ON u.UserID = uts.UserID) INNER JOIN SaveFile s ON uts.SaveFileID = s.SaveFileID) ORDER BY s.Score DESC"></asp:SqlDataSource>
</asp:Content>
