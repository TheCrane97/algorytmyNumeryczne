using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class DzialaniaMatematyczne
    {
        public static M Divide<M>(M a, M b)
        {

            if(a is float)
            {
                return (M)Convert.ChangeType((float)Convert.ChangeType(a,typeof(float))/ (float)Convert.ChangeType(b, typeof(float)), typeof(M));
            }
            else
            {
                return (M)Convert.ChangeType((double)Convert.ChangeType(a, typeof(double)) / (double)Convert.ChangeType(b, typeof(double)), typeof(M));

            }

        }

        public static M Multiply<M>(M a, M b)
        {

            if (a is float)
            {
                return (M)Convert.ChangeType((float)Convert.ChangeType(a, typeof(float)) * (float)Convert.ChangeType(b, typeof(float)), typeof(M));
            }
            else
            {
                return (M)Convert.ChangeType((double)Convert.ChangeType(a, typeof(double)) * (double)Convert.ChangeType(b, typeof(double)), typeof(M));

            }
        }


        public static M Add<M>(M a, M b)
        {

            if (a is float)
            {
                return (M)Convert.ChangeType((float)Convert.ChangeType(a, typeof(float)) + (float)Convert.ChangeType(b, typeof(float)), typeof(M));
            }
            else
            {
                return (M)Convert.ChangeType((double)Convert.ChangeType(a, typeof(double)) + (double)Convert.ChangeType(b, typeof(double)), typeof(M));

            }

        }

        public static M Substract<M>(M a, M b)
        {
            if (a is float)
            {
                return (M)Convert.ChangeType((float)Convert.ChangeType(a, typeof(float)) - (float)Convert.ChangeType(b, typeof(float)), typeof(M));
            }
            else
            {
                return (M)Convert.ChangeType((double)Convert.ChangeType(a, typeof(double)) - (double)Convert.ChangeType(b, typeof(double)), typeof(M));

            }

        }


        public static M ABS<M>(M a)
        {

            if (a is float)
            {
                if ((float)Convert.ChangeType(a, typeof(float)) > 0)
                    return (M)Convert.ChangeType((float)Convert.ChangeType(a, typeof(float)), typeof(M));
                else
                    return (M)Convert.ChangeType((float)Convert.ChangeType(a, typeof(float)) * (float)Convert.ChangeType(-1, typeof(float)), typeof(M));
                
            }
            else
            {
                if ((double)Convert.ChangeType(a, typeof(double)) > 0)
                    return (M)Convert.ChangeType((double)Convert.ChangeType(a, typeof(double)), typeof(M));
                else
                    return (M)Convert.ChangeType((double)Convert.ChangeType(a, typeof(double)) * (double)Convert.ChangeType(-1, typeof(double)), typeof(M));

            }

        }

        public static bool Bigger<M>(M a, M b)
        {

            if (a is float)
            {
                if ((float)Convert.ChangeType(a, typeof(float)) > (float)Convert.ChangeType(b, typeof(float)))
                    return true;
                else
                    return false;

            }
            else
            {
                if ((double)Convert.ChangeType(a, typeof(double)) > (double)Convert.ChangeType(b, typeof(double)))
                    return true;
                else
                    return false;

            }

        }

    }
}
