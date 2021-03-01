using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutuphane.Data.Entities
{
    public class Member : BaseDataSet
    {
        public string Name { get; set; }
        public short Age { get; set; }
        public string Adress { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
