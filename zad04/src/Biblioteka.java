import org.apache.commons.math3.linear.Array2DRowRealMatrix;
import org.apache.commons.math3.linear.RealMatrix;
import org.apache.commons.math3.linear.DecompositionSolver;
import org.apache.commons.math3.linear.LUDecomposition;
import org.apache.commons.math3.linear.RealVector;
import org.apache.commons.math3.linear.ArrayRealVector;


public class Biblioteka {

    public static Wektor LiczZBiblioteki(Macierz m,Wektor w)
    {
        Wektor wynik = new Wektor(m.rozmiarMacierzy);


        RealMatrix coefficients =new Array2DRowRealMatrix(m.macierz, false);
        DecompositionSolver solver = new LUDecomposition(coefficients).getSolver();
        RealVector constants = new ArrayRealVector(w.wektor, false);
        RealVector solution = solver.solve(constants);


        for(int i=0;i<m.rozmiarMacierzy;i++)
        {
            wynik.wektor[i]=solution.getEntry(i);
        }

        return wynik;
    }


}
