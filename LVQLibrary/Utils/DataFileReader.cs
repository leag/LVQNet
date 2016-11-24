using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVQLibrary.Model;
using System.IO;

namespace LVQLibrary.Utils
{
    public static class DataFileReader
    {
        public static List<Vector> GetDataFromFile(string fileName)
        {
            List<Vector> teachingDataList = new List<Vector>();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                int sp = line.Count(x => x.Equals(' '));
                char[] lch = new char[line.Count()];
                line.CopyTo(0, lch, 0, line.Count());
                string l = new string(lch);
                int start = 0;
                List<double> inputs = new List<double>();
                for (int j = 0; j < sp; j++)
                {
                    int end = l.IndexOf(' ');
                    string s = l.Substring(start, end);
                    inputs.Add(System.Convert.ToDouble(s));
                    l = l.Remove(start, end + 1);
                }
                int ev = System.Convert.ToInt32(l.Substring(start, l.Length));
                teachingDataList.Add(new Vector() { x = inputs.ToArray(), C = ev });
            }
            return teachingDataList;
        }
    }
}
