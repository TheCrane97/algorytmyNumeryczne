using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{

    class Program
    {
        static void Main(string[] args)
        {
            int rozmiar = 4;
            Macierz m1 = new Macierz(rozmiar);
            Macierz m2 = new Macierz(rozmiar);
            Wektor w1 = new Wektor(m1.rozmiarMacierzy);
            Wektor w2 = new Wektor(m1.rozmiarMacierzy);
            Wektor X = new Wektor(m1.rozmiarMacierzy);

            m1.WyswietlMacierz();
            m1.SkopiujDo(m2);

            m2.OdejmijJedynki();
            m2.WyswietlMacierz();

            //Gauss gauss = new Gauss(m1.macierz,w1.wektor,m2.macierz,w2.wektor,m1.rozmiarMacierzy);
            //X = gauss.GaussBWP();
            //X.WyswietlWektor();
            //Testuj.GaussaBWP(m1, X);

            //  X=MonteCarlo.GenerujMonte(m1);
            // X.WyswietlWektor();
            //  m1.WyswietlMacierz();
            //    w1.WyswietlWektor();
            // Console.WriteLine();

            ////Macierz przyklad = new Macierz(6);
            ////przyklad.rozmiarMacierzy = 4;
            ////przyklad.macierz[0, 0] = 10;
            ////przyklad.macierz[0, 1] = -1;
            ////przyklad.macierz[0, 2] = 2;
            ////przyklad.macierz[0, 3] = 0;
            ////przyklad.macierz[1, 0] = -1;
            ////przyklad.macierz[1, 1] = 11;
            ////przyklad.macierz[1, 2] = -1;
            ////przyklad.macierz[1, 3] = 3;
            ////przyklad.macierz[2, 0] = 2;
            ////przyklad.macierz[2, 1] = -1;
            ////przyklad.macierz[2, 2] = 10;
            ////przyklad.macierz[2, 3] = -1;
            ////przyklad.macierz[3, 0] = 0;
            ////przyklad.macierz[3, 1] = 3;
            ////przyklad.macierz[3, 2] = -1;
            ////przyklad.macierz[3, 3] = 8;

            ////Wektor wektor = new Wektor(4);
            ////wektor.wektor[0] = 6;
            ////wektor.wektor[1] = 25;
            ////wektor.wektor[2] = -11;
            ////wektor.wektor[3] = 15;

            ////przyklad.WyswietlMacierz();

            X =Jacob.Jacobe(m1, w1, -3);
            X.WyswietlWektor();
            



        }
    }
}
