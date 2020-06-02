using System;
using System.Collections.Generic;
using System.Text;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Beerify
{
    class DrinkInPlace
    {
        public int m_drink_id = 0;
        public int m_place_id = 0;

        public DrinkInPlace() { }

        public DrinkInPlace(int drinkId, int placeId)
        {
            m_drink_id = drinkId;
            m_place_id = placeId;
        }

        public void Insert()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into drinks_in_places values( " +
                "  {0},  " +
                "  {1})  ",
                m_drink_id, m_place_id));

            cmd.ExecuteNonQuery();
        }

        public static List<DrinkInPlace> DownLoadAllForDrink(int DrinkId)
        {
            List<DrinkInPlace> DiPs = new List<DrinkInPlace>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from drinks_in_places" +
                " where drink_id = {0} ", DrinkId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DrinkInPlace newDiP = new DrinkInPlace(rd.GetInt32(0),
                                                       rd.GetInt32(1));

                DiPs.Add(newDiP);
            }
            rd.Close();

            return DiPs;
        }

        public static List<DrinkInPlace> DownLoadAllForPlace(int PlaceId)
        {
            List<DrinkInPlace> DiPs = new List<DrinkInPlace>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from drinks_in_places" +
                " where place_id = {0} ", PlaceId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DrinkInPlace newDiP = new DrinkInPlace(rd.GetInt32(0),
                                                       rd.GetInt32(1));

                DiPs.Add(newDiP);
            }
            rd.Close();

            return DiPs;
        }
    }
}


