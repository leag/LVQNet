using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVQLibrary.Model;

namespace LVQLibrary
{
    public class LVQAlgorithm
    {
        public List<Vector> trainingData { get; set; }
        public List<Vector> testingData { get; set; }
        public List<Vector> _w;
        Random _random = new Random();
        public void Initialize(int k)
        {
            _w = new List<Vector>();
            List<Vector> _data = trainingData;
            for (int i = 0; i < k; i++)
            {
                Vector vec = _data[_random.Next(_data.Count)];
                _w.Add(new Vector() { C = vec.C, x = vec.x.ToArray() });
            }
            var arr = _w.ToArray();
            _w = arr.ToList(); ;
        }
        public void Learn(int k)
        {

            double alpha = 0.3;

            for (int i = 0; i < k; i++)
            {
                //alpha *= k - i;
                //alpha = alpha / (1 + alpha);
                foreach (Vector teachVector in trainingData)
                {
                    List<double> d = new List<double>();
                    foreach (Vector w in _w)
                    {
                        d.Add(CalculateDistance(teachVector, w));
                    }
                    int min = d.IndexOf(d.Min());
                    double cc = d[min];
                    if (teachVector.C == _w[min].C)
                    {
                        for (int j = 0; j < _w[min].x.Length; j++)
                        {
                            double roz = teachVector.x[j] - _w[min].x[j];
                            double wag = alpha * (teachVector.x[j] - _w[min].x[j]);
                            _w[min].x[j] += alpha * (teachVector.x[j] - _w[min].x[j]);
                        }
                        double c = CalculateDistance(teachVector, _w[min]);
                        Console.Write("");
                    }
                    else
                    {
                        for (int j = 0; j < _w[min].x.Length; j++)
                        {
                            double roz = teachVector.x[j] - _w[min].x[j];
                            double wag = alpha * (teachVector.x[j] - _w[min].x[j]);
                            _w[min].x[j] -= alpha * (teachVector.x[j] - _w[min].x[j]);
                        }
                        double c = CalculateDistance(teachVector, _w[min]);
                        Console.Write("");
                    }

                }
            }
        }
        public int Test()
        {
            int test = 0;

            foreach (Vector testVector in testingData)
            {
                List<double> d = new List<double>();
                foreach (Vector w in _w)
                {
                    d.Add(CalculateDistance(testVector, w));
                }
                int min = d.IndexOf(d.Min());

                if (testVector.C == _w[min].C)
                {
                    test++;
                }
            }
            return test;
        }
        double CalculateDistance(Vector A, Vector B)
        {
            double s = 0.0;

            for (int i = 0; i < A.x.Length; i++)
            {
                s += Math.Pow(A.x[i] - B.x[i], 2);
            }

            return Math.Sqrt(s);
        }
        public void LearnOneEpoch(double alpha)
        {

            //double alpha = 0.001;
            //double alpha = 0.01;

            //alpha *= k - i;
            foreach (Vector teachVector in trainingData)
            {
                alpha = alpha / (1 + alpha);
                List<double> d = new List<double>();
                foreach (Vector w in _w)
                {
                    d.Add(CalculateDistance(teachVector, w));
                }
                int min = d.IndexOf(d.Min());
                double cc = d[min];
                if (teachVector.C == _w[min].C)
                {
                    for (int j = 0; j < _w[min].x.Length; j++)
                    {
                        double roz = teachVector.x[j] - _w[min].x[j];
                        double wag = alpha * (teachVector.x[j] - _w[min].x[j]);
                        _w[min].x[j] += alpha * (teachVector.x[j] - _w[min].x[j]);
                    }
                    double c = CalculateDistance(teachVector, _w[min]);
                    Console.Write("");
                }
                else
                {
                    for (int j = 0; j < _w[min].x.Length; j++)
                    {
                        double roz = teachVector.x[j] - _w[min].x[j];
                        double wag = alpha * (teachVector.x[j] - _w[min].x[j]);
                        _w[min].x[j] -= alpha * Math.Abs(teachVector.x[j] - _w[min].x[j]);
                    }
                    double c = CalculateDistance(teachVector, _w[min]);
                    Console.Write("");

                    //Console.WriteLine();
                }
            }
        }
    }
}
