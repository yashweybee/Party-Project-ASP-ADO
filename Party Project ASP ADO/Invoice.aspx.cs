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
        int grandTotal;
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
        public void setGrandTotal(int total)
        {
            if (ViewState["Gt"] != null)
            {
                grandTotal = Convert.ToInt32(ViewState["Gt"]);
            }
            else
            {
                grandTotal = 0;
            }
            grandTotal = grandTotal + total;
            ViewState["Gt"] = grandTotal;

            lblGrandTotal.Text = grandTotal.ToString();
        }

        public void setCounter(int num)
        {
            if (ViewState["Count"] != null)
            {
                counter = Convert.ToInt32(ViewState["Count"]);
            }
            else
            {
                counter = 0;
            }
            counter = counter + num;
            ViewState["Count"] = counter;
        }

        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {
            //string productRate = (string.IsNullOrEmpty(txtBoxRate.Text.Trim()) && int.Parse(txtBoxRate.Text.Trim()) > 0) ? txtBoxRate.Text.Trim() : "0";
            //string productQuantity = (string.IsNullOrEmpty(txtBoxQuantity.Text.Trim()) && int.Parse(txtBoxQuantity.Text.Trim()) > 0) ? txtBoxQuantity.Text.Trim() : "0";
            try
            {
                string productName = ddProducts.Text;
                string partyName = ddParty.Text;
                string productRate = txtBoxRate.Text.Trim();
                if (string.IsNullOrEmpty(productRate) || int.Parse(productRate) < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Rate Value!!')", true);
                }
                string productQuantity = txtBoxQuantity.Text.Trim();
                int total = int.Parse(productRate) * int.Parse(productQuantity);
                setGrandTotal(total);


                string insertQuery = "insert into invoice values((select P_Id from Party where Name = '" + partyName + "'), (select Pr_Id from Product where Name = '" + productName + "')," + int.Parse(productRate) + ", " + int.Parse(productQuantity) + ", " + total + " )";
                conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
                SqlCommand cm = new SqlCommand(insertQuery, conn);
                conn.Open();
                noOfRowEffected = cm.ExecuteNonQuery();

                setCounter(noOfRowEffected);

                lblDataStatus.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter Valid Values!!')", true);
            }
            finally { conn.Close(); }

            showInvoiceTable();

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
            resetGrid();
            resetPage();
            setGrandTotal(0);
            setCounter(0);
            ddParty.Enabled = true;
            lblGrandTotal.Text = " ";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Invoice is cleared!!')", true);
        }

        public void resetPage()
        {
            txtBoxRate.Text = "";
            txtBoxQuantity.Text = "";
            lblDataStatus.Visible = false;
        }
        public void resetGrid()
        {
            GridView_Invoice.DataSource = null;
            GridView_Invoice.DataBind();

        }
    }
}