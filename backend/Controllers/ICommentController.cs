using Beerify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ICommentController : ApiController
    {
        [HttpPost]
        public CnRforPlace CreateCommPlace(int userId, int placeId, int rate, string comment,
            bool is_hidden, DateTime dateTime)
        {
            return new CnRforPlace(userId, placeId, rate, comment,
            is_hidden,  dateTime);
        }

        [HttpPost]
        public CnRforDrink CreateCommDrink(int UserId, int DrinkId, int PlaceId)
        {
            return new CnRforDrink(UserId, DrinkId, PlaceId);
        }

        [HttpGet]
        public List<CnRforDrink> GetDrinksComm(int DrinkId)
        {
            return CnRforDrink.DownLoadAllForDrink(DrinkId);
        }

        [HttpGet]
        public List<CnRforPlace> GetPlaceComm(int PlaceId)
        {
            return CnRforPlace.DownLoadAllForPlace(PlaceId);
        }

    }
}
