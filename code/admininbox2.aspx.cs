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

public partial class admininbox2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    int id;
    string vs = "yes";

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.Params["id"]);

        if (!IsPostBack)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update usercompose set viewstatus='" + vs + "'where usercomposeid='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        SqlDataAdapter adp = new SqlDataAdapter("select * from usercompose where usercomposeid='" + id + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label2.Text = ds.Tables[0].Rows[0]["userfrom"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["username"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["sub"].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["msg"].ToString();
        }
    }

    protected void  ImageButton1_Click(object sender, ImageClickEventArgs e)
{
        Response.Redirect("admininbox1.aspx");
}
}

