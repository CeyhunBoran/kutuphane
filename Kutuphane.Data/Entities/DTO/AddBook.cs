using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutuphane.Data.Entities.DTO
{
    public class AddBook
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int NumberOfBooks { get; set; }
    }
}
