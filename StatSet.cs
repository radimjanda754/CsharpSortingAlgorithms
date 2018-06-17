using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RadiciAlgoritmy
{
    public partial class StatSet : Form
    {
        private string enabled = "";
        public StatSet()
        {
            InitializeComponent();
            enabled = TryToRead();
            if(enabled == "POVOLENO")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
            }

        }

        public string TryToRead()
            // Pokusi se precist informaci, popr ji necha vytvorit
        {
            try
            {
                StreamReader sr = new StreamReader("statst.txt");
                sr.ReadLine();
                string temp = sr.ReadLine();
                sr.Close();
                return (temp);
            }
            catch
            {
                Reset();
            }
            return ("");
        }

        private void Reset()
            // Vyresetovani informace (defalutne POVOLENO), popr necha soubor vytvorit
        {
            StreamWriter tmp = new StreamWriter("statst.txt");
            tmp.WriteLine(" - UKLADANI DO STATISTIK: -");
            tmp.WriteLine("POVOLENO");
            tmp.Close();
            enabled = TryToRead();
        }

        private void button1_Click(object sender, EventArgs e)
            // Button zavrit, pouze zavre formu
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
            // Button na potvrzeni zmen, ulozeni zmen ne souboru s informaci
        {
            if (checkBox1.Checked == true | checkBox2.Checked == true)
            {
                StreamWriter tmp = new StreamWriter("statst.txt");
                tmp.WriteLine(" - UKLADANI DO STATISTIK: -");
                if (checkBox1.Checked == true)
                {
                    tmp.WriteLine("POVOLENO");
                    tmp.Close();
                    Close();
                }
                if (checkBox2.Checked == true)
                {
                    tmp.WriteLine("ZAKAZANO");
                    tmp.Close();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Zvolte alespoň jednu možnost!", "Chyba");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
            // Checkbox povoleno
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
            // Checkbox zakazano
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }
    }
}
