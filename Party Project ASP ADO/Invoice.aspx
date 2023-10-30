<%@ Page Language="C#" Title="Invoice" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="Party_Project_ASP_ADO.Invoice" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table class="auto-style20" style="vertical-align: middle; text-align: center">
        <tr>
            <td class="auto-style14">
                <strong>
                    <asp:Label ID="Label1" runat="server" Text="Invoice"></asp:Label>
                </strong>
            </td>
        </tr>
    </table>
    <br />
    <table class="auto-style19" style="vertical-align: middle; text-align: center">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lblDataStatus" Visible="False" runat="server" Text="Data Inserted!!"></asp:Label>
            </td>
        </tr>
    </table>

    <table class="auto-style15" style="vertical-align: middle; text-align: center">
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle">
                <asp:Label ID="Label3" runat="server" Text="Party Name :"></asp:Label>
            </td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">
                <asp:DropDownList ID="ddParty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddParty_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle">Product Name :</td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">

                <asp:DropDownList ID="ddProducts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddProducts_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle">Current Rate :</td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">
                <asp:TextBox ID="txtBoxRate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle">&nbsp;</td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle">Quantity :</td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">
                <asp:TextBox ID="txtBoxQuantity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle">
                <asp:Button ID="btnAddInvoice" runat="server" OnClick="btnAddInvoice_Click" Text="Add Invoice" Width="80px" />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="auto-style16" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style17" style="text-align: left; vertical-align: middle"></td>
            <td class="auto-style18" style="text-align: left; vertical-align: middle"></td>
        </tr>
    </table>

    <br />
    <asp:GridView ID="GridView_Invoice" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <%--<Columns>
            <asp:BoundField DataField="Party" HeaderText="Party" />
            <asp:BoundField DataField="Party" HeaderText="Party" />
            <asp:BoundField DataField="Product" HeaderText="Product" />
            <asp:BoundField DataField="Rate" HeaderText="Rate" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Total" HeaderText="Total" />
        </Columns>--%>
    </asp:GridView>

    <%--<asp:Panel>--%>
    <asp:Label runat="server" Text="Grand Total"></asp:Label>
    <asp:Label runat="server" Text="" ID="lblGrandTotal"></asp:Label>
    <asp:Button ID="close_Invoice" runat="server" Text="Close Invoice" Width="100px" OnClick="close_Invoice_Click" />
    <%--</asp:Panel>--%>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style9 {
            width: 100%;
            height: 60px;
        }

        .auto-style14 {
            height: 42px;
        }

        .auto-style15 {
            width: 100%;
            margin-bottom: 5px;
        }

        .auto-style16 {
            width: 513px;
            height: 30px;
        }

        .auto-style17 {
            width: 268px;
            height: 30px;
        }

        .auto-style18 {
            height: 30px;
        }

        .auto-style19 {
            width: 100%;
            margin-top: 0px;
        }
        .auto-style20 {
            width: 1513px;
            height: 23px;
        }
    </style>
</asp:Content>



