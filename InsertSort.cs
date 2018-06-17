using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiciAlgoritmy
{
    public class InsertSort
    {
        
        private Zobrazeni form;
        private int[] cislobarva;
        private int cas;
        private int[] cislo;
        private int[] info;
        private bool timecheck;

        public InsertSort(Zobrazeni zobrazeni, ref int[] cislo, ref int[] cislobarva, int cas, ref int[] info, bool timecheck)
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
            int sloupec = 0;
            int sloupecp = 0;
            int sloupecs = 0;
            while (sloupec < 10)
                // Pohyb hlavniho ukazatele
            {
                cislobarva[sloupec] = 1;
                form.Refresh();
                Thread.Sleep(cas);
                form.ColorReset();
                sloupecp = sloupec;
                sloupecs = sloupec;
                while (sloupecp > 0)
                    // Presun cisla do leva tak dlouho dokud je pred nim vetsi cislo
                    // popř. ukonceni pokud je cislo uplne na zacatku
                {
                    sloupecp = (sloupecp - 1);
                    info[1] = info[1] + 1;
                    if (cislo[sloupecp] > cislo[sloupecs])
                    {
                        form.Swap(ref cislo[sloupecp], ref cislo[sloupecs], sloupecp, sloupecs);
                        info[0] = info[0] + 1;
                        sloupecs = (sloupecp);
                        cislobarva[sloupecp] = 1;
                        cislobarva[sloupec] = 2;
                        form.Refresh();
                        Thread.Sleep(cas);
                        form.ColorReset();
                    }
                    else
                    {
                        sloupecp = 0;
                    }
                }
                sloupec = (sloupec + 1);
            }

            form.ColorReset();
            form.Refresh();
            if (timecheck == false)
            {
                var stat = new Statistiky();
                stat.SaveStats(0, info[0], info[1], info[2]);
            }
        }
    }
}
