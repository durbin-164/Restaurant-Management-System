using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurent_demo
{
    public partial class FormSalesManagerView : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";

        public FormSalesManagerView(String cart_id)
        {
            InitializeComponent();
            Debug.WriteLine("cart_id="+cart_id);
            SqlConnection con = new SqlConnection(db);
            
            String query = "Select order_id as Id,item.name as Name,quentity as Quantity,order_details.Price from Order_details inner join item on item_id=item.id where cart_id='"+cart_id+"'";
            //String query = "Select * From Order_details";// where cart_id='" + cart_id + "'";

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();

            cmd.Fill(dt);
            dataGridView1.DataSource = dt;

            String query1 = "Select id,name,email,phone,address from customer inner join cart on cu_id=id where cart_id='"+cart_id+"'";
            SqlDataAdapter cmd1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            cmd1.Fill(dt1);
            lbl_cus_id.Text = dt1.Rows[0][0].ToString();
            lbl_cus_name.Text = dt1.Rows[0][1].ToString();
            lbl_cus_email.Text = dt1.Rows[0][2].ToString();
            lbl_cus_num.Text = dt1.Rows[0][3].ToString();
            lbl_cus_add.Text = dt1.Rows[0][4].ToString();

            String query2 = "Select cart_id,date,time,status,online_onplase,Tot_price from cart where cart_id='"+cart_id+"'";
            SqlDataAdapter cmd2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            cmd2.Fill(dt2);
            for(int i = 0; i < dt2.Columns.Count; i++)
            {
                Debug.WriteLine("i=" + i + " value=" + dt2.Rows[0][i].ToString());
            }
            lbl_cart_id.Text = dt2.Rows[0][0].ToString();
            lbl_cart_date.Text = dt2.Rows[0][1].ToString();
            lbl_cart_time.Text = dt2.Rows[0][2].ToString();
            lbl_cart_status.Text = dt2.Rows[0][3].ToString();
            lbl_cart_type.Text = dt2.Rows[0][4].ToString();
            lbl_cart_tp.Text = dt2.Rows[0][5].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
