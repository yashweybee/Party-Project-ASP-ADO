<%@ Page Language="C#" Title="Assign party list" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Assign_PartyList.aspx.cs" Inherits="Party_Project_ASP_ADO.Assign_PartyList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="btnAssignParty" runat="server" OnClick="btnAssignParty_Click" Text="Assign Party" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="As_Id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddParty" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [Name] FROM [Party]"></asp:SqlDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Products" SortExpression="Expr1">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddProducts" runat="server" DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [Name] FROM [Product]"></asp:SqlDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Expr1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ButtonType="Button" />
        </Columns>
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
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT p.Name, pr.Name AS Expr1, As_Id FROM Assign_Party AS ap LEFT OUTER JOIN Party AS p ON p.P_Id = ap.P_Id LEFT OUTER JOIN Product AS pr ON pr.Pr_Id = ap.Pr_Id" UpdateCommand="update Assign_Party set P_Id = (select P_Id from Party where Name = @partyName), Pr_Id = (select Pr_Id from Product where Name = @productName) where As_Id = @As_Id" DeleteCommand="delete Assign_Party where As_Id = @As_Id">

        <UpdateParameters>
            <asp:Parameter Name="partyName" Type="String"></asp:Parameter>
            <asp:Parameter Name="productName" Type="String"></asp:Parameter>
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="As_Id" Type="String"></asp:Parameter>
        </DeleteParameters>
    </asp:SqlDataSource>
    <br />

</asp:Content>


