using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Party_Project_ASP_ADO
{
    public partial class ProductRateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProductRate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Rate.aspx");
        }

        protected void Product_Rate_Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string RoD_Id = Product_Rate_Grid.DataKeys[e.RowIndex].Value.ToString();
            //SqlDataSource1.DeleteParameters["RoD_Id"].DefaultValue = RoD_Id;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product Rate deleted!!')", true);
        }

        protected void Product_Rate_Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //TextBox txtBoxRate = (TextBox)Product_Rate_Grid.Rows[e.RowIndex].FindControl("txtBoxRate");
            //TextBox txtBoxDateOfRate = (TextBox)Product_Rate_Grid.Rows[e.RowIndex].FindControl("txtBoxDate_Of_Rate");
            //string RoD_Id = Product_Rate_Grid.DataKeys[e.RowIndex].Value.ToString();

            //SqlDataSource1.UpdateParameters["rate"].DefaultValue = txtBoxRate.Text;
            //SqlDataSource1.UpdateParameters["date_of_rate"].DefaultValue = txtBoxDateOfRate.Text;
            //SqlDataSource1.UpdateParameters["RoD_Id"].DefaultValue = RoD_Id;
        }
    }
}