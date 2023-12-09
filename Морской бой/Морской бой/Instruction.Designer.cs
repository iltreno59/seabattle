namespace Морской_бой
{
    partial class Instruction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instruction));
            this.game_rules = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // game_rules
            // 
            this.game_rules.BackColor = System.Drawing.Color.Transparent;
            this.game_rules.Dock = System.Windows.Forms.DockStyle.Top;
            this.game_rules.Font = new System.Drawing.Font("High Tower Text", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_rules.ForeColor = System.Drawing.Color.Blue;
            this.game_rules.Location = new System.Drawing.Point(0, 0);
            this.game_rules.Name = "game_rules";
            this.game_rules.Size = new System.Drawing.Size(678, 410);
            this.game_rules.TabIndex = 0;
            this.game_rules.Text = resources.GetString("game_rules.Text");
            this.game_rules.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.back_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 244);
            this.panel1.TabIndex = 1;
            // 
            // back_button
            // 
            this.back_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back_button.Font = new System.Drawing.Font("High Tower Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_button.ForeColor = System.Drawing.Color.Red;
            this.back_button.Location = new System.Drawing.Point(860, 125);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(200, 50);
            this.back_button.TabIndex = 0;
            this.back_button.Text = "Назад";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // Instruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(678, 644);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.game_rules);
            this.Name = "Instruction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инструкция";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label game_rules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back_button;
    }
}