using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutuphane.Data.Entities.DTO
{
    public class AddTransaction
    {
        public long BookId { get; set; }
        public long MemberId { get; set; }

        /// <summary>
        /// Teslim alınma beklenilen tarih
        /// </summary>
        public DateTime DueTime { get; set; }
    }
}
