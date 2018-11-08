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
    public partial class FormItems : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";

        String[] cart_d = { "Cart Id", "Customer Name", "Type", "Date", "Time", "Status", "Total Price", "View", "Delete" };
        String[] customer_d = { "Id", "Name", "Sex", "Age", "Email", "Phone", "Address" };
         String[] table_d = { "Id", "Capacity","Edit","Delete"};
        String[] catagory_d = { "Id", "Name","Edit","Delete" };
        String[] item_d = { "Id", "Name", "Category", "Price","View","Delete" };
        String[] ingradients_d = { "Id", "Name", "Quantity", "View", "Delete" };
        String[] staff_d = { "Id", "Name", "Age", "Sex", "Email", "Phone", "Address", "View", "Delete" };
        String[] reserve_d = { "Cart Id", "Customer Name", "Date", "Start Time", "End Time", "Status", "View", "Delete" };
        String[,] items_data = new String[2, 3] { { "Name", "Catagory", "Price" },
                                                    {"BBQ Burger", "Burger", "180" }};
        String user_id;

        public FormItems( String User)
        {
            InitializeComponent();
            user_id = User;

            side_panel.Height = btn_home.Height;
            side_panel.Top = btn_home.Top;

            panel_sales.Hide();
            panel_rev.Hide();
            panel_ingrediant.Hide();
            panel_items.Hide();
            panel_table.Hide();
            panel_customer.Hide();
            panel_staff.Hide();
            panel_catagory.Hide();


            label9.AutoSize = false;
            label9.Height = 2;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.Width = 305;

            label10.AutoSize = false;
            label10.Height = 2;
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Width = 305;

            label11.AutoSize = false;
            label11.Height = 2;
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.Width = 305;
            DataTable dt = Get_data("select employee_name from employee where employee_id='" + user_id + "'");
            lbl_name.Text = dt.Rows[0][0].ToString();

            overview();

            panel_rev.Location = new Point(162, 126);
            panel_ingrediant.Location = new Point(162, 126);
            panel_items.Location = new Point(162, 126);
            panel_table.Location = new Point(162, 126);
            panel_customer.Location = new Point(162, 126);
            panel_staff.Location = new Point(162, 126);
            panel_catagory.Location = new Point(162, 126);

            btn_search_rev.Click += new EventHandler(btn_search_rev_Click);
        }
        private DataTable Get_data(String query)
        {
            SqlConnection con = new SqlConnection(db);

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);
            return dt;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            side_panel.Height = btn_home.Height;
            side_panel.Top = btn_home.Top;
            panel_sales.Hide();
            panel_rev.Hide();
            panel_ingrediant.Hide();
            panel_items.Hide();
            panel_table.Hide();
            panel_customer.Hide();
            panel_staff.Hide();
            panel_catagory.Hide();
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);

            String query = "Select cart_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);

            Debug.WriteLine("row=" + dt.Rows.Count + " col=" + dt.Columns.Count);

            
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            comb_type.Items.Add("All");
            comb_type.Items.Add("Online");
            comb_type.Items.Add("Onplace");

            //Debug.WriteLine(comb_type.SelectedItem.ToString());
            comb_type.SelectedItem = "All";
            //Debug.WriteLine(comb_type.SelectedItem.ToString());


            side_panel.Height = btn_sales.Height;
            side_panel.Top = btn_sales.Top;
            GenerateItemsTable(tlp_sales, "sales", 9, dt.Rows.Count + 1, dt, cart_d, 7, 8);
            panel_sales.Show();
            panel_rev.Hide();
            panel_ingrediant.Hide();
            panel_items.Hide();
            panel_table.Hide();
            panel_customer.Hide();
            panel_staff.Hide();
            panel_catagory.Hide();


        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btn_reserve_Click(object sender, EventArgs e)
        {
            dateTimePicker_rev_from.Value = DateTime.Now;
            dateTimePicker_rev_to.Value = DateTime.Now;

            SqlConnection con = new SqlConnection(db);

            String query = "Select table_cart_id,customer.name,date,start_time,end_time,status from table_cart_make inner join customer on customer_id=customer.id";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);


            side_panel.Height = btn_reserve.Height;
            side_panel.Top = btn_reserve.Top;
            GenerateItemsTable(tlp_rev, "reservation", 8, dt.Rows.Count+1,dt,reserve_d,6,7);
            panel_rev.Show();
            panel_sales.Hide();
            panel_ingrediant.Hide();
            panel_items.Hide();
            panel_table.Hide();
            panel_customer.Hide();
            panel_staff.Hide();
            panel_catagory.Hide();
        }

        private void btn_ingredient_Click(object sender, EventArgs e)
        {
            update_ingrediant();
            side_panel.Height = btn_ingredient.Height;
            side_panel.Top = btn_ingredient.Top;
            //GenerateItemsTable(tlp_ingrediant, "ingrediant", 5, dt.Rows.Count+1,dt,ingradients_d,3,4);
            panel_ingrediant.Show();
            panel_sales.Hide();
            panel_rev.Hide();
            panel_items.Hide();
            panel_table.Hide();
            panel_customer.Hide();
            panel_staff.Hide();
            panel_catagory.Hide();
        }

        private void btn_items_Click(object sender, EventArgs e)
        {
            comb_catagory_items.Items.Add("All");

            comb_catagory_items.SelectedItem = "All";
            SqlConnection con1 = new SqlConnection(db);
            String query1 = "Select name from category";
            SqlDataAdapter cmd1 = new SqlDataAdapter(query1, con1);


            DataTable dt1 = new DataTable();

            cmd1.Fill(dt1);
            for(int i = 0; i < dt1.Rows.Count; i++)
            {
                comb_catagory_items.Items.Add(dt1.Rows[i][0].ToString());
            }


            SqlConnection con = new SqlConnection(db);

            String query = "Select it.id,it.name,category.name,it.price from item as it inner join category on catid=category.id";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);


            side_panel.Height = btn_items.Height;
            side_panel.Top = btn_items.Top;
            GenerateItemsTable(tlp_item, "item", 6, dt.Rows.Count+1,dt,item_d,4,5);
            panel_items.Show();
            panel_sales.Hide();
            panel_rev.Hide();
            panel_ingrediant.Hide();
            panel_table.Hide();
            panel_customer.Hide();
            panel_staff.Hide();
            panel_catagory.Hide();
        }

        private void btn_table_Click(object sender, EventArgs e)
        {

        }

        private void btn_customer_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(db);

            String query = "Select id,name,sex,age,email,phone,address from customer";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);

            side_panel.Height = btn_customer.Height;
            side_panel.Top = btn_customer.Top;
            GenerateItemsTable(tlp_customer, "customer", 9, dt.Rows.Count+1,dt,customer_d,7,8);
            panel_customer.Show();
            panel_sales.Hide();
            panel_rev.Hide();
            panel_ingrediant.Hide();
            panel_items.Hide();
            panel_table.Hide();
            panel_staff.Hide();
            panel_catagory.Hide();
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            txt_staff_name.Text = "";
            update_staff();
            
            side_panel.Height = btn_staff.Height;
            side_panel.Top = btn_staff.Top;
            panel_staff.Show();
            panel_sales.Hide();
            panel_rev.Hide();
            panel_ingrediant.Hide();
            panel_items.Hide();
            panel_table.Hide();
            panel_customer.Hide();
            panel_catagory.Hide();
        }

        private void btn_table_Click_1(object sender, EventArgs e)
        {
            txt_table_number.Text = "";
            txt_table_capacity.Text = "";
            update_table();

            side_panel.Height = btn_table.Height;
            side_panel.Top = btn_table.Top;

            panel_table.Show();
            panel_sales.Hide();
            panel_rev.Hide();
            panel_ingrediant.Hide();
            panel_items.Hide();
            panel_customer.Hide();
            panel_staff.Hide();
            panel_catagory.Hide();
        }
        private void btn_catagory_Click(object sender, EventArgs e)
        {
            update_catagory();
            side_panel.Height = btn_catagory.Height;
            side_panel.Top = btn_catagory.Top;

            panel_catagory.Show();
            panel_sales.Hide();
            panel_rev.Hide();
            panel_ingrediant.Hide();
            panel_items.Hide();
            panel_table.Hide();
            panel_customer.Hide();
            panel_staff.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //(new Form1()).Show();
            //this.Close();
        }

        private void GenerateItemsTable(TableLayoutPanel table, String tag, int columnCount, int rowCount, DataTable dt, String[] head, int sel_col,int sel_del)
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
                table.ColumnStyles[x].Width = Math.Min(table.Width / columnCount,200);

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
                    //Debug.Print("x=" + x + " y=" + y);
                    //lbl.Text = dt.Rows[y][x].ToString();

                    if (tag == "customer" && (x == sel_col || x == sel_del)) continue;
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
                    else if(y!=0 && x == sel_del)
                    {
                        lbl.ForeColor = System.Drawing.Color.Blue;
                        lbl.Tag = tag + " " + dt.Rows[y - 1][0].ToString();
                        lbl.Click += new EventHandler(LabelViewDel);
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
                if (tag1 == "sales")
                {
                    (new FormSalesManagerView(id)).ShowDialog();
                }
                else if (tag1 == "reservation")
                {
                    (new FormReservationManagerView(id)).ShowDialog();

                }
                else if (tag1 == "item")
                {
                    (new FormItemManagerView(id,"view")).ShowDialog();

                    update_item();
                }
                else if (tag1 == "category")
                {
                    (new FormEdit(id,tag1,"view")).ShowDialog();

                    update_catagory();
                }
                else if (tag1 == "table")
                {
                    (new FormEdit(id, tag1,"view")).ShowDialog();

                    update_table();

                }
                else if (tag1 == "staff")
                {
                    (new FormStaffDetails(id, "view")).ShowDialog();

                    update_staff();
                }
                else if(tag1== "ingrediant")
                {
                    (new FormEdit("-1", "ingrediant", "add")).ShowDialog();
                    //(new FormItemManagerView()).ShowDialog();
                }
                //MessageBox.Show(String.Format("Hello im the {0} button", txt+" "+tag));
                //tsb.Checked = true;
            }


        }
        void LabelViewDel(object sender, EventArgs e)
        {
            Label tsb = sender as Label;
            String tag = tsb.Tag.ToString();
            String txt = tsb.Text.ToString();
            String query;

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
                if (tag1 == "sales")
                {
                    if (MessageBox.Show("Do you want to delete order cart with id=" + id, "Delete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "Delete from order_details where cart_id='" + id + "'";
                        SqlConnection con = new SqlConnection(db);
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        query = "Delete from cart where cart_id='" + id + "'";
                        SqlCommand cmd1 = new SqlCommand(query, con);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();

                        update_sales();

                    }
                }
                else if (tag1 == "reservation")
                {
                    if (MessageBox.Show("Do you want to delete reservation cart with id=" + id, "Delete Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "Delete from table_reservation where table_cart_id='" + id + "'";
                        SqlConnection con = new SqlConnection(db);
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        query = "Delete from table_cart_make where table_cart_id='" + id + "'";
                        SqlCommand cmd1 = new SqlCommand(query, con);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();

                        update_rev();

                    }
                }
                else if (tag1 == "item")
                {
                    if (MessageBox.Show("Do you want to delete item with id=" + id, "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "Delete from item where id='" + id + "'";
                        SqlConnection con = new SqlConnection(db);
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        update_item();

                    }

                }
                else if (tag1 == "category")
                {
                    if (MessageBox.Show("Do you want to delete catagory with id=" + id + "? All items will also be deleted under this catagory.", "Delete Catagory", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "Delete from item where catid='" + id + "'";
                        SqlConnection con = new SqlConnection(db);
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                        query = "Delete from category where id='" + id + "'";
                        SqlCommand cmd1 = new SqlCommand(query, con);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();

                        update_catagory();

                    }
                }
                else if (tag1 == "table")
                {
                    if (MessageBox.Show("Do you want to delete table with id=" + id + "? All reservation for this table will also be deleted.", "Delete Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "Delete from table_details where table_id='" + id + "'";
                        SqlConnection con = new SqlConnection(db);
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        update_table();

                    }
                }
                else if (tag1 == "staff")
                {
                    if (MessageBox.Show("Do you want to delete staff with id=" + id + "?(Note: All action done by this staff will be null).", "Delete Staff", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        query = "Delete from employee where employee_id='" + id + "'";
                        SqlConnection con = new SqlConnection(db);
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        
                        update_staff();

                    }

                }
                else
                {
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

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_rev_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_sales_Click_1(object sender, EventArgs e)
        {
            update_sales();
        }
        private void update_sales()
        {
            String from_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            String to_date = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            String type = comb_type.SelectedItem.ToString();
            Debug.WriteLine("from=" + from_date + " to=" + to_date + " type=" + type);

            SqlConnection con = new SqlConnection(db);
            String query;

            if (type == "All")
            {
                query = "Select cart_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where date between '" + from_date + "' and '" + to_date + "'";
            }
            else
            {
                query = "Select cart_id,customer.name,online_Onplase,Date,time,status,tot_price from Cart inner join Customer on customer.id=cu_id where online_Onplase='" + type + "' and date between '" + from_date + "' and '" + to_date + "'";
            }

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);


            GenerateItemsTable(tlp_sales, "sales", 9, dt.Rows.Count + 1, dt, cart_d, 7, 8);

        }
        private void update_rev()
        {

            String from_date = dateTimePicker_rev_from.Value.ToString("dd/MM/yyyy");
            String to_date = dateTimePicker_rev_to.Value.ToString("dd/MM/yyyy");

            Debug.WriteLine("from=" + from_date + " to=" + to_date);

            SqlConnection con = new SqlConnection(db);

            String query = "Select table_cart_id,customer.name,date,start_time,end_time,status from table_cart_make inner join customer on customer_id=customer.id where date between '" + from_date + "' and '" + to_date + "'";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);


            side_panel.Height = btn_reserve.Height;
            side_panel.Top = btn_reserve.Top;
            GenerateItemsTable(tlp_rev, "reservation", 8, dt.Rows.Count + 1, dt, reserve_d, 6, 7);
        }

        private void update_table()
        {
            String table_num = txt_table_number.Text;
            String table_cap = txt_table_capacity.Text;
            String query;
            if (table_cap != "" && table_num != "")
            {
                query = "Select table_id,capacity from table_details where table_id='" + table_num + "' and capacity='" + table_cap + "'";
            }
            else if (table_num != "")
            {
                query = "Select table_id,capacity from table_details where table_id='" + table_num + "'";
            }
            else if (table_cap != "")
            {
                query = "Select table_id,capacity from table_details where capacity='" + table_cap + "'";
            }
            else
            {
                query = "Select table_id,capacity from table_details";
            }
            Debug.WriteLine("query=" + query);
            SqlConnection con = new SqlConnection(db);

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);

            GenerateItemsTable(tlp_table, "table", 4, dt.Rows.Count + 1, dt, table_d, 2, 3);

        }

        private void btn_search_rev_Click(object sender, EventArgs e)
        {
            update_rev();
        }

        private void btn_add_items_Click(object sender, EventArgs e)
        {
            (new FormItemManagerView("-1", "add")).ShowDialog();
            String select_category = comb_catagory_items.SelectedItem.ToString();
            String query;
            if (select_category == "All")
            {
                query = "Select it.id,it.name,category.name,it.price from item as it inner join category on catid=category.id";
            }
            else
            {

                query = "Select it.id,it.name,category.name,it.price from item as it inner join category on catid=category.id where category.name='" + select_category + "'";

            }

            SqlConnection con = new SqlConnection(db);

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);
            GenerateItemsTable(tlp_item, "item", 6, dt.Rows.Count + 1, dt, item_d, 4,5);
        }

        private void btn_search_items_Click(object sender, EventArgs e)
        {
            update_item();
        }
        private void update_item()
        {

            String select_category = comb_catagory_items.SelectedItem.ToString();
            String query;
            if (select_category == "All")
            {
                query = "Select it.id,it.name,category.name,it.price from item as it inner join category on catid=category.id";
            }
            else
            {

                query = "Select it.id,it.name,category.name,it.price from item as it inner join category on catid=category.id where category.name='" + select_category + "'";

            }

            SqlConnection con = new SqlConnection(db);

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);
            GenerateItemsTable(tlp_item, "item", 6, dt.Rows.Count + 1, dt, item_d, 4, 5);
        }

        private void update_staff()
        {

            String u = "Staff";
            SqlConnection con = new SqlConnection(db);

            String query = "Select employee_id,employee_name,age,sex,email,phone,adress from employee inner join employee_type on employee.type_id=employee_type.type_id where type_name='" + u + "'";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);

            GenerateItemsTable(tlp_staff, "staff", 9, dt.Rows.Count + 1, dt, staff_d, 7, 8);

        }

        private void update_catagory()
        {

            SqlConnection con = new SqlConnection(db);

            String query = "Select id,name from Category";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);

            //Debug.WriteLine("row=" + dt.Rows.Count + " col=" + dt.Columns.Count);

            GenerateItemsTable(tlp_catagory, "category", 4, dt.Rows.Count + 1, dt, catagory_d, 2, 3);
        }

        private void update_ingrediant()
        {
            String quantity=txt_quantity_ingrediants.Text;
            String name = txt_name_ingrediants.Text;
            String query;
            SqlConnection con = new SqlConnection(db);

            if(quantity!="") query = "Select ing_id,name,quentity from ingradients where quentity='"+quantity+"'";
            else  query = "Select ing_id,name,quentity from ingradients";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);

            side_panel.Height = btn_ingredient.Height;
            side_panel.Top = btn_ingredient.Top;
            GenerateItemsTable(tlp_ingrediant, "ingrediant", 5, dt.Rows.Count + 1, dt, ingradients_d, 3, 4);
        }

        private void btn_search_customer_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_catagory_Click(object sender, EventArgs e)
        {

            (new FormEdit("-1", "category", "add")).ShowDialog();

            SqlConnection con = new SqlConnection(db);

            String query = "Select id,name from Category";
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);

            //Debug.WriteLine("row=" + dt.Rows.Count + " col=" + dt.Columns.Count);

            GenerateItemsTable(tlp_catagory, "category", 4, dt.Rows.Count + 1, dt, catagory_d, 2, 3);

        }

        private void btn_search_staff_Click(object sender, EventArgs e)
        {

        }

        private void btn_staff_add_Click(object sender, EventArgs e)
        {
            (new FormStaffDetails("-1", "add")).ShowDialog();
            update_staff();
        }

        private void btn_table_search_Click(object sender, EventArgs e)
        {

            update_table();
        }

        private void btn_add_table_Click(object sender, EventArgs e)
        {
            (new FormEdit("-1", "table", "add")).ShowDialog();

            update_table();
        }

        private void btn_add_ingrediants_Click(object sender, EventArgs e)
        {
            (new FormEdit("-1", "ingrediants", "add")).ShowDialog();
            update_ingrediant();

        }

        private void btn_search_ingrediants_Click(object sender, EventArgs e)
        {
            update_ingrediant();

        }

        private void btn_ingrediant_history_Click(object sender, EventArgs e)
        {

        }
        private void overview()
        {

            String today = DateTime.Now.ToString("yyyy-MM-dd");

            String yesterday = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            String tomorrow = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");


            DataTable dt = Get_data("select count(cart_id) from cart where online_onplase='Online' and Status='Accepted' and date between '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'");
            int x = 0;
            x += Convert.ToInt32(dt.Rows[0][0].ToString());
            label_o_t_on.Text = x.ToString();
            dt = Get_data("select count(cart_id) from cart where online_onplase='OnPlace' and Status='Accepted' and date between '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'");
            x = 0;
            x += Convert.ToInt32(dt.Rows[0][0].ToString());

            label_o_t_pl.Text = x.ToString();

            dt = Get_data("select count(cart_id) from cart where status='Accepted' and date between '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'");
            x = 0;
            x += Convert.ToInt32(dt.Rows[0][0].ToString());

            label_o_t_tot.Text = x.ToString();


            dt = Get_data("select count(cart_id) from cart where online_onplase='Online' and Status='Accepted' and date between '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            x = 0;
            x += Convert.ToInt32(dt.Rows[0][0].ToString());

            label_o_y_on.Text = x.ToString();

            dt = Get_data("select count(cart_id) from cart where online_onplase='OnPlace' and Status='Accepted' and date between '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            x = 0;
            x += Convert.ToInt32(dt.Rows[0][0].ToString());

            label_o_y_pl.Text = x.ToString();

            dt = Get_data("select count(cart_id) from cart where  Status='Accepted' and date between '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            x = 0;
            x += Convert.ToInt32(dt.Rows[0][0].ToString());

            label_o_y_tot.Text = x.ToString();

            int y = 0;
            dt = Get_data("select count(Table_cart_id) from table_cart_make where Status='Accepted' and date='" + DateTime.Now.ToString("dd/mm/yyyy") + "'");
            y += Convert.ToInt32(dt.Rows[0][0].ToString());
            label_r_t.Text = y.ToString();
            y = 0;
            dt = Get_data("select count(Table_cart_id) from table_cart_make where Status='Accepted' and date between '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            y += Convert.ToInt32(dt.Rows[0][0].ToString());
            label_r_y.Text = y.ToString();
            y = 0;
            dt = Get_data("select count(Table_cart_id) from table_cart_make where Status='Accepted' and date between '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") + "'");
            y += Convert.ToInt32(dt.Rows[0][0].ToString());
            label_r_tm.Text = y.ToString();


            dt = Get_data("select sum(tot_price) from cart where online_onplase='Online' and Status='Accepted' and date between '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'");
            Double z = 0.0;
            //z += Convert.ToDouble(dt.Rows[0][0].ToString());

            label_rev_t_on.Text = dt.Rows[0][0].ToString();
            dt = Get_data("select sum(tot_price) from cart where online_onplase='OnPlace' and Status='Accepted' and date between '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'");
            z = 0.0;
            //z += Convert.ToDouble(dt.Rows[0][0].ToString());
            label_rev_t_pl.Text = dt.Rows[0][0].ToString();

            dt = Get_data("select sum(tot_price) from cart where Status='Accepted' and date between '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "'");
            z = 0.0;
            //z += Convert.ToDouble(dt.Rows[0][0].ToString());
            label_rev_t_tot.Text = dt.Rows[0][0].ToString();

            dt = Get_data("select sum(tot_price) from cart where online_onplase='Online' and Status='Accepted' and date between '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            z = 0.0;
            //z += Convert.ToDouble(dt.Rows[0][0].ToString());
            label_rev_y_on.Text = dt.Rows[0][0].ToString();
            dt = Get_data("select sum(tot_price) from cart where online_onplase='OnPlace' and Status='Accepted' and date between '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            z = 0.0;
            //z += Convert.ToDouble(dt.Rows[0][0].ToString());
            label_rev_y_pl.Text = dt.Rows[0][0].ToString();
            dt = Get_data("select sum(tot_price) from cart where  Status='Accepted' and date between '" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            z = 0.0;
            //z += Convert.ToDouble(dt.Rows[0][0].ToString());
            label_rev_y_tot.Text = dt.Rows[0][0].ToString();

        }
    }
}
