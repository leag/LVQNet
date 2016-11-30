using LVQLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVQLibrary.Utils
{
    public static class DataStandarizator
    {
        public static void NormalizeData(List<Vector> data)
        {
            List<double> values = new List<double>();
            foreach(Vector vec in data)
            {
                values.AddRange(vec.x);
            }
            //for (int i = 0; i < data.Count; i++)
            foreach(Vector vec in data)
            {
                for(int i = 0; i < 2; i++)
                    vec.x[i] = (vec.x[i] - values.Min()) / (values.Max() - values.Min());
            }
        }
    }
}
