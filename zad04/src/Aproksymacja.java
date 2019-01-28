import java.util.List;

public class Aproksymacja {

    private Double[] rozmiarWektor;
    private Double[] czasWektor;
    private int m;

    Aproksymacja (Double[] rozmiar, Double[] czas, int m) {
        this.rozmiarWektor = rozmiar;
        this.czasWektor = czas;
        this.m = m;
    }


    Macierz generujMacierzAproksymacja() {
        double[][] approxMacierz = new double[m + 1][m + 1];
        for (int i = 0; i <= m; i++)
            for (int j = 0; j <= m; j++)
                approxMacierz[i][j] = s(j + i);

        return new Macierz(approxMacierz);
    }

    Wektor generujWektor() {
        double[] wektor = new double[m + 1];

        for (int i = 0; i <= m; i++)
            wektor[i] = t(i);

        return new Wektor(wektor);
    }

    private double s(int k) {
        double suma = 0;
        for (int i = 0; i < rozmiarWektor.length; i++) {
            suma += Math.pow(rozmiarWektor[i], k);
        }

        return suma;
    }

    private double t(int k) {
        double suma = 0;
        for (int i = 0; i < rozmiarWektor.length; i++) {
            suma += czasWektor[i] * Math.pow(rozmiarWektor[i], k);
        }

        return suma;
    }
    
}
