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

public partial class usershoppping1 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        id =Convert.ToInt32( Request.Params["id"]);

        SqlDataAdapter adp = new SqlDataAdapter("select * from ordercust where custid='" + id + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            Label9.Text = ds.Tables[0].Rows[0]["proid"].ToString();

            SqlDataAdapter adp1 = new SqlDataAdapter("select * from adminupdate where updateid='" + Label9.Text + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);

            Label16.Text = ds1.Tables[0].Rows[0]["category"].ToString();
            Label18.Text = ds1.Tables[0].Rows[0]["item"].ToString();
            Label20.Text = ds1.Tables[0].Rows[0]["modelname"].ToString();
            Label22.Text = ds1.Tables[0].Rows[0]["qualities"].ToString();
            Label24.Text = ds1.Tables[0].Rows[0]["price"].ToString();

            Label7.Text = ds.Tables[0].Rows[0]["custname"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["email"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["addres"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["city"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["landmark"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["phone"].ToString();
        }
    }
}
