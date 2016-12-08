using Altkom.RentBikes.Models;
using Altkom.RentBikes.WebApiService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Altkom.RentBikes.WebApiService.Controllers
{
    public class StationsController : ApiController
    {
        private IStationsService Service = new MockStationsService();


        [Route("api/Stations/{id:int}", Order = 1)]
        public IHttpActionResult GetStation(int id)
        {
            var station = Service.GetStation(id);

            if (station==null)
            {
                return NotFound();
            }

            return Ok(station);
        }

        //[Route("api/Stations/{name}", Order = 2)]
        //public Station GetStation(string name)
        //{
        //    return Service.GetStation(name);
        //}

        //[Route("api/Stations?lat={lat}&lng={lng}")]
        //public Station GetStationByLocation(double lat, double lng)
        //{
        //    return Service.GetStation(1);
        //}

        //public Station GetStationByLocation([FromUri] Location location)
        //{
        //    return Service.GetStation(1);
        //}

        public IList<Station> GetStations()
        {
            return Service.GetStations();
        }


        //[Route("api/Stations/{id}/Bikes")]
        //public IList<Bike> GetBikesByStation(int id)
        //{
        //    return Service.GetBikesByStation(id);
        //}



        public IHttpActionResult Post(Station station)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: napisz dodawanie 

            return Ok();
        }
    }
}
