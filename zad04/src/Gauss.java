import javax.crypto.Mac;

public class Gauss {

    public Macierz mOrig; //macierz oryginalna
    public Wektor wOrig;  //wektor oryginalny
    public Macierz mCopy; // kopia macierzy
    public Wektor wCopy;  //kopia wektora
    public int SIZE;        //wymiar macierzy

    public Gauss(Macierz mOrig, Wektor wOrig, Macierz mCopy, Wektor wCopy, int wymiar)
    {
        this.mOrig = mOrig;
        this.wOrig = wOrig;
        this.mCopy = mCopy;
        this.wCopy = wCopy;
        SIZE = wymiar;
        double[][] matrix = mCopy.macierz;
    }


    ///Gauss bez wyboru elementu podstawowego
    public Wektor GaussBWP()
    {
        Wektor X = new Wektor(SIZE);
        X.WyzerujWektor();

        TworzenieMacierzySchodkowej(0);
        WyliczanieX(X);
        return X;

    }
    ///Gauss bez wyboru elementu podstawowego zoptymalizowany
    public Wektor GaussBWPO()
    {
        Wektor X = new Wektor(SIZE);
        X.WyzerujWektor();

        TworzenieMacierzySchodkowejO(0);
        WyliczanieXO(X);
        return X;

    }


    public Wektor GaussCWP() //Gauss z czesciowym wyborem elementu podstawowego
    {
        double m;
        Wektor X = new Wektor(SIZE);
        X.WyzerujWektor();
        for (int i = 0; i < SIZE; i++) {

            int max = i;

            //Wyszukanie najwiekszego elementu
            for (int j = i + 1; j < SIZE; j++) {
                if (ABS(mCopy.macierz[j][i]) > ABS(mCopy.macierz[max][i])) {
                    max = j;
                }
            }

            double temp;
            //SWAP macierzy
            for (int j = 0; j < SIZE; j++) {
                temp = mCopy.macierz[i][j];
                mCopy.macierz[i][j] = mCopy.macierz[max][j];
                mCopy.macierz[max][j] = temp;
            }

            //SWAP wektora
            temp = wCopy.wektor[i];
            wCopy.wektor[i] = wCopy.wektor[max];
            wCopy.wektor[max] = temp;


            TworzenieMacierzySchodkowej(i);
        }

        WyliczanieX(X);


        return X;

    }

    void TworzenieMacierzySchodkowej(int i)
    {
        double m;
        for (int k = 0; k < SIZE - 1; k++)
        {
            for (i = k + 1; i < SIZE; i++) {

                    m = mCopy.macierz[i][k] / mCopy.macierz[k][k];
                    wCopy.wektor[i] = wCopy.wektor[i] - (m * wCopy.wektor[k]);
                    for (int j = k; j < SIZE; j++) {
                        mCopy.macierz[i][j] = mCopy.macierz[i][j] - (m * mCopy.macierz[k][j]);
                    }

            }
        }

    }

        void TworzenieMacierzySchodkowejO(int i)
        {
            double m;
            for (int k = 0; k < SIZE - 1; k++)
            {
                for (i = k + 1; i < SIZE; i++)
                {
                    if (mCopy.macierz[i][k] != 0.0) {
                    m = mCopy.macierz[i][ k]/ mCopy.macierz[k][k];
                    wCopy.wektor[i] = wCopy.wektor[i]- (m* wCopy.wektor[k]);
                    for (int j = k; j < SIZE; j++)
                    {
                        mCopy.macierz[i][ j] = mCopy.macierz[i][ j]-(m* mCopy.macierz[k][ j]);
                    }
                    }
                }

            }

        }




    void WyliczanieX(Wektor X)
    {
        double m;
        for (int i = SIZE - 1; i >= 0; i--)
        {
            m = 0;
            for (int j = i + 1; j < SIZE; j++)
            {
                m =m+ (mCopy.macierz[i][ j]* X.wektor[j]);
            }
            X.wektor[i] = (wCopy.wektor[i]- m)/ mCopy.macierz[i][ i];
        }
    }


    void WyliczanieXO(Wektor X)
    {
        double m;
        for (int i = SIZE - 1; i >= 0; i--)
        {
            m = 0;
            for (int j = i + 1; j < SIZE; j++)
            {
                if(mCopy.macierz[i][ j]!=0)
                m =m+ (mCopy.macierz[i][ j]* X.wektor[j]);
            }
            X.wektor[i] = (wCopy.wektor[i]- m)/ mCopy.macierz[i][ i];
        }
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
