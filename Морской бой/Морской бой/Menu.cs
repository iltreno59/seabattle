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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void play_button_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
        }
        private void instruction_button_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.Show();
        }
        private void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
