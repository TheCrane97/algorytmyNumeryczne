using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{
    class Seidel
    {
        public static Wektor Seid(Macierz M,Wektor V, int p) //M=kopia / V=wektor kopia (same 0 i 1 na koncu) / p=precyzja na -10 itp
        {
            //Nasz wynik i pomoc do obliczania prezycji	
            Wektor X1 = new Wektor(M.rozmiarMacierzy);
            Wektor X2 = new Wektor(M.rozmiarMacierzy);
            double suma1 = 0;
            double suma2 = 0;
            X1.WyzerujWektor();
            X2.WyzerujWektor();
            double precyzja = Math.Pow(10, p); // nasza obliczona precyzja	
            int rozmiar = M.rozmiarMacierzy; // Rozmiar macierzy wszystkie przypadki

            do
            {

                X1.SkopiujDo(X2); //X2=X1

                for (int i = 0; i < rozmiar; i++)
                {
                    suma1 = 0.0;
                    suma2 = 0.0;
                    for (int j = 0; j < i; j++)
                        suma1 -= (M.macierz[i,j] * X1.wektor[j]);
                    for (int j = i + 1; j < rozmiar; j++)
                        suma2 -= (M.macierz[i,j] * X2.wektor[j]);

                    suma1 += suma2 + V.wektor[i];
                    X1.wektor[i] = suma1 / M.macierz[i, i];
                }

            } while (X1.ObliczBladZ(X2) > precyzja);


            return X1;
        }
    }
}
