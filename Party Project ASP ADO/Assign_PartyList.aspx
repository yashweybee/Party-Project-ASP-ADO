<%@ Page Language="C#" Title="Assign party list" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Assign_PartyList.aspx.cs" Inherits="Party_Project_ASP_ADO.Assign_PartyList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="btnAssignParty" runat="server" OnClick="btnAssignParty_Click" Text="Assign Party" />
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    <br />

</asp:Content>


