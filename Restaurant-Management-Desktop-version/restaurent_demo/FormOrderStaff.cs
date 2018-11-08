using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurent_demo
{
    public partial class FormOrderStaff : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";
        String cart;
        public FormOrderStaff(String cart_id)
        {
            InitializeComponent();
            cart = cart_id;
            SqlConnection con = new SqlConnection(db);

            String query = "Select order_id as Id,item.name as Name,quentity as Quantity,order_details.Price from Order_details inner join item on item_id=item.id where cart_id='" + cart_id + "'";
            //String query = "Select * From Order_details";// where cart_id='" + cart_id + "'";

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();

            cmd.Fill(dt);
            dataGridView1.DataSource = dt;

            String query1 = "Select id,name,email,phone,address from customer inner join cart on cu_id=id where cart_id='" + cart_id + "'";
            SqlDataAdapter cmd1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            cmd1.Fill(dt1);
            lbl_cus_id.Text = dt1.Rows[0][0].ToString();
            lbl_cus_name.Text = dt1.Rows[0][1].ToString();
            lbl_cus_email.Text = dt1.Rows[0][2].ToString();
            lbl_cus_num.Text = dt1.Rows[0][3].ToString();
            lbl_cus_add.Text = dt1.Rows[0][4].ToString();

            String query2 = "Select cart_id,date,time,status,online_onplase,Tot_price from cart where cart_id='" + cart_id + "'";
            SqlDataAdapter cmd2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            cmd2.Fill(dt2);
           
            lbl_cart_id.Text = dt2.Rows[0][0].ToString();
            lbl_cart_date.Text = dt2.Rows[0][1].ToString();
            lbl_cart_time.Text = dt2.Rows[0][2].ToString();
            lbl_cart_type.Text = dt2.Rows[0][4].ToString();
            lbl_cart_tp.Text = dt2.Rows[0][5].ToString();


            comboBox.Items.Add("Pending");
            comboBox.Items.Add("Accepted");
            comboBox.Items.Add("Canceled");
            comboBox.Items.Add("Delivered");
            comboBox.SelectedItem = dt2.Rows[0][3].ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);
            try
            {
                String query = "update cart set status='" + comboBox.SelectedItem.ToString() + "' where cart_id='" + cart + "'";
                

                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successful");
            }
            catch(Exception)
            {
                MessageBox.Show("Can not update the status");
            }

            

            String query2 = "Select cart_id,date,time,status,online_onplase,Tot_price from cart where cart_id='" + cart + "'";
            SqlDataAdapter cmd2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            cmd2.Fill(dt2);

            lbl_cart_id.Text = dt2.Rows[0][0].ToString();
            lbl_cart_date.Text = dt2.Rows[0][1].ToString();
            lbl_cart_time.Text = dt2.Rows[0][2].ToString();
            lbl_cart_type.Text = dt2.Rows[0][4].ToString();
            lbl_cart_tp.Text = dt2.Rows[0][5].ToString();

            
            comboBox.SelectedItem = dt2.Rows[0][3].ToString();
        }
    }
}
