using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.Geometry
{
    public class Edge : IDrawable
    {
        public enum Relation
        {
            None,
            FixedLength,
            LengthTheSameAs
        }

        public Vertex Start { get; set; }
        public Vertex End { get; set; }

        public Edge(Vertex s, Vertex e)
        {
            Start = s;
            End = e;
        }

        public Edge(Point s, Point e)
        {
            Start = new Vertex(s);
            End = new Vertex(e);
        }

        public void DrawShape(Graphics g)
        {
            Start.DrawShape(g);
            g.DrawEdge(Start, End);
        }

        public void Move(Point start, Point end)
        {
            Start.Move(start, end);
            End.Move(start, end);
        }

        public IDrawable Hit(Point point)
        {
            if (Start.Hit(point) != null)
                return Start;
            if (End.Hit(point) != null)
                return End;
            return null;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
