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

public partial class yourviews : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        con.Open();

        SqlCommand cmd = new SqlCommand("insert into yourviews values('" + TextBox8.Text + "','" + TextBox1.Text + "','"+TextBox2.Text + "')", con);

        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("feedback1.aspx");
        //string s = string.Empty;
        //s = "Updated sucessfully!!!";
        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox8.Text = "";

    }
}
