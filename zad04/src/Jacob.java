public class Jacob {
    public static Wektor Jacobe(Macierz M,Wektor V,int p)
    {
        //Nasz wynik i pomoc do obliczania prezycji
        Wektor X1 = new Wektor(M.rozmiarMacierzy);
        Wektor X2 = new Wektor(M.rozmiarMacierzy);
        double suma = 0;
        X1.WyzerujWektor();
        X2.WyzerujWektor();
        double precyzja = Math.pow(10, p); // nasza obliczona precyzja
        int rozmiar = M.rozmiarMacierzy; // Rozmiar macierzy wszystkie przypadki


        int z = 0;

        do
        {
            X1.SkopiujDo(X2); //X2=X1;
            // X1.WyswietlWektor();
            for (int i = 0; i < rozmiar; i++)
            {
                suma = 0.0;

                for (int j = 0; j < rozmiar; j++)
                {

                    if (i != j)
                    {
                        suma += M.macierz[i][j] * X2.wektor[j];

                    }
                }

                suma *=(double)-1;
                suma = suma + V.wektor[i];

                X1.wektor[i] = (double)(suma / M.macierz[i][ i]);

            }
            z++;

        } while (X1.ObliczBladZ(X2)>precyzja);

        //Blad to roznica wektora X1 i X2

        return X1;

    }

}
