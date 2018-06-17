using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RadiciAlgoritmy
{
    public class ShellSort
    {
        private Zobrazeni form;
        private int[] cislobarva;
        private int cas;
        private int[] cislo;
        private int[] info;
        private bool timecheck;

        public ShellSort(Zobrazeni zobrazeni, ref int[] cislo, ref int[] cislobarva, int cas, ref int[] info, bool timecheck)
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
            int pocets = 0;
            int ic = 0;
            int hop = 0;
            int last = 0;
            pocets = 10;
            ic = Convert.ToInt32(pocets / 2.2); // Vypočtení inkrementu (počet sloupců)/2.2, převod do Int
            while (ic > 0)
                // Program bude postupovat tak dlouho dokud není inkrement 0
            {
                for (int i = ic; i < pocets; i ++)
                    // Pohyb pravého ukazatele
                {
                    hop = 1;    // Určuje počet skoků v levo (násobí se s inkrementem)
                    last = i;   // Pomocná proměná k dočasnému uchování porovnávané hodnoty
                    while ( (i-(ic*hop)) >= 0)
                        // Levý ukazatel, porovnávání
                    {
                        cislobarva[last] = 1;
                        cislobarva[i - (ic * hop)] = 2;
                        form.Refresh();
                        Thread.Sleep(cas);
                        form.ColorReset();
                        info[1] = info[1] + 1;
                        if (cislo[i - (ic * hop)] > cislo[last])
                        {
                            form.Swap(ref cislo[i - (ic * hop)], ref cislo[last], i - (ic * hop), last);
                            info[0] = info[0] + 1;
                            cislobarva[last] = 2;
                            cislobarva[i - (ic * hop)] = 1;
                            last = (i - (ic * hop));
                            form.Refresh();
                            Thread.Sleep(cas);
                            form.ColorReset();
                        }
                        else
                        {
                            hop = i;    // Ukončení cyklu
                        }
                        hop = hop + 1;
                    }
                }
                ic = Convert.ToInt32(ic / 2.2); // Hodnoty inkrementů  budou 5 -> int(5/2.2) = 2 -> int(2/2.2) = 1 -> int(1/2,2) = 0
            }
            form.ColorReset();
            form.Refresh();
            if (timecheck == false)
            {
                var stat = new Statistiky();
                stat.SaveStats(3, info[0], info[1], info[2]);
            }
        }

    }
}
