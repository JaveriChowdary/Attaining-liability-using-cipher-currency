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

public partial class inbox : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    string viewstatus = "no";

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select * from admincompose where adminto='" + (string)Session["UserLoginID"] + "' and viewstatus='" + viewstatus + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            Label2.Text = "You have no unread mails !!!";
        }
        else
        {
            Label2.Text = "You have (" + ds.Tables[0].Rows.Count + ") unread mails !!!";
        }

        SqlDataAdapter adp1 = new SqlDataAdapter("select * from usercompose where username='" + (string)Session["UserLoginID"] + "' and viewstatus='" + viewstatus + "'", con);
        DataSet ds1 = new DataSet();
        adp1.Fill(ds1);
        if (ds1.Tables[0].Rows.Count == 0)
        {
            Label1.Text = "You have no unread mails !!!";
        }
        else
        {
            Label1.Text = "You have (" + ds1.Tables[0].Rows.Count + ") unread mails !!!";
        }
        con.Close();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("inbox1.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("inbox3.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Usermasterpagehome.aspx");
    }
}
