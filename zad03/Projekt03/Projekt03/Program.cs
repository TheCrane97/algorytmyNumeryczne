using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{

    class Program
    {
        static void Main(string[] args)
        {
            for (int rozmiar = 19; rozmiar <= 21; rozmiar++)
            {
                Macierz m1 = new Macierz(rozmiar);
                Macierz m2 = new Macierz(rozmiar);
                Wektor w1 = new Wektor(m1.rozmiarMacierzy);
                Wektor w2 = new Wektor(m1.rozmiarMacierzy);
                Wektor X = new Wektor(m1.rozmiarMacierzy);
                Wektor Z = new Wektor(m1.rozmiarMacierzy);

                string path = Path.GetFullPath("POPRAWNE.txt");
                TimeSpan ts;
                Stopwatch stopWatch = new Stopwatch();
                string elapsedTime;

                m1.OdejmijJedynki();
                m1.SkopiujDo(m2);
                // m2.ZapiszDoPliku();

                Gauss gauss = new Gauss(m1.macierz, w1.wektor, m2.macierz, w2.wektor, m1.rozmiarMacierzy);

                Console.WriteLine("MONTE CARLO----------------------------------------");
                X = MonteCarlo.GenerujMonte(m2);
                X.WyswietlWektor();
                //X.ZapiszDoPliku();


                Console.WriteLine("JACOB----------------------------------------");
                Z = Jacob.Jacobe(m2, w1, -6);
                Z.WyswietlWektor();
                System.IO.File.AppendAllText(@path, Convert.ToString(X.ObliczBladZ(Z)) + ";");
                //  X.ZapiszDoPliku();


                Console.WriteLine("JACOB----------------------------------------");
                Z = Jacob.Jacobe(m2, w1, -10);
                Z.WyswietlWektor();
                System.IO.File.AppendAllText(@path, Convert.ToString(X.ObliczBladZ(Z)) + ";");
                //  X.ZapiszDoPliku();


                Console.WriteLine("JACOB----------------------------------------");
                Z = Jacob.Jacobe(m2, w1, -14);
                Z.WyswietlWektor();
                System.IO.File.AppendAllText(@path, Convert.ToString(X.ObliczBladZ(Z)) + ";");
                //  X.ZapiszDoPliku();

                Console.WriteLine("SEIDEL----------------------------------------");
                Z = Seidel.Seid(m2, w1, -6);
                ts = stopWatch.Elapsed;
                Z.WyswietlWektor();
                System.IO.File.AppendAllText(@path, Convert.ToString(X.ObliczBladZ(Z)) + ";");
                //  X.ZapiszDoPliku();

                Console.WriteLine("SEIDEL----------------------------------------");
                Z = Seidel.Seid(m2, w1, -10);
                ts = stopWatch.Elapsed;
                Z.WyswietlWektor();
                System.IO.File.AppendAllText(@path, Convert.ToString(X.ObliczBladZ(Z)) + ";");
                //  X.ZapiszDoPliku();

                Console.WriteLine("SEIDEL----------------------------------------");
                Z = Seidel.Seid(m2, w1, -14);
                ts = stopWatch.Elapsed;
                Z.WyswietlWektor();
                System.IO.File.AppendAllText(@path, Convert.ToString(X.ObliczBladZ(Z)) + ";");
                //  X.ZapiszDoPliku();

                Console.WriteLine("GAUSS Z CZESCIOWYM  WYBOREM ELEMENTU PODSTAWOWEGO----------------------------------------");
                Z = gauss.GaussCWP();
                Z.WyswietlWektor();
                System.IO.File.AppendAllText(@path, Convert.ToString(X.ObliczBladZ(Z)) + ";");
                //  X.ZapiszDoPliku();

                Console.WriteLine("GAUSS BEZ  WYBORU ELEMENTU PODSTAWOWEGO----------------------------------------");
                Z = gauss.GaussBWP();
                Z.WyswietlWektor();
                System.IO.File.AppendAllText(@path, Convert.ToString(X.ObliczBladZ(Z)) + "\r\n");
                // X.ZapiszDoPliku();


            }




        }
    }
}
