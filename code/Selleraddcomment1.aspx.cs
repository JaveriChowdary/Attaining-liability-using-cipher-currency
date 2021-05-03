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


public partial class Selleraddcomment1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);

    int id,commentid;
    Class1 cs = new Class1();

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.Params["id"]);
        commentid = cs.commentidgeneration();

        SqlDataAdapter adp = new SqlDataAdapter("select * from adminupdate where updateid='" + id + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            TextBox2.Text = ds.Tables[0].Rows[0]["updateid"].ToString();
           TextBox3.Text = ds.Tables[0].Rows[0]["category"].ToString();
           TextBox4.Text = ds.Tables[0].Rows[0]["item"].ToString();
           TextBox5.Text= ds.Tables[0].Rows[0]["modelname"].ToString();
             
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        

        con.Open();
        SqlCommand cmd = new SqlCommand("insert into addcomment values('" + commentid + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox1.Text + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();

        string s = string.Empty;
        s = "Your comment has been added sucessfully!!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Selleraddcomment.aspx");
    }
}
