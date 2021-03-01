using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutuphane.Data.Entities
{
    public abstract class BaseDataSet
    {
        public long Id { get; set; }
        public DateTime RegisterationTime { get; set; }
    }
}
