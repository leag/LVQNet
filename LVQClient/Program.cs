using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVQLibrary.Model;
using LVQLibrary.Utils;
using LVQLibrary;

namespace LVQClient
{
    class Program
    {
        static List<Vector> makeTrainingSet(List<List<Vector>> d, int x)
        {
            List<Vector> list = new List<Vector>();
            for (int i = 0; i < d.Count; i++)
            {
                if (i != x)
                    list.AddRange(d[i]);
            }
            return list;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            string path = "iris.txt";
            //string path = "diabetes.txt";
            //string path = "vote.txt";
            //string path = "iris2D.txt";
            int N = 10; //k - fold
            int M = 1; //liczba wektorów kodujących
            List<List<Vector>> d = new List<List<Vector>>();
            List<Vector> _data = DataFileReader.GetDataFromFile(path);
            List<Vector> tempData = _data.ToList();
            int b = _data.Count() / N;
            for (int i = 0; i < N; i++)
            {
                d.Add(new List<Vector>());
                for (int j = 0; j < b; j++)
                {
                    int x = random.Next(tempData.Count);
                    d.Last().Add(tempData[x]);
                    tempData.RemoveAt(x);
                }
            }
            d.Last().AddRange(tempData);
            int num = 0;
            for (int i = 0; i < N; i++)
            {
                LVQAlgorithm _lvq = new LVQAlgorithm();
                _lvq.trainingData = makeTrainingSet(d, i);
                _lvq.testingData = d[i];
                _lvq.Initialize(M);
                _lvq.Learn(100);
                num += _lvq.Test();
            }
            Console.WriteLine("Crossvalidation {0}-folds", N);
            Console.WriteLine("Number of Codebooks Vectors: {0}", M);
            Console.WriteLine("Number of Instances : {0}", _data.Count);
            Console.WriteLine("Correctly Classified Instances : {0}", num);
            Console.WriteLine("Incorrectly Classified Instances : {0}", _data.Count - num);
            Console.WriteLine("Accuracy: {0:F5}%", 100 * (double)num / _data.Count);
            Console.ReadKey();
        }
    }
}
