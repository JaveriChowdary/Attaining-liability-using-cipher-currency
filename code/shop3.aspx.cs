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


public partial class shop3 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    protected void Page_Load(object sender, EventArgs e)
    {

        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select * from addproduct where proid='" + (string)Session["itemid"] + "' ", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label2.Text = ds.Tables[0].Rows[0]["currencyValue"].ToString();

            Label4.Text = ds.Tables[0].Rows[0]["puchaseAmount"].ToString();

            Label15.Text = ds.Tables[0].Rows[0]["bitCoinCount"].ToString();
            
        }
        con.Close();

    }
}
