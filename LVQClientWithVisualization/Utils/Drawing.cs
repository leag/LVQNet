using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVQClientWithVisualization.Model;
using LVQLibrary.Model;
using System.Drawing.Imaging;

namespace LVQClientWithVisualization.Utils
{
    public static class Drawing
    {
        public static void DrawDot(Graphics _graphics, int x, int y)
        {
            int d = 2;
            _graphics.DrawEllipse(Pens.Red, new Rectangle(x - d / 2, y - d / 2, d, d));
        }

        public static void DrawDot(Graphics _graphics, int x, int y, int C)
        {
            int d = 4;
            if (C == 1)
                _graphics.DrawEllipse(Pens.Red, new Rectangle(x - d / 2, y - d / 2, d, d));
            if (C == 2)
                _graphics.DrawEllipse(Pens.Green, new Rectangle(x - d / 2, y - d / 2, d, d));
            if (C == 3)
                _graphics.DrawEllipse(Pens.Blue, new Rectangle(x - d / 2, y - d / 2, d, d));
            if (C == 4)
                _graphics.DrawEllipse(Pens.Orange, new Rectangle(x - d / 2, y - d / 2, d, d));
        }

        public static void DrawBigDot(Graphics _graphics, int x, int y)
        {
            int d = 10;

            for (int i = 0; i < d; i++)
                _graphics.DrawEllipse(Pens.Black, new Rectangle(x - i / 2, y - i / 2, i, i));
        }

        public static void DrawBigDot(Graphics _graphics, int x, int y, int c)
        {
            int d = 10; //srednica punktu
            if (c == 1)
                for (int i = 0; i < d; i++)
                    _graphics.DrawEllipse(Pens.Red, new Rectangle(x - i / 2 * 1, y - i / 2 * 1, i, i));

            if (c == 2)
                for (int i = 0; i < d; i++)
                    _graphics.DrawEllipse(Pens.Green, new Rectangle(x - i / 2, y - i / 2, i, i));

            if (c == 3)
                for (int i = 0; i < d; i++)
                    _graphics.DrawEllipse(Pens.Blue, new Rectangle(x - i / 2, y - i / 2, i, i));

            if (c == 4)
                for (int i = 0; i < d; i++)
                    _graphics.DrawEllipse(Pens.Orange, new Rectangle(x - i / 2, y - i / 2, i, i));
        }

        public static void DrawData(Graphics _graphics, List<Dot> _points, int C)
        {
            foreach (Dot p in _points)
                DrawDot(_graphics, p.x, p.y, C);
        }

        public static void DrawCodeVectors(Graphics graphics, List<Vector> vectors)
        {
            int l = 500;
            int k = 500;
            foreach (Vector vec in vectors)
            {
                Drawing.DrawBigDot(graphics, System.Convert.ToInt32(vec.x[0] * l), System.Convert.ToInt32(vec.x[1] * k), vec.C);
            }
        }

        public static void DrawData(Graphics _graphics, List<Vector> _data, int width, int height)
        {
            foreach (Vector vec in _data)
            {
                DrawDot(_graphics, (int)(vec.x[0] * width), (int)(vec.x[1] * height), vec.C);
            }
        }

        public static Bitmap DrawBitmap(int height, int width)
        {
            Bitmap _bitmap = new Bitmap(height, width, PixelFormat.Format24bppRgb);
            for (int i = 0; i < _bitmap.Height; i++)
            {
                for (int j = 0; j < _bitmap.Width; j++)
                {
                    _bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
            return _bitmap;
        }
    }
}
