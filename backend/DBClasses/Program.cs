using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using Data;
using System.Collections.Generic;

namespace Beerify
{
    class Program
    {
        static void Main(string[] args)
        {
            PlaceOwner sdf = new PlaceOwner();
            sdf.m_user_id = 1;
            sdf.m_place_id = 1;
            sdf.Insert();

            List<PlaceOwner> pas = PlaceOwner.DownLoadAllForUser(1);

            PlaceOwner ppp = new PlaceOwner(pas[0].m_user_id, pas[0].m_place_id);
            Console.WriteLine("sdfd");
            Console.ReadKey(true);
        }
    }
}
