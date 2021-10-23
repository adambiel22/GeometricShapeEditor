using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edytor.OnlyGeometry;

namespace Edytor.GeometryVisualization
{
    public static class GraphicsExtention
    {
        public static void DrawPixel(this Graphics g, int x, int y)
        {
            g.FillRectangle(new SolidBrush(Color.Black), x, y, 1, 1);
        }
        public static void DrawEdge(this Graphics g, Vertex p1, Vertex p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            int x = p1.X;
            int y = p1.Y;
            int x2 = p2.X;
            int y2 = p2.Y;

            DrawPixel(g, x, y);
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
                    DrawPixel(g, x, y);
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
                    DrawPixel(g, x, y);
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
                    DrawPixel(g, x, y);
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
                    DrawPixel(g, x, y);
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
                    DrawPixel(g, x, y);
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
                    DrawPixel(g, x, y);
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
                    DrawPixel(g, x, y);
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
                    DrawPixel(g, x, y);
                }
            }
        }
    }
}
