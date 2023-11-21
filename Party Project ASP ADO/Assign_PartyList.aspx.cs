using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Party_Project_ASP_ADO
{
    public partial class Assign_PartyList : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAssignParty_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assign_Party.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string PartyId = ((DropDownList)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("ddParty"))).SelectedValue;
            string ProductId = ((DropDownList)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("ddProducts"))).SelectedValue;


            SqlDataSource1.UpdateParameters["partyName"].DefaultValue = PartyId;
            SqlDataSource1.UpdateParameters["productName"].DefaultValue = ProductId;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string AsId = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlDataSource1.DeleteParameters["As_Id"].DefaultValue = AsId;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assigned Party deleted!!')", true);
        }
    }
}