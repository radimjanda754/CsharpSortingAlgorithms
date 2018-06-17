using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiciAlgoritmy
{
    public class HeapSort
    {
        private Zobrazeni form;
        private int[] cislobarva;
        private int cas;
        private int[] cislo;
        private int[] info;
        private int lastrdy = 10;   // Promena ukazujici na posledni serazeny sloupec (v pripade 10 neni serazen zadny)
        private bool timecheck;

        public HeapSort(Zobrazeni zobrazeni, ref int[] cislo, ref int[] cislobarva, int cas, ref int[] info, bool timecheck)
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
            int b;          // Pomocna promena k zapisovani vysledku
            int ik = 5;     // Promena urcujici posledni sloupec ktery k sobe ma prirazeny alespon 1 dalsi sloupec
            int k = 5;      // Pomocna promena urcujici ke kteremu sloupci pripada jen 1 sloupec
            
            while (lastrdy > 0)
            {
                for (int i = 0; i < ik; i++)
                { 
                    b = cmp3(i,k);
                    while (b != -1)
                    {
                        int c = b;  // Pomocna promena k zapisovani vysledku
                        b = cmp3(c,k);
                    }

                }
                if (ik == k)
                {
                    ik = ik - 1;
                }
                else
                {
                    k = k - 1;
                }
                info[0] = info[0] + 1;
                form.Swap(ref cislo[0], ref cislo[lastrdy - 1], 0, lastrdy - 1);
                cislobarva[0] = 1;
                cislobarva[lastrdy-1] = 2;
                cislordycolor();
                form.Refresh();
                form.ColorReset();
                Thread.Sleep(cas);
                lastrdy = lastrdy - 1;
            }
            form.ColorReset();
            form.Refresh(); 
            if (timecheck == false)
            {
                var stat = new Statistiky();
                stat.SaveStats(5, info[0], info[1], info[2]);
            }
        }

        private int cmp3(int a, int b)
            // Tato metoda porovna a popripadne prohodi prirazene sloupce vzhedem k sloupci vybranemu (int a)
            // Sloupce musi byt cislovany od 1
            // V takovemto pripade budou prirazene sloupce   1 -> 2*a     2 -> 2*a+1
        {
            a = a + 1;
            if (a < 1)
                return (-1);

            if (a == b)     // V pripade ze ke sloupci A pripada jen jeden sloupec
            {

                    cislobarva[a - 1] = 1;
                    cislobarva[a + a - 1] = 1;
                    cislordycolor();
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                    info[1] = info[1] + 1;
                
                if (cislo[a - 1] < cislo[a + a - 1])
                {
                    info[0] = info[0] + 1;
                    form.Swap(ref cislo[a - 1], ref cislo[a + a - 1], a - 1, a + a - 1);
                    cislobarva[a - 1] = 1;
                    cislobarva[a + a - 1] = 1;
                    cislordycolor();
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                    return ((a/2)-1);
                }
            }
            else            // V pripade ze ke sloupci A pripadaji 2 sloupce
            {
                cislobarva[a - 1] = 1;
                cislobarva[a + a - 1] = 1;
                cislordycolor();
                form.Refresh();
                form.ColorReset();
                Thread.Sleep(cas);
                info[1] = info[1] + 1;
                if (cislo [a + a - 1] < cislo[a + a])
                {
                    cislobarva[a - 1] = 1;
                    cislobarva[a + a] = 1;
                    cislordycolor();
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                    info[1] = info[1] + 1;
                    if (cislo[a + a] > cislo[a - 1])
                    {
                        info[0] = info[0] + 1;
                        form.Swap(ref cislo[a + a], ref cislo[a - 1], a + a, a - 1);
                        cislobarva[a - 1] = 1;
                        cislobarva[a + a] = 1;
                        cislordycolor();
                        form.Refresh();
                        form.ColorReset();
                        Thread.Sleep(cas);
                        return((a/2)-1);
                    }
                }
                else
                {
                    info[1] = info[1] + 1;
                    if (cislo[a + a - 1] > cislo[a - 1])
                    {
                        info[0] = info[0] + 1;
                        form.Swap(ref cislo[a + a - 1], ref cislo[a - 1], a + a - 1, a - 1);
                        cislobarva[a - 1] = 1;
                        cislobarva[a + a - 1] = 1;
                        cislordycolor();
                        form.Refresh();
                        form.ColorReset();
                        Thread.Sleep(cas);
                        return((a/2)-1);
                    }
                }

            }
            return (-1);
        }

        private void cislordycolor()
            // Nastaveni zelene barvy vsem jiz serazenym sloupcum
        {
            if (lastrdy < 10)
            {
                for (int i = 9; i >= lastrdy; i--)
                {
                    cislobarva[i] = 2;
                }
            }
        }


    }

}