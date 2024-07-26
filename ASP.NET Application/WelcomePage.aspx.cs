using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Application
{
    public partial class WelcomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string uniqueId = Session["Username"] != null ? Session["Username"].ToString() : string.Empty;
            // Response.Redirect("http://localhost:8411/Registration/ChangePasswordUsingCurrentPassword.aspx?uid=" + uniqueId);

        }
    }
}