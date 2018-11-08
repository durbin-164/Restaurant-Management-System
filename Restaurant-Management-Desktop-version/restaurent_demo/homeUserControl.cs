using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurent_demo
{
    public partial class homeUserControl : UserControl, INotifyPropertyChanged
    {
        Int64[] order_today=new Int64[2];
        Int64[] order_yes = new Int64[2];
        Int64[] rev_today = new Int64[2];
        Int64[] rev_yes = new Int64[2];
        Int64[] reser = new Int64[3];

        public event PropertyChangedEventHandler PropertyChanged;

        public homeUserControl()
        {
            InitializeComponent();

            label11.AutoSize = false;
            label11.Height = 2;
            label11.Width = 200;
            label11.BorderStyle = BorderStyle.Fixed3D;

            label10.AutoSize = false;
            label10.Height = 2;
            label10.Width = 200;
            label10.BorderStyle = BorderStyle.Fixed3D;

            label9.AutoSize = false;
            label9.Height = 2;
            label9.Width = 200;
            label9.BorderStyle = BorderStyle.Fixed3D;

            label_o_t_on.Text= order_today[0].ToString();
            label_o_t_pl.Text= order_today[1].ToString();
            label_o_y_on.Text= order_yes[0].ToString();
            label_o_y_pl.Text= order_yes[1].ToString();

            label_rev_t_on.Text = rev_today[0].ToString();
            label_rev_t_pl.Text = rev_today[1].ToString();
            label_rev_y_on.Text = rev_yes[0].ToString();
            label_rev_y_pl.Text = rev_yes[1].ToString();

            label_r_t.Text = reser[0].ToString();
            label_r_y.Text = reser[1].ToString();
            label_r_tm.Text = reser[2].ToString();


        }
        public void SetOrderToday(Int64 x, Int64 y)
        {
            order_today[0] = x;
            order_today[1] = y;
        }
        public void SetOrderYesterday(Int64 x, Int64 y)
        {
            order_yes[0] = x;
            order_yes[1] = y;
        }
        public void SetRevenueToday(Int64 x, Int64 y)
        {
            rev_today[0] = x;
            rev_today[1] = y;
        }
        public void SetRevenueYesterday(Int64 x, Int64 y)
        {
            rev_yes[0] = x;
            rev_yes[1] = y;
        }
        public void SetReservation(Int64 x, Int64 y, Int64 z)
        {
            reser[0] = x;
            reser[1] = y;
            reser[2] = z;
            OnPropertyChanged("label_r_t");
            OnPropertyChanged("label_r_y");
            OnPropertyChanged("label_r_tm");
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

   
}
