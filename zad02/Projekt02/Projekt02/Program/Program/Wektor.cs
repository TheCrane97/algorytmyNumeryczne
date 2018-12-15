using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Wektor<M>:DzialaniaMatematyczne
    {
        public M[] wektor; //Deklaracja wektora okreslonego wczesniej typu

        public int wymiar;           //wymiar wektora
        static int max = 65535;     // 2^16 - 1
        static int min = -65536;    // -(2^16)
        static int dzielnik = 65536; // 2^16

        //Konstruktor
        public Wektor(int wymiar)
        {
            this.wymiar = wymiar;
            wektor = new M[wymiar];

        }


        //Funkcja losujaca macierz okreslonej wielkosci i zwracajaca ja
        //Wielkosc podajemy w konstruktorze 
        public void Losuj()
        {
          
            Random pseudolosowa = new Random();

            if (typeof(M) == typeof(float))//Generowanie liczb dla typu float
            {
                for (int i = 0; i < wymiar; i++)
                {
                    wektor[i] = (M)Convert.ChangeType(((float)pseudolosowa.Next(min, max) / (float)dzielnik), typeof(M));
                }
            }
            else
                 if (typeof(M) == typeof(double))//Generowanie liczb dla typu double
            {

                for (int i = 0; i < wymiar; i++)
                {
                    wektor[i] = (M)Convert.ChangeType(((double)pseudolosowa.Next(min, max) / (double)dzielnik), typeof(M));
                }
            }
 
        }

        public M[] GetWektor()
        {
            return wektor;
        }


        public void SkopiujDo(Wektor<M> w)
        {
       
                for (int i = 0; i < wymiar; i++)
                {
                    w.wektor[i] = wektor[i];
                }

        }


        public void SkopiujISkonwersujDo(Wektor<double> w)
        {
           
                for (int i = 0; i < wymiar; i++)
                {
                    w.wektor[i] = (double)Convert.ChangeType(wektor[i], typeof(double));
                }
            

        }
   


        public double WyliczanieDlugosciWektora()
        {
           
            M m = (M)Convert.ChangeType(0, typeof(M));
            for (int i = 0; i < wymiar; i++)
            {
                m = Add(m, Multiply(wektor[i], wektor[i]));
            }
            double wynik = (double)Convert.ChangeType(m, typeof(double));
            wynik = Math.Sqrt(wynik);
            return wynik;
        }


        public void WyswietlWektor()
        {

                for (int i = 0; i < wymiar; i++)
                {
                    Console.Write(wektor[i] + " ");
                }
                Console.WriteLine();

        }
    }
}
