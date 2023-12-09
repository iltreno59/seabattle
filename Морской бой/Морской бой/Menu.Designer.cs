namespace Морской_бой
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.play_button = new System.Windows.Forms.Button();
            this.instruction_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.sea_battle_text = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // play_button
            // 
            this.play_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.play_button.Font = new System.Drawing.Font("High Tower Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.play_button.Location = new System.Drawing.Point(860, 60);
            this.play_button.Name = "play_button";
            this.play_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.play_button.Size = new System.Drawing.Size(200, 50);
            this.play_button.TabIndex = 0;
            this.play_button.Text = "Играть";
            this.play_button.UseVisualStyleBackColor = true;
            this.play_button.Click += new System.EventHandler(this.play_button_Click);
            // 
            // instruction_button
            // 
            this.instruction_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.instruction_button.Font = new System.Drawing.Font("High Tower Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instruction_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.instruction_button.Location = new System.Drawing.Point(860, 140);
            this.instruction_button.Name = "instruction_button";
            this.instruction_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.instruction_button.Size = new System.Drawing.Size(200, 50);
            this.instruction_button.TabIndex = 1;
            this.instruction_button.Text = "Инструкция";
            this.instruction_button.UseVisualStyleBackColor = true;
            this.instruction_button.Click += new System.EventHandler(this.instruction_button_Click);
            // 
            // close_button
            // 
            this.close_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_button.Font = new System.Drawing.Font("High Tower Text", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_button.ForeColor = System.Drawing.Color.Red;
            this.close_button.Location = new System.Drawing.Point(860, 220);
            this.close_button.Name = "close_button";
            this.close_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.close_button.Size = new System.Drawing.Size(200, 50);
            this.close_button.TabIndex = 2;
            this.close_button.Text = "Выйти из игры";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // sea_battle_text
            // 
            this.sea_battle_text.BackColor = System.Drawing.Color.Transparent;
            this.sea_battle_text.Dock = System.Windows.Forms.DockStyle.Top;
            this.sea_battle_text.Font = new System.Drawing.Font("High Tower Text", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sea_battle_text.ForeColor = System.Drawing.Color.Blue;
            this.sea_battle_text.Location = new System.Drawing.Point(0, 0);
            this.sea_battle_text.Name = "sea_battle_text";
            this.sea_battle_text.Size = new System.Drawing.Size(1232, 93);
            this.sea_battle_text.TabIndex = 3;
            this.sea_battle_text.Text = "МОРСКОЙ БОЙ";
            this.sea_battle_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.close_button);
            this.panel1.Controls.Add(this.instruction_button);
            this.panel1.Controls.Add(this.play_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 332);
            this.panel1.TabIndex = 4;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1232, 667);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sea_battle_text);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button play_button;
        private System.Windows.Forms.Button instruction_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label sea_battle_text;
        private System.Windows.Forms.Panel panel1;
    }
}

