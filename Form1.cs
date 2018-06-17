using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace RadiciAlgoritmy
{
    public partial class Form1 : Form
    {
        private int algvyber = 1;
        private bool sinfoenabled = true;

        public Form1()
        {
            InitializeComponent();
            textBox11.Text = "500";
            checkBox1.Checked = true;
            var sinfo = new StartInfo();
            string enabled = sinfo.TryToRead();
            if (enabled != "POVOLENO")
            {
                sinfoenabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
            // Button pokracovat - skontroluje spravnost hodnot, vlozi je do pole a spusti formu zobrazeni
        {
            int cas = 0;
            int chyba = 0;
            int[] cislo = new int[10];
            int[] cislobarva = new int[10];
            try { cislo[0] = Convert.ToInt32(textBox1.Text); }
            catch
            { cislo[0] = 0; chyba = chyba + 1; }
            try { cislo[1] = Convert.ToInt32(textBox2.Text); }
            catch
            { cislo[1] = 0; chyba = chyba + 1; }
            try { cislo[2] = Convert.ToInt32(textBox3.Text); }
            catch
            { cislo[2] = 0; chyba = chyba + 1; }
            try { cislo[3] = Convert.ToInt32(textBox4.Text); }
            catch
            { cislo[3] = 0; chyba = chyba + 1; }
            try { cislo[4] = Convert.ToInt32(textBox5.Text); }
            catch
            { cislo[4] = 0; chyba = chyba + 1; }
            try { cislo[5] = Convert.ToInt32(textBox6.Text); }
            catch
            { cislo[5] = 0; chyba = chyba + 1; }
            try { cislo[6] = Convert.ToInt32(textBox7.Text); }
            catch
            { cislo[6] = 0; chyba = chyba + 1; }
            try { cislo[7] = Convert.ToInt32(textBox8.Text); }
            catch
            { cislo[7] = 0; chyba = chyba + 1; }
            try { cislo[8] = Convert.ToInt32(textBox9.Text); }
            catch
            { cislo[8] = 0; chyba = chyba + 1; }
            try { cislo[9] = Convert.ToInt32(textBox10.Text); }
            catch
            { cislo[9] = 0; chyba = chyba + 1; }
            try { cas = Convert.ToInt32(textBox11.Text); }
            catch
            { 
                MessageBox.Show("Špatne zadaná časová prodleva! Časová prodleva byla nastavena na defalutních 500ms");
                cas = 500;
            }
            if (chyba > 0)
            {
                if (chyba == 10)
                {
                    MessageBox.Show("Nejprve zadejte hodnoty, můžete také použít předem připravené hodnoty.","Chyba");
                }
                else
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show(Convert.ToString(chyba) + " hodnot bylo špatně zadáno a jejich hodnota byla nastavena na nulu. Přejete si přesto pokračovat?","Chyba",MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        var zobr = new Zobrazeni(cislo, cislobarva, cas, algvyber);
                        zobr.ShowDialog();
                    }
                }
            }
            else
            {
                var zobr = new Zobrazeni(cislo, cislobarva, cas, algvyber);
                zobr.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
            // Button pro vygenerovani nahodnych hodnot
        {
            var rnd = new Random();
            int a = rnd.Next(100);
            textBox1.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox2.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox3.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox4.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox5.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox6.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox7.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox8.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox9.Text = Convert.ToString(a);
            a = rnd.Next(100);
            textBox10.Text = Convert.ToString(a);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == Enabled)
            {
                algvyber = 1;
                CheckBoxUncheck(algvyber);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == Enabled)
            {
                algvyber = 2;
                CheckBoxUncheck(algvyber);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == Enabled)
            {
                algvyber = 3;
                CheckBoxUncheck(algvyber);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == Enabled)
            {
                algvyber = 4;
                CheckBoxUncheck(algvyber);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == Enabled)
            {
                algvyber = 5;
                CheckBoxUncheck(algvyber);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == Enabled)
            {
                algvyber = 6;
                CheckBoxUncheck(algvyber);
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == Enabled)
            {
                algvyber = 7;
                CheckBoxUncheck(algvyber);
            }
        }

        private void CheckBoxUncheck(int a)
        {
            if (a != 1) checkBox1.Checked = false;
            if (a != 2) checkBox2.Checked = false;
            if (a != 3) checkBox3.Checked = false;
            if (a != 4) checkBox4.Checked = false;
            if (a != 5) checkBox5.Checked = false;
            if (a != 6) checkBox6.Checked = false;
            if (a != 7) checkBox7.Checked = false;
        }

        private void ukončitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var getinfo = new GetInfo(0);
            MessageBox.Show(getinfo.GetProgramInfo(1), "O programu");
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var getinfo = new GetInfo(0);
            MessageBox.Show(getinfo.GetProgramInfo(2), "Autor programu");
        }

        private void button4_Click(object sender, EventArgs e)
            // Button pro opacne serazene hodnoty
        {
            textBox1.Text = "10";
            textBox2.Text = "9";
            textBox3.Text = "8";
            textBox4.Text = "7";
            textBox5.Text = "6";
            textBox6.Text = "5";
            textBox7.Text = "4";
            textBox8.Text = "3";
            textBox9.Text = "2";
            textBox10.Text = "1";
        }

        private void button3_Click(object sender, EventArgs e)
            // Button pro temer serazene hodnoty
        {
            textBox1.Text = "1";
            textBox2.Text = "2";
            textBox3.Text = "4";
            textBox4.Text = "3";
            textBox5.Text = "5";
            textBox6.Text = "8";
            textBox7.Text = "6";
            textBox8.Text = "7";
            textBox9.Text = "10";
            textBox10.Text = "9";
        }

        private void statistikyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zobrazitStatistikyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stat = new Statistiky();
            stat.ShowDialog();
        }

        private void nastaveníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var statst = new StatSet();
            statst.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (sinfoenabled == true)
            {
                Thread.Sleep(250);
                sinfoenabled = false;
                var sinfo = new StartInfo();
                sinfo.ShowDialog();
            }
        }                 
    }
}
