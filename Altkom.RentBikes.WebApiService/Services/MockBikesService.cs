using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Altkom.RentBikes.Models;

namespace Altkom.RentBikes.WebApiService.Services
{
    public class MockBikesService : IBikesService
    {
        private List<Bike> _bikes = new List<Bike>
            {
                new Bike { BikeId = 1, Number = "R001" },
                new Bike { BikeId = 2, Number = "R002" },
                new Bike { BikeId = 3, Number = "R003" },
            };

        public void Add(Bike bike)
        {
            if (_bikes.Exists(x => x.Number == bike.Number))
            {
                throw new DuplicateNumberException();
            }

            var newBikeId = _bikes.Max(x => x.BikeId) + 1;

            bike.BikeId = newBikeId;

            _bikes.Add(bike);
        }

        public void Delete(int bikeId)
        {
            var foundBike = GetBike(bikeId);

            if (foundBike == null)
                throw new ArgumentException("Not found");

            _bikes.Remove(foundBike);
        }

        public Bike GetBike(string number)
        {
            return _bikes.SingleOrDefault(p => p.Number == number);
        }

        public Bike GetBike(int bikeId)
        {
            return _bikes.SingleOrDefault(p => p.BikeId == bikeId);
        }

        public IList<Bike> GetBikes()
        {
            return _bikes.Take(1000).ToList();
        }

        public void Update(Bike bike)
        {
            var foundBike = GetBike(bike.BikeId);

            if (foundBike == null)
                throw new ArgumentException("Not found");
        
            var index = _bikes.IndexOf(foundBike);

            _bikes[index] = bike;

        }
    }
}