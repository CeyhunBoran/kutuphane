using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kutuphane.Data.Entities
{
    public class Transaction : BaseDataSet
    {
        public long BookId { get; set; }
        public long MemberId { get; set; }

        /// <summary>
        /// Teslim alınma beklenilen tarih
        /// </summary>
        public DateTime DueTime { get; set; }

        /// <summary>
        /// Teslim alındığında sisteme yazılacak tarih alanıdır
        /// </summary>
        public DateTime? ReceiveTime { get; set; }

        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
