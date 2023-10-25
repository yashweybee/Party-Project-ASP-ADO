<%@ Page Language="C#" Title="Party List" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="PartyList.aspx.cs" Inherits="Party_Project_ASP_ADO.PartyList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Button ID="btnAddParty" runat="server" Text="Add Party" OnClick="btnAddParty_Click" />
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="P_Id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="P_Id" HeaderText="P_Id" InsertVisible="False" ReadOnly="True" SortExpression="P_Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" DeleteCommand="DELETE FROM [Party] WHERE [P_Id] = @original_P_Id AND [Name] = @original_Name" InsertCommand="INSERT INTO [Party] ([Name]) VALUES (@Name)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Party]" UpdateCommand="UPDATE [Party] SET [Name] = @Name WHERE [P_Id] = @original_P_Id AND [Name] = @original_Name">
        <DeleteParameters>
            <asp:Parameter Name="original_P_Id" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="original_P_Id" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
</asp:Content>


