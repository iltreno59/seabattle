using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морской_бой
{
    public partial class Instruction : Form
    {
        public Instruction()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private void back_button_Click(object sender, EventArgs e)
        {
            Close();
            
        }
    }
}
