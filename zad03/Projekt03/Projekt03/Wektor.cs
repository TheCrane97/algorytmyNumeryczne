using System;
using System.Collections.Generic;
using System.IO;
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

        public double WyliczanieDlugosciWektora(Wektor w2)
        {

            double m = 0;
            double m2 = 0;
            for (int i = 0; i < rozmiar; i++)
            {
                m += wektor[i]* wektor[i];
                m2 += w2.wektor[i] * w2.wektor[i];
            }
            double wynik;
            double wynik2;
            wynik = Math.Sqrt(m);
            wynik2 = Math.Sqrt(m2);

            if (wynik - wynik2 > 0)
                return wynik - wynik2;
            else
                return (-1) * (wynik - wynik2);
        }

        public void ZapiszDoPliku()
        {
            string text;
            string path =Path.GetFullPath("odp.txt");

            for (int i=0;i<rozmiar;i++)
            {
                text = Convert.ToString(wektor[i]) + "\r\n";
                System.IO.File.AppendAllText(@path, text);
            }

            System.IO.File.AppendAllText(@path, "\r\n");
            System.IO.File.AppendAllText(@path, "\r\n");
        }
    }
}
