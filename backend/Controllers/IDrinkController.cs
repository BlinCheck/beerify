using Beerify;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ubiety.Dns.Core.Common;

namespace WebApplication1.Controllers
{
     
    [Route("api/[drinkcontroller]")]
    public class IDrinkController : ApiController
    {
        [HttpPost]
        public Drink CreateDrink(int drinkId, string name, string type,
            string picturePath, string description)
        {
            return new Drink(drinkId, name, type,
            picturePath, description);
           
        }
        [HttpGet]
        public List<Drink> GetDrinks()
        {
            return Drink.DownLoadAll();
        }
        
        [HttpGet]
        public List<DrinkInPlace> GetPlaceDrinks(int PlaceID)
        {
            return DrinkInPlace.DownLoadAllForPlace(PlaceID);
        }

       


    }
}
