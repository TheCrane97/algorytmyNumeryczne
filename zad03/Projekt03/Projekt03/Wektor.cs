using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{
    class Wektor
    {
        public double[] wektor;
        public int rozmiar;
        public Wektor(int rozmiar)
        {
            this.rozmiar = rozmiar;
            wektor = new double[rozmiar];
            wektor[rozmiar - 1] = -1;
        }

        public void WyzerujWektor()
        {
            for (int i = 0; i < rozmiar; i++)
                wektor[i] = 0;
        }

        public  void WyswietlWektor()
        {
            for(int i=0;i<rozmiar;i++)
            {
                Console.WriteLine(wektor[i]);
            }

        }

        public void SkopiujDo(Wektor w)
        {
            for (int i = 0; i < rozmiar; i++)
                w.wektor[i] = this.wektor[i];
        }

        public double ObliczBladZ(Wektor w)
        {
            double wynik;
            Wektor pom = new Wektor(rozmiar);
            pom.WyzerujWektor();

            for(int i=0;i<rozmiar;i++)
            {
                pom.wektor[i] = wektor[i] - w.wektor[i];
              //  Console.WriteLine(pom.wektor[i] + "   " + wektor[i] + "   " + w.wektor[i]);
                if (pom.wektor[i] < 0)
                    pom.wektor[i] *= (double)-1;
            }

            wynik = pom.wektor[0];
            for(int i=1;i<rozmiar;i++)
            {
                if (pom.wektor[i] > wynik)
                    wynik = pom.wektor[i];

            }


            return wynik;
        }
    }
}
