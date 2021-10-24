using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.OnlyGeometry;

namespace Edytor.Relations
{
    public interface IRelation : IDrawable
    {
        public bool IsRelation();
        public bool RecursivelyRepareRelation(
            List<PolygonVertex> Z,
            Stack<IRelation> S,
            Func<List<PolygonVertex>, Stack<IRelation>, bool> recursiveFunction);
        public void DisposeRelation();
    }
}
