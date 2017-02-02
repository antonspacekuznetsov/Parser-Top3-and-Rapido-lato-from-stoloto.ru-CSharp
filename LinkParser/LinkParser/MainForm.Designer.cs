namespace LinkParser
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.главнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.топ3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рапидоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxRapido = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxRapido = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBoxRapido.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главнаяToolStripMenuItem,
            this.топ3ToolStripMenuItem,
            this.рапидоToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(560, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            this.главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            this.главнаяToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.главнаяToolStripMenuItem.Text = "Главная";
            this.главнаяToolStripMenuItem.Click += new System.EventHandler(this.главнаяToolStripMenuItem_Click);
            // 
            // топ3ToolStripMenuItem
            // 
            this.топ3ToolStripMenuItem.Name = "топ3ToolStripMenuItem";
            this.топ3ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.топ3ToolStripMenuItem.Text = "Топ 3";
            this.топ3ToolStripMenuItem.Click += new System.EventHandler(this.топ3ToolStripMenuItem_Click);
            // 
            // рапидоToolStripMenuItem
            // 
            this.рапидоToolStripMenuItem.Name = "рапидоToolStripMenuItem";
            this.рапидоToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.рапидоToolStripMenuItem.Text = "Рапидо";
            this.рапидоToolStripMenuItem.Click += new System.EventHandler(this.рапидоToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Запуск через:";
            // 
            // groupBoxRapido
            // 
            this.groupBoxRapido.Controls.Add(this.textBox4);
            this.groupBoxRapido.Controls.Add(this.label6);
            this.groupBoxRapido.Controls.Add(this.label4);
            this.groupBoxRapido.Controls.Add(this.textBox2);
            this.groupBoxRapido.Controls.Add(this.label3);
            this.groupBoxRapido.Controls.Add(this.label2);
            this.groupBoxRapido.Controls.Add(this.textBox1);
            this.groupBoxRapido.Controls.Add(this.checkBoxRapido);
            this.groupBoxRapido.Controls.Add(this.button1);
            this.groupBoxRapido.Controls.Add(this.label1);
            this.groupBoxRapido.Location = new System.Drawing.Point(0, 27);
            this.groupBoxRapido.Name = "groupBoxRapido";
            this.groupBoxRapido.Size = new System.Drawing.Size(342, 295);
            this.groupBoxRapido.TabIndex = 2;
            this.groupBoxRapido.TabStop = false;
            this.groupBoxRapido.Text = "Рапидо";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "тиражей";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(140, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Учитывать последние";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "секунд";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // checkBoxRapido
            // 
            this.checkBoxRapido.AutoSize = true;
            this.checkBoxRapido.Location = new System.Drawing.Point(15, 138);
            this.checkBoxRapido.Name = "checkBoxRapido";
            this.checkBoxRapido.Size = new System.Drawing.Size(75, 17);
            this.checkBoxRapido.TabIndex = 3;
            this.checkBoxRapido.Text = "Включить";
            this.checkBoxRapido.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.button2);
            this.groupBoxMain.Controls.Add(this.textBox3);
            this.groupBoxMain.Controls.Add(this.label5);
            this.groupBoxMain.Controls.Add(this.checkBox1);
            this.groupBoxMain.Location = new System.Drawing.Point(348, 29);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(342, 293);
            this.groupBoxMain.TabIndex = 3;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Главная";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(78, 57);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(207, 20);
            this.textBox3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "e-mail";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(201, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Отправлять уведомления на e-mail";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Последовательность";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(140, 103);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 329);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.groupBoxRapido);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxRapido.ResumeLayout(false);
            this.groupBoxRapido.PerformLayout();
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem топ3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рапидоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem главнаяToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxRapido;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxRapido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
    }
}