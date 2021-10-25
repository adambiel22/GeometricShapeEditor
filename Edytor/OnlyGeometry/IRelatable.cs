using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edytor.Relations;

namespace Edytor.OnlyGeometry
{
    public interface IRelatable
    {
        public void SetRelation(IRelation relation, bool ifRepare = true);
        public bool IsRelationFullfiled();
    }
}
