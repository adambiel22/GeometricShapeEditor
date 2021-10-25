using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edytor.OnlyGeometry
{
    public static class GraphicsExtention
    {
        public static void DrawPixel(this Graphics g, int x, int y, Color color)
        {
            g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
        }

        

        public static void WuLine(this Graphics g, Vertex p1, Vertex p2, Color color)
        {
            double frac(double y)
            {
                return y - Math.Floor(y);
            }

            if (p1.X == p2.X)
            {
                DrawEdge(g, p1, p2, color);
                return;
            }
            
            if (Math.Abs(p1.Y - p2.Y) < 5*Math.Abs(p1.X - p2.X))
            {
                if (p1.X > p2.X)
                {
                    (p1, p2) = (p2, p1);
                }
                double m = (double)(p1.Y - p2.Y) / (double)(p1.X - p2.X);
                double y = p1.Y;
                for (int x = p1.X; x < p2.X; x++)
                {
                    double c1 = 1.0 - frac(y);
                    double c2 = frac(y);
                    DrawPixel(g, x, (int)y, Color.FromArgb((int)(c1 * color.A), color));
                    DrawPixel(g, x, (int)y + 1, Color.FromArgb((int)(c2 * color.A), color));
                    y += m;
                }
            }
            else
            {
                DrawEdge(g, p1, p2, color);
                return;
                //double m = (double)(p1.Y - p2.Y) / (double)(p1.X - p2.X);
                //double x = p1.X;
                //for (int y = p1.Y; y < p2.Y; y += Math.Sign(m))
                //{
                //    double c1 = 1.0 - frac(x);
                //    double c2 = frac(x);
                //    DrawPixel(g, (int)x, (int)y, Color.FromArgb((int)(c1 * color.A), color));
                //    DrawPixel(g, (int)x + 1, (int)y, Color.FromArgb((int)(c2 * color.A), color));
                //    x += 1.0 / m;
                //}
            }

        }

        public static void WuCircle(this Graphics g, int x_1, int y_1, int R, Color color)
        {
            double D(int R, double y)
            {
                return Math.Ceiling(Math.Sqrt(R * R - y * y)) - Math.Sqrt(R * R - y * y);
            }

            {
                int x = R;
                int y = 0;
                double T = 0;
                DrawPixel(g, x + x_1, y + y_1, color);
                while (x > y)
                {
                    y++;
                    if (D(R, y) < T)
                        x--;
                    DrawPixel(g, x + x_1, y + y_1, Color.FromArgb((int)((1.0 - (double)D(R, y)) * (double)color.A), color));
                    DrawPixel(g, x - 1 + x_1, y + y_1, Color.FromArgb((int)(D(R, y) * (double)color.A), color));
                    T = D(R, y);
                }
            }
            //{
            //    int x = R;
            //    int y = 0;
            //    int i = 1;
            //    double T = 0;
            //    DrawPixel(g, x + x_1, y + y_1, color);
            //    while (x > y)
            //    {
            //        y+=1;
            //        if (D(R, y) < T)
            //            x-=1;
            //        DrawPixel(g, x + x_1, y + y_1, Color.FromArgb((int)((1.0 - (double)D(R, y)) * (double)color.A), color));
            //        DrawPixel(g, x - 1 + x_1, y + y_1, Color.FromArgb((int)(D(R, y) * (double)color.A), color));
            //        T = D(R, y);
            //    }
            //}
        }

        public static void DrawEdge(this Graphics g, Vertex p1, Vertex p2, Color color)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            int x = p1.X;
            int y = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            DrawPixel(g, x, y, color);
            //[0, pi/4)
            if (dx > 0 && dy >= 0 && dy < dx)
            {
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrNE = 2 * (dy - dx);

                while (x < x2)
                {
                    x++;
                    if (d < 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrNE;
                        y++;
                    }
                    DrawPixel(g, x, y, color);
                }
            }
            //[pi/4, pi/2)
            else if (dx > 0 && dy > 0 && dy >= dx)
            {
                int d = dy - 2 * dx;
                int incrN = -2 * dx;
                int incrNE = 2 * (dy - dx);

                while (y < y2)
                {
                    y++;
                    if (d > 0)
                    {
                        d += incrN;
                    }
                    else
                    {
                        d += incrNE;
                        x++;
                    }
                    DrawPixel(g, x, y, color);
                }
            }
            //[pi/2, 3pi/4)
            else if (dx <= 0 && dy > 0 && dy >= -dx)
            {
                int d = -dy - 2 * dx;
                int incrN = -2 * dx;
                int incrNW = -2 * dy - 2 * dx;

                while (y < y2)
                {
                    y++;
                    if (d < 0)
                    {
                        d += incrN;
                    }
                    else
                    {
                        d += incrNW;
                        x--;
                    }
                    DrawPixel(g, x, y, color);
                }
            }
            //[3pi/4, pi)
            else if (dx < 0 && dy > 0 && dy <= -dx)
            {
                int d = -2 * dy - dx;
                int incrW = -2 * dy;
                int incrNW = -2 * dy - 2 * dx;

                while (x > x2)
                {
                    x--;
                    if (d > 0)
                    {
                        d += incrW;
                    }
                    else
                    {
                        d += incrNW;
                        y++;
                    }
                    DrawPixel(g, x, y, color);
                }
            }
            //[pi, 5pi/4)
            else if (dx < 0 && dy <= 0 && dy > dx)
            {
                int d = -2 * dy + dx;
                int incrW = -2 * dy;
                int incrSW = -2 * dy + 2 * dx;

                while (x > x2)
                {
                    x--;
                    if (d < 0)
                    {
                        d += incrW;
                    }
                    else
                    {
                        d += incrSW;
                        y--;
                    }
                    DrawPixel(g, x, y, color);
                }
            }
            //[5pi/4, 3pi/2)
            else if (dx < 0 && dy < 0 && dy <= dx)
            {
                int d = -dy + 2 * dx;
                int incrS = 2 * dx;
                int incrSW = -2 * dy + 2 * dx;

                while (y > y2)
                {
                    y--;
                    if (d > 0)
                    {
                        d += incrS;
                    }
                    else
                    {
                        d += incrSW;
                        x--;
                    }
                    DrawPixel(g, x, y, color);
                }
            }
            //[3pi/2, 7pi/4)
            else if (dx >= 0 && dy < 0 && -dy > dx)
            {
                int d = dy + 2 * dx;
                int incrS = 2 * dx;
                int incrSE = 2 * dy + 2 * dx;

                while (y > y2)
                {
                    y--;
                    if (d < 0)
                    {
                        d += incrS;
                    }
                    else
                    {
                        d += incrSE;
                        x++;
                    }
                    DrawPixel(g, x, y, color);
                }
            }
            //[7pi/4, 2pi)
            else if (dx > 0 && dy < 0 && -dy <= dx)
            {
                int d = 2 * dy + dx;
                int incrE = 2 * dy;
                int incrSE = 2 * dy + 2 * dx;

                while (x < x2)
                {
                    x++;
                    if (d > 0)
                    {
                        d += incrE;
                    }
                    else
                    {
                        d += incrSE;
                        y--;
                    }
                    DrawPixel(g, x, y, color);
                }
            }
        }
    }
}
