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


public partial class shop2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["socialcln"]);
    Class1 cs = new Class1();
    Cryptography cr = new Cryptography();
    int custoid, shopcount, fsc;
    string request = "yes";
    string tocken;
    string initialAmt, initialCoin;
    string yes = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Label9.Text = (string)Session["itemid"];
        Label7.Text = (string)Session["UserLoginID"];
        custoid = cs.custidgeneration();

        SqlDataAdapter adp = new SqlDataAdapter("select * from addproduct where proid='" + Label9.Text + "'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        Label10.Text = ds.Tables[0].Rows[0]["puchaseAmount"].ToString();
        Label15.Text = ds.Tables[0].Rows[0]["bitCoinCount"].ToString();
    }

    public void GenTocken()
    {
        Random val = new Random();
        int rno = val.Next(12345, 54321);
        tocken = Convert.ToString(rno);
    }

    public void GenTocken1()
    {
        Random val = new Random();
        int rno = val.Next(42345, 50321);
        tocken = Convert.ToString(rno);
    }

    public void GenTocken2()
    {
        Random val = new Random();
        int rno = val.Next(22345, 44321);
        tocken = Convert.ToString(rno);
    }

    public void GenTocken3()
    {
        Random val = new Random();
        int rno = val.Next(12345, 24321);
        tocken = Convert.ToString(rno);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int coin = (Convert.ToInt32(Label10.Text)) / 500;

        if (DropDownList1.SelectedIndex == 0)
        {
            string s = string.Empty;
            s = "Choose Type of Purchase must !!";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);
        }
        else
        {

            SqlDataAdapter adp1 = new SqlDataAdapter("select * from registration where username='" + Label7.Text + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            con.Open();

            if (ds1.Tables[0].Rows.Count != 0)
            {
                initialCoin = ds1.Tables[0].Rows[0]["walletBitCoin"].ToString();
                initialAmt = ds1.Tables[0].Rows[0]["walletAmount"].ToString();
            }

            if (DropDownList1.SelectedIndex == 1)
            {
                if (Convert.ToInt32(initialAmt) > Convert.ToInt32(Label10.Text))
                {
                    yes = "yes";

                    int currentBal = Convert.ToInt32(initialAmt) - Convert.ToInt32(Label10.Text);
                    int cuurentBitCoin = Convert.ToInt32(initialCoin) + Convert.ToInt32(coin);

                    SqlCommand cmd6 = new SqlCommand("update registration set walletAmount='" + currentBal + "'where username='" + Label7.Text + "'", con);
                    cmd6.ExecuteNonQuery();

                    SqlCommand cmd7 = new SqlCommand("update registration set walletBitCoin='" + cuurentBitCoin + "'where username='" + Label7.Text + "'", con);
                    cmd7.ExecuteNonQuery();
                }
                else
                {
                    string s = string.Empty;
                    s = "You not have Sufficiant Balance !!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);

                    yes = "no";
                }
            }
            else
            {
                
                if (Convert.ToInt32(coin) < Convert.ToInt32(initialCoin))
                {
                    yes = "yes";

                    //int currentBal1 = Convert.ToInt32(initialAmt) - Convert.ToInt32(Label10.Text);
                    int cuurentBitCoin1 = Convert.ToInt32(initialCoin) - Convert.ToInt32(coin);
                    int cuurentBitCoin2 = Convert.ToInt32(initialCoin) + Convert.ToInt32(Label15.Text);

                    SqlCommand cmd6 = new SqlCommand("update registration set walletBitCoin='" + cuurentBitCoin1 + "'where username='" + Label7.Text + "'", con);
                    cmd6.ExecuteNonQuery();

                    SqlCommand cmd7 = new SqlCommand("update registration set walletBitCoin='" + cuurentBitCoin2 + "'where username='" + Label7.Text + "'", con);
                    cmd7.ExecuteNonQuery();
                }
                else
                {
                    string s = string.Empty;
                    s = "You not have Sufficiant BitCoins !!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + s + "')", true);

                    yes = "no";
                }
            }

            if (yes == "yes")
            {

                SqlDataAdapter adp = new SqlDataAdapter("select * from adminupdate where updateid='" + Label9.Text + "'", con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                //shopcount = Convert.ToInt32(ds.Tables[0].Rows[0]["countt"].ToString());
                //fsc = shopcount + 1;

                //con.Open();
                //SqlCommand cmd1 = new SqlCommand("update adminupdate set countt='" + fsc + "'where updateid='" + Label9.Text + "'", con);
                //cmd1.ExecuteNonQuery();
                //SqlCommand cmd2 = new SqlCommand("update purchaseProduct set purchaseBy='" + Label7.Text + "'where proid='" + Label9.Text + "'", con);
                //cmd2.ExecuteNonQuery();

                GenTocken();
                string commonhashvalue = tocken;
                string enccommonhashvalue = cr.Encrypt(tocken);

                GenTocken1();
                string hashvalueTblAmount = tocken;
                string enchashvalueTblAmount = cr.Encrypt(tocken);

                GenTocken2();
                string hashvalueTblPurchaseBy = tocken;
                string enchashvalueTblPurchaseBy = cr.Encrypt(tocken);

                GenTocken3();
                string hashvalueTblBitCoin = tocken;
                string enchashvalueTblBitCoin = cr.Encrypt(tocken);

                SqlCommand cmd3 = new SqlCommand("insert into purchaseProductWithHashKeyAmount values('" + Label9.Text + "','" + cr.Encrypt(Label10.Text) + "','" + hashvalueTblAmount + "','" + commonhashvalue + "','" + enchashvalueTblAmount + "','" + enccommonhashvalue + "')", con);
                cmd3.ExecuteNonQuery();

                SqlCommand cmd4 = new SqlCommand("insert into purchaseProductWithHashKeyBitCoin values('" + Label9.Text + "','" + cr.Encrypt(Label15.Text) + "','" + hashvalueTblBitCoin + "','" + commonhashvalue + "','" + enchashvalueTblBitCoin + "','" + enccommonhashvalue + "')", con);
                cmd4.ExecuteNonQuery();

                SqlCommand cmd5 = new SqlCommand("insert into purchaseProductWithHashKeyPurchaseBy values('" + Label9.Text + "','" + cr.Encrypt(Label7.Text) + "','" + hashvalueTblPurchaseBy + "','" + commonhashvalue + "','" + enchashvalueTblPurchaseBy + "','" + enccommonhashvalue + "')", con);
                cmd5.ExecuteNonQuery();

                con.Close();

                //con.Open();
                //SqlCommand cmd = new SqlCommand("insert into ordercust values('" + custoid + "','" + Label9.Text + "','" + Label7.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
                //cmd.ExecuteNonQuery();
                con.Close();

                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                Response.Redirect("shop3.aspx");
            }
        }
    }
}
