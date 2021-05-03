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


public partial class virtualgift11 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {

        id = Convert.ToInt32(Request.Params["id"]);
        SqlDataAdapter adp = new SqlDataAdapter("select * from adminupdate where updateid='" + id + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label2.Text = ds.Tables[0].Rows[0]["updateid"].ToString();
            Session["itemid"] = Label2.Text;
            Label4.Text = ds.Tables[0].Rows[0]["category"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["item"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["price"].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["qualities"].ToString();

            Image1.ImageUrl = ds.Tables[0].Rows[0]["localpath"].ToString();

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("remind.aspx");
    }
}
