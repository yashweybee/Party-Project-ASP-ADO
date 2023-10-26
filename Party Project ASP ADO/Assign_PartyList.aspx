<%@ Page Language="C#" Title="Assign party list" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Assign_PartyList.aspx.cs" Inherits="Party_Project_ASP_ADO.Assign_PartyList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="btnAssignParty" runat="server" OnClick="btnAssignParty_Click" Text="Assign Party" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [Name] FROM [Party]"></asp:SqlDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Expr1" SortExpression="Expr1">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [Name] FROM [Product]"></asp:SqlDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Expr1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ButtonType="Button" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT p.Name, pr.Name AS Expr1 FROM Assign_Party AS ap LEFT OUTER JOIN Party AS p ON p.P_Id = ap.P_Id LEFT OUTER JOIN Product AS pr ON pr.Pr_Id = ap.Pr_Id"></asp:SqlDataSource>
    <br />

</asp:Content>


