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

    public partial class FormStaff : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";
        String user_id;

        String[] cart_d = { "Cart Id", "Customer Id", "Customer Name", "Type", "Date", "Time", "Status", "Total Price", "View" };

        String[] stf_btn = new String[5] { "Home", "On Place Orders", "Online Orders", "Reservations","Profile" };
        String[] reserve_d = { "Cart Id", "Customer Name", "Date", "Start Time", "End Time", "Status", "View" };


        public FormStaff(String user)
        {
            InitializeComponent();

            side_panel.Height = btn_sales.Height;
            side_panel.Top = btn_sales.Top;
            user_id = user;

            DataTable dt = Get_data("select employee_name from employee where employee_id='" + user_id + "'");
            lbl_name.Text = dt.Rows[0][0].ToString();


            panel_sales.Location = new Point(162, 126);
            panel_reserve.Location = new Point(162, 126);


            txt_cus_id_order.Text = "";
            comb_status_order.Items.Add("All");
            comb_status_order.Items.Add("Pending");
            comb_status_order.Items.Add("Accepted");
            comb_status_order.Items.Add("Canceled");
            comb_status_order.Items.Add("Delivered");
            comb_status_order.SelectedItem = "All";

            comb_type_order.Items.Add("All");
            comb_type_order.Items.Add("Online");

            comb_type_order.Items.Add("OnPlace");
            comb_type_order.SelectedItem = "All";

            update_order();

            panel_reserve.Hide();


        }
        private DataTable Get_data(String query)
        {
            SqlConnection con = new SqlConnection(db);

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);
            return dt;

        }
        void add_ts_btn(String s)
        {
            

        }
        void add_seperator()
        {
            
        }
        void btn_click(object sender, EventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_logout_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            side_panel.Height = btn_sales.Height;
            side_panel.Top = btn_sales.Top;

            txt_cus_id_order.Text = "";
            comb_status_order.Items.Add("All");
            comb_status_order.Items.Add("Pending");
            comb_status_order.Items.Add("Accepted");
            comb_status_order.Items.Add("Canceled");
            comb_status_order.Items.Add("Delivered");
            comb_status_order.SelectedItem = "All";

            comb_type_order.Items.Add("All");
            comb_type_order.Items.Add("Online");

            comb_type_order.Items.Add("OnPlace");
            comb_type_order.SelectedItem = "All";

            update_order();
            panel_sales.Show();
            panel_reserve.Hide();
        }

        private void GenerateItemsTable(TableLayoutPanel table, String tag, int columnCount, int rowCount, DataTable dt, String[] head, int sel_col)
        {
            //rowCount *= 2;
            //Clear out the existing controls, we are generating a new table layout
            table.Controls.Clear();

            //Clear out the existing row and column styles
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            table.AutoScroll = true;
            //Now we will generate the table, setting up the row and column counts first
            table.ColumnCount = columnCount;
            table.RowCount = rowCount;
            Debug.WriteLine("col_cou=" + columnCount + " row cou=" + rowCount);



            for (int x = 0; x < columnCount; x++)
            {
                //First add a column
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                table.ColumnStyles[x].Width = Math.Min(table.Width / columnCount, 200);

                for (int y = 0; y < rowCount; y++)
                {
                    //Debug.WriteLine("x=" + x + " y=" + y + " value=" + dt.Rows[0][0].ToString());

                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }

                    Label lbl = new Label();
                    lbl.AutoSize = false;
                    lbl.Dock = DockStyle.None;
                    lbl.Height = 20;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;

                    lbl.ForeColor = System.Drawing.Color.Black;

                    lbl.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                    Debug.Print("x=" + x + " y=" + y);
                    //lbl.Text = dt.Rows[y][x].ToString();

                    if (tag == "customer" && x == sel_col) continue;
                    if (y == 0)
                    {

                        lbl.Text = head[x];

                    }

                    else if (y != 0 && x == sel_col)
                    {
                        lbl.ForeColor = System.Drawing.Color.Blue;
                        lbl.Tag = tag + " " + dt.Rows[y - 1][0].ToString();
                        lbl.Click += new EventHandler(LabelView);
                        lbl.MouseEnter += new EventHandler(LabelHover);
                        lbl.MouseLeave += new EventHandler(LabelHoverLeave);
                        lbl.Text = head[x];

                    }
                    
                    else
                    {

                        lbl.Text = dt.Rows[y - 1][x].ToString();
                    }

                    lbl.Height = 35;
                    //   items_data[y, x];         //Finally, add the control to the correct location in the table
                    table.Controls.Add(lbl, x, y);
                    //  }
                    //Create the control, in this case we will add a button

                }

                
                }

            }
        void LabelView(object sender, EventArgs e)
        {
            Label tsb = sender as Label;
            String tag = tsb.Tag.ToString();
            String txt = tsb.Text.ToString();

            String tag1 = "", id = "";
            bool found = false;
            for (int i = 0; i < tag.Length; i++)
            {
                if (tag[i] == ' ')
                {
                    found = true;
                    continue;
                }
                else if (!found)
                {
                    tag1 += tag[i];
                }
                else
                {
                    id += tag[i];
                }

            }
            Debug.WriteLine("tag1=" + tag1 + " id=" + id);
            if (tsb != null && tag != null)
            {
                if (tag1 == "Order")
                {
                    (new FormOrderStaff(id)).ShowDialog();
                    update_order();
                }
                else if (tag1 == "reservation")
                {
                    (new FormReserveStaff(id)).ShowDialog();
                    update_reserve();

                }
                
                else if (tag1 == "ingrediant")
                {
                    (new FormEdit("-1", "ingrediant", "add")).ShowDialog();
                    //(new FormItemManagerView()).ShowDialog();
                }
                //MessageBox.Show(String.Format("Hello im the {0} button", txt+" "+tag));
                //tsb.Checked = true;
            }
        }
        void LabelHover(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = System.Drawing.Color.Red;
            lbl.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
        }
        void LabelHoverLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = System.Drawing.Color.Blue;
            lbl.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
        }

        private void btn_search_order_Click(object sender, EventArgs e)
        {
            update_order();
        }
        private void update_order()
        {
            String cus_id = txt_cus_id_order.Text;
            String type = comb_type_order.SelectedItem.ToString();
            String status = comb_status_order.SelectedItem.ToString();
            String query;
            Debug.WriteLine("Type=" + type + " status=" + status + " cus=" + cus_id);
            if (type == "All" && status == "All")
            {
                if (cus_id != "")
                {
                    query = "Select cart_id,cu_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where customer.id='" + cus_id + "'";
                }
                else
                {

                    query = "Select cart_id,cu_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id";
                }

            }
            else if (type == "All")
            {
                if (cus_id != "")
                {
                    query = "Select cart_id,cu_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where status='" + status + "' and customer.id='" + cus_id + "'";

                }
                else
                {

                    query = "Select cart_id,cu_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where status='" + status + "'";
                }

            }
            else if (status == "All")
            {
                if (cus_id != "")
                {
                    query = "Select cart_id,cu_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where online_Onplase='" + type + "' and customer.id='" + cus_id + "'";
                }
                else
                {
                    query = "Select cart_id,cu_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where online_Onplase='" + type + "'";

                }
            }
            else
            {
                if (cus_id != "")
                {
                    query = "Select cart_id,cu_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where online_Onplase='" + type + "' and status='" + status + "' and customer.id='" + cus_id + "'";
                }
                else
                {
                    query = "Select cart_id,cu_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where online_Onplase='" + type + "' and status='" + status + "'";
                }
            }

            DataTable dt = Get_data(query);
            Debug.WriteLine("row=" + dt.Rows.Count + " col=" + dt.Columns.Count);
            GenerateItemsTable(tlp_order, "Order", 9, dt.Rows.Count + 1, dt, cart_d, 8);

        }

        private void btn_reserve_Click(object sender, EventArgs e)
        {
            side_panel.Height = btn_reserve.Height;
            side_panel.Top = btn_reserve.Top;
            

            comboBox_status_reserve.Items.Add("All");
            comboBox_status_reserve.Items.Add("Pending");
            comboBox_status_reserve.Items.Add("Accepted");
            comboBox_status_reserve.Items.Add("Canceled");
            comboBox_status_reserve.Items.Add("Delivered");
            comboBox_status_reserve.SelectedItem = "All";
            update_reserve();
            panel_reserve.Show();
            panel_sales.Hide();

        }
        private void update_reserve()
        {
            String status = comboBox_status_reserve.SelectedItem.ToString();
            String query;
            if (status != "All")
            {
                query =  "Select table_cart_id,customer.name,date,start_time,end_time,status from table_cart_make inner join customer on customer_id=customer.id where status='"+status+"'";
            }
            else
            {
                query = "Select table_cart_id,customer.name,date,start_time,end_time,status from table_cart_make inner join customer on customer_id=customer.id";

            }

            SqlConnection con = new SqlConnection(db);

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);


            
            GenerateItemsTable(tlp_reserve, "reservation", 7, dt.Rows.Count + 1, dt, reserve_d, 6);
        }

        private void btn_search_reserve_Click(object sender, EventArgs e)
        {
            update_reserve();
        }
    }
}
