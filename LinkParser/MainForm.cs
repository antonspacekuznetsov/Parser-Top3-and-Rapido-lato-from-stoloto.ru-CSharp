using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Reflection;
namespace LinkParser
{
    public partial class MainForm : Form
    {
        MyThread _rapido;
        MyThread _top3;

        public MainForm()
        {
            this.setSettings();

            InitializeComponent();
            groupBoxMain.Visible = true;
            groupBoxMain.Enabled = true;
            groupBoxMain.Location = new Point(0, 27);
            groupBoxRapido.Visible = false;
            groupBoxRapido.Enabled = false;

            textBox3.Enabled = false;
            _rapido = new MyThread();
            _top3 = new MyThread();

        }

        private void setSettings()
        {
            Settings.soundLoop = 1;

            Settings.rThread = false;
            Settings.top3Thread = false;

            Settings.top3Time = this.conv(ConfigurationManager.AppSettings["top3Time"]);
            Settings.top3Count = this.conv(ConfigurationManager.AppSettings["top3Count"]);
            Settings.top3On = this.conv(ConfigurationManager.AppSettings["top3On"]);
            Settings.top3Seq = this.conv(ConfigurationManager.AppSettings["top3Seq"]);
            Settings.top3NSeq = this.conv(ConfigurationManager.AppSettings["top3NSeq"]);

            Settings.rTime = this.conv(ConfigurationManager.AppSettings["rTime"]);
            Settings.rCount = this.conv(ConfigurationManager.AppSettings["rCount"]);
            Settings.rOn = this.conv(ConfigurationManager.AppSettings["rOn"]);
            Settings.rSeq = this.conv(ConfigurationManager.AppSettings["rSeq"]);
            Settings.rNSeq = this.conv(ConfigurationManager.AppSettings["rNSeq"]);
            Settings.rSrav18 = this.conv(ConfigurationManager.AppSettings["rSrav18"]);
            Settings.rChislo = ConfigurationManager.AppSettings["rChislo"];
        }

        private int conv(string s)
        {
            int tmp;
            int.TryParse(s, out tmp);
            return tmp;
        }
        private void топ3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxMain.Visible = false;
            groupBoxMain.Enabled = false;
            if (groupBoxRapido.Visible == false)
            {
                groupBoxRapido.Visible = true;
                groupBoxRapido.Enabled = true;
            }
            groupBoxRapido.Text = "Топ 3";
            textBox1.Text = Settings.top3Time.ToString();
            textBox2.Text = Settings.top3Count.ToString();
            textBox4.Text = Settings.top3Seq.ToString();
            textBox5.Text = Settings.top3NSeq.ToString();
            if (Settings.top3On == 1)
                checkBoxRapido.Checked = true;
            else
                checkBoxRapido.Checked = false;
            label8.Visible = false;
            textBox6.Visible = false;
            label9.Visible = false;
            textBox7.Visible = false;
        }

        private void рапидоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBoxMain.Visible = false;
            groupBoxMain.Enabled = false;
            if (groupBoxRapido.Visible == false)
            {
                groupBoxRapido.Visible = true;
                groupBoxRapido.Enabled = true;
            }
            groupBoxRapido.Text = "Рапидо";
            textBox1.Text = Settings.rTime.ToString();
            textBox2.Text = Settings.rCount.ToString();
            textBox4.Text = Settings.rSeq.ToString();
            textBox5.Text = Settings.rNSeq.ToString();
            textBox6.Text = Settings.rSrav18.ToString();
            textBox7.Text = Settings.rChislo;
            if (Settings.rOn == 1)
                checkBoxRapido.Checked = true;
            else
                checkBoxRapido.Checked = false;

            label8.Visible = true;
            textBox6.Visible = true;
            label9.Visible = true;
            textBox7.Visible = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void главнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBoxRapido.Visible == true)
            {
                groupBoxRapido.Visible = false;
                groupBoxRapido.Enabled = false;
                groupBoxMain.Visible = true;
                groupBoxMain.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (groupBoxRapido.Text == "Рапидо")
            {
                int tmp=-1;
                int.TryParse(textBox1.Text, out tmp);

                if (tmp == -1)
                {
                    MessageBox.Show("В поле время нужно ввести число");
                    return;
                }
                Settings.rTime = tmp;
                tmp = -1;
                int.TryParse(textBox2.Text, out tmp);
                if (tmp == -1)
                {
                    MessageBox.Show("В поле тиражи нужно ввести число");
                    return;
                }
                Settings.rCount = tmp;

                if (checkBoxRapido.Checked)
                    Settings.rOn = 1;
                else
                    Settings.rOn = 0;

                tmp = -1;
                int.TryParse(textBox4.Text, out tmp);

                if (tmp == -1)
                {
                    MessageBox.Show("В поле четные нужно ввести последовательность");
                    return;
                }

                Settings.rSeq = tmp;

                tmp = -1;
                int.TryParse(textBox5.Text, out tmp);

                if (tmp == -1)
                {
                    MessageBox.Show("В поле нечетные нужно ввести последовательность");
                    return;
                }

                Settings.rNSeq = tmp;

                tmp = -1;
                int.TryParse(textBox6.Text, out tmp);

                if (tmp == -1)
                {
                    MessageBox.Show("В поле число от 1 до 8 нужно ввести последовательность");
                    return;
                }

                Settings.rSrav18 = tmp;

                Settings.rChislo = textBox7.Text;
            }

            if (groupBoxRapido.Text == "Топ 3")
            {
                int tmp = -1;
                int.TryParse(textBox1.Text, out tmp);

                if (tmp == -1)
                {
                    MessageBox.Show("В поле время нужно ввести число");
                    return;
                }
                Settings.top3Time = tmp;
                tmp = -1;
                int.TryParse(textBox2.Text, out tmp);
                if (tmp == -1)
                {
                    MessageBox.Show("В поле тиражи нужно ввести число");
                    return;
                }
                Settings.top3Count = tmp;

                if (checkBoxRapido.Checked)
                    Settings.top3On = 1;
                else
                    Settings.top3On = 0;

                tmp = -1;
                int.TryParse(textBox4.Text, out tmp);

                if (tmp == -1)
                {
                    MessageBox.Show("В поле тиражи нужно ввести последовательность");
                    return;
                }

                Settings.top3Seq = tmp;

                tmp = -1;
                int.TryParse(textBox5.Text, out tmp);

                if (tmp == -1)
                {
                    MessageBox.Show("В поле нечетные нужно ввести последовательность");
                    return;
                }

                Settings.top3NSeq = tmp;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Старт")
            {
                if (Settings.emailOn == 1)
                    Settings.email=textBox3.Text;

                button2.Text = "Стоп";
                menuStrip1.Enabled = false;
                checkBox1.Enabled = false;
                textBox3.Enabled = false;

                Settings.soundLoop = 1;

                 _rapido.Start();   
            }
            else
            {
                if (Settings.rOn == 1)
                     _rapido.Stop();
                if (Settings.top3On == 1)
                    _top3.Stop();
                button2.Text = "Старт";
                menuStrip1.Enabled = true;
                checkBox1.Enabled = true;
                textBox3.Enabled = true;
                Settings.soundLoop = 1;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.Enabled = true;
                Settings.emailOn = 1;
            }
            else
            {
                textBox3.Enabled = false;
                Settings.emailOn = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Settings.sound = 1;
            }
            else
            {
                Settings.sound = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                Settings.soundLoop = 1;
        }
    }
}
