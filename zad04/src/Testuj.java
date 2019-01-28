public class Testuj {
    public static Wektor CzyDobrzeObliczyloWektor(Macierz test, Wektor X)
    {
        Wektor wynik = new Wektor(test.rozmiarMacierzy);
        wynik.WyzerujWektor();

        for (int i = 0; i < test.rozmiarMacierzy; i++)
        {
            for (int j = 0; j < test.rozmiarMacierzy; j++)
            {
                wynik.wektor[i] += test.macierz[i][ j] * X.wektor[j];
            }
        }

        return wynik;

    }
}
