using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurent_demo
{
    public partial class HomeForm : Form
    {
        
        String[] man_btn = new String[6] { "Home", "Items", "Ingrediant", "Equipment", "Sales Track", "Reservation Track" };
        String[,] items_data = new String[2, 3] { { "Name", "Catagory", "Price" },
                                                    {"BBQ Burger", "Burger", "180" }};
        String[,] ingrediants_data = new String[2, 3] { { "Name", "Quantity", "Cost" },
                                                    {"Burger Bun", "100", "1000" }};
        String[,] equipments_data = new String[2, 3] { { "Name", "Quantity", "Cost" },
                                                    {"Table", "10", "50000" }};

        public HomeForm()
        {
            InitializeComponent();

            

            //panel_items.Hide();
            //panel_ingrediant.Hide();


            panel_head.BackColor = Color.FromArgb(77, 77, 51);
            label_res.Text = "TEN 11";
            panel_home.BackColor = Color.FromArgb(200, 100, 50);
            label_res.Font = new Font("Arial", 40, FontStyle.Bold);
            ts_menu.AutoSize = false;
            ts_menu.Width = 150;
            ts_menu.Height = 200;
            
            for (int i = 0; i < 6; i++)
            {
                add_ts_btn(man_btn[i]);
                add_seperator();
            }

            //tlp_sales.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            //tlp_ingrediant.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            //btn_edit.Visible = false;



        }
        void add_ts_btn(String s)
        {
            ToolStripButton btn = new ToolStripButton();
            btn.AutoSize = false;
            btn.Width = 150;
            btn.Height = 50;
            btn.Text = s;
            btn.Tag = s;
            btn.Click += new EventHandler(btn_click);
            ts_menu.Items.Add(btn);

        }
        void add_seperator()
        {
            ToolStripSeparator sep = new ToolStripSeparator();
            sep.AutoSize = false;
            sep.Width = 140;
            sep.Height = 5;
            ts_menu.Items.Add(sep);
        }
        void btn_click(object sender, EventArgs e)
        {
            
            ToolStripButton tsb = sender as ToolStripButton;
            String s= tsb.Tag.ToString();
            for (int i = 0; i < 6; i++)
            {
                if(tsb != null && s == "Home")
                {
                    //panel_items.Hide();
                }
                else if (tsb != null && s == "Items")
                {
                    GenerateItemsTable(3, 2);
                    
                    //panel_items.Show();
                    //panel_ingrediant.Hide();
                    //panel_about.Hide();
                    //(new FormItems()).Show();
                    //this.Close();
                    //MessageBox.Show(String.Format("Hello im the {0} button", tsb.Tag.ToString()));
                    //tsb.Checked = true;
                    break;
                }
                else if (tsb != null && s == "Ingrediant")
                {
                    //label_ingrediant.Text = "Ingrediant";
                    //btn_search_ingrediants.Text = "Search Ingrediant";
                    //btn_add_ingrediants.Text = "Add Ingrediant";
                    GenerateIngrediantTable(3, 2);

                    
                    

                    //panel_items.Show();
                    //panel_ingrediant.Show();
                    //panel_sales.Hide();
                    // panel_about.Hide();

                    break;
                }
                else if (tsb != null && s == "Equipment")
                {
                   // label_ingrediant.Text = "Equipment";
                    //btn_search_ingrediants.Text = "Search Equipment";
                    //btn_add_ingrediants.Text = "Add Equipment";
                    GenerateIngrediantTable(3, 2);
                    
                    //panel_items.Show();
                    //panel_ingrediant.Show();
                    //panel_sales.Hide();
                    // panel_about.Hide();

                    break;
                }
                else if (tsb != null && s == "Sales Track")
                {
                    //label_sales.Text = "Sales";
                    //btn_search_ingrediants.Text = "Search Equipment";
                    //btn_add_ingrediants.Text = "Add Equipment";
                    //GenerateIngrediantTable(3, 2);

                    //panel_items.Show();
                    //panel_ingrediant.Show();
                    //panel_sales.Show();
                    // panel_about.Hide();

                    break;
                }
                else if (tsb != null && s == "Reservation Track")
                {
                    //label_sales.Text = "Reservation";
                    //btn_search_ingrediants.Text = "Search Equipment";
                    //btn_add_ingrediants.Text = "Add Equipment";
                    //GenerateIngrediantTable(3, 2);
                    
                    //panel_items.Show();
                    //panel_ingrediant.Show();
                    //panel_sales.Show();
                    // panel_about.Hide();

                    break;
                }
            }
          
        }

        private void GenerateItemsTable(int columnCount, int rowCount)
        {
            //rowCount *= 2;
            //Clear out the existing controls, we are generating a new table layout
            //tableLayoutPanel1.Controls.Clear();

            //Clear out the existing row and column styles
            //tableLayoutPanel1.ColumnStyles.Clear();
            //tableLayoutPanel1.RowStyles.Clear();

            //Now we will generate the table, setting up the row and column counts first
            //tableLayoutPanel1.ColumnCount = columnCount;
            //tableLayoutPanel1.RowCount = rowCount;

            for (int x = 0; x < columnCount; x++)
            {
                //First add a column
                //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                //tableLayoutPanel1.ColumnStyles[x].Width = tableLayoutPanel1.Width / columnCount;

                for (int y = 0; y < rowCount; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    
                    Label lbl = new Label();
                    if (y != 0 && x == 0)
                    {
                        lbl.Tag = items_data[y, x];
                        lbl.Click += new EventHandler(LabelView);
                        lbl.MouseEnter += new EventHandler(LabelHover);
                        lbl.MouseLeave += new EventHandler(LabelHoverLeave);

                    }
                    lbl.ForeColor = System.Drawing.Color.Black;
                    lbl.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                    Debug.Print("x=" + x + " y=" + y);
                    lbl.Text = items_data[y, x];         //Finally, add the control to the correct location in the table
                    //tableLayoutPanel1.Controls.Add(lbl, x, y);
                    //  }
                    //Create the control, in this case we will add a button



                }
            }
        }


        private void GenerateIngrediantTable(int columnCount, int rowCount)
        {
            //rowCount *= 2;
            //Clear out the existing controls, we are generating a new table layout
            //tlp_ingrediant.Controls.Clear();

            //Clear out the existing row and column styles
            //tlp_ingrediant.ColumnStyles.Clear();
            //tlp_ingrediant.RowStyles.Clear();

            //Now we will generate the table, setting up the row and column counts first
            //tlp_ingrediant.ColumnCount = columnCount;
            //tlp_ingrediant.RowCount = rowCount;

            for (int x = 0; x < columnCount; x++)
            {
                //First add a column
                //tlp_ingrediant.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
                //tlp_ingrediant.ColumnStyles[x].Width = tlp_ingrediant.Width / columnCount;

                for (int y = 0; y < rowCount; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        //tlp_ingrediant.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    /*   if (y % 2 == 1)
                       {
                           Label sep = new Label();
                           sep.AutoSize = false;
                           sep.Height = 2;
                           sep.BorderStyle = BorderStyle.Fixed3D;
                           //tableLayoutPanel1.Controls.Add(sep, x, y);
                       }
                       else
                       {
                   */
                    Label lbl = new Label();
                    if (y != 0 && x == 0)
                    {
                       // if(label_ingrediant.Text=="Ingrediant")lbl.Tag = ingrediants_data[y, x];
                       // else lbl.Tag = equipments_data[y, x];
                        lbl.Click += new EventHandler(LabelView);
                        lbl.MouseEnter += new EventHandler(LabelHover);
                        lbl.MouseLeave += new EventHandler(LabelHoverLeave);
                        

                    }
                    lbl.ForeColor = System.Drawing.Color.Black;
                    lbl.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                    Debug.Print("x=" + x + " y=" + y);
                    //if (label_ingrediant.Text == "Ingrediant") lbl.Text = ingrediants_data[y, x];
                    //else lbl.Text = equipments_data[y, x];
                    //Finally, add the control to the correct location in the table
                    //tlp_ingrediant.Controls.Add(lbl, x, y);
                    //  }
                    //Create the control, in this case we will add a button



                }
            }
        }

        void LabelView(object sender, EventArgs e)
        {
            Label tsb = sender as Label;
            String s = tsb.Tag.ToString();

            if (tsb != null && s != null)
            {
                MessageBox.Show(String.Format("Hello im the {0} button", tsb.Tag.ToString()));
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
            lbl.ForeColor = System.Drawing.Color.Black;
            lbl.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
        }






        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void panel_home_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            (new Form1()).Show();
            this.Close();
        }

        private void btn_add_items_Click(object sender, EventArgs e)
        {

        }

        private void txt_name_ingrediants_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel_ingrediant_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
