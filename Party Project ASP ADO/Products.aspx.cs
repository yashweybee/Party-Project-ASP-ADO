using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party_Project_ASP_ADO
{
    public partial class Products : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string productName = txtBoxProductName.Text;
            try
            {

                string insertQuery = "insert into Product values " + "('" + productName + "')";
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
                Response.Redirect("ProductsList.aspx");
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            txtBoxProductName.Text = "";
        }
    }
}