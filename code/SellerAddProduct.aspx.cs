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

public partial class SellerAddProduct : System.Web.UI.Page
{
    string filepath, localpath, fileext, filename;
    int addproductID;

    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    Class1 cs = new Class1();

    protected void Page_Load(object sender, EventArgs e)
    {
        addproductID = cs.addproductidgeneration();
        TextBox1.Text = (string)Session["UserLoginID"];
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox2.Text != "")
        {
            con.Open();
            filepath = Request.PhysicalApplicationPath + "uploads/" + System.IO.Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(filepath);
            localpath = "uploads/" + System.IO.Path.GetFileName(FileUpload1.FileName);
            fileext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            filename = System.IO.Path.GetFileName(FileUpload1.FileName);

            var empty = "";

            SqlCommand cmd = new SqlCommand("insert into addproduct values('" + addproductID + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + filename + "','" + fileext + "','" + localpath + "','" + filepath + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox3.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + empty + "','" + empty + "','" + empty + "','" + empty + "','" + empty + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            string s = string.Empty;
            s = "Product Add sucessfully!!!";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
            //TextBox1.Text = "";
            TextBox2.Text = "";

            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
        }

    }
}
