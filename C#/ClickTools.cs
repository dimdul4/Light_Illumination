using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using howto_floodfill;

namespace howto_click
{
    class clickTools
    {
         public static void click_mouse(Bitmap bm, int eX, int eY, Color col2, PictureBox pictureBox1,
            Int32 part,int n,int AN,double Angle, int Xc, int Yc)
        {
            double radius, cos, sin, arccos, arcsin, tekyshii_gradus;
            int ugol;
            int alpha;
            alpha = 360 / part;
            double PI = 3.14159265;
            int[,] a = new int[17, n];
            AN = 3;
            n = 360 / AN;//120
            Angle = 2 * PI / n;
            Xc = pictureBox1.Width / 2;   // Координаты центра
            Yc = pictureBox1.Height / 2;
            radius = (double)(Math.Sqrt(Convert.ToDouble(Math.Pow((Xc - eX), 2) + Math.Pow((Yc - eY), 2))));
            cos = (double)(eX - Xc) / (radius);
            sin = (double)(Yc - eY) / (radius);
            arccos = Math.Acos(cos) * 180 / PI;
            arcsin = Math.Asin(sin) * 180 / PI;

            Color old_color = bm.GetPixel(eX, eY);
            if (arccos > 0 && arcsin > 0)
            {
                tekyshii_gradus = arccos;
                Color cvet = new Color();
                ugol = (int)tekyshii_gradus;
                int x0, y0;
                for (int i = 0; i < part; i++)
                {
                    x0 = Xc + Convert.ToInt32((radius - Angle) * Math.Cos(tekyshii_gradus * PI / 180));
                    y0 = Yc - Convert.ToInt32((radius - Angle) * Math.Sin(tekyshii_gradus * PI / 180));
                    tekyshii_gradus = tekyshii_gradus + alpha;
                    cvet = bm.GetPixel(x0, y0);
                    if ((cvet.R == 0) && (cvet.G == 0) && (cvet.B == 0)) return;
                    if ((old_color.R == 0) && (old_color.G == 0) && (old_color.B == 0)) return;
                    FloodTools.FloodFill(bm, x0, y0, col2);
                    pictureBox1.Refresh();
                }
            }
            if (arccos > 0 && arcsin < 0)
            {
                tekyshii_gradus = 360 - arccos;

                ugol = (int)tekyshii_gradus;
                Color cvet = new Color();
                int x0, y0;
                for (int i = 0; i < part; i++)
                {
                    x0 = Xc + Convert.ToInt32((radius - Angle) * Math.Cos(tekyshii_gradus * PI / 180));
                    y0 = Yc - Convert.ToInt32((radius - Angle) * Math.Sin(tekyshii_gradus * PI / 180));
                    tekyshii_gradus = tekyshii_gradus + alpha;
                    cvet = bm.GetPixel(x0, y0);
                    if ((cvet.R == 0) && (cvet.G == 0) && (cvet.B == 0)) return;
                    if ((old_color.R == 0) && (old_color.G == 0) && (old_color.B == 0)) return;
                    FloodTools.FloodFill(bm, x0, y0, col2);
                    pictureBox1.Refresh();
                }
            }
        }
    }
}