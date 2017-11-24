using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Hash { get; set; }

        public Guid Salt { get; set; }
    }
}
