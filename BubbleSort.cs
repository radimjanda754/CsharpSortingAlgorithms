using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiciAlgoritmy
{
    public class BubbleSort
    {
        private Zobrazeni form;
        private int[] cislobarva;
        private int cas;
        private int[] cislo;
        private int[] info;
        private bool timecheck;

        public BubbleSort(Zobrazeni zobrazeni, ref int[] cislo, ref int[] cislobarva, int cas, ref int[] info, bool timecheck)
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
            for (int ik = 0; ik < 10; ik++)     // Posun zeleneho ukazatele
            {
                for (int i = 9; i > ik; i--)    // Posun cerveneho ukazatele
                {
                    cislordycolor(ik);
                    cislobarva[i] = 1;
                    form.Refresh();
                    form.ColorReset();
                    Thread.Sleep(cas);
                    info[1] = info[1] + 1;
                    if (cislo[i] < cislo[i - 1])    // Pripadne prohozeni sloupcu
                    {
                        form.Swap(ref cislo[i], ref cislo[i - 1], i, i - 1);
                        info[0] = info[0] + 1;
                    }

                }
            }
            form.ColorReset();
            form.Refresh();
            if (timecheck == false)
            {
                var stat = new Statistiky();
                stat.SaveStats(2, info[0], info[1], info[2]);
            }
        }

        private void cislordycolor(int ik)
            // Nastaveni zelene barvy vsem jiz serazenym sloupcum
        {
            for (int i = 1; i <= ik && ik != 0; i++)
            {
                cislobarva[i - 1] = 2;
            }
        }

    }
}