using Altkom.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.WebApiService.Services
{
    public interface IStationsService
    {

        IList<Station> GetStations();

        Station GetStation(int stationId);

        Station GetStation(string name);

        IList<Bike> GetBikesByStation(int stationId);
    } 
}
