<%@ Page Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Party.aspx.cs" Inherits="Party_Project_ASP_ADO.Party" %>






<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <p>
        Party Add
    </p>
<p>
        <asp:Label ID="Label1" runat="server" Text="Data Inserted!!!"></asp:Label>
    </p>
<p>
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Party Name :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="58px" />
&nbsp;
        <asp:Button ID="btnCancle" runat="server" Text="Cancle" Width="58px" />
    </p>

</asp:Content>







