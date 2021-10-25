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
            List<ISelectable> Z,
            Stack<IRelation> S,
            Func<List<ISelectable>, Stack<IRelation>, bool> recursiveFunction);
        public void DisposeRelation();
    }
}
