using System;
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

public partial class adminapproveBuyer1 : System.Web.UI.Page 
{
    string filepath, localpath, fileext, filename,filename1;

    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    Class1 cs = new Class1();
    int id, rate = 0, nor = 0, id1, count = 0,avg=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        id1 = Convert.ToInt32(Request.Params["userid"]);
        string getallowstatus = "";
        //id = cs.adminupdateidgeneration();
        con.Open();
        var Approve = "Allow";
        var Block = "Block";

        SqlDataAdapter adp = new SqlDataAdapter("select * from registration where userid='" + id1 + "'", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    getallowstatus = ds.Tables[0].Rows[0]["allowType"].ToString();
                }

                if (getallowstatus == "Allow")
                {
                    SqlCommand cmd = new SqlCommand("update registration set allowType='" + Block + "'where userid='" + id1 + "'", con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("update registration set allowType='" + Approve + "'where userid='" + id1 + "'", con);
                    cmd1.ExecuteNonQuery();
                }
       
        con.Close();
        Response.Redirect("adminapproveBuyer.aspx");
    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
        
    //    con.Open();
    //    var Approve = "Approve";
    //    SqlCommand cmd = new SqlCommand("update addproduct set ApproveStatus='" + Approve + "'where proid='" + id1 + "'", con);
    //    cmd.ExecuteNonQuery();
    //    SqlCommand cmd1 = new SqlCommand("insert into adminupdate values('" + id + "', '" + TextBox1.Text + "','" + TextBox2.Text + "','" + filename + "','" + fileext + "','" + localpath + "','" + filepath + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + rate + "','" + nor + "','" + count + "','" + avg + "')", con);
    //    cmd1.ExecuteNonQuery();
    //    con.Close();
    //    string s = string.Empty;
    //    s = "Product Approved sucessfully!!!";
    //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
    //    TextBox1.Text = "";
    //    TextBox2.Text = "";
    //    TextBox3.Text = "";
    //    TextBox4.Text = "";
    //    TextBox5.Text = "";
    //    TextBox6.Text = "";

    //    //SqlDataAdapter adp = new SqlDataAdapter("select * from adminupdate where modelname='" + TextBox3.Text + "'and price='" + TextBox5.Text + "'", con);
    //    //DataSet ds = new DataSet();
    //    //adp.Fill(ds);
    //    //if (ds.Tables[0].Rows.Count == 0)
    //    //{
    //    //    //filepath = Request.PhysicalApplicationPath + "uploads/" + System.IO.Path.GetFileName(FileUpload1.FileName);
    //    //    //filename1 = System.IO.Path.GetFileName(FileUpload1.FileName);
    //    //    if (TextBox6.Text == "")
    //    //    {
    //    //        string s1 = string.Empty;
    //    //        s1 = "Price not uploaded!!!";
    //    //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s1 + "')", true);
    //    //    }
    //    //    else
    //    //    {
    //    //        //FileUpload1.SaveAs(filepath);
    //    //        //localpath = "uploads/" + System.IO.Path.GetFileName(FileUpload1.FileName);
    //    //        //fileext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
    //    //        //filename = System.IO.Path.GetFileName(FileUpload1.FileName);

    //    //        //SqlCommand cmd = new SqlCommand("insert into adminupdate values('" + id + "', '" + TextBox1.Text + "','" + TextBox2.Text + "','" + filename + "','" + fileext + "','" + localpath + "','" + filepath + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + rate + "','" + nor + "','" + count + "','" + avg + "')", con);
    //    //        //cmd.ExecuteNonQuery();
    //    //        //con.Close();
    //    //        SqlCommand cmd = new SqlCommand("insert into adminupdate values('" + id + "', '" + TextBox1.Text + "','" + TextBox2.Text + "','" + filename + "','" + fileext + "','" + localpath + "','" + filepath + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + rate + "','" + nor + "','" + count + "','" + avg + "')", con);
    //    //        cmd.ExecuteNonQuery();
    //    //        con.Close();
    //    //        string s = string.Empty;
    //    //        s = "Updated sucessfully!!!";
    //    //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
    //    //        TextBox1.Text = "";
    //    //        TextBox2.Text = "";
    //    //        TextBox3.Text = "";
    //    //        TextBox4.Text = "";
    //    //        TextBox5.Text = "";
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    string s2 = string.Empty;
    //    //    s2 = "Product Already Approved!!!";
    //    //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s2 + "')", true);
    //    //}
        
    //}
}
