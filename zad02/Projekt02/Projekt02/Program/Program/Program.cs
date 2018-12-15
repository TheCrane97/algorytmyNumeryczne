using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?redirectedfrom=MSDN&view=netframework-4.7.2
namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 2000;

            
            Macierz<float> mOrig = new Macierz<float>(size);//Macierz A
            Macierz<float> mCopy = new Macierz<float>(size);//Macierz ktorej wartosci beda takie same jak macierzy A; na niej sa wykonywane dzialania
            Wektor<float> wOrig = new Wektor<float>(size);//Wektor B
            Wektor<float> wCopy = new Wektor<float>(size);//Wektor ktorego wartosci beda takie same jak wektora B; na nim sa wykonywane dzialania

            Macierz<double> mOrig2 = new Macierz<double>(size);//Macierz A
            Macierz<double> mCopy2 = new Macierz<double>(size);//Macierz ktorej wartosci beda takie same jak macierzy A; na niej sa wykonywane dzialania
            Wektor<double> wOrig2 = new Wektor<double>(size);//Wektor B
            Wektor<double> wCopy2 = new Wektor<double>(size);//Wektor ktorego wartosci beda takie same jak wektora B; na nim sa wykonywane dzialania


            Wektor<float> X = new Wektor<float>(size);//Wektor X ktory zostanie wyliczony
            Wektor<float> B = new Wektor<float>(size);//Wektor B'

            Wektor<double> X2 = new Wektor<double>(size);//Wektor X ktory zostanie wyliczony
            Wektor<double> B2 = new Wektor<double>(size);//Wektor B'


            TimeSpan ts;
            Stopwatch stopWatch = new Stopwatch();
            string elapsedTime;

            //Losowanie wartosci i przypisywanie je w macierzy
            mOrig.Losuj();
            wOrig.Losuj();

            //Kopiowanie wartoci do kopii macierzy i wektora
            mOrig.SkopiujDo(mCopy);
            wOrig.SkopiujDo(wCopy);


            mOrig.SkopiujISkonwersujDo(mOrig2);
            wOrig.SkopiujISkonwersujDo(wOrig2);

            mOrig2.SkopiujDo(mCopy2);
            wOrig2.SkopiujDo(wCopy2);


            //utworzenie obiektu MyMatrix w ktorym sa metody Gaussa; przekazywane sa wszystkie powyzej utworzone obiekty;
            MyMatrix<float> myMatrix = new MyMatrix<float>(mOrig.GetMacierz(), wOrig.GetWektor(), mCopy.GetMacierz(), wCopy.GetWektor(), X.GetWektor(), B.GetWektor(), mCopy.GetWymiar());
            MyMatrix<double> myMatrix2 = new MyMatrix<double>(mOrig2.GetMacierz(), wOrig2.GetWektor(), mCopy2.GetMacierz(), wCopy2.GetWektor(), X2.GetWektor(), B2.GetWektor(), mCopy2.GetWymiar());





            ///Mierzenie czasow dla typu float
            Console.WriteLine("Mierzenie Czasu dla typu Float-------------------------------------------------------------");
            //Mierzenie czasu dla funkcji Gaussa bez wyboru elementu podstawowego, oraz wyswietlenie bledu przyblizenia
            stopWatch.Start();
            myMatrix.GaussBWP();
            stopWatch.Stop();

            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("Czas wykonania dla funkcji Gaussa bez wyboru elementu podstawowego: " + elapsedTime);

            if (wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora() < 0)
                Console.WriteLine("Blad przyblizenia:                                                  " + (-(wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora())));
            else
                Console.WriteLine("Blad przyblizenia:                                                  " + (wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora()));



            
            mOrig.SkopiujDo(mCopy);
            wOrig.SkopiujDo(wCopy);
            stopWatch.Reset();


            //Mierzenie czasu dla funkcji Gaussa z czesciowym wyborem elementu podstawowego, oraz wyswietlenie bledu przyblizenia
            stopWatch.Start();
            myMatrix.GaussCWP();
            stopWatch.Stop();

            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("Czas wykonania dla funkcji Gaussa z czesciowym wyborem elementu podstawowego: " + elapsedTime);

            if (wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora() < 0)
                Console.WriteLine("Blad przyblizenia:                                                            " + (-(wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora())));
            else
                Console.WriteLine("Blad przyblizenia:                                                            " + (wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora()));


            mOrig.SkopiujDo(mCopy);
            wOrig.SkopiujDo(wCopy);
            stopWatch.Reset();
            

            //Mierzenie czasu dla funkcji Gaussa z pelnym wyborem elementu podstawowego, oraz wyswietlenie bledu przyblizenia
            stopWatch.Start();
            myMatrix.GaussWP();
            stopWatch.Stop();

            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("Czas wykonania dla funkcji Gaussa z pelnym wyborem elementu podstawowego: " + elapsedTime);

            if (wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora() < 0)
                Console.WriteLine("Blad przyblizenia:                                                            " + (-(wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora())));
            else
                Console.WriteLine("Blad przyblizenia:                                                            " + (wOrig.WyliczanieDlugosciWektora() - B.WyliczanieDlugosciWektora()));


            Console.WriteLine();

            stopWatch.Reset();

            ///Mierzenie czasu dla typu double
            Console.WriteLine("Mierzenie Czasu dla typu Double-------------------------------------------------------------");
            //Mierzenie czasu dla funkcji Gaussa bez wyboru elementu podstawowego, oraz wyswietlenie bledu przyblizenia
            stopWatch.Start();
            myMatrix2.GaussBWP();
            stopWatch.Stop();

            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("Czas wykonania dla funkcji Gaussa bez wyboru elementu podstawowego: " + elapsedTime);

            if (wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora() < 0)
                Console.WriteLine("Blad przyblizenia:                                                  " + (-(wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora())));
            else
                Console.WriteLine("Blad przyblizenia:                                                  " + (wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora()));


            mOrig2.SkopiujDo(mCopy2);
            wOrig2.SkopiujDo(wCopy2);
            stopWatch.Reset();


            //Mierzenie czasu dla funkcji Gaussa z czesciowym wyborem elementu podstawowego, oraz wyswietlenie bledu przyblizenia
            stopWatch.Start();
            myMatrix2.GaussCWP();
            stopWatch.Stop();

            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("Czas wykonania dla funkcji Gaussa z czesciowym wyborem elementu podstawowego: " + elapsedTime);

            if (wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora() < 0)
                Console.WriteLine("Blad przyblizenia:                                                            " + (-(wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora())));
            else
                Console.WriteLine("Blad przyblizenia:                                                            " + (wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora()));

            mOrig2.SkopiujDo(mCopy2);
            wOrig2.SkopiujDo(wCopy2);
            stopWatch.Reset();

            //Mierzenie czasu dla funkcji Gaussa z pelnym wyborem elementu podstawowego, oraz wyswietlenie bledu przyblizenia
            stopWatch.Start();
            myMatrix2.GaussWP();
            stopWatch.Stop();

            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("Czas wykonania dla funkcji Gaussa z pelnym wyborem elementu podstawowego: " + elapsedTime);

            if (wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora() < 0)
                Console.WriteLine("Blad przyblizenia:                                                            " + (-(wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora())));
            else
                Console.WriteLine("Blad przyblizenia:                                                            " + (wOrig2.WyliczanieDlugosciWektora() - B2.WyliczanieDlugosciWektora()));


            Console.Read();




        }
    }
}
