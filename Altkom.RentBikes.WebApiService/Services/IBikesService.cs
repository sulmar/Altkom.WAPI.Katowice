using Altkom.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.WebApiService.Services
{
    public interface IBikesService
    {
        IList<Bike> GetBikes();

        Bike GetBike(int bikeId);

        Bike GetBike(string number);

        void Update(Bike bike);

        void Add(Bike bike);

        void Delete(int bikeId);

    }
}
