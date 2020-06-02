using Beerify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class IPlaceController : ApiController
    {
        [HttpPost]
        public Place CreatePlace(int placeId, string name, string location,
            string picturePath, string description)
        {
            return new Place(placeId, name, location,
            picturePath, description);

        }
        
        [HttpGet]
        public List<Place> ShowClosePlace(double longitude, double latitude, double radius)
       {
           return Place.DownLoadAllInRadius(longitude,  latitude, radius)
        }
    }
}
