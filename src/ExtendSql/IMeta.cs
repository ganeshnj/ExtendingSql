using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendSql
{
    public interface IMeta
    {
        int Id { get; set; }
        string Key { get; set; }
        string Value { get; set; }
    }
}
