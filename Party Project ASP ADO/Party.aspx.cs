using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Party_Project_ASP_ADO
{
    public partial class Party : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string partyName = txtBoxPartyName.Text;
            try
            {

                string insertQuery = "insert into Party values " + "('" + partyName + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblDataStatus.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
                Response.Redirect("PartyList.aspx");
            }

        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            txtBoxPartyName.Text = "";
        }
    }
}