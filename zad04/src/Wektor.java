import java.io.FileNotFoundException;
import java.io.PrintWriter;

public class Wektor {

    public double[] wektor;
    public int rozmiar;
    public Wektor(int rozmiar)
    {
        this.rozmiar = rozmiar;
        wektor = new double[rozmiar];
        WyzerujWektor();
        wektor[rozmiar - 1] = -1;
    }



    public Wektor(double [] wektor)
    {
        this.rozmiar = wektor.length;
        this.wektor = wektor;

    }


    public void WyzerujWektor()
    {
        for (int i = 0; i < rozmiar; i++)
            wektor[i] = 0;
    }

    public  void WyswietlWektor()
    {
        for(int i=0;i<rozmiar;i++)
        {
            System.out.println(wektor[i]);
        }

    }

    public void SkopiujDo(Wektor w)
    {
        for (int i = 0; i < rozmiar; i++)
            w.wektor[i] = (double)this.wektor[i];
    }

    public double ObliczBladZ(Wektor w)
    {
        double wynik;
        Wektor pom = new Wektor(rozmiar);
        pom.WyzerujWektor();

        for(int i=0;i<rozmiar;i++)
        {
            pom.wektor[i] = wektor[i] - w.wektor[i];
            //  Console.WriteLine(pom.wektor[i] + "   " + wektor[i] + "   " + w.wektor[i]);
            if (pom.wektor[i] < 0)
                pom.wektor[i] *= (double)-1;
        }

        wynik = pom.wektor[0];
        for(int i=1;i<rozmiar;i++)
        {
            if (pom.wektor[i] > wynik)
                wynik = pom.wektor[i];

        }


        return wynik;
    }

    public double WyliczanieDlugosciWektora(Wektor w2)
    {

        double m = 0;
        double m2 = 0;
        for (int i = 0; i < rozmiar; i++)
        {
            m += wektor[i]* wektor[i];
            m2 += w2.wektor[i] * w2.wektor[i];
        }
        double wynik;
        double wynik2;
        wynik = Math.sqrt(m);
        wynik2 = Math.sqrt(m2);

        if (wynik - wynik2 > 0)
            return wynik - wynik2;
        else
            return (-1) * (wynik - wynik2);
    }

    public void ZapiszDoPliku(String nazwa) throws FileNotFoundException {
        PrintWriter zapis = new PrintWriter(nazwa);
        String text="";

        for (int i=0;i<rozmiar;i++)
        {
            text = String.valueOf(wektor[i]) + "\n";

            zapis.print(text);
        }

        zapis.print("\r\n");
        zapis.print("\r\n");
        zapis.close();
    }
}
