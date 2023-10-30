using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party_Project_ASP_ADO
{

    public partial class Invoice : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
        public DataTable invoiceTableStructure = null;
        int counter;
        int noOfRowEffected;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //clearInvoiceTable();
                setPartyDropDown();
            }
        }

        public void setPartyDropDown()
        {
            try
            {
                ddProducts.Enabled = false;
                string selectQuery = "select distinct p.Name from Assign_Party ap Left join Party p on p.P_Id = ap.P_Id";
                SqlCommand cm = new SqlCommand(selectQuery, conn);
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cm);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                ddParty.DataSource = dataTable;
                ddParty.DataTextField = "Name";
                ddParty.DataBind();
                ddParty.Items.Insert(0, "Select Party");

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally
            {
                conn.Close();

                ddProducts.Enabled = true;
            }
        }
        public void setRateTxtBox()
        {
            string productName = ddProducts.Text;
            try
            {
                string selectQuery = "select Top 1 pr.Rate from Product_Rate pr left join Product p on p.Pr_Id = pr.Pr_Id where p.Name = '" + productName + "' ";
                conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
                SqlCommand cm = new SqlCommand(selectQuery, conn);
                conn.Open();
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    txtBoxRate.Text = rd.GetValue(0).ToString();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally { conn.Close(); }
        }

        public void setProductsDropDown(string partyName)
        {
            try
            {
                string selectQuery = "select pr.Name from Assign_Party ap Left join Party p on p.P_Id = ap.P_Id Left join Product pr on pr.Pr_Id = ap.Pr_Id where p.Name = '" + partyName + "'";
                conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
                SqlCommand cm = new SqlCommand(selectQuery, conn);
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cm);
                DataTable dataTable = new DataTable();
                ad.Fill(dataTable);
                ddProducts.DataSource = dataTable;
                ddProducts.DataTextField = "Name";
                ddProducts.DataBind();
                ddProducts.Items.Insert(0, "Select Product");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally { conn.Close(); }
        }

        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {
            //string productRate = (string.IsNullOrEmpty(txtBoxRate.Text.Trim()) && int.Parse(txtBoxRate.Text.Trim()) > 0) ? txtBoxRate.Text.Trim() : "0";
            //string productQuantity = (string.IsNullOrEmpty(txtBoxQuantity.Text.Trim()) && int.Parse(txtBoxQuantity.Text.Trim()) > 0) ? txtBoxQuantity.Text.Trim() : "0";


            string productName = ddProducts.Text;
            string partyName = ddParty.Text;
            string productRate = txtBoxRate.Text.Trim();
            string productQuantity = txtBoxQuantity.Text.Trim();
            int total = int.Parse(productRate) * int.Parse(productQuantity);


            try
            {
                string insertQuery = "insert into invoice values((select P_Id from Party where Name = '" + partyName + "'), (select Pr_Id from Product where Name = '" + productName + "')," + int.Parse(productRate) + ", " + int.Parse(productQuantity) + ", " + total + " )";
                conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
                SqlCommand cm = new SqlCommand(insertQuery, conn);
                conn.Open();
                noOfRowEffected = cm.ExecuteNonQuery();

                if (ViewState["Count"] != null)
                {
                    counter = Convert.ToInt32(ViewState["Count"]);
                }
                else
                {
                    counter = 0;
                }
                counter = counter + noOfRowEffected;
                ViewState["Count"] = counter;

                lblDataStatus.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Values!!')", true);
            }
            finally { conn.Close(); }

            showInvoiceTable();
            setGrandTotal();
            resetPage();
        }
        public void showInvoiceTable()
        {
            try
            {
                string selectQuery = "select top " + counter + " i.Invoice_Id, p.Name [Party], pr.Name [Product], i.Rate, i.Quantity, i.Total from invoice i Left join Party p on p.P_Id = i.P_Id Left join Product pr on pr.Pr_Id = i.Pr_Id order by i.Invoice_Id desc";
                conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
                SqlCommand cm = new SqlCommand(selectQuery, conn);
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                GridView_Invoice.DataSource = dt;
                GridView_Invoice.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally { conn.Close(); }
        }
        public void setGrandTotal()
        {
            try
            {
                string selectQuery = "select sum(Total) from invoice";
                conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
                SqlCommand cm = new SqlCommand(selectQuery, conn);
                conn.Open();
                cm.ExecuteNonQuery();
                int total = (int)cm.ExecuteScalar();
                lblGrandTotal.Text = total.ToString();

                lblDataStatus.Visible = true;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally { conn.Close(); }
        }

        protected void ddParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            setProductsDropDown(ddParty.SelectedValue);
            ddParty.Enabled = false;
        }

        protected void ddProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRateTxtBox();
        }

        protected void close_Invoice_Click(object sender, EventArgs e)
        {
            clearInvoiceTable();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Invoice is cleared!!')", true);
            showInvoiceTable();
            resetPage();
        }
        public void clearInvoiceTable()
        {
            try
            {
                string insertQuery = "delete from Invoice";
                conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
                SqlCommand cm = new SqlCommand(insertQuery, conn);
                conn.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally
            {
                conn.Close();
            }

        }
        public void resetPage()
        {
            txtBoxRate.Text = "";
            txtBoxQuantity.Text = "";
            lblDataStatus.Visible = false;

        }
    }
}