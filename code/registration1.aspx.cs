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

public partial class registration1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    int regid;

    protected void Page_Load(object sender, EventArgs e)
    {
        regid = (int)Session["regid"];

        SqlDataAdapter adp = new SqlDataAdapter("select * from registration where userid='" + regid + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label15.Text = ds.Tables[0].Rows[0]["walletBitCoin"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["walletAmount"].ToString();
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");

    }
}
