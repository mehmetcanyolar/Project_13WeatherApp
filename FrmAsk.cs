using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_13WeatherApp
{
    public partial class FrmAsk : Form
    {
        public FrmAsk()
        {
            InitializeComponent();
        }

        public void btnGo_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this);



            form1.ShowDialog();
        }
    }
}
