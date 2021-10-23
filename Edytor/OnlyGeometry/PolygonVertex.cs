﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edytor.OnlyGeometry
{
    public class PolygonVertex : Vertex
    {
        public Edge NextEdge { get; set; }
        public Edge PrevEdge { get; set; }

        public Polygon ParentPolygon { get; set; }

        public PolygonVertex(Point p, Polygon polygon) : base(p)
        {
            ParentPolygon = polygon;
        }
        public PolygonVertex(int x, int y, Polygon polygon) : base(x, y)
        {
            ParentPolygon = polygon;
        }

    }
}
