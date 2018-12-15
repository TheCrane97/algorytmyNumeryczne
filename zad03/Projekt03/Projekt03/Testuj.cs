using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{
    class Testuj
    {
        public static void CzyDobrzeObliczyloWektor(Macierz test, Wektor X)
        {
            double[] wynik = new double[test.rozmiarMacierzy];

            for (int i = 0; i < test.rozmiarMacierzy; i++)
            {
                for (int j = 0; j < test.rozmiarMacierzy; j++)
                {
                    wynik[i] += test.macierz[i, j] * X.wektor[j];
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < test.rozmiarMacierzy; i++)
                Console.WriteLine(wynik[i]);
        }
    }
}
