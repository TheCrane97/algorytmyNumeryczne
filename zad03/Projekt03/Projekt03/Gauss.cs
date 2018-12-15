using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{
    class Gauss
    {
        public double[,] mOrig; //macierz oryginalna
        public double[] wOrig;  //wektor oryginalny
        public double[,] mCopy; // kopia macierzy
        public double[] wCopy;  //kopia wektora            
        public int SIZE;        //wymiar macierzy

        public Gauss(double[,] mOrig, double[] wOrig, double[,] mCopy, double[] wCopy, int wymiar)
        {
            this.mOrig = mOrig;
            this.wOrig = wOrig;
            this.mCopy = mCopy;
            this.wCopy = wCopy;
            SIZE = wymiar;
        }

        ///Gauss bez wyboru elementu podstawowego
        public Wektor GaussBWP() 
        {
            Wektor X = new Wektor(SIZE);
            X.WyzerujWektor();
            double m;

            //Tworzenie macierzy schodkowej
            for (int k = 0; k < SIZE - 1; k++)
            {
                for (int i = k + 1; i < SIZE; i++)
                {
                    m = mCopy[i, k]/ mCopy[k, k];
                    wCopy[i] = wCopy[i]- (m* wCopy[k]);
                    for (int j = k; j < SIZE; j++)
                    {
                        mCopy[i, j] = mCopy[i, j]-(m* mCopy[k, j]);
                    }
                }

            }


            //Wyliczanie X
            for (int i = SIZE - 1; i >= 0; i--)
            {
                m = 0;
                for (int j = i + 1; j < SIZE; j++)
                {
                    m =m+ (mCopy[i, j]* X.wektor[j]);
                }
                X.wektor[i] = (wCopy[i]- m)/ mCopy[i, i];
            }

            return X;

        }


        public Wektor GaussCWP() //Gauss z czesciowym wyborem elementu podstawowego
        {
            double m;
            Wektor X = new Wektor(SIZE);
            X.WyzerujWektor();
            for (int i = 0; i < SIZE; i++)
            {

                int max = i;

                //Wyszukanie najwiekszego elementu
                for (int j = i + 1; j < SIZE; j++)
                {
                    if (ABS(mCopy[j, i]) > ABS(mCopy[max, i]))
                    {
                        max = j;
                    }
                }

                double temp;
                //SWAP macierzy
                for (int j = 0; j < SIZE; j++)
                {
                    temp = mCopy[i, j];
                    mCopy[i, j] = mCopy[max, j];
                    mCopy[max, j] = temp;
                }

                //SWAP wektora
                temp = wCopy[i];
                wCopy[i] = wCopy[max];
                wCopy[max] = temp;





                //Tworzenie macierzy schodkowej
                for (int j = i + 1; j < SIZE; j++)
                {
                    m = mCopy[j, i] / mCopy[i, i];
                    wCopy[j] = wCopy[j] - (m * wCopy[i]);
                    for (int k = i; k < SIZE; k++)
                    {
                        mCopy[j, k] = mCopy[j, k] - (m * mCopy[i, k]);
                    }
                }
            }

            //Wyliczanie X
            for (int i = SIZE - 1; i >= 0; i--)
            {
                m = 0;
                //m=0;
                for (int j = i + 1; j < SIZE; j++)
                {
                    m = m + (mCopy[i, j] * X.wektor[j]);
                }
                X.wektor[i] = (wCopy[i] - m) / mCopy[i, i];
            }

            return X;
          


        }



        //wartosc bezwzgledna z liczby
        double ABS(double liczba)
        {
            if (liczba > 0)
                return liczba;
            else
                return liczba * (-1);

        }
    }
}
