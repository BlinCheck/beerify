using Beerify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [Route("api/[usercontroller]")]
    public class IUserController : ApiController
    {
        [HttpPost]
        public User CreateUser(int userId, string email, string password, string name,
            DateTime birthDate, string picturePath, int telegramId, string bio)
        {
            return new User(userId, email, password, name,
            birthDate, picturePath, telegramId, bio);
        }

        [HttpPost]
        public List<UserSub> ShowUserSub(int UserID)
        {
            return UserSub.DownLoadAllForUser(UserID);
        }
    }
}
