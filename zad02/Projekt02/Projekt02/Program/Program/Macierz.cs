using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Macierz<M>
    {
        public M[,] macierz;//Deklaracja macierzy okreslonego wczesniej typu

        public int wymiar;                 //wymiar macierzy
        static int max = 65535;     // 2^16 - 1
        static int min = -65536;    // -(2^16)
        static int dzielnik = 65536; // 2^16
   
        //Konstruktor
        public Macierz(int wymiar)
        {
            this.wymiar = wymiar;
            macierz = new M[wymiar, wymiar];
        }

        //Funkcja losujaca macierz okreslonej wielkosci i zwracajaca ja
        //Wielkosc podajemy w konstruktorze 
        public void Losuj()
        {
            
            Random pseudolosowa = new Random();

            if (typeof(M) == typeof(float))//Generowanie liczb dla typu float
            {
                for (int wiersz = 0; wiersz < wymiar; wiersz++)
                {
                    for (int kolumna = 0; kolumna < wymiar; kolumna++)
                    {
                        macierz[wiersz, kolumna] = (M)Convert.ChangeType(((float)pseudolosowa.Next(min, max) / (float)dzielnik), typeof(M));
                    }
                }
            }
            else
                if (typeof(M) == typeof(double))//Generowanie liczb dla typu double
            {
                for (int wiersz = 0; wiersz < wymiar; wiersz++)
                {
                    for (int kolumna = 0; kolumna < wymiar; kolumna++)
                    {
                        macierz[wiersz, kolumna] = (M)Convert.ChangeType(((double)pseudolosowa.Next(min, max) / (double)dzielnik), typeof(M));
                    }
                }
                Console.WriteLine("DOUBLE");
            }

            
        }
        public void SkopiujDo(Macierz<M> m)
        {
            for (int wiersz = 0; wiersz < wymiar; wiersz++)
            {
                for (int kolumna = 0; kolumna < wymiar; kolumna++)
                {
                    m.macierz[wiersz,kolumna] = macierz[wiersz, kolumna];
                }
            }

        }


        public void SkopiujISkonwersujDo(Macierz<double> m)
        {
            for (int wiersz = 0; wiersz < wymiar; wiersz++)
            {
                for (int kolumna = 0; kolumna < wymiar; kolumna++)
                {
                    m.macierz[wiersz, kolumna] = (double)Convert.ChangeType(macierz[wiersz, kolumna], typeof(double));
                }
            }

        }

        public M[,] GetMacierz()
        {
            return macierz;
        }

        public int GetWymiar()
        {
            return wymiar;
        }

        public void WyswietlMacierz()
        {
            for (int wiersz = 0; wiersz < wymiar; wiersz++)
            {
                for (int kolumna = 0; kolumna < wymiar; kolumna++)
                {
                    Console.Write(macierz[wiersz,kolumna]+ " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

    }
}
