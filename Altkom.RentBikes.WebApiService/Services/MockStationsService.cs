using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Altkom.RentBikes.Models;

namespace Altkom.RentBikes.WebApiService.Services
{
    public class MockStationsService : IStationsService
    {
        private List<Station> _stations;
        private List<Rent> _rents;
        private List<Bike> _bikes;

        public MockStationsService()
        {
              _stations = new List<Station>
                {// [Station(1), Name="43434"]
                    new Station(1) { StationId = 1, Name = "ST1" },
                    new Station { StationId = 2, Name = "ST2" },
                    new Station { StationId = 3, Name = "ST3" },
                };

             _bikes = new List<Bike>
                {
                    new Bike { BikeId = 1, Number = "R001" },
                    new Bike { BikeId = 2, Number = "R002" },
                    new Bike { BikeId = 3, Number = "R003" },
                };

            _rents = new List<Rent>
                {
                    new Rent
                    {
                        Bike = _bikes[0],
                        RentDateFrom = DateTime.Now,
                        StationFrom = _stations[1],
                        RentDateTo = DateTime.Now.AddMinutes(30),
                        StationTo = _stations[1],
                    },

                    new Rent
                    {
                        Bike = _bikes[1],
                        RentDateFrom = DateTime.Now,
                        StationFrom = _stations[0],
                        RentDateTo = DateTime.Now.AddMinutes(30),
                        StationTo = _stations[1],
                    },

                    new Rent
                    {
                        Bike = _bikes[2],
                        RentDateFrom = DateTime.Parse("2016-05-31 14:30"),
                        StationFrom = _stations[0],
                        RentDateTo = DateTime.Parse("2016-05-31 15:40"),
                        StationTo = _stations[0],
                    },
                };

        }

        public Station GetStation(int stationId)
        {
            return _stations.SingleOrDefault(s => s.StationId == stationId);
        }

        public IList<Station> GetStations()
        {
            return _stations;
        }

        public IList<Bike> GetBikesByStation(int stationId)
        {
            var rents = _rents
                .Where(r => r.StationTo != null)
                .GroupBy(r => r.Bike)
                .Select(g => new {
                    Bike = g.Key,
                    Rents = g.OrderByDescending(x=>x.RentDateTo) });

            return _rents.Select(d => d.Bike).ToList();


            throw new ArgumentNullException();


        }

        public Station GetStation(string name)
        {
            return _stations.SingleOrDefault(d => d.Name == name);
        }
    }
}