using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadiciAlgoritmy
{
    public class MergeSort
    {
        private Zobrazeni form;
        private int[] cislobarva;
        private int cas;
        private int[] cislo;
        private int[] cislo2 = new int[10];
        private int[] cislosipka;
        private int[] info;
        private bool timecheck;

        public MergeSort(Zobrazeni zobrazeni, ref int[] cislo, ref int[] cislobarva, int cas, ref int[] info, bool timecheck,ref int[] cislosipka)
        {
            form = zobrazeni;
            this.cislo = cislo;
            this.cislobarva = cislobarva;
            this.cas = cas;
            this.info = info;
            this.timecheck = timecheck;
            this.cislosipka = cislosipka;
        }

        public void start()
        {
            // Spustí znázornění rozdělování hodnot
            if (timecheck == false)
                rozdeleni();

            // Postupně spouští řazení algoritmu tak jak byli hodnoty rozděleny
            sort(3, 4, 5);
            sort(2, 3, 5);
            sort(0, 1, 2);
            sort(0, 2, 5);
            sort(8, 9, 10);
            sort(7, 8, 10);
            sort(5, 6, 7);
            sort(5, 7, 10);
            sort(0, 5, 10);
            form.ColorReset();
            form.Refresh();
            if (timecheck == false)
            {
                var stat = new Statistiky();
                stat.SaveStats(6, info[0], info[1], info[2]);
            }
        }

        private void sort(int a, int b, int end)
        {
            int start = a;
            int enda = b;
            int move = a;

            while (a < enda | b < end)
            {
                if (a == enda | b == end)
                {
                    if (a == enda)
                    {
                        while (b < end)
                        {
                            cislo2[move] = cislo[b];
                            if (move != b)
                                info[0] = info[0] + 1;
                            cislosipka[b] = move + 1 - start;
                            move = move + 1;
                            b = b + 1;
                        }
                    }
                    else
                    {
                        while (a < enda)
                        {
                            cislo2[move] = cislo[a];
                            if (move != a)
                                info[0] = info[0] + 1;
                            cislosipka[a] = move + 1 - start;
                            move = move + 1;
                            a = a + 1;
                        }
                    }
                }
                else
                {
                    info[1] = info[1] + 1;
                    if (cislo[a] > cislo[b])
                    {
                        cislo2[move] = cislo[b];
                        if (move != b)
                            info[0] = info[0] + 1;
                        cislosipka[b] = move + 1 - start;
                        b = b + 1;
                        move = move + 1;
                    }
                    else
                    {
                        cislo2[move] = cislo[a];
                        if (move != a)
                            info[0] = info[0] + 1;
                        cislosipka[a] = move + 1 - start;
                        a = a + 1;
                        move = move + 1;
                    }
                }

                for (int i = start; i < end; i++)
                    cislobarva[i] = 1;
                form.Refresh();
                form.ColorReset();
                Thread.Sleep(cas);

            }
            novysloupec(start, end);
        }

        private void novysloupec(int start, int end)
            // Vykresli novy sloupec z pomocneho pole
        {
            form.ColorReset();
            for (int i = start; i < end; i++)
            {
                cislobarva[i] = 2;
                cislo[i] = cislo2[i];
                form.Refresh();
                Thread.Sleep(cas);
            }
            form.ColorReset();
        }

        private void rozdeleni()
            // Graficke znazorneni rozdeleni
        {
            for (int i = 5; i < 10; i++)
                cislobarva[i] = 1;
            form.Refresh();
            Thread.Sleep(2*cas);
            for (int i = 2; i < 5; i++)
                cislobarva[i] = 1;
            for (int i = 5; i < 7; i++)
                cislobarva[i] = 0;
            form.Refresh();
            Thread.Sleep(2*cas);
            cislobarva[1] = 1;
            cislobarva[2] = 0;
            cislobarva[6] = 1;
            cislobarva[7] = 0;
            form.Refresh();
            Thread.Sleep(2*cas);
            cislobarva[3] = 2;
            cislobarva[8] = 2;
            form.Refresh();
            Thread.Sleep(2*cas);
            form.ColorReset();
            form.Refresh();
            Thread.Sleep(cas);
        }
    }
}
