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

public partial class Default2 : System.Web.UI.Page
{
    int userid; 
    string block = "Block";
    string allow = "Allow";
    string initialAmount = "5000";
    string initialBitCoin = "20";
    string empty = "";
    Class1 cs = new Class1();

    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = cs.registrationidgeneration();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Session["regid"] = userid;

        if (DropDownList1.SelectedIndex != 0)
        {
            if (DropDownList1.SelectedIndex == 1)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into registration values('" + userid + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + TextBox5.Text + "','" + DropDownList1.SelectedItem.Text + "','" + allow + "','" + empty + "','" + empty + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into registration values('" + userid + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + TextBox5.Text + "','" + DropDownList1.SelectedItem.Text + "','" + block + "','" + initialAmount + "','" + initialBitCoin + "')", con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("registration1.aspx");
            TextBox1.Text = "";
            TextBox2.Text = "";

            TextBox4.Text = "";
            RadioButtonList1.SelectedIndex = -1;
            TextBox5.Text = "";
        }
        else
        {
            string s = string.Empty;
            s = "Choose Registration Type must !!";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
        }
        
    }
}
