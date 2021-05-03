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


public partial class shop1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label2.Text = (string)Session["itemid"];
        id = Convert.ToInt32(Request.Params["id"]);

        SqlDataAdapter adp = new SqlDataAdapter("select * from addproduct where proid='" + id + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label2.Text = ds.Tables[0].Rows[0]["proid"].ToString();
            Session["itemid"] = Label2.Text;
            Label4.Text = ds.Tables[0].Rows[0]["currencycode"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["currencynumber"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["currencyType"].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["currencyValue"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["currencySign"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["puchaseAmount"].ToString();
            Image1.ImageUrl = ds.Tables[0].Rows[0]["localpath"].ToString();
            Label15.Text = ds.Tables[0].Rows[0]["bitCoinCount"].ToString();
        }
    }
    
    
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("shop2.aspx");
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("shop.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("barGainshop2.aspx");
    }
}
