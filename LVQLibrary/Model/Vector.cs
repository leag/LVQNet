using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVQLibrary.Model
{
    public class Vector
    {
        public double[] x;

        public int C;

        public Vector(List<double> list)
        {
            x = list.ToArray();
        }

        public Vector()
        {

        }
        public Vector(int n)
        {
            x = new double[n];
        }
        public Vector(int n, Random rnd)
        {
            x = new double[n];
            for (int i = 0; i < n; i++)
                x[i] = rnd.NextDouble() - 0.5;
        }
    }
}
