using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendSql
{
    public interface IMetas<T>
    {
        ICollection<T> Metas { get; set; }
    }
}
