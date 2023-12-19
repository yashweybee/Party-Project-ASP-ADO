<%@ Page Language="C#" Title="Products" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Party_Project_ASP_ADO.Products" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table class="auto-style9" style="vertical-align: middle; text-align: center">
        <tr>
            <td class="auto-style14">
                <strong>
                    <asp:Label ID="Label1" runat="server" Text="Product Add"></asp:Label>
                </strong>
            </td>
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
                <asp:Label ID="Label3" runat="server" Text="Product Name :"></asp:Label>
            </td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">
                <asp:TextBox ID="txtBoxProductName" runat="server" Width="160px" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle"></td>
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



