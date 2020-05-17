using System;
using System.Collections.Generic;
using System.Text;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Beerify
{
    class PlaceOwner
    {
        public int m_user_id = 0;
        public int m_place_id = 0;

        public PlaceOwner() { }

        public PlaceOwner(int UserId, int placeId)
        {
            m_user_id = UserId;
            m_place_id = placeId;
        }

        public void Insert()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into place_owners values( " +
                "  {0},  " +
                "  {1})  ",
                m_user_id, m_place_id));

            cmd.ExecuteNonQuery();
        }

        public static List<PlaceOwner> DownLoadAllForUser(int UserId)
        {
            List<PlaceOwner> PlaceOwners = new List<PlaceOwner>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from place_owners" +
                " where user_id = {0} ", UserId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                PlaceOwner newDungeonMaster = new PlaceOwner(rd.GetInt32(0),
                                                             rd.GetInt32(1));

                PlaceOwners.Add(newDungeonMaster);
            }
            rd.Close();

            return PlaceOwners;
        }

        public static List<PlaceOwner> DownLoadAllForPlace(int PlaceId)
        {
            List<PlaceOwner> PlaceOwners = new List<PlaceOwner>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from place_owners" +
                " where place_id = {0} ", PlaceId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                PlaceOwner newDungeonMaster = new PlaceOwner(rd.GetInt32(0),
                                                             rd.GetInt32(1));

                PlaceOwners.Add(newDungeonMaster);
            }
            rd.Close();

            return PlaceOwners;
        }
    }
}


