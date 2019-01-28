import java.io.FileNotFoundException;
import java.util.List;
import java.util.ArrayList;


public class Main {
    public static void main(String args[]) throws FileNotFoundException {


        List<Double> czasGaussaZoptymalizowanego = new ArrayList<>();
        List<Double> czasGaussa = new ArrayList<>();
        List<Double> czasBiblioteki = new ArrayList<>();
        List<Double> czasSeidel = new ArrayList<>();
        List<Double> rozmiarWektora = new ArrayList<>();
        long millis;


        for (int rozmiar = 20; rozmiar <=30 ; rozmiar+=3)
        {
            System.out.println("\n\n\n____________________________________________________________________________"
                    + "________________________________________________________________________"
                    + "\n AGENTOW: "+rozmiar);
            Macierz m1 = new Macierz(rozmiar);
            Macierz m2 = new Macierz(rozmiar);
            Wektor w1 = new Wektor(m1.rozmiarMacierzy);
            Wektor w2 = new Wektor(m1.rozmiarMacierzy);
            Wektor Z ;
            millis=0;
            m1.OdejmijJedynki();
            m1.SkopiujDo(m2);
            w1.SkopiujDo(w2);




            // m1.ZapiszDoPliku("macierz.txt");<--dane sa oddzielone ";"




            Gauss gauss = new Gauss(m1, w1, m2, w2, m1.rozmiarMacierzy);

            System.out.println("\n\nGAUSS BEZ  WYBORU ELEMENTU PODSTAWOWEGO ZOPTYMALIZOWANE----------------------------------------");
            millis=System.currentTimeMillis();//start czas
            Z = gauss.GaussBWPO();
            millis=System.currentTimeMillis()-millis;//stop czas
            //Z.WyswietlWektor();//wyswietlenie wyniku
            System.out.println("CZAS_________________________________ "+millis);

            rozmiarWektora.add((double)m1.rozmiarMacierzy);
            czasGaussaZoptymalizowanego.add((double)millis);


            System.out.println("\n\nGAUSS BEZ  WYBORU ELEMENTU PODSTAWOWEGO--------------------------------------------------------");
            millis=System.currentTimeMillis();//start czas
            Z = gauss.GaussBWP();
            millis=System.currentTimeMillis()-millis;//stop czas
            //Z.WyswietlWektor();
            System.out.println("CZAS_________________________________ "+millis);


            czasGaussa.add((double)millis);


            System.out.println("\n\nWYNIK Z BIBLIOTEKI APACHE----------------------------------------------------------------------");

            millis=System.currentTimeMillis();//start czas
            Z= Biblioteka.LiczZBiblioteki(m2,w2);
            millis=System.currentTimeMillis()-millis;//stop czas
            //Z.WyswietlWektor();
            System.out.println("CZAS_________________________________ "+millis);


            czasBiblioteki.add((double)millis);

            /*

            System.out.println("GAUSS Z CZESCIOWYM  WYBOREM ELEMENTU PODSTAWOWEGO----------------------------------------");
            Z = gauss.GaussCWP();
            Z.WyswietlWektor();


            System.out.println("JACOB----------------------------------------");
            Z = Jacob.Jacobe(m2, w1, -6);
            Z.WyswietlWektor();



            System.out.println("JACOB----------------------------------------");
            Z = Jacob.Jacobe(m2, w2, -10);
            Z.WyswietlWektor();


            System.out.println("JACOB----------------------------------------");
            Z = Jacob.Jacobe(m2, w2, -14);
            Z.WyswietlWektor();



            System.out.println("SEIDEL----------------------------------------");
            Z = Seidel.Seid(m2, w2, -6);
            Z.WyswietlWektor();


			*/

            System.out.println("\n\nSEIDEL----------------------------------------");
            millis=System.currentTimeMillis();//start czas
            Z = Seidel.Seid(m2, w2, -10);
            millis=System.currentTimeMillis()-millis;//stop czas
            //Z.WyswietlWektor();
            System.out.println("CZAS_________________________________ "+millis);

            czasSeidel.add((double)millis);
            /*


            System.out.println("SEIDEL----------------------------------------");
            Z = Seidel.Seid(m2, w2, -14);
            Z.WyswietlWektor();
            */




        }
        Double[] target = new Double[rozmiarWektora.size()];
        Double[] target1 = new Double[rozmiarWektora.size()];
        Double[] targetG = new Double[rozmiarWektora.size()];
        Double[] targetB = new Double[rozmiarWektora.size()];
        Double[] targetS = new Double[rozmiarWektora.size()];

        for (int i = 0; i < target.length; i++) {
            target[i] = rozmiarWektora.get(i).doubleValue();
            target1[i] = czasGaussaZoptymalizowanego.get(i).doubleValue();
            targetG[i] = czasGaussa.get(i).doubleValue();
            targetB[i] = czasBiblioteki.get(i).doubleValue();
            targetS[i] = czasSeidel.get(i).doubleValue();
        }

        Aproksymacja apro = new Aproksymacja(target,target1,2);
        Aproksymacja aproG = new Aproksymacja(target,targetG,3);
        Aproksymacja aproB = new Aproksymacja(target,targetB,1);
        Aproksymacja aproS = new Aproksymacja(target,targetS,2);
///////////////////////////////////////////////////////////////////////////////// TO PONIZEJ DODALAM
        Macierz mac1;
        Wektor wek1;
        Wektor wynik;
//////////////////////////////////////////////////////////////////////////////////ZOPTYMALIZOWANY:
        mac1 = apro.generujMacierzAproksymacja();
        wek1 = apro.generujWektor();

        double[][] macierz= new double[mac1.rozmiarMacierzy][mac1.rozmiarMacierzy];
        for(int i=0;i< mac1.rozmiarMacierzy;i++)
            for(int j=0;j<mac1.rozmiarMacierzy;j++)
            {
                macierz[i][j]=mac1.macierz[i][j];
            }
        Macierz mac2= new Macierz(macierz);
        Wektor wek2 = new Wektor(mac1.rozmiarMacierzy);
        mac1.SkopiujDo(mac2);
        wek1.SkopiujDo(wek2);

        Gauss gau = new Gauss(mac1, wek1, mac2, wek2, mac1.rozmiarMacierzy);
        wynik=gau.GaussBWPO();//<-- wynik
        System.out.println("\nWspolczynniki dla Gaussa zoptymalizowanego:\t");
        wynik.WyswietlWektor();

        //////////////////////////////////////////////////////////////////////////////////GAUSS:
        mac1 = aproG.generujMacierzAproksymacja();
        wek1 = aproG.generujWektor();

        macierz= new double[mac1.rozmiarMacierzy][mac1.rozmiarMacierzy];
        for(int i=0;i< mac1.rozmiarMacierzy;i++)
            for(int j=0;j<mac1.rozmiarMacierzy;j++)
            {
                macierz[i][j]=mac1.macierz[i][j];
            }
        mac2= new Macierz(macierz);
        wek2 = new Wektor(mac1.rozmiarMacierzy);
        mac1.SkopiujDo(mac2);
        wek1.SkopiujDo(wek2);

        gau = new Gauss(mac1, wek1, mac2, wek2, mac1.rozmiarMacierzy);
        wynik=gau.GaussBWPO();//<-- wynik
        System.out.print("\nWspolczynniki dla Gaussa bez optymalizacji:\t");
        wynik.WyswietlWektor();

        //////////////////////////////////////////////////////////////////////////////////BIBLIOTECZNIE:
        mac1 = aproB.generujMacierzAproksymacja();
        wek1 = aproB.generujWektor();

        macierz= new double[mac1.rozmiarMacierzy][mac1.rozmiarMacierzy];
        for(int i=0;i< mac1.rozmiarMacierzy;i++)
            for(int j=0;j<mac1.rozmiarMacierzy;j++)
            {
                macierz[i][j]=mac1.macierz[i][j];
            }
        mac2= new Macierz(macierz);
        wek2 = new Wektor(mac1.rozmiarMacierzy);
        mac1.SkopiujDo(mac2);
        wek1.SkopiujDo(wek2);

        gau = new Gauss(mac1, wek1, mac2, wek2, mac1.rozmiarMacierzy);
        wynik=gau.GaussBWPO();//<-- wynik
        System.out.print("\nWspolczynniki dla Gaussa z biblioteki:\t");
        wynik.WyswietlWektor();

        //////////////////////////////////////////////////////////////////////////////////SEIDEL::
        mac1 = aproS.generujMacierzAproksymacja();
        wek1 = aproS.generujWektor();

        macierz= new double[mac1.rozmiarMacierzy][mac1.rozmiarMacierzy];
        for(int i=0;i< mac1.rozmiarMacierzy;i++)
            for(int j=0;j<mac1.rozmiarMacierzy;j++)
            {
                macierz[i][j]=mac1.macierz[i][j];
            }
        mac2= new Macierz(macierz);
        wek2 = new Wektor(mac1.rozmiarMacierzy);
        mac1.SkopiujDo(mac2);
        wek1.SkopiujDo(wek2);

        gau = new Gauss(mac1, wek1, mac2, wek2, mac1.rozmiarMacierzy);
        wynik=gau.GaussBWPO();//<-- wynik
        System.out.print("\nWspolczynniki dla Gaussa-Seidela:\t");
        wynik.WyswietlWektor();

    }
}