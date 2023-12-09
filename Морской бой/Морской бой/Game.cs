using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морской_бой
{
    public partial class Game : Form
    {
        public const int map_size = 11;
        public int cell_size = 30;
        public string abc = "АБВГДЕЖЗИК";
        public int[,] user_map = new int[map_size, map_size];
        public int[,] bot_map = new int[map_size, map_size];
        public bool game_start = false;
        public Button[,] user_cells = new Button[map_size, map_size];
        public Button[,] bot_cells = new Button[map_size, map_size];
        Bot bot;



        public Game()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Init();


        }
        Button start_button = new Button();
        public void Init()
        {
            
            int k1 = 0;
            int k2 = 1;
            for (int i = 0; i < map_size; i++) //карта ПОЛЬЗОВАТЕЛЯ
            {
                for (int j = 0; j < map_size; j++)
                {
                    user_map[i, j] = 0;
                    Button cell = new Button();
                    cell.Location = new Point(i * cell_size + 100, j * cell_size + 100);
                    cell.Size = new Size(cell_size, cell_size);
                    if (i == 0 || j == 0)
                    {
                        cell.BackColor = Color.Gray;
                        if (i != 0)
                        {
                            cell.Text = abc[k1++].ToString();
                        }
                        if (j != 0)
                        {
                            cell.Text = k2++.ToString();
                        }
                        cell.ForeColor = Color.Blue;
                    }
                    else
                    {
                        cell.Click += new EventHandler(initShips);
                    }
                    user_cells[i, j] = cell;
                    this.Controls.Add(cell);
                }
            }
            k1 = 0;
            k2 = 1;
            Label user_field = new Label();
            user_field.Location = new Point(map_size * cell_size / 2 + 100, map_size * cell_size + 150);
            user_field.Text = "Ваше поле";
            this.Controls.Add(user_field);
            int bot_map_edge_x = map_size * cell_size + 700;
            for(int i = 0; i < map_size; i++) //карта БОТА
            {
                for (int j = 0; j < map_size; j++)
                { 
                    bot_map[i, j] = 0;
                    Button cell = new Button();
                    cell.Location = new Point(i * cell_size + 600, j * cell_size + 100);
                    cell.Size = new Size(cell_size, cell_size);
                    if (i == 0 || j == 0)
                    {
                        cell.BackColor = Color.Gray;
                        if (i != 0)
                        {
                            cell.Text = abc[k1++].ToString();
                        }
                        if (j != 0)
                        {
                            cell.Text = k2.ToString();
                            k2++;
                        };
                        cell.ForeColor = Color.Blue;
                    }
                    else
                    {
                        cell.Click += new EventHandler(PlayerShoot);
                    }
                    bot_cells[i, j] = cell;
                    this.Controls.Add(cell);
                }
            }
            Label bot_field = new Label();
            bot_field.Location = new Point(map_size * cell_size / 2 + 600, map_size * cell_size + 150);
            bot_field.Text = "Поле соперника";
            this.Controls.Add(bot_field);

            bot = new Bot(bot_map, user_map, bot_cells, user_cells);
            bot_map = bot.initShips(); 

            
            start_button.Location = new Point(0, exit_button.Location.Y + 30);
            start_button.Text = "Начать";
            start_button.ForeColor = Color.Green;
            this.Controls.Add(start_button);
            start_button.Click += new EventHandler(gameStart);
        }
        public void initShips(object sender, EventArgs e)
        {
            Button pressed_button = sender as Button;
            if (!game_start)
            {
                if (user_map[(pressed_button.Location.X - 100) / cell_size, (pressed_button.Location.Y - 100) / cell_size] == 0)
                {
                    pressed_button.BackColor = Color.Blue;
                    user_map[(pressed_button.Location.X - 100) / cell_size, (pressed_button.Location.Y - 100) / cell_size] = 1;
                }
                else
                {
                    user_map[(pressed_button.Location.X - 100) / cell_size, (pressed_button.Location.Y - 100) / cell_size] = 0;
                    pressed_button.BackColor = Color.Transparent;
                }
            }
        }
        public void gameStart(object sender, EventArgs e)
        {
            if (!checkShips() && !game_start)
            {
                MessageBox.Show("Попробуйте ещё раз");
                clearAll();
            }
            else
            {
                game_start = true;
                start_button.Text = "Поехали";
                MessageBox.Show("Ваш ход");
            }
        }
        public bool checkShips()
        {
            int count = 0;
            for (int i = 1; i < map_size; i++)
            {
                for (int j = 1; j < map_size; j++)
                {
                    if (user_cells[i, j].BackColor == Color.Blue) count++;
                }
            }
            if (count != 20)
            {
                return false;
            }
            return true;
        }
        public void clearAll()
        {
            for (int i = 1; i < map_size; i++)
            {
                for (int j = 1; j < map_size; j++)
                {
                    user_map[i, j] = 0;
                    user_cells[i, j].BackColor = Color.Transparent;
                    user_cells[i, j].Text = "";
                    bot_map[i, j] = 0;
                    bot_cells[i, j].BackColor = Color.Transparent;
                    bot_cells[i, j].Text = "";
                    game_start = false;
                    start_button.Text = "Начать";
                }
            }
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool isEmpty(Button[,] cells)
        {
            bool check = true;
            int count = 0;
            for (int i = 1; i < map_size; i++)
            {
                for (int j = 1; j < map_size; j++)
                {
                    if (cells[i, j].Text == "X")
                    {
                        count++;
                    }
                }
            }
            if (count != 20) check = false;
            return check;
        }
        public void Shoot(Button pressed_button)
        {
            if (pressed_button.BackColor != Color.Gray && pressed_button.Text != "X")
            {
                if (bot_map[(pressed_button.Location.X - 600) / cell_size, (pressed_button.Location.Y - 100) / cell_size] != 0)
                {
                    pressed_button.Text = "X";
                    pressed_button.ForeColor = Color.Red;
                    
                    MessageBox.Show("Вы попали");
                    if (isEmpty(bot_cells))
                    {
                        MessageBox.Show("Победа!");
                        clearAll();
                        Close();
                    }
                    }
                else
                {
                    pressed_button.BackColor = Color.Gray;
                    MessageBox.Show("Вы промахнулись");
                    bot.Shoot(user_map);
                }
            }
        }
        public void PlayerShoot(object sender, EventArgs e)
        {
            Button pressed_button = sender as Button;
            if (isEmpty(user_cells))
            {
                MessageBox.Show("Поражение");
                clearAll();
                Close();
            }
            else if (game_start)
            {
                Shoot(pressed_button);
            }
        }
        
    }
}
