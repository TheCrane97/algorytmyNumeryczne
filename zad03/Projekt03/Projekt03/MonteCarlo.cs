using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{
    class MonteCarlo
    {
        public static Wektor GenerujMonte(Macierz m)
        {
            Wektor wynik = new Wektor(m.rozmiarMacierzy);
           
            bool choice = true;
            Random r = new Random();

            int iloscWykonan = 100000;

            wynik.WyzerujWektor();
            int tak, nie, nw,s1,s2;

            double[] wektor = new double[m.iloscAgentow];
            double[] kopia = new double[m.iloscAgentow];

            for (int ktoraStruktura = 0; ktoraStruktura < m.struktura.Count(); ktoraStruktura++)
            {
                int licznik = 0;
                
                
                tak = m.struktura[ktoraStruktura].t;
                nie = m.struktura[ktoraStruktura].n;
                nw = m.iloscAgentow - tak - nie;

                for (int i = 0; i < m.iloscAgentow; i++)
                {
                    if (i < tak)
                        wektor[i] = 0;
                    if (i >= tak && i < tak + nie)
                        wektor[i] = 1;
                    if (i >= tak + nie)
                        wektor[i] = 2;
                }


                for (int i = 0; i < iloscWykonan; i++)
                {
                    kopia = Skopiuj(wektor,kopia);

                    choice = true;
                    do
                    {
                        s1 = r.Next(m.iloscAgentow);
                        s2 = r.Next(m.iloscAgentow);
                        if (kopia[s1] == 0 && kopia[s2] == 2 || kopia[s1] == 2 && kopia[s2] == 0)
                        {
                            kopia[s1] = 0;
                            kopia[s2] = 0;
                        }
                        else if (kopia[s1] == 0 && kopia[s2] == 1 || kopia[s1] == 1 && kopia[s2] == 0)
                        {
                            kopia[s1] = 2;
                            kopia[s2] = 2;
                        }
                        else if (kopia[s1] == 1 && kopia[s2] == 2 || kopia[s1] == 2 && kopia[s2] == 1)
                        {
                            kopia[s1] = 1;
                            kopia[s2] = 1;
                        }
                        if (!Jest(kopia, 1) && !Jest(kopia, 0)) { choice = false; }
                        else if (!Jest(kopia, 1)) { licznik++; choice = false; }
                        else if (!Jest(kopia, 0)) { choice = false; }
                    } while (choice);

                }

                wynik.wektor[ktoraStruktura] = (double)licznik / (double)iloscWykonan;
            }


            return wynik;
        }




        public static bool Jest(double [] w, double liczba)
        {
            int size = w.Count() - 1;
            while (size >= 0)
            {
                if (w[size] == liczba)
                    return true;
                size--;
            }
            return false;
        }

        static double[] Skopiuj(double [] a,double [] b)
        {
            for (int i = 0; i < a.Count(); i++)
                b[i] = a[i];
            return b;

        }

    }
}
