using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (TextBox1.Text == "admin" && TextBox2.Text == "admin" && DropDownList1.SelectedIndex == 1)
    //    {
    //        Session["AdminID"] = TextBox1.Text;

    //        Response.Redirect("adminhome.aspx");
    //    }
    //    else
    //    {
    //        var regisrationType = DropDownList1.SelectedItem.Text;
    //        if (regisrationType == "User")
    //        {
    //            SqlDataAdapter adp = new SqlDataAdapter("select * from registration where username='" + TextBox1.Text + "'and upwd='" + TextBox2.Text + "'and registrationType='" + regisrationType + "'", con);
    //            DataSet ds = new DataSet();
    //            adp.Fill(ds);
    //            if (ds.Tables[0].Rows.Count == 0)
    //            {
    //                Label3.Visible = true;

    //                TextBox1.Text = "";
    //                TextBox2.Text = "";
    //            }
    //            else
    //            {
    //                //con.Open();
    //                //SqlCommand cmd = new SqlCommand("update staffregi set chatstatus='" + c + "' where uname='" + TextBox1.Text + "'", con);
    //                //cmd.ExecuteNonQuery();
    //                //con.Close();

    //                Session["UserLoginID"] = TextBox1.Text;

    //                TextBox1.Text = "";
    //                TextBox2.Text = "";

    //                Response.Redirect("Usermasterpagehome.aspx");
    //            }
    //        }

    //        if (regisrationType == "Seller")
    //        {
    //            SqlDataAdapter adp = new SqlDataAdapter("select * from registration where username='" + TextBox1.Text + "'and upwd='" + TextBox2.Text + "'and registrationType='" + regisrationType + "'", con);
    //            DataSet ds = new DataSet();
    //            adp.Fill(ds);
    //            if (ds.Tables[0].Rows.Count == 0)
    //            {
    //                Label3.Visible = true;

    //                TextBox1.Text = "";
    //                TextBox2.Text = "";
    //            }
    //            else
    //            {
    //                //con.Open();
    //                //SqlCommand cmd = new SqlCommand("update staffregi set chatstatus='" + c + "' where uname='" + TextBox1.Text + "'", con);
    //                //cmd.ExecuteNonQuery();
    //                //con.Close();

    //                Session["UserLoginID"] = TextBox1.Text;

    //                TextBox1.Text = "";
    //                TextBox2.Text = "";

    //                Response.Redirect("Sellermasterpagehome.aspx");
    //            }
    //        }

    //    }
    //}

}
