using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_disconnected_web_140924
{
    public partial class LoginCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Desktop-ABKHEEV;Initial Catalog=tempdb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tbllogin", con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            DataSet ds = new DataSet();

            adp.Fill(ds, "tbllogin");

            foreach (DataRow row in ds.Tables["tbllogin"].Rows)
            {
                ListBox1.Items.Add(row[0].ToString());
                ListBox2.Items.Add(row["password"].ToString());
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Desktop-ABKHEEV;Initial Catalog=tempdb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tbllogin", con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);

            DataSet ds = new DataSet();

            adp.Fill(ds, "tbllogin");

            string uid = txtUserID.Text;
            string pass = txtPassword.Text;

            bool loginflag = false;
            foreach (DataRow row in ds.Tables["tbllogin"].Rows)
            {
                if ((uid == row["userid"].ToString()) && (pass == row["password"].ToString()))
                {
                    loginflag = true;
                    Response.Write("<script> alert('Login Successful....');</script>");
                    Session["uid"] = uid;
                    Response.Redirect("Home.aspx");
                    break;
                }

            }
            if (loginflag == false)
            {
                Response.Write("<script> alert('invalid userid or password!!');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Desktop-ABKHEEV;Initial Catalog=tempdb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tbllogin", con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);

            DataSet ds = new DataSet();

            adp.Fill(ds, "tbllogin");

            ds.Tables["tbllogin"].Rows[0][0] = "abcd";
            DataRow row = ds.Tables["tbllogin"].NewRow();
            row["userid"] = txtUserID.Text;
            row[1] = txtPassword.Text;
            ds.Tables["tbllogin"].Rows.Add(row);
            int n = adp.Update(ds, "tbllogin");
            if (n > 0)
            {
                Response.Write($"<script> alert('record inserted successfully...{n}');</script>");
            }
            else
            {
                Response.Write($"<script> alert('Record not inserted!!  {n}');</script>");
            }


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Desktop-ABKHEEV;Initial Catalog=tempdb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tbllogin", con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);

            DataSet ds = new DataSet();

            adp.Fill(ds, "tbllogin");


            string uid = txtUserID.Text;
            foreach (DataRow row in ds.Tables["tbllogin"].Rows)
            {
                if (uid == row["userid"].ToString())
                {
                    row.Delete();
                    break;
                }
            }

            int n = adp.Update(ds, "tbllogin");
            if (n > 0)
            {
                Response.Write($"<script> alert('record Deleted successfully...{n}');</script>");
            }
            else
            {
                Response.Write($"<script> alert('Record not Deleted!!  {n}');</script>");
            }



        }
    }
}