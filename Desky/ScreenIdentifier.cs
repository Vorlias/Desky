using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desky
{
    public partial class ScreenIdentifier : Form
    {
        public ScreenIdentifier(uint number)
        {
            InitializeComponent();
            monitorId.Text = number.ToString();
        }

        private void Ticked(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Hide();
            this.Close();
        }
    }
}
