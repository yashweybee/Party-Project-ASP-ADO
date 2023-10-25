using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Party_Project_ASP_ADO
{
    public partial class PartyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
            Response.Redirect("Party.aspx");
        }
    }
}