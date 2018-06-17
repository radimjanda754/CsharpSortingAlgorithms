using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiciAlgoritmy
{
    public partial class Zobrazeni : Form
    {
        private int[] cislo;
        private int[] cislobarva;
        private int[] mergesort = new int[10];
        private int cas;
        private float k;
        private int algvyber;
        private int[] info = new int[3];
        private int graf1 = -1;
        private int graf2 = -1;
        private bool timecheck = true;
        
        public Zobrazeni(int[] cislo, int[] cislobarva, int cas, int algvyberx)
        {
            InitializeComponent();
            this.cislo = cislo;
            this.cislobarva = cislobarva;
            this.cas = cas;
            algvyber = algvyberx;

            // Vypise informace o algoritmu ze tridy GetInfo
            var getinfo = new GetInfo(algvyber);
            textBox1.Text = getinfo.GetAlgInfo();
            // Vypocteni maximalni hodnoty sloupcu a konstanty k podle ktere se sloupce budou vykreslovat
            int max = 0;
            for (int i = 0; i < 10; i++)
            {
                if (cislo[i] > max)
                {
                    max = cislo[i];
                }
            }
            k = (300f / max);

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
        
        private void Zobrazeni_Paint(object sender, PaintEventArgs e)
        {
            if (timecheck == false)
            {
                // Vytvoření grafického prostředí
                Graphics g = this.CreateGraphics();

                // Nastavení fontu a brushů
                Brush p = new SolidBrush(Color.Blue);
                Brush fontcolor = new SolidBrush(Color.Black);
                Brush pozadi = new SolidBrush(Color.White);
                Font f = new Font("Arial Black", 16);
                Font finfo = new Font("Arial", 14);

                // Vykreslení-vypsání měřičů algoritmu
                g.FillRectangle(pozadi, 10, 400, 720, 100);
                g.DrawString("Pocet přesunů sloupců: " + Convert.ToString(info[0]), finfo, fontcolor, 30, 410);
                g.DrawString("Počet porovnání sloupců: " + Convert.ToString(info[1]), finfo, fontcolor, 30, 435);
                g.DrawString("Čas: " + Convert.ToString(info[2]) + " ms (Meřeno bez spomalování)", finfo, fontcolor, 30, 460);

                // Vykresleni sloupcu a cisel
                for (int i = 0; i < 10; i++)
                {
                    // Nastaveni barev
                    if (cislobarva[i] == 0)
                    {
                        p = new SolidBrush(Color.Blue);
                        fontcolor = new SolidBrush(Color.Black);
                    }
                    if (cislobarva[i] == 1)
                    {
                        p = new SolidBrush(Color.Red);
                        fontcolor = new SolidBrush(Color.Red);
                    }
                    if (cislobarva[i] == 2)
                    {
                        p = new SolidBrush(Color.Green);
                        fontcolor = new SolidBrush(Color.Green);
                    }

                    // Vykresleni sloupce
                    g.FillRectangle(p, (30 + (i * 70)), (350 - (cislo[i] * k)), 35, (cislo[i] * k) + 1);

                    // Vykresleni cisel
                    g.DrawString(Convert.ToString(cislo[i]), f, fontcolor, (30 + (i * 70)), 365);
                }

                if (graf1 >= 0)
                {
                    Pen pn = new Pen(Color.Purple, 3);
                    int xk = cislo[graf1];
                    if (cislo[graf1] < cislo[graf2])
                        xk = cislo[graf2];
                    xk = Convert.ToInt32((300 - (xk * k)));
                    if (xk < 15)
                        xk = 15;

                    g.DrawLine(pn, 47 + (graf1 * 70), xk, 47 + (graf2 * 70), xk);
                    g.DrawLine(pn, 47 + (graf1 * 70), xk, 47 + (graf1 * 70), (337 - (cislo[graf1] * k)));
                    g.DrawLine(pn, 47 + (graf2 * 70), xk, 47 + (graf2 * 70), (337 - (cislo[graf2] * k)));
                    g.DrawLine(pn, 58 + (graf1 * 70), (325 - (cislo[graf1] * k)), 48 + (graf1 * 70), (336 - (cislo[graf1] * k)));
                    g.DrawLine(pn, 36 + (graf1 * 70), (325 - (cislo[graf1] * k)), 46 + (graf1 * 70), (336 - (cislo[graf1] * k)));
                    g.DrawLine(pn, 58 + (graf2 * 70), (325 - (cislo[graf2] * k)), 48 + (graf2 * 70), (336 - (cislo[graf2] * k)));
                    g.DrawLine(pn, 36 + (graf2 * 70), (325 - (cislo[graf2] * k)), 46 + (graf2 * 70), (336 - (cislo[graf2] * k)));
                }
                if (algvyber == 7)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (mergesort[i] > 0)
                        {
                            fontcolor = new SolidBrush(Color.Purple);
                            int xk = cislo[i];
                            xk = Convert.ToInt32((300 - (xk * k)));
                            if (xk < 15)
                            xk = 15;
                            Pen pn = new Pen(Color.Purple, 3);
                            g.DrawLine(pn, 47 + (i * 70), xk, 47 + (i * 70), (337 - (cislo[i] * k)));
                            g.DrawLine(pn, 58 + (i * 70), (325 - (cislo[i] * k)), 48 + (i * 70), (336 - (cislo[i] * k)));
                            g.DrawLine(pn, 36 + (i * 70), (325 - (cislo[i] * k)), 46 + (i * 70), (336 - (cislo[i] * k)));
                            g.DrawString(Convert.ToString(mergesort[i]) + ".", finfo, fontcolor, 67 + (i * 70), xk);
                            mergesort[i] = 0;
                        }
                    }
                }
            }
        }

        public void ColorReset() 
            // Nastaví vsechny barvy na zakladni (sloupce modry, cisla cerne)
        {
            for (int i = 0; i < 10; i++)
            {
                cislobarva[i] = 0;
            }
            graf1 = -1;
            graf2 = -1;
        }

        public void Swap(ref int a, ref int b, int ax, int bx) 
            // Pomocna metoda na prohozeni dvou promenych
        {
            int c = 0;
            c = a;
            a = b;
            b = c;
            graf1 = ax;
            graf2 = bx;
        }

        private void button1_Click(object sender, EventArgs e) 
            // Spousteci button "Start", spusti predem vybrany algoritmus
        {
            button3.Visible = false;
            button1.Visible = false;

            if (algvyber == 1)
                // ------------ INSERT SORT -------------
            {
                var alg = new InsertSort(this, ref cislo, ref cislobarva, cas, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 2)
                // ------------ SELECTION SORT -------------
            {
                var alg = new SelectionSort(this, ref cislo, ref cislobarva, cas, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 3)
                // ------------ BUBBLE SORT -------------
            {
                var alg = new BubbleSort(this, ref cislo, ref cislobarva, cas, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 4)
                // ------------ SHELL SORT -------------
            {
                var alg = new ShellSort(this, ref cislo, ref cislobarva, cas, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 5)
                // ------------ QUICK SORT -------------
            {
                var alg = new QuickSort(this, ref cislo, ref cislobarva, cas, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 6)
                // ------------ HEAP SORT -------------
            {
                var alg = new HeapSort(this, ref cislo, ref cislobarva, cas, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 7)
            // ------------ MERGE SORT -------------
            {
                var alg = new MergeSort(this, ref cislo, ref cislobarva, cas, ref info, timecheck, ref mergesort);
                alg.start();
            }
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e) 
            // Button "Pokracovat", presune program do dalsi faze odstranenim buttonu a textboxu, mereni casu
        {
            var getinfo = new GetInfo(algvyber);
            ActiveForm.Text = getinfo.GetAlgTxt();
            button1.Visible = true;
            button2.Visible = false;
            button3.Text = "Zavřít";

            int[] tmpcislo = new int[10];
            for (int i = 0; i < 10; i++)
                tmpcislo[i] = cislo[i];

            int[] tmpcislobarva = new int[10];
            for (int i = 0; i < 10; i++)
                tmpcislobarva[i] = cislobarva[i];

            int[] tmpinfo = new int[3];
            for (int i = 0; i < 3; i++)
                tmpinfo[i] = info[i];

            int s = Convert.ToInt32(DateTime.Now.ToString("ss"));
            int ms = Convert.ToInt32(DateTime.Now.ToString("fff"));
            textBox1.Text = "Probíhá meření času, prosím čekejte";

            if (algvyber == 1)
            // ------------ INSERT SORT -------------
            {
                var alg = new InsertSort(this, ref cislo, ref cislobarva, 0, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 2)
            // ------------ SELECTION SORT -------------
            {
                var alg = new SelectionSort(this, ref cislo, ref cislobarva, 0, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 3)
            // ------------ BUBBLE SORT -------------
            {
                var alg = new BubbleSort(this, ref cislo, ref cislobarva, 0, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 4)
            // ------------ SHELL SORT -------------
            {
                var alg = new ShellSort(this, ref cislo, ref cislobarva, 0, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 5)
            // ------------ QUICK SORT -------------
            {
                var alg = new QuickSort(this, ref cislo, ref cislobarva, 0, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 6)
            // ------------ HEAP SORT -------------
            {
                var alg = new HeapSort(this, ref cislo, ref cislobarva, 0, ref info, timecheck);
                alg.start();
            }
            if (algvyber == 7)
            // ------------ MERGE SORT -------------
            {
                var alg = new MergeSort(this, ref cislo, ref cislobarva, 0, ref info, timecheck, ref mergesort);
                alg.start();
            }

            int s2 = Convert.ToInt32(DateTime.Now.ToString("ss"));
            int ms2 = Convert.ToInt32(DateTime.Now.ToString("fff"));

            cislo = tmpcislo;
            cislobarva = tmpcislobarva;
            info = tmpinfo;
            info[2] = GetTime(s, s2, ms, ms2);
            timecheck = false;
            Refresh();
            textBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e) 
            // Button "Zpet", zavre okno
        {
            Close();
        }

        private int GetTime(int s1, int s2, int ms1, int ms2)
            // Zmereni rozdilu casu (1 pred spustenim algoritmu, 2 po spusteni)
        {
            if (s1 > s2)
            {
                s2 = s2 + 60;
            }
            s2 = s2 - s1;
            ms2 = (ms2 - ms1) + (1000 * s2);
            return (ms2);
        }
    }
}
