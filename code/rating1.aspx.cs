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

public partial class rating1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    int id, rate = 0, nor = 0, getnor, returnnor;
    double returnrat, returnrate, getrate;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.Params["id"]);
        SqlDataAdapter adp = new SqlDataAdapter("select * from adminupdate where updateid='" + id + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label2.Text = ds.Tables[0].Rows[0]["updateid"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["category"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["item"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["price"].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["qualities"].ToString();
            Image1.ImageUrl = ds.Tables[0].Rows[0]["localpath"].ToString();
            getrate =Convert.ToDouble( ds.Tables[0].Rows[0]["rating"].ToString());
            getnor =Convert.ToInt32( ds.Tables[0].Rows[0]["nor"].ToString());
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        rate=1;
        nor=1;
        returnnor = getnor + nor;
        returnrat = getrate + rate;
        returnrate = returnrat / returnnor;

        con.Open();
        SqlCommand cmd = new SqlCommand("update adminupdate set rating='" + returnrat + "'where updateid='" + Label2.Text + "'", con);
        cmd.ExecuteNonQuery();
        SqlCommand cmd1 = new SqlCommand("update adminupdate set nor='" + returnnor + "'where updateid='" + Label2.Text + "'", con);
        cmd1.ExecuteNonQuery();
        SqlCommand cmd2 = new SqlCommand("update adminupdate set avgrate='" + returnrate + "'where updateid='" + Label2.Text + "'", con);
        cmd2.ExecuteNonQuery();
        con.Close();

        string s = string.Empty;
        s = "Rated sucessfully!!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);

        ImageButton2.ImageUrl = "images/greenstar.png";
        ImageButton3.ImageUrl = "images/star.jpg";
        ImageButton4.ImageUrl = "images/star.jpg";
        ImageButton5.ImageUrl = "images/star.jpg"; 
        ImageButton6.ImageUrl = "images/star.jpg";

        ImageButton2.Enabled = false;
        ImageButton3.Enabled = false;
        ImageButton4.Enabled = false;
        ImageButton5.Enabled = false;
        ImageButton6.Enabled = false;

    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        rate = 2;
        nor = 1;
        returnnor = getnor + nor;
        returnrat = getrate + rate;
        returnrate = returnrat / returnnor;

        con.Open();
        SqlCommand cmd = new SqlCommand("update adminupdate set rating='" + returnrat + "'where updateid='" + Label2.Text + "'", con);
        cmd.ExecuteNonQuery();
        SqlCommand cmd1 = new SqlCommand("update adminupdate set nor='" + returnnor + "'where updateid='" + Label2.Text + "'", con);
        cmd1.ExecuteNonQuery();
        SqlCommand cmd2 = new SqlCommand("update adminupdate set avgrate='" + returnrate + "'where updateid='" + Label2.Text + "'", con);
        cmd2.ExecuteNonQuery();
        con.Close();

        string s = string.Empty;
        s = "Rated sucessfully!!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
        ImageButton2.ImageUrl = "images/greenstar.png";

        ImageButton3.ImageUrl = "images/greenstar.png";
        ImageButton4.ImageUrl = "images/star.jpg";
        ImageButton5.ImageUrl = "images/star.jpg";
        ImageButton6.ImageUrl = "images/star.jpg";

        ImageButton2.Enabled = false;
        ImageButton3.Enabled = false;
        ImageButton4.Enabled = false;
        ImageButton5.Enabled = false;
        ImageButton6.Enabled = false;
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        rate = 3;
        nor = 1;
        returnnor = getnor + nor;
        returnrat = getrate + rate;
        returnrate = returnrat / returnnor;

        con.Open();
        SqlCommand cmd = new SqlCommand("update adminupdate set rating='" + returnrat + "'where updateid='" + Label2.Text + "'", con);
        cmd.ExecuteNonQuery();
        SqlCommand cmd1 = new SqlCommand("update adminupdate set nor='" + returnnor + "'where updateid='" + Label2.Text + "'", con);
        cmd1.ExecuteNonQuery();
        SqlCommand cmd2 = new SqlCommand("update adminupdate set avgrate='" + returnrate + "'where updateid='" + Label2.Text + "'", con);
        cmd2.ExecuteNonQuery();
        con.Close();

        string s = string.Empty;
        s = "Rated sucessfully!!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);

        ImageButton2.ImageUrl = "images/greenstar.png";
        ImageButton3.ImageUrl = "images/greenstar.png";
        ImageButton4.ImageUrl = "images/greenstar.png";
        ImageButton5.ImageUrl = "images/star.jpg";
        ImageButton6.ImageUrl = "images/star.jpg";

        ImageButton2.Enabled = false;
        ImageButton3.Enabled = false;
        ImageButton4.Enabled = false;
        ImageButton5.Enabled = false;
        ImageButton6.Enabled = false;
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        rate = 4;
        nor = 1;
        returnnor = getnor + nor;
        returnrat =getrate + rate;
        returnrate = returnrat / returnnor;
        

        con.Open();
        SqlCommand cmd = new SqlCommand("update adminupdate set rating='" + returnrat + "'where updateid='" + Label2.Text + "'", con);
        cmd.ExecuteNonQuery();
        SqlCommand cmd1 = new SqlCommand("update adminupdate set nor='" + returnnor + "'where updateid='" + Label2.Text + "'", con);
        cmd1.ExecuteNonQuery();
        SqlCommand cmd2 = new SqlCommand("update adminupdate set avgrate='" + returnrate + "'where updateid='" + Label2.Text + "'", con);
        cmd2.ExecuteNonQuery();
        con.Close();

        string s = string.Empty;
        s = "Rated sucessfully!!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);

        ImageButton2.ImageUrl = "images/greenstar.png";
        ImageButton3.ImageUrl = "images/greenstar.png";
        ImageButton4.ImageUrl = "images/greenstar.png";
        ImageButton5.ImageUrl = "images/greenstar.png";
        ImageButton6.ImageUrl = "images/star.jpg";

        ImageButton2.Enabled = false;
        ImageButton3.Enabled = false;
        ImageButton4.Enabled = false;
        ImageButton5.Enabled = false;
        ImageButton6.Enabled = false;
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        rate = 5;
        nor = 1;
        returnnor = getnor + nor;
        returnrat = getrate + rate;
        returnrate = returnrat / returnnor;

        con.Open();
        SqlCommand cmd = new SqlCommand("update adminupdate set rating='" + returnrat + "'where updateid='" + Label2.Text + "'", con);
        cmd.ExecuteNonQuery();
        SqlCommand cmd1 = new SqlCommand("update adminupdate set nor='" + returnnor + "'where updateid='" + Label2.Text + "'", con);
        cmd1.ExecuteNonQuery();
        SqlCommand cmd2 = new SqlCommand("update adminupdate set avgrate='" + returnrate + "'where updateid='" + Label2.Text + "'", con);
        cmd2.ExecuteNonQuery();
        con.Close();

        string s = string.Empty;
        s = "Rated sucessfully!!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);

        ImageButton2.ImageUrl = "images/greenstar.png";
        ImageButton3.ImageUrl = "images/greenstar.png";
        ImageButton4.ImageUrl = "images/greenstar.png";
        ImageButton5.ImageUrl = "images/greenstar.png";
        ImageButton6.ImageUrl = "images/greenstar.png";

        ImageButton2.Enabled = false;
        ImageButton3.Enabled = false;
        ImageButton4.Enabled = false;
        ImageButton5.Enabled = false;
        ImageButton6.Enabled = false;
    }

    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("rating.aspx");
    }
}
