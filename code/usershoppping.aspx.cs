﻿using System;
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
        
public partial class usershoppping : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataAdapter adp = new SqlDataAdapter("select * from addproduct", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
    }
}
