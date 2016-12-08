using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.Models
{
    public class Rent : Base
    {
        public int RentId { get; set; }

        public Bike Bike { get; set; }

        public User User { get; set; }

        public Station StationFrom { get; set; }

        public DateTime RentDateFrom { get; set; }

        public Station StationTo { get; set; }

        public DateTime? RentDateTo { get; set; }

    }
}
