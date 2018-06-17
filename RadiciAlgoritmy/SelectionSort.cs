using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiciAlgoritmy
{
    public class SelectionSort
    {
        private Zobrazeni form;
        private int[] cislobarva;
        private int cas;
        private int[] cislo;
        private int[] info;
        private bool timecheck;

        public SelectionSort(Zobrazeni zobrazeni, ref int[] cislo, ref int[] cislobarva, int cas, ref int[] info, bool timecheck)
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
            int sloupecmin = 0;             // Do teto promene se zapisuje hodnota minimalniho sloupce
            int sloupecminnm = 0;           // Do teto promene se zapisuje cislo minimalniho sloupce

            for (int i = 0; i < 10; i++)
            {
                sloupecmin = cislo[i];
                sloupecminnm = i;
                for (int ik = i+1; ik < 10; ik++)
                {
                    info[1] = info[1] + 1;
                    if (cislo[ik] < sloupecmin)
                        // Zápis nejnižší hodnoty
                    {
                        sloupecmin = cislo[ik];
                        sloupecminnm = ik;
                    }
                    cislobarva[i] = 1;
                    cislobarva[ik] = 1;
                    cislobarva[sloupecminnm] = 2;
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                }
                form.Swap(ref cislo[i], ref cislo[sloupecminnm], i, sloupecminnm);
                info[0] = info[0] + 1;
                cislobarva[i] = 1;
                cislobarva[sloupecminnm] = 2;
                form.Refresh();
                form.ColorReset();
                Thread.Sleep(cas);
            }
            form.ColorReset();
            form.Refresh();
            if (timecheck == false)
            {
                var stat = new Statistiky();
                stat.SaveStats(1, info[0], info[1], info[2]);
            }
        }

    }
}