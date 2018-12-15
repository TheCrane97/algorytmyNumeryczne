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
            int rozmiar = 5;
            Macierz m1 = new Macierz(rozmiar);
            Macierz m2 = new Macierz(rozmiar);
            Wektor w1 = new Wektor(m1.rozmiarMacierzy);
            Wektor w2 = new Wektor(m1.rozmiarMacierzy);
            Wektor X = new Wektor(m1.rozmiarMacierzy);

     

            m1.OdejmijJedynki();
            m1.SkopiujDo(m2);
           // m2.WyswietlMacierz();

            Gauss gauss = new Gauss(m1.macierz, w1.wektor, m2.macierz, w2.wektor, m1.rozmiarMacierzy);

            Console.WriteLine("JACOB----------------------------------------");
            X =Jacob.Jacobe(m2, w1, -13);
            X.WyswietlWektor();

            Console.WriteLine("SEIDEL----------------------------------------");
            X = Seidel.Seid(m1, w1, -13);
            X.WyswietlWektor();

            Console.WriteLine("GAUSS Z CZESCIOWYM  WYBOREM ELEMENTU PODSTAWOWEGO----------------------------------------");
            X = gauss.GaussCWP();
            X.WyswietlWektor();

            Console.WriteLine("GAUSS BEZ  WYBORU ELEMENTU PODSTAWOWEGO----------------------------------------");
            X=gauss.GaussBWP();
            X.WyswietlWektor();


            Console.WriteLine("MONTE CARLO----------------------------------------");
            X=MonteCarlo.GenerujMonte(m1);
            X.WyswietlWektor();


            

        }
    }
}
