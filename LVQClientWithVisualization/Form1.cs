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

namespace LVQClientWithVisualization
{
    public partial class Form1 : Form
    {
        List<Dot> points = new List<Dot>();
        List<Vector> data = new List<Vector>();
        Graphics g;
        Random rnd = new Random();
        int height;
        int width;
        Image image;
        LVQAlgorithm lvq;
        public Form1()
        {
            InitializeComponent();
            height = 500;
            width = 500;
            Bitmap bitmap = new Bitmap(height, width, PixelFormat.Format24bppRgb);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }

            image = bitmap;
            g = Graphics.FromImage(image);
            pictureBox1.Image = image;

            data = DataFileReader.GetDataFromFile("lol.txt");

            lvq = new LVQAlgorithm();
            lvq.trainingData = data;
            lvq.testingData = data;
            lvq.Initialize(20);

            foreach (Vector vec in lvq._w)
            {
                drawBigDot(g, System.Convert.ToInt32(vec.x[0]), System.Convert.ToInt32(vec.x[1]), vec.C);
            }

            DrawData(g);
        }

        void drawDot(Graphics g, int x, int y)
        {
            int d = 2;
            g.DrawEllipse(Pens.Red, new Rectangle(x - d / 2, y - d / 2, d, d));
        }

        void drawBigDot(Graphics g, int x, int y)
        {
            int d = 10;

            for (int i = 0; i < d; i++)
                g.DrawEllipse(Pens.Black, new Rectangle(x - i / 2, y - i / 2, i, i));
        }

        void drawBigDot(Graphics g, int x, int y, int c)
        {
            int d = 10;

            if (c == 1)
                for (int i = 0; i < d; i++)
                    g.DrawEllipse(Pens.Red, new Rectangle(x - i / 2, y - i / 2, i, i));

            if (c == 2)
                for (int i = 0; i < d; i++)
                    g.DrawEllipse(Pens.Green, new Rectangle(x - i / 2, y - i / 2, i, i));

            if (c == 3)
                for (int i = 0; i < d; i++)
                    g.DrawEllipse(Pens.Blue, new Rectangle(x - i / 2, y - i / 2, i, i));

            if (c == 4)
                for (int i = 0; i < d; i++)
                    g.DrawEllipse(Pens.Orange, new Rectangle(x - i / 2, y - i / 2, i, i));
        }

        void drawDot(Graphics g, int x, int y, int C)
        {
            int d = 4;
            if (C == 1)
                g.DrawEllipse(Pens.Red, new Rectangle(x - d / 2, y - d / 2, d, d));
            if (C == 2)
                g.DrawEllipse(Pens.Green, new Rectangle(x - d / 2, y - d / 2, d, d));
            if (C == 3)
                g.DrawEllipse(Pens.Blue, new Rectangle(x - d / 2, y - d / 2, d, d));
            if (C == 4)
                g.DrawEllipse(Pens.Orange, new Rectangle(x - d / 2, y - d / 2, d, d));
        }

        void DrawData(Graphics g, int C)
        {
            foreach (Dot p in points)
                drawDot(g, p.x, p.y, C);
        }

        void DrawData(Graphics g)
        {
            foreach (Vector vec in data)
            {
                drawDot(g, (int)vec.x[0], (int)vec.x[1], vec.C);
            }
        }
        void drawTriangle(Graphics g, int height, int width)
        {
            g.DrawLine(Pens.Black, width / 2, 50, width - 50, height - 50);
            g.DrawLine(Pens.Black, width / 2, 50, 50, height - 50);
            g.DrawLine(Pens.Black, 50, width - 50, width - 50, height - 50);
        }

        void GenerateData(int startX, int endX, int startY, int endY, int N, int c)
        {
            for (int i = 0; i < N; i++)
            {
                int a = rnd.Next(startX, endX);
                int b = rnd.Next(startY, endY);
                points.Add(new Dot { x = a, y = b });
                data.Add(new Vector(new List<double> { a, b }) { C = c });
            }


        }

        void SaveDataToFile(string fileName)
        {
            string text = "";
            foreach (Vector v in data)
                text += v.x[0] + " " + v.x[1] + " " + v.C + Environment.NewLine;
            File.WriteAllText(fileName, text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lvq.LearnOneEpoch();
            g.Clear(Color.White);
            pictureBox1.Image = image;
            foreach (Vector vec in lvq._w)
            {
                drawBigDot(g, System.Convert.ToInt32(vec.x[0]), System.Convert.ToInt32(vec.x[1]), vec.C);
            }

            DrawData(g);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            g.Clear(Color.White);
            lvq = new LVQAlgorithm();
            lvq.Initialize(20);

            foreach (Vector vec in lvq._w)
            {
                drawBigDot(g, System.Convert.ToInt32(vec.x[0]), System.Convert.ToInt32(vec.x[1]), vec.C);
            }

            DrawData(g);
            pictureBox1.Image = image;
        }
    }
}
