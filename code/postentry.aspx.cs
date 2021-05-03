using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;



public partial class postentry : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    Class1 cs = new Class1();
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = cs.postentryidgeneration();
        Label4.Text = (string)Session["UserLoginID"];
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        con.Open();
        SqlCommand cmd = new SqlCommand("insert into postentry values('" + id + "','" + Label4.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();
        string s = string.Empty;
        s = "Posted sucessfully!!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
        TextBox1.Text = "";
        TextBox2.Text = "";
        Label4.Text = "";
    }
}
