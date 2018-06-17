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
    public partial class Statistiky : Form
    {
        private string[,] lines = new string[7,3];
        private string openfile = "NOFILE";

        public Statistiky()
        {
            InitializeComponent();
            TryToRead();
            Vypis();
            var statst = new StatSet();
            string enabled = statst.TryToRead();
            if (enabled == "POVOLENO")
            {
                label36.Text = "ZAPNUTO";
                label36.ForeColor = Color.Green;
            }
            else
            {
                label36.Text = "VYPNUTO";
                label36.ForeColor = Color.Red;
            }
        }

        public void SaveStats(int a, int presun, int porovnani, int cas)
            // Ulozi zmeny provedene ve statistikach do textoveho souboru
        {
            var statst = new StatSet();
            string enabled = statst.TryToRead();
            if (enabled == "POVOLENO")
            {
                TryToRead();
                StreamWriter tmp = new StreamWriter("stat.txt");
                tmp.WriteLine(" - STATISTIKY PROGRAMU RADICI ALGORITMY -");
                for (int i = 0; i < a; i++)
                {
                    tmp.WriteLine(lines[i, 0]);
                }
                tmp.WriteLine(lines[a, 0] + Convert.ToString(presun) + ";");
                for (int i = a + 1; i < 7; i++)
                {
                    tmp.WriteLine(lines[i, 0]);
                }
                for (int i = 0; i < a; i++)
                {
                    tmp.WriteLine(lines[i, 1]);
                }
                tmp.WriteLine(lines[a, 1] + Convert.ToString(porovnani) + ";");
                for (int i = a + 1; i < 7; i++)
                {
                    tmp.WriteLine(lines[i, 1]);
                }
                for (int i = 0; i < a; i++)
                {
                    tmp.WriteLine(lines[i, 2]);
                }
                tmp.WriteLine(lines[a, 2] + Convert.ToString(cas) + ";");
                for (int i = a + 1; i < 7; i++)
                {
                    tmp.WriteLine(lines[i, 2]);
                }
                tmp.Close();
            }
        }

        private void Vypis()
            // Vypise statistiky
        {
            label12.Text = Vypocti(lines[0, 0]);
            label13.Text = Vypocti(lines[1, 0]);
            label14.Text = Vypocti(lines[2, 0]);
            label15.Text = Vypocti(lines[3, 0]);
            label16.Text = Vypocti(lines[4, 0]);
            label17.Text = Vypocti(lines[5, 0]);
            label18.Text = Vypocti(lines[6, 0]);
            label19.Text = Vypocti(lines[0, 1]);
            label20.Text = Vypocti(lines[1, 1]);
            label21.Text = Vypocti(lines[2, 1]);
            label22.Text = Vypocti(lines[3, 1]);
            label23.Text = Vypocti(lines[4, 1]);
            label24.Text = Vypocti(lines[5, 1]);
            label25.Text = Vypocti(lines[6, 1]);
            label26.Text = Vypocti(lines[0, 2]);
            label27.Text = Vypocti(lines[1, 2]);
            label28.Text = Vypocti(lines[2, 2]);
            label29.Text = Vypocti(lines[3, 2]);
            label30.Text = Vypocti(lines[4, 2]);
            label31.Text = Vypocti(lines[5, 2]);
            label32.Text = Vypocti(lines[6, 2]);
        }

        private void TryToRead()
            // Pokusi se precist statistiky ze souboru, pakli ze soubor neexistuje je vytvoren
        {
            try
            {
                string stattxt;
                if (openfile == "NOFILE")
                {
                    stattxt = "stat.txt";
                }
                else
                {
                    stattxt = openfile;
                }

                StreamReader sr = new StreamReader(stattxt);
                
                
                sr.ReadLine();
                for (int ik = 0; ik < 3; ik++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        lines[i, ik] = sr.ReadLine();
                    }
                }
                openfile = "NOFILE";
                sr.Close();
            }
            catch
            {
                Reset();
            }
        }

        private string Vypocti(string a)
            // Vypocta statistiky z nacteneho textoveho souboru, popr. ohlasi chybi
        {
            string tmp = "";
            string cislo = "";
            int cisloint = 0;
            int cislopoc = 0;
            int cislosouc = 0;
            int move = 0;
            try
            {
                int ultratemp = a.Length;
            }
            catch
            {
                return "x";
            }
            if (a.Length > 0)
            {
                while (tmp != "!")
                {
                    tmp = "";
                    cislo = "";
                    while (tmp != ";" && tmp != "!")
                    {
                        try
                        {
                            tmp = Convert.ToString(a[move]);
                            if (tmp != ";")
                                cislo = cislo + tmp;
                        }
                        catch
                        {
                            tmp = "!";
                        }
                        move = move + 1;
                    }
                    if (tmp != "!")
                    {
                        try
                        {
                            cisloint = Convert.ToInt32(cislo);
                        }
                        catch
                        {
                            DialogResult dr = new DialogResult();
                            dr = MessageBox.Show("Nalezena chyba v textovém souboru obsahujicím informace o statistikách. Přejete si jej vyresetovat?", "Chyba", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                Reset();
                                MessageBox.Show("Statistiky byli vyresetováný", "Reset");
                            }
                            tmp = "!";
                        }
                        cislosouc = cislosouc + cisloint;
                        cislopoc = cislopoc + 1;
                    }
                }
                try
                {
                    return (Convert.ToString(cislosouc / cislopoc));
                }
                catch
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Nalezena chyba v textovém souboru obsahujicím informace o statistikách. Přejete si jej vyresetovat?", "Chyba", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Reset();
                        MessageBox.Show("Statistiky byli úspěšně vyresetováný", "Reset");
                    }
                    tmp = "!";
                }

            }

            return ("x");
        }

        private void button1_Click(object sender, EventArgs e)
            // Button zavrit, pouze zavre formu
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
            // Button vyresetovat, zepta se na vyresetovani statistik popripadne je vyresetuje
        {
            DialogResult dr = MessageBox.Show("Opravdu chcete trvale odstranit dosavadní statistiky?", "Potvrdit odstraneni", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Reset();
                MessageBox.Show("Statistiky byli úspěšně vyresetováný", "Reset");
            }
        }

        private void Reset()
            // Vyresetovani statistik i vytvoreni souboru pakli - ze neexistuje
        {
            StreamWriter tmp = new StreamWriter("stat.txt");
            tmp.WriteLine(" - STATISTIKY PROGRAMU RADICI ALGORITMY -");
            for (int i = 0; i < 21; i++)
                tmp.WriteLine("");
            tmp.Close();
            TryToRead();
            Vypis();
        }

        private void button4_Click(object sender, EventArgs e)
            // Načtení statistik
        {
            DialogResult dr = MessageBox.Show(@"Současně načtané hodnoty budou přepsání. Pokud je chcete zachovat, je možné jejich uložení.

Opravdu chcete pokračovat?", "Upozornění", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                checkdirectory();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Načíst statistiku";
                ofd.Filter = "txt soubory se statistikou(*.txt)|*.txt";
                string pth = Directory.GetCurrentDirectory();
                ofd.InitialDirectory = pth + "\\SavedStats";
                DialogResult drx = new DialogResult();
                drx = ofd.ShowDialog();
                if (drx == DialogResult.OK)
                {
                    openfile = (Convert.ToString(ofd.FileName));
                    TryToRead();
                    Vypis();
                    StreamWriter tmp = new StreamWriter("stat.txt");
                    tmp.WriteLine(" - STATISTIKY PROGRAMU RADICI ALGORITMY -");
                    for (int ik = 0; ik < 3; ik++)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            tmp.WriteLine(lines[i, ik]);
                        }
                    }
                    tmp.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
            // Uložení statistik
        {
            checkdirectory();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Uložit statistiku";
            sfd.Filter = "txt soubory se statistikou(*.txt)|*.txt";
            Directory.CreateDirectory("SavedStats");
            string pth = Directory.GetCurrentDirectory();
            sfd.InitialDirectory = pth + "\\SavedStats";
            DialogResult dr = new DialogResult();
            dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                StreamWriter tmp = new StreamWriter(Convert.ToString(sfd.FileName));
                tmp.WriteLine(" - STATISTIKY PROGRAMU RADICI ALGORITMY -");
                for (int ik = 0; ik < 3; ik++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        tmp.WriteLine(lines[i, ik]);
                    }
                }
                tmp.Close();
            }
        }

        private void checkdirectory()
            // Ověří zda je vytvořena složka SavedStats. Pokud ne tak ji vytvoří.
        {
            bool createdir = Directory.Exists("SavedStats");
            if (createdir == false)
            {
                Directory.CreateDirectory("SavedStats");
            }
        }
    }

}
