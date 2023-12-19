<%@ Page Language="C#" Title="Assign Party" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Assign_Party.aspx.cs" Inherits="Party_Project_ASP_ADO.Assign_Party" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table class="auto-style9" style="vertical-align: middle; text-align: center">
        <tr>
            <td class="auto-style14"><strong>
                <asp:Label ID="Label1" runat="server" Text="Assign Party"></asp:Label>
            </strong></td>
        </tr>
    </table>
    <br />
    <table class="auto-style9" style="vertical-align: middle; text-align: center">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblDataStatus" Visible="False" runat="server" Text="Data Inserted!!"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="auto-style15" style="vertical-align: middle; text-align: center">
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle"></td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="vertical-align: middle">
                <asp:Label ID="Label3" runat="server" Text="Party Name :"></asp:Label>
            </td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">
                <asp:DropDownList ID="ddPartyName" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="P_Id" Width="250px" CssClass="form-control">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [Name], [P_Id] FROM [Party]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="vertical-align: middle">
                <asp:Label ID="Label4" runat="server" Text="Product Name :"></asp:Label>
            </td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">
                <asp:DropDownList ID="ddProductName" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Pr_Id" Width="250px" CssClass="form-control">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [Name], [Pr_Id] FROM [Product]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-success" />
                &nbsp;
                <asp:Button ID="btnCancle" runat="server" OnClick="btnCancle_Click" Text="Cancle" CssClass="btn btn-danger" />
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle"></td>
        </tr>
    </table>
</asp:Content>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style9 {
            width: 100%;
        }

        .auto-style14 {
            height: 42px;
        }

        .auto-style15 {
            width: 100%;
            margin-bottom: 5px;
        }

        .auto-style16 {
            width: 461px;
            height: 30px;
        }

        .auto-style17 {
            width: 234px;
            height: 30px;
        }

        .auto-style18 {
            height: 30px;
        }
    </style>
</asp:Content>




