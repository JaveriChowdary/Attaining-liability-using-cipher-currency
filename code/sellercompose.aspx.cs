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

public partial class sellercompose : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    string a = "Admin";
    Class1 cs = new Class1();
    int id;
    string viewstatus = "no";

    protected void Page_Load(object sender, EventArgs e)
    {
        id = cs.usercomposeidgeneration();

        Label3.Text = (string)Session["UserLoginID"];
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter adp = new SqlDataAdapter("select * from registration where userid='" + DropDownList3.SelectedItem.Text + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            //errormsg
        }
        else
        {
            Label10.Text = ds.Tables[0].Rows[0]["username"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["email"].ToString();
        }
        con.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 1)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, "--Select--");
            DropDownList3.Enabled = false;
            Label10.Text = "Admin";
            Label11.Text = "Admin";
        
        }
        else
        {

            if (DropDownList1.SelectedIndex == 2)
            {
                DropDownList3.Enabled = true;
                con.Open();
                DropDownList3.Items.Clear();
                DropDownList3.Items.Insert(0, "--Select--");
                SqlDataAdapter adp = new SqlDataAdapter("select * from registration where username!='" + Label3.Text + "' ", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownList3.Items.Add(ds.Tables[0].Rows[i]["userid"].ToString());
                }
                con.Close();
            }
        
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (DropDownList1.SelectedIndex == 1)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into usercompose values('" + id + "','" + Label3.Text + "','" + DropDownList1.SelectedItem.Text + "','" + a + "','" + a + "','" + a + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + viewstatus + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DropDownList1.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
            Label10.Text = "";
            Label11.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            Response.Redirect("sellercompose1.aspx");
        }
        else
        {
            if (DropDownList1.SelectedIndex == 2)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into usercompose values('" + id + "','" + Label3.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + Label10.Text + "','" + Label11.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + viewstatus + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                DropDownList1.SelectedIndex = 0;
                DropDownList3.SelectedIndex = 0;
                Label10.Text = "";
                Label11.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                Response.Redirect("sellercompose1.aspx");
            }
        }

    }
}
