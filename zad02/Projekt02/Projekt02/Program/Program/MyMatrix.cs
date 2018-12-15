using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class MyMatrix<M> : DzialaniaMatematyczne
    {
        public M[,] mOrig;
        public M[] wOrig;
        public M[,] mCopy;
        public M[] wCopy;
        public M[] X;
        public M[] B;
        public int SIZE;

        public MyMatrix (M[,] mOrig, M[] wOrig,M[,] mCopy, M[] wCopy,M[] X, M[] B,int wymiar)
        {
            this.mOrig = mOrig;
            this.wOrig = wOrig;
            this.mCopy = mCopy;
            this.wCopy = wCopy;
            this.X = X;
            this.B = B;
            SIZE = wymiar;
        }

        
        public void GaussBWP() //Gauss bez wyboru elementu podstawowego
        {
            M m;
            //Tworzenie macierzy schodkowej
            for (int k = 0; k < SIZE - 1; k++)
            {
                for (int i = k + 1; i < SIZE; i++)
                {
                    m = Divide(mCopy[i, k], mCopy[k, k]);
                    wCopy[i] = Substract(wCopy[i], Multiply(m, wCopy[k])); 
                    for (int j = k; j < SIZE; j++)
                    {
                        mCopy[i, j] = Substract(mCopy[i, j], Multiply(m, mCopy[k, j]));
                    }
                }

            }


            


            //Wyliczanie X
            for (int i = SIZE - 1; i >= 0; i--)
            {
                m = (M)Convert.ChangeType(0, typeof(M)); 
                for (int j = i + 1; j < SIZE; j++)
                {
                    m = Add(m, Multiply(mCopy[i, j], X[j]));
                }
                X[i] = Divide(Substract(wCopy[i], m), mCopy[i, i]); 
            }


            //Oryginalna macierz * X; Wyliczenie B'
            for (int i = 0; i < SIZE; i++)
            {
                m = (M)Convert.ChangeType(0, typeof(M));
                for (int j = 0; j < SIZE; j++)
                {
                    m = Add(m, Multiply(mOrig[i, j], X[j]));
                }
                B[i] = m;
            }


        }

        
        public void GaussCWP() //Gauss z czesciowym wyborem elementu podstawowego
        {
            M m;


            for (int i = 0; i < SIZE; i++)
            {

                int max = i;

                //Wyszukanie najwiekszego elementu
                for (int j = i + 1; j < SIZE; j++)
                {
                    if (Bigger(ABS(mCopy[j, i]), ABS(mCopy[max, i])))
                    {
                        max = j;
                    }
                }

                M temp;
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
                    m = Divide(mCopy[j, i], mCopy[i, i]);
                    wCopy[j] = Substract(wCopy[j], Multiply(m, wCopy[i]));
                    for (int k = i ; k < SIZE; k++)
                    {
                        mCopy[j, k] = Substract(mCopy[j, k], Multiply(m, mCopy[i, k]));
                    }
                }
            }
        
                    //Wyliczanie X
                    for (int i = SIZE - 1; i >= 0; i--)
                    {
                        m = (M)Convert.ChangeType(0, typeof(M));
                        //m=0;
                        for (int j = i + 1; j < SIZE; j++)
                        {
                            m = Add(m, Multiply(mCopy[i, j], X[j]));
                        }
                        X[i] = Divide(Substract(wCopy[i], m), mCopy[i, i]);
                    }


                    //Oryginalna macierz * X; Wyliczenie B'
                    for (int i = 0; i < SIZE; i++)
                    {
                        m = (M)Convert.ChangeType(0, typeof(M));
                        for (int j = 0; j < SIZE; j++)
                        {
                            m = Add(m, Multiply(mOrig[i, j], X[j]));
                        }
                        B[i] = m;
                    }

                
            }






        public void GaussWP()//Gauss z pelnym wyborem elementu podstawowego
        {
            int pomoc;
            int[] pwp = new int[SIZE]; //Prawdziwa pozycja

            for (int i = 0; i < SIZE; i++)
            { pwp[i] = i; }

            M m;

            for (int i = 0; i < SIZE; i++)
            {

                int maxw = i;
                int maxk = i;

                //Wyszukiwanie najwiekszego elementu w macierzy
                for (int j = i; j < SIZE; j++)
                {
                    for (int k = i; k < SIZE; k++)
                    {
                        if (Bigger(ABS(mCopy[j,k]) , ABS(mCopy[maxw,maxk])))
                        {
                            maxw = j;
                            maxk = k;
                        }
                    }
                }


                //Zamiana wierszy
                for (int j = 0; j < SIZE; j++)
                {
                    m = mCopy[i,j];
                    mCopy[i, j] = mCopy[maxw, j];
                    mCopy[maxw, j] = m;
                }


                //Zamiana kolumn
                for (int j = 0; j < SIZE; j++)
                {
                    m = mCopy[j, i];
                    mCopy[j, i] = mCopy[j, maxk];
                    mCopy[j, maxk] = m;
                }

                //Zamiana wektora 
                m = wCopy[i];
                wCopy[i] = wCopy[maxw];
                wCopy[maxw] = m;
            
                //prawdziwy wektor pomoc
                pomoc = pwp[i];
                pwp[i] = pwp[maxk];
                pwp[maxk] = pomoc;

                //Schodki
                for (int j = i + 1; j < SIZE; j++)
                {
                    m = Divide(mCopy[j, i], mCopy[i, i]);
                    wCopy[j] = Substract(wCopy[j], Multiply(m, wCopy[i]));
                    for (int k = i; k < SIZE; k++)
                    {
                        mCopy[j, k] = Substract(mCopy[j, k], Multiply(m, mCopy[i, k]));
                    }
                }




            }

            //Wyliczenie X poprzestawianego
            for (int i = SIZE - 1; i >= 0; i--)
            {
                m = (M)Convert.ChangeType(0, typeof(M));
                for (int j = i + 1; j < SIZE; j++)
                {
                    m = Add(m, Multiply(mCopy[i, j], X[j]));
                }
                X[i] = Divide(Substract(wCopy[i], m), mCopy[i, i]);
            }


            M[] Xd = new M[SIZE];

            for (int j = 0; j < SIZE; j++)
            {
                Xd[pwp[j]] = X[j];
            }

            //Wyliczenie B majac wyliczone Xd i orginalna macierz :)
            for (int i = 0; i < SIZE; i++)
            {
                m = (M)Convert.ChangeType(0, typeof(M));
                for (int j = 0; j < SIZE; j++)
                {
                    m = Add(m, Multiply(mOrig[i, j], Xd[j]));
                }
                B[i] = m;
            }

        }

     }
}
