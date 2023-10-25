using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party_Project_ASP_ADO
{
    public partial class Product_Rate : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Write(Calendar1.SelectedDate.ToShortDateString());
            string productDate = Calendar1.SelectedDate.ToShortDateString();
            string productName = ddProductName.Text;
            string productRate = txtBoxProductRate.Text;
            try
            {

                string insertQuery = "insert into Product_Rate values((select Pr_Id from Product where Name =" + "'" + productName + "') ," + int.Parse(productRate) + ", '" + productDate + "')";
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
                Response.Redirect("ProductRateList.aspx");
            }


        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Write("Product rate");
        }
    }
}