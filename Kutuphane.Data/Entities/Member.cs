using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kutuphane.Data.Entities
{
    public class Member : BaseDataSet
    {
        public string Name { get; set; }
        public short Age { get; set; }
        public string Adress { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
