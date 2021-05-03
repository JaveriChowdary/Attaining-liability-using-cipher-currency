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


public partial class barGainshop2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    Class1 cs = new Class1();
    int custoid, shopcount, fsc;
    string minimunBargainPrice, yes="yes";

    protected void Page_Load(object sender, EventArgs e)
    {
        Label9.Text = (string)Session["itemid"];
        Label7.Text = (string)Session["UserLoginID"];
        custoid = cs.custidgeneration();

        SqlDataAdapter adp = new SqlDataAdapter("select * from addproduct where proid='" + Label9.Text + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count != 0)
        {
            TextBox1.Text = ds.Tables[0].Rows[0]["price"].ToString();
            minimunBargainPrice = ds.Tables[0].Rows[0]["minimumBargainRate"].ToString();
            Label7.Text = ds.Tables[0].Rows[0]["itemname"].ToString();
        }


    }
    
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    SqlDataAdapter adp = new SqlDataAdapter("select * from adminupdate where updateid='" + Label9.Text + "'", con);
    //    DataSet ds = new DataSet();
    //    adp.Fill(ds);

    //    shopcount = Convert.ToInt32(ds.Tables[0].Rows[0]["countt"].ToString());
    //    fsc = shopcount + 1;

    //    con.Open();
    //    SqlCommand cmd1 = new SqlCommand("update adminupdate set countt='" + fsc + "'where updateid='" + Label9.Text + "'", con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();

    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("insert into ordercust values('" + custoid + "','" + Label9.Text + "','" + Label7.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
    //    cmd.ExecuteNonQuery();
    //    con.Close();

    //    TextBox2.Text = "";
    //    TextBox3.Text = "";
    //    TextBox4.Text = "";
    //    TextBox5.Text = "";
    //    TextBox6.Text = "";
    //    Response.Redirect("shop3.aspx");
    //}

    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    //SqlDataAdapter adp = new SqlDataAdapter("select * from adminupdate where updateid='" + Label9.Text + "'", con);
    //    //DataSet ds = new DataSet();
    //    //adp.Fill(ds);

    //    //shopcount = Convert.ToInt32(ds.Tables[0].Rows[0]["countt"].ToString());
    //    //fsc = shopcount + 1;

    //    //con.Open();
    //    //SqlCommand cmd1 = new SqlCommand("update adminupdate set countt='" + fsc + "'where updateid='" + Label9.Text + "'", con);
    //    //cmd1.ExecuteNonQuery();
    //    //con.Close();

    //    //con.Open();
    //    //SqlCommand cmd = new SqlCommand("insert into ordercust values('" + custoid + "','" + Label9.Text + "','" + Label7.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "','" + TextBox1.Text + "','" + TextBox3.Text + "')", con);
    //    //cmd.ExecuteNonQuery();
    //    //con.Close();

    //    //TextBox2.Text = "";
    //    //TextBox3.Text = "";
    //    //TextBox4.Text = "";
    //    ////TextBox8.Text = "";
    //    //TextBox6.Text = "";
    //    //Response.Redirect("shop3.aspx");

    //    if (Convert.ToInt64(minimunBargainPrice) >= Convert.ToInt64(TextBox3.Text))
    //    {
    //        con.Open();
    //        SqlCommand cmd1 = new SqlCommand("update addproduct set UserBargainPrice='" + TextBox3.Text + "'where proid='" + Label9.Text + "'", con);
    //        cmd1.ExecuteNonQuery();
    //        SqlCommand cmd2 = new SqlCommand("update addproduct set BargainRequest='" + yes + "'where proid='" + Label9.Text + "'", con);
    //        cmd2.ExecuteNonQuery();
    //        con.Close();

    //        Label12.Visible = true;
    //    }
    //    else
    //    {
    //        string s = string.Empty;
    //        s = "Minimum Bargaind Price is : " + minimunBargainPrice;
    //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
    //    }

       
    //}


    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt64(minimunBargainPrice) <= Convert.ToInt64(TextBox3.Text))
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("update addproduct set UserBargainPrice='" + TextBox3.Text + "'where proid='" + Label9.Text + "'", con);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("update addproduct set BargainRequest='" + yes + "'where proid='" + Label9.Text + "'", con);
            cmd2.ExecuteNonQuery();
            con.Close();

            Label12.Visible = true;
        }
        else
        {
            string s = string.Empty;
            s = "Minimum Bargaind Price is : " + minimunBargainPrice;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
        }

    }
}
