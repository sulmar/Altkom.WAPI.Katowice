using Altkom.RentBikes.Models.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.Models
{

    [Validator(typeof(StationValidator))]
    public class Station : Base
    {
        public int StationId { get; set; }

        public string Name { get; set; }

        public Location Location { get; set; }


        public Station()
        {

        }
        public Station(int id)
        {
        }


    }
}
