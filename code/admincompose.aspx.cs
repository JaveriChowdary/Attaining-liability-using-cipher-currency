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

public partial class admincompose : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    Class1 cs = new Class1();
    int id;
    string viewstatus = "no";

    protected void Page_Load(object sender, EventArgs e)
    {
        id = cs.admincomposeidgeneration();
        con.Open();

        if (!IsPostBack)
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from registration", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DropDownList3.Items.Add(ds.Tables[0].Rows[i]["userid"].ToString());
            }
        }
        con.Close();
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        SqlDataAdapter adp = new SqlDataAdapter("select * from registration where userid='" + DropDownList3.SelectedItem.Text + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            //errormsg
        }
        else
        {
            Label9.Text = ds.Tables[0].Rows[0]["username"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["email"].ToString();
        }
       

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into admincompose values('" + id + "','" + Label3.Text + "','" + DropDownList3.SelectedItem.Text + "','" + Label9.Text + "','" + Label10.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','"+viewstatus+"')", con);

        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("admincompose1.aspx");
        DropDownList3.SelectedIndex = 0;
        Label9.Text = "";
        Label10.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
            }
}
