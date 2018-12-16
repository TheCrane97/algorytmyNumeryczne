using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{
    class Macierz
    {
        public double[,] macierz;
        public List<Agent> struktura = new List<Agent>();
        public int rozmiarMacierzy;
        public int iloscAgentow;

        public Macierz(int iloscAgentow)
        {
            this.iloscAgentow = iloscAgentow;
            StworzStrukture(iloscAgentow);
            rozmiarMacierzy = struktura.Count();
            WypelnijMacierz();
        }

        void StworzStrukture(int iloscAgentow)
        {
            for (int i = 0; i <= iloscAgentow; i++)
            {
                for (int j = 0; j <= iloscAgentow; j++)
                {
                    if (i + j <= iloscAgentow)
                        struktura.Add(new Agent(i, j));
                }
            }
        }

        void WypelnijMacierz()
        {
            macierz = new double[rozmiarMacierzy, rozmiarMacierzy];
            int tak, nie, nw;
            for(int i=0;i<rozmiarMacierzy;i++)
            {
                tak = struktura[i].t;
                nie = struktura[i].n;
                nw = iloscAgentow - tak - nie;

                macierz[i, i] = (DwumianNeewtona(tak, 2) / DwumianNeewtona(iloscAgentow, 2))
                                  + (DwumianNeewtona(nw, 2) / DwumianNeewtona(iloscAgentow, 2))
                                  + (DwumianNeewtona(nie, 2) / DwumianNeewtona(iloscAgentow, 2));

                if (tak >= 1 && nie >= 1)
                {
                      macierz[i,struktura.FindIndex(x => x.t == tak - 1 && x.n == nie - 1)]= (tak * nie) / DwumianNeewtona(iloscAgentow, 2);
                }

                if (tak >= 1 && nw >= 1)
                {
                    macierz[i,struktura.FindIndex(x => x.t == tak + 1 && x.n == nie)] = (tak * nw) / DwumianNeewtona(iloscAgentow, 2);
                }

                if (nw >= 1 && nie >= 1)
                {

                    macierz[i, struktura.FindIndex(x => x.t == tak && x.n == nie + 1)] = (nw * nie) / DwumianNeewtona(iloscAgentow, 2);
                }



            }

        }


        public void OdejmijJedynki()
        {

            for(int i=0;i<rozmiarMacierzy;i++)
            {
                for (int j = 0; j < rozmiarMacierzy ; j++)
                    if (i == j)
                    {
                        if(macierz[i,j]==1)
                            macierz[i, j] -= 2;
                        else
                            macierz[i, j] -= 1;
                    }
            }
           
        }

        
        public double DwumianNeewtona(int n,int k)
        {
            if (n < k)
                return 0;
            else
                return Silnia(n) / (Silnia(k) * Silnia(n - k));
        }

        public long Silnia(int liczba)
        {
            long silnia = 1;

            for (int i = 2; i <= liczba; i++)
                silnia *= i;

            return silnia;

        }


        public void WyswietlMacierz()
        {
            Console.Write("    ");

            for (int i = 0; i < struktura.Count(); i++)
            {
                struktura[i].WyswietlAgenta();
            }
            Console.WriteLine();

            for (int i = 0; i < rozmiarMacierzy; i++)
            {
                struktura[i].WyswietlAgenta();
                for (int j = 0; j < rozmiarMacierzy;j++)
                {
                    Console.Write(macierz[i, j]+"   ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        public void WyswietlStrukture()
        {
            Console.WriteLine();
            for (int i = 0; i < struktura.Count(); i++)
            {
                struktura[i].WyswietlAgenta();
                Console.WriteLine();
            }

        }


        public void SkopiujDo(Macierz kopia)
        {
            for(int i=0;i<kopia.rozmiarMacierzy;i++)
            {
                for(int j=0;j<kopia.rozmiarMacierzy;j++)
                {
                    kopia.macierz[i, j] = macierz[i, j];
                }
            }
        }

        public void ZapiszDoPliku()
        {
            string text="";
            for (int i = 0; i < rozmiarMacierzy; i++)
            {
                for (int j = 0; j < rozmiarMacierzy; j++)
                {
                    text += Convert.ToString(macierz[i,j]) + ";";
                    
                }
                text += "\r\n";
                System.IO.File.AppendAllText(@"D:\Uczelnia\semestr_5\algorytmyNumeryczne\zad03\odp.txt", text);
                text = "";
            }

            System.IO.File.AppendAllText(@"D:\Uczelnia\semestr_5\algorytmyNumeryczne\zad03\odp.txt", "\r\n");
            System.IO.File.AppendAllText(@"D:\Uczelnia\semestr_5\algorytmyNumeryczne\zad03\odp.txt", "\r\n");
        }

    }
}
