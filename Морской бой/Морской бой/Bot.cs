using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морской_бой
{
    public class Bot
    {
        public int[,] user_map = new int[Game.map_size, Game.map_size];
        public int[,] bot_map = new int[Game.map_size, Game.map_size];
        public Button[,] user_cells = new Button[Game.map_size, Game.map_size];
        public Button[,] bot_cells = new Button[Game.map_size, Game.map_size];
        int[,] allowed_ship = new int[Game.map_size, Game.map_size];
        public int cell_size = 30;

        public Bot(int[,] bot_map, int[,] user_map, Button[,] bot_cells, Button[,] user_cells)
        {
            this.bot_map = bot_map;
            this.user_map = user_map;
            this.bot_cells = bot_cells;
            this.user_cells = user_cells;
        }
        public bool checkShipsVertical(int posX, int posY, int ship_length) 
        {
            bool free = true;
            for(int i = posX; i < posX + ship_length; i++)
            {
                if (bot_map[i, posY] == 1 || allowed_ship[i, posY] == 0)
                { 
                    free = false;
                    break;
                }
            }
            return free; 
        }
        public bool checkShipsHorizontal(int posX, int posY, int ship_length)
        {
            bool free = true;
            for (int i = posY; i < posY + ship_length; i++)
            {
                if (bot_map[posX, i] == 1 || allowed_ship[posX, i] == 0)
                {
                    free = false;
                    break;
                }
            }
            return free;
        }
        public int[,] initShips()
        {
            int ship_length = 4;
            int type_count = 0;
            int ship_count = 0;
            int direction;
            int posX = 0;
            int posY = 0;
            
            for (int i = 0; i < allowed_ship.GetLength(0); i++)
            {
                for (int j = 0; j < allowed_ship.GetLength(1); j++)
                {
                    allowed_ship[i, j] = 1;
                }
            }
            Random rnd = new Random();
            while (ship_count < 10)
            {
                Button[] buttons = new Button[ship_length];
                direction = rnd.Next(1, 3);
                if (direction == 1) //ВЕРТИКАЛЬНО
                {
                    posY = rnd.Next(1, Game.map_size);
                    posX = rnd.Next(1, Game.map_size - ship_length);
                    while(!checkShipsVertical(posX, posY, ship_length)) 
                    {
                        posY = rnd.Next(1, Game.map_size);
                        posX = rnd.Next(1, Game.map_size - ship_length);
                    }
                    
                    for (int i = 0; i < ship_length; i++)
                    {
                        if (posX - 1 > 0)
                        {
                            allowed_ship[posX - 1, posY] = 0;
                        }
                        if (posY - 1 > 0)
                        {
                            allowed_ship[posX, posY - 1] = 0;
                        }
                        if (posY + 1 < Game.map_size)
                        {
                            allowed_ship[posX, posY + 1] = 0;
                        }
                        if (posX + 1 < Game.map_size)
                        {
                            allowed_ship[posX + 1, posY] = 0;
                        }
                        bot_map[posX, posY] = 1;
                        buttons.Append(bot_cells[posX, posY]);

                        posX++;
                    }
                    if (posX + 1 < Game.map_size)
                    {
                        allowed_ship[posX + 1, posY] = 0;
                    }

                }
                else //ГОРИЗОНТАЛЬНО
                {
                    posX = rnd.Next(1, Game.map_size);
                    posY = rnd.Next(1, Game.map_size - ship_length);
                    while(!checkShipsHorizontal(posX, posY, ship_length))
                    {
                        posX = rnd.Next(1, Game.map_size);
                        posY = rnd.Next(1, Game.map_size - ship_length);
                    }
                    
                    for (int i = 0; i < ship_length; i++)
                    {
                        if (posY - 1 > 0)
                        {
                            allowed_ship[posX, posY - 1] = 0;
                        }
                        if (posX - 1 > 0)
                        {
                            allowed_ship[posX - 1, posY] = 0;
                        }
                        if (posX + 1 < Game.map_size)
                        {
                            allowed_ship[posX + 1, posY] = 0;
                        }
                        if (posY + 1 < Game.map_size)
                        {
                            allowed_ship[posX, posY + 1] = 0;
                        }
                        bot_map[posX, posY] = 1;
                        buttons.Append(bot_cells[posX, posY]);

                        posY++;
                     }
                    if (posY + 1 < Game.map_size)
                    {
                        allowed_ship[posX, posY + 1] = 0;
                    }
                }
                type_count++;
                ship_count++;
                if (ship_length + type_count == 5)
                {
                    ship_length--;
                    type_count = 0;
                }
            }
            return bot_map;
        }
        int flagX = 0;
        /*
        0 - не найдено неуничтоженных кораблей
        1 - было попадание в корабль
        2 - идёт проверка клеток справа
        3 - справа более нет ячеек, корабль лежит горизонтально, идёт проверка клеток слева
        -1  справа не найдено ячеек: либо однопалубник, либо корабль лежит горизонтально
        */
        int flagY = 0;
        /*
        0 - идёт проверка нахождения корабля по горизонтали
        1 - корабль лежит вертикально
        2 - идёт проверка, есть ли клетки снизу
        3 - идёт проверка клеток сверху
        */ 
        int posX = 0;
        int posY = 0;
        int first_hit_X = 0;
        int first_hit_Y = 0;
        public void Shoot(int[,] map)
        {
            bool hit = false;
            Random rnd = new Random();
            if (flagX == 0) //Корабль ещё не найден, стрельба в случайную клетку
            {
                posX = rnd.Next(1, Game.map_size);
                posY = rnd.Next(1, Game.map_size);
                while (user_cells[posX, posY].BackColor == Color.Gray || user_cells[posX, posY].BackColor == Color.Black)
                {
                    posX = rnd.Next(1, Game.map_size);
                    posY = rnd.Next(1, Game.map_size);
                }
            }
            else //Корабль уже найден, сначала идёт проверка горизонтально
            {
                if (flagX == 1 && posX + 1 < Game.map_size && user_cells[posX + 1, posY].BackColor != Color.Gray && user_cells[posX + 1, posY].BackColor != Color.Black)
                {
                    posX++;
                }
                else if (flagX == 1) flagX = 2;
                if (flagX == 2 && first_hit_X - 1 > 0 && user_cells[first_hit_X - 1, posY].BackColor != Color.Gray && user_cells[first_hit_X - 1, posY].BackColor != Color.Black)
                {
                    posX = first_hit_X;
                    posX--;
                }
                else if (flagX == 2)
                {
                    flagX = 3;
                }
                if (flagX == 3 && posX - 1 > 0 && user_cells[posX - 1, posY].BackColor != Color.Gray && user_cells[posX - 1, posY].BackColor != Color.Black)
                {
                    posX--;
                }
                else if (flagX == 3 && first_hit_X + 1 < Game.map_size && user_cells[first_hit_X, posY].BackColor == Color.Black && user_cells[first_hit_X + 1, posY].BackColor == Color.Black)
                {
                    posX = rnd.Next(1, Game.map_size);
                    posY = rnd.Next(1, Game.map_size);
                    while (user_cells[posX, posY].BackColor == Color.Gray || user_cells[posX, posY].BackColor == Color.Black)
                    {
                        posX = rnd.Next(1, Game.map_size);
                        posY = rnd.Next(1, Game.map_size);
                    }
                    flagX = 0;
                    flagY = 0;
                }
                else if (flagX == 3)
                {
                    flagX = -1;
                }

                //Начинается проверка вертикально
                if (flagX == -1)
                {
                    posX = first_hit_X;
                    if (flagY == 0) flagY = 1;
                    if (flagY == 1 && posY + 1 < Game.map_size && user_cells[posX, posY + 1].BackColor != Color.Gray && user_cells[posX, posY + 1].BackColor != Color.Black)
                    {
                        posY++;
                    }
                    else if (flagY == 1) flagY = 2;

                    if (flagY == 2 && first_hit_Y - 1 > 0 && user_cells[posX, first_hit_Y - 1].BackColor != Color.Gray && user_cells[posX, first_hit_Y - 1].BackColor != Color.Black)
                    {
                        posY = first_hit_Y;
                        posY--;
                    }
                    else if (flagY == 2)
                    {
                        flagY = 3;
                    }
                    if (flagY == 3 && posY - 1 > 0 && user_cells[posX, posY - 1].BackColor != Color.Gray && user_cells[posX, posY - 1].BackColor != Color.Black)
                    {
                        posY--;
                    }
                    else if (flagY == 3)
                    {
                        posX = rnd.Next(1, Game.map_size);
                        posY = rnd.Next(1, Game.map_size);
                        while (user_cells[posX, posY].BackColor == Color.Gray || user_cells[posX, posY].BackColor == Color.Black)
                        {
                            posX = rnd.Next(1, Game.map_size);
                            posY = rnd.Next(1, Game.map_size);
                        }
                        flagX = 0;
                        flagY = 0;
                    }
                }

            }
            if (user_map[posX, posY] == 1)
            {
                hit = true;

                user_map[posX, posY] = 0;
                user_cells[posX, posY].BackColor = Color.Black;
                user_cells[posX, posY].Text = "X";
                user_cells[posX, posY].ForeColor = Color.Red;
            }
            else
            {
                
                if (flagX == 1) flagX = 2;
                else if (flagX == 2) flagX = -1;
                else if (flagX == 3)
                {
                    flagX = 0;
                    flagY = 0;
                    first_hit_X = 0;
                    first_hit_Y = 0;
                }

                if (flagY == 1) flagY = 2;
                else if (flagY == 3)
                {
                    flagX = 0;
                    flagY = 0;
                    first_hit_X = 0;
                    first_hit_Y = 0;
                }
                if (user_cells[posX, posY].BackColor != Color.Gray) user_cells[posX, posY].BackColor = Color.Gray;
                MessageBox.Show("Противник промахнулся");
            }
            if (hit)
            {
                MessageBox.Show("Противник попал");
                if (flagX == 0)
                {
                    first_hit_X = posX;
                    first_hit_Y = posY;
                    flagX = 1;
                }
                
                if (flagX == 2) flagX = 3;
                if (flagY == 2) flagY = 3;

                Shoot(user_map);
            }
        }

    }
}
