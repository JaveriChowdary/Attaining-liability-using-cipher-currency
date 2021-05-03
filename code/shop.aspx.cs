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

public partial class shop : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter adp1 = new SqlDataAdapter("select * from addproduct", con);
        DataSet ds1 = new DataSet();
        adp1.Fill(ds1);
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Close();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    public void bindgrid()
    {
        con.Open();
        SqlDataAdapter adp1 = new SqlDataAdapter("select * from addproduct", con);
        DataSet ds1 = new DataSet();
        adp1.Fill(ds1);
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        con.Close();
    }

}
