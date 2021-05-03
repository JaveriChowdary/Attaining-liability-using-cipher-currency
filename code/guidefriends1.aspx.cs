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

public partial class guidefriends1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.Params["id"];

        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select * from postentry where entryid='"+id+"'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label2.Text = ds.Tables[0].Rows[0]["entryid"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["entryname"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["title"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["entrymsg"].ToString();
           
        }

        con.Close();

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("guidefriends.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into entryreply values('" + Label2.Text + "','" + Label4.Text + "','" + Label6.Text + "','" + TextBox2.Text + "','" + TextBox1.Text + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();
        string s2 = string.Empty;
        s2 = "You Reply has been posted successfully !!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s2 + "')", true);
        Response.Redirect("masterpagehome.aspx");

    }
}
