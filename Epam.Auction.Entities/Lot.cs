using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.Entities
{
    public class Lot
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public byte[] Image { get; set; }

        public Guid UserId { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
