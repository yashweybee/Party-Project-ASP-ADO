<%@ Page Language="C#" Title="Product rate list" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="ProductRateList.aspx.cs" Inherits="Party_Project_ASP_ADO.ProductRateList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="btnAddProductRate" runat="server" Text="Add Product Rate" OnClick="btnAddProductRate_Click" />
    <br />
    <br />
    <asp:GridView ID="Product_Rate_Grid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="Product_Rate_Grid_RowDeleting" OnRowUpdating="Product_Rate_Grid_RowUpdating" DataKeyNames="RoD_Id">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:BoundField DataField="Pr_Id" HeaderText="Pr_Id" SortExpression="Pr_Id" />--%>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <%--<EditItemTemplate>
                    <asp:DropDownList ID="ddProduct" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT [Name] FROM [Product]"></asp:SqlDataSource>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="Product_Name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate" SortExpression="Rate">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBoxRate" runat="server" Text='<%# Bind("Rate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date_Of_Rate" SortExpression="Date_Of_Rate">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBoxDate_Of_Rate" runat="server" Text='<%# Bind("Date_Of_Rate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Date_Of_Rate") %>'></asp:Label>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT  pr.Pr_Id, p.Name, pr.Rate,Convert(date, pr.Date_Of_Rate)[Date_Of_Rate], pr.RoD_Id FROM Product_Rate AS pr LEFT OUTER JOIN Product AS p ON pr.Pr_Id = p.Pr_Id" DeleteCommand="delete Product_Rate where RoD_Id = @RoD_Id" UpdateCommand="update Product_Rate set Rate = @Rate , Date_Of_Rate = @Date_Of_Rate where RoD_Id = @RoD_Id">

        <%--        <UpdateParameters>
            <asp:Parameter Name="rate" Type="String" />
            <asp:Parameter Name="date_of_rate" Type="String" />
            <asp:Parameter Name="RoD_Id" Type="String" />
        </UpdateParameters>

        <DeleteParameters>
            <asp:Parameter Name="RoD_Id" Type="String"></asp:Parameter>
        </DeleteParameters>--%>
    </asp:SqlDataSource>
    <br />


</asp:Content>

