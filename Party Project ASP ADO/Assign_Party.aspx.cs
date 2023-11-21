using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party_Project_ASP_ADO
{
    public partial class Assign_Party : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string partyName = ddPartyName.Text;
            int partyId = int.Parse(ddPartyName.SelectedValue);
            string productName = ddProductName.Text;
            int productId = int.Parse(ddProductName.SelectedValue);
            try
            {
                string insertQuery = "insert into Assign_Party values(" + partyId + "," + productId + ")";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblDataStatus.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR!!!')", true);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assign_PartyList.aspx");
        }
    }
}