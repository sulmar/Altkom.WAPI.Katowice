using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.Models
{
    public class Bike : Base, IDisposable
    {
        public int BikeId { get; set; }

        [Required, MaxLength(10)]
        public string Number { get; set; }

        public Category Category { get; set; }

        [Required]
        public string Color { get; set; }

        public void Dispose()
        {
           /// clear
        }
    }
}
