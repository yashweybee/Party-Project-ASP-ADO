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


            string ddl = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[0].FindControl("ddParty")).SelectedValue;
            string ddl2 = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[0].FindControl("ddProducts")).SelectedValue;

            SqlDataSource1.UpdateParameters["PartyName"].DefaultValue = ddl;
            SqlDataSource1.UpdateParameters["ProductName"].DefaultValue = ddl2;


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //SqlDataSource1.UpdateParameters["PartyName"].DefaultValue = ;



        }
    }
}