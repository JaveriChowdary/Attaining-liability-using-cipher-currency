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

public partial class scrapbook : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataAdapter adp1 = new SqlDataAdapter("select * from postentry where entryname='" + (string)Session["UserLoginID"] + "'", con);
        DataSet ds1 = new DataSet();
        adp1.Fill(ds1);
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Close();
    }
}
