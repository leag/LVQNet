using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LVQLibrary;
using LVQLibrary.Model;
using System.Drawing.Imaging;
using LVQLibrary.Utils;
using LVQClientWithVisualization.Model;
using System.IO;
using LVQClientWithVisualization.Utils;

namespace LVQClientWithVisualization
{
    public partial class Form1 : Form
    {
        List<Dot> _points = new List<Dot>();
        List<Vector> _data = new List<Vector>();
        double _alpha = 0.1;
        Graphics _graphics;
        Bitmap _bitmap;
        LVQAlgorithm _lvq;
        int _numOfCodeVectors = 20;
        int _height = 500;
        int _width = 500;
        double _learningRate;

        public Form1()
        {
            InitializeComponent();
            
            _bitmap = Drawing.DrawBitmap(_height, _width);
            _graphics = Graphics.FromImage(_bitmap);
            pictureBox1.Image = _bitmap;
            //string fileName = "lol.txt";
            string fileName = "iris2D.txt";
            _data = DataFileReader.GetDataFromFile(fileName);
            DataStandarizator.NormalizeData(_data);
            _lvq = new LVQAlgorithm();
            _lvq.trainingData = _data;
            _lvq.testingData = _data;
            _lvq.Initialize(_numOfCodeVectors);
            Drawing.DrawData(_graphics, _data, _width, _height);
            Drawing.DrawCodeVectors(_graphics, _lvq._w);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _lvq.LearnOneEpoch(_learningRate);
            double d = (double)_lvq.Test() / _lvq.trainingData.Count;
            nud_accuracy.Value = System.Convert.ToInt32((100 * d));
            _graphics.Clear(Color.White);
            pictureBox1.Image = _bitmap;
            Drawing.DrawCodeVectors(_graphics, _lvq._w);
            Drawing.DrawData(_graphics, _data, _width, _height);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            //_numOfCodeVectors = System.Convert.ToInt32(nud_numOfCodeVectors.Value);
            get_parameters();
            timer1.Start();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            //_numOfCodeVectors = System.Convert.ToInt32(nud_numOfCodeVectors.Value);
            get_parameters();
            _graphics.Clear(Color.White);
            _lvq = new LVQAlgorithm();
            _lvq.trainingData = _data;
            _lvq.testingData = _data;
            _lvq.Initialize(_numOfCodeVectors);

            Drawing.DrawCodeVectors(_graphics, _lvq._w);

            Drawing.DrawData(_graphics,_data, _width, _height);
            pictureBox1.Image = _bitmap;
        }

        private void get_parameters()
        {
            _numOfCodeVectors = System.Convert.ToInt32(nud_numOfCodeVectors.Value);
            _learningRate = System.Convert.ToDouble(nud_learningRate.Value);
        }
    }
}
