using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt03
{
    class Agent
    {
        public int t;
        public int n;

        public Agent(int t,int n)
        {
            this.t = t;
            this.n = n;
        }

        public void WyswietlAgenta()
        {
            Console.Write( t + "" + n+"  ");
        }
    }
}
