import java.io.FileNotFoundException;
import java.util.*;
import java.io.PrintWriter;

public class Macierz {

    public double[][] macierz;
    public List<Agent> struktura ;//= new List<Agent>();
    public int rozmiarMacierzy;
    public int iloscAgentow;

    public Macierz(int iloscAgentow)
    {
        this.iloscAgentow = iloscAgentow;
        StworzStrukture(iloscAgentow);
        rozmiarMacierzy = struktura.size();
        macierz = new double[rozmiarMacierzy][ rozmiarMacierzy];
        WyzerujMacierz();
        WypelnijMacierz();
    }

    public Macierz(double [][] macierz){
        this.macierz = macierz;
        this.rozmiarMacierzy = macierz[0].length;
    }


    void StworzStrukture(int iloscAgentow)
    {
        struktura = new ArrayList<>();

        for (int i = 0; i <= iloscAgentow; i++)
        {
            for (int j = 0; j <= iloscAgentow; j++)
            {
                if (i + j <= iloscAgentow)
                    struktura.add(new Agent(i, j));
            }
        }
    }

    void WyzerujMacierz()
    {
        for(int i=0; i<rozmiarMacierzy;i++)
            for(int j=0;j<rozmiarMacierzy;j++)
                macierz[i][j]=0;
    }

    void WypelnijMacierz()
    {

        int tak, nie, nw;

        for(int i=0;i<rozmiarMacierzy;i++)
        {
            tak = struktura.get(i).t;
            nie = struktura.get(i).n;
            nw = iloscAgentow - tak - nie;

            macierz[i][ i] = (DwumianNeewtona(tak, 2) / DwumianNeewtona(iloscAgentow, 2))
                + (DwumianNeewtona(nw, 2) / DwumianNeewtona(iloscAgentow, 2))
                + (DwumianNeewtona(nie, 2) / DwumianNeewtona(iloscAgentow, 2));

            if (tak >= 1 && nie >= 1)
            {
                macierz[i][FindIndex(tak-1,nie-1)]= (tak * nie) / DwumianNeewtona(iloscAgentow, 2);
            }

            if (tak >= 1 && nw >= 1)
            {
                macierz[i][FindIndex(tak+1,nie)] = (tak * nw) / DwumianNeewtona(iloscAgentow, 2);
            }

            if (nw >= 1 && nie >= 1)
            {

                macierz[i][FindIndex(tak,nie+1)] = (nw * nie) / DwumianNeewtona(iloscAgentow, 2);
            }

        }

    }


    public void OdejmijJedynki()
    {

        for(int i=0;i<rozmiarMacierzy;i++)
        {
            for (int j = 0; j < rozmiarMacierzy ; j++)
                if (i == j)
                {
                    if(macierz[i][j]==1)
                    macierz[i][ j] -= 2;
                        else
                    macierz[i][j] -= 1;
                }
        }

    }


    public double DwumianNeewtona(int n,int k)
    {
        if (n < k)
            return 0;
        else
            return Silnia(n) / (Silnia(k) * Silnia(n - k));
    }

    public double Silnia(int liczba)
    {
        double silnia = 1;

        for (int i = 2; i <= liczba; i++)
            silnia *= i;

        return silnia;

    }

    public int FindIndex(int tak,int nie)
    {
        for(int i=0;i<struktura.size();i++)
        {
            if(struktura.get(i).t==tak && struktura.get(i).n==nie)
                return i;
        }
        return -1;
    }

    public void WyswietlMacierz()
    {
     //   System.out.print("    ");

     //   for (int i = 0; i < struktura.size(); i++)
    //    {
    //        struktura.get(i).WyswietlAgenta();
    //    }
    //    System.out.println();

        for (int i = 0; i < rozmiarMacierzy; i++)
        {
            //struktura.get(i).WyswietlAgenta();
            for (int j = 0; j < rozmiarMacierzy;j++)
            {
                System.out.print(macierz[i][j]+"   ");

            }
            System.out.println();
        }
        System.out.println();

    }

    public void WyswietlStrukture()
    {
        System.out.println();
        for (int i = 0; i < struktura.size(); i++)
        {
            struktura.get(i).WyswietlAgenta();
            System.out.println();
        }

    }


    public void SkopiujDo(Macierz kopia)
    {
        for(int i=0;i<kopia.rozmiarMacierzy;i++)
        {
            for(int j=0;j<kopia.rozmiarMacierzy;j++)
            {
                kopia.macierz[i][ j] = (double)macierz[i][ j];
            }
        }
    }

    public void ZapiszDoPliku(String nazwa) throws FileNotFoundException {

        PrintWriter zapis = new PrintWriter(nazwa);
        String text="";

        for (int i = 0; i < rozmiarMacierzy; i++)
        {
            for (int j = 0; j < rozmiarMacierzy; j++)
            {

                text += String.valueOf(macierz[i][j]) + ";";

            }
            text += "\r\n";
            zapis.print(text);
            text = "";
        }

        zapis.print("\r\n");
        zapis.print("\r\n");
        zapis.close();
    }
}
