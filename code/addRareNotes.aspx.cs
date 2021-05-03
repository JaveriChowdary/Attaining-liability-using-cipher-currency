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

public partial class addRareNotes : System.Web.UI.Page
{
    string filepath, localpath, fileext, filename, purchaseBy="";
    int addproductID;

    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    Class1 cs = new Class1();

    protected void Page_Load(object sender, EventArgs e)
    {
        addproductID = cs.addproductidgeneration();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        con.Open();
        filepath = Request.PhysicalApplicationPath + "uploads/" + System.IO.Path.GetFileName(FileUpload1.FileName);
        FileUpload1.SaveAs(filepath);
        localpath = "uploads/" + System.IO.Path.GetFileName(FileUpload1.FileName);
        fileext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        filename = System.IO.Path.GetFileName(FileUpload1.FileName);

        SqlCommand cmd = new SqlCommand("insert into addproduct values('" + addproductID + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + filename + "','" + fileext + "','" + localpath + "','" + filepath + "','" + DropDownList1.SelectedItem.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox8.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox7.Text + "','" + TextBox9.Text + "')", con);
        cmd.ExecuteNonQuery();
        //SqlCommand cmd1 = new SqlCommand("insert into purchaseProduct values('" + addproductID + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + filename + "','" + fileext + "','" + localpath + "','" + filepath + "','" + DropDownList1.SelectedItem.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox8.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox7.Text + "','" + purchaseBy + "','" + TextBox9.Text + "')", con);
        //cmd1.ExecuteNonQuery();
        con.Close();
        string s = string.Empty;
        s = "Currency Added sucessfully!!!";
        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
        TextBox1.Text = "";
        TextBox2.Text = "";

        DropDownList1.SelectedIndex = 0;
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox9.Text = "";
    }
}
