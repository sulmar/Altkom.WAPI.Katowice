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
    public class BikesController : ApiController
    {
        private IBikesService BikesService;

        public BikesController()
        {
            BikesService = new MockBikesService();
        }

        public BikesController(IBikesService service)
        {
            BikesService = service;
        }

        public IList<Bike> GetBikes()
        {
            return BikesService.GetBikes();
        }


        [HttpGet]
        public Bike Found(int id)
        {
            return BikesService.GetBike(id);
        }

        //public Bike Get(int id)
        //{
        //    return BikesService.GetBike(id);
        //}

        [HttpPost]
        [Authorize]
        public IHttpActionResult Add(Bike bike)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                BikesService.Add(bike);
            }

            catch(DuplicateNumberException e)
            {
                return BadRequest();
            }

            string uri = Url.Link("DefaultApi", new { id = bike.BikeId });

            return Created(uri, bike);
        }


        public void Delete(int id)
        {
            BikesService.Delete(id);
        }


        public void Put(Bike bike)
        {
            BikesService.Update(bike);
        }

        //public Bike Get(string number)
        //{
        //    return BikesService.GetBike(number);
        //}
    }
}
