using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiciAlgoritmy
{
    public class QuickSort
    {
        private Zobrazeni form;
        private int[] cislobarva;
        private int cas;
        private int[] cislo;
        private int[] info;
        private int[] cislordy = new int[10];
        private int ready = 0;
        private bool timecheck;

        public QuickSort(Zobrazeni zobrazeni, ref int[] cislo, ref int[] cislobarva, int cas, ref int[] info, bool timecheck)
        {
            form = zobrazeni;
            this.cislo = cislo;
            this.cislobarva = cislobarva;
            this.cas = cas;
            this.info = info;
            this.timecheck = timecheck;
        }

        public void start()
        {
            int a;  // urcuje levy index razeni
            int b;  // urcuje pravy index razeni
            int i;  // pomocna promena pri zjistovani indexu

            while (ready == 0)
            {
                // Nastaveni leveho indexu razeni
                a = -1;
                i = 0;
                while (a == -1 && i < 10 && ready == 0)
                {
                    if (cislordy[i] == 0)
                        a = i ;
                    else
                        i = i + 1;
                     
                }

                // Nastaveni praveho indexu razeni
                b = -1;
                while (b == -1 && i < 11 && ready == 0 && i >= 0)
                {
                    i = i + 1;
                    if (i > 9)
                    {
                        b = 9;
                    }
                    else
                    {
                        if (cislordy[i] == 1)
                            b = i - 1;
                    }
                }

                // Skontroluje spravnost indexu a spusti razeni
                if (a != -1 && b != -1)
                {
                    // Spusti razeni s danymi indexi a zapise vysledek
                    int x = sort(a, b);     // sort(levy index, pravy index)
                    cislordy[x] = 1;
                }
                else
                    ready = 1;
            }
            form.ColorReset();
            form.Refresh();
            if (timecheck == false)
            {
                var stat = new Statistiky();
                stat.SaveStats(4, info[0], info[1], info[2]);
            }
        }

        private int sort(int lindex, int rindex)
        {
            cislobarva[lindex] = 1;
            cislobarva[rindex] = 1;
            cislordycolor();
            form.Refresh();
            form.ColorReset();
            Thread.Sleep(cas);
            while (lindex != rindex)
            {
                // Pohyb praveho praveho ukazatele
                if (cislo[lindex] > cislo[rindex])
                    info[1] = info[1] + 1;

                while (cislo[lindex] <= cislo[rindex] && lindex != rindex)
                {
                    info[1] = info[1] + 1;
                    rindex = rindex - 1;
                    cislobarva[lindex] = 1;
                    cislobarva[rindex] = 1;
                    cislordycolor();
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                }
                // Pripadne prohozeni sloupcu
                if (lindex != rindex)
                {
                    form.Swap(ref cislo[lindex], ref cislo[rindex], lindex, rindex);
                    info[0] = info[0] + 1;
                    cislobarva[lindex] = 1;
                    cislobarva[rindex] = 1;
                    cislordycolor();
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                }

                // Pohyb leveho ukazatele
                if (cislo[lindex] > cislo[rindex])
                    info[1] = info[1] + 1;

                while (cislo[lindex] <= cislo[rindex] && lindex != rindex)
                {
                    info[1] = info[1] + 1;
                    lindex = lindex + 1;
                    cislobarva[lindex] = 1;
                    cislobarva[rindex] = 1;
                    cislordycolor();
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                }
                // Pripadne prohozeni sloupcu
                if (lindex != rindex)
                {
                    form.Swap(ref cislo[lindex], ref cislo[rindex], lindex, rindex);
                    info[0] = info[0] + 1;
                    cislobarva[lindex] = 1;
                    cislobarva[rindex] = 1;
                    cislordycolor();
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                }
                
            }
            return (lindex);
        }

        private void cislordycolor()    
            // Nastaveni zelene barvy vsem jiz serazenym sloupcum
        {
            int readytest = 0;
            for (int i = 0; i < 10; i++)
            {
                if (cislordy[i] == 1)
                {
                    cislobarva[i] = 2;
                    readytest = readytest + 1;
                }
            }
            if (readytest == 10)        
                // Pripadne nastaveni ukonceni algoritmu
                ready = 1;
        }
    }
}