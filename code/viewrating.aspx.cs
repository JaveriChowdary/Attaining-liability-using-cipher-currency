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


public partial class viewrating : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        id = Convert.ToInt32(Request.Params["id"]);
        SqlDataAdapter adp = new SqlDataAdapter("select * from adminupdate where updateid='" + id + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label3.Text = ds.Tables[0].Rows[0]["category"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["item"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["price"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["modelname"].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0]["qualities"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["avgrate"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["nor"].ToString();       

        }
        con.Close();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("searchrating.aspx");
    }
}
