using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO_disconnected_web_140924
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"]!=null)
            {
                Label2.Text = Session["uid"].ToString();
            }
            else
            {
                Response.Write("<script> alert('Not logged in....');</script>");
                Response.Redirect("LoginCRUD.aspx");

            }
        }
    }
}