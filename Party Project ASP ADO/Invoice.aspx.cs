using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party_Project_ASP_ADO
{
    public partial class Invoice : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {
            //showTableData();
            if (!IsPostBack)
            {
                try
                {
                    string selectQuery = "select distinct p.Name from Assign_Party ap Left join Party p on p.P_Id = ap.P_Id";
                    SqlCommand cm = new SqlCommand(selectQuery, conn);
                    conn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    DataTable dataTable = new DataTable();
                    ad.Fill(dataTable);
                    ddParty.DataSource = dataTable;
                    ddParty.DataTextField = "Name";
                    ddParty.DataBind();
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
        }
        protected void Page_PageUn(object sender, EventArgs e)
        {

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
                //SqlDataReader dr = cm.ExecuteReader();
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    txtBoxRate.Text = (string)rd["Rate"];
                }
                //Response.Write("aaaaaaaaaaaaaaaaaaa");
                //lblDataStatus.Visible = true;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally { conn.Close(); }
        }

        public void setDropDown(string partyName)
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
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());

            }
            finally { conn.Close(); }
        }

        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {
            //string productName = ddProducts.Text;
            //string partyName = ddParty.Text;
            //string productRate = txtBoxRate.Text;
            //string productQuantity = txtBoxQuantity.Text;
            //int total = int.Parse(productRate) * int.Parse(productQuantity);

            //try
            //{
            //    string insertQuery = "insert into invoice values((select P_Id from Party where Name = '" + partyName + "'), (select Pr_Id from Product where Name = '" + productName + "')," + int.Parse(productRate) + ", " + int.Parse(productQuantity) + ", " + total + " )";
            //    conn = new SqlConnection("data source =.; database = PartyProduct; integrated security = SSPI");
            //    SqlCommand cm = new SqlCommand(insertQuery, conn);
            //    conn.Open();
            //    cm.ExecuteNonQuery();
            //    lblDataStatus.Visible = true;

            //}
            //catch (Exception ex)
            //{
            //    Response.Write(ex.ToString());

            //}
            //finally { conn.Close(); }

            showTableData();
            setGrandTotal();


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
        public void showTableData()
        {
            GridView_Invoice.AutoGenerateColumns = false;
            BoundField bf = new BoundField();
            bf.DataField = "Party";
            bf.DataField = "Product";
            bf.DataField = "Rate";
            bf.DataField = "Quantity";
            bf.DataField = "Total";
            GridView_Invoice.Columns.Add(bf);

        }

        protected void ddParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDropDown(ddParty.Text);
        }

        protected void ddProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRateTxtBox();
        }
    }
}