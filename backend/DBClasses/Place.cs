using System;
using System.Collections.Generic;
using System.Text;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Beerify
{
    class Place
    {
        public int m_place_id       = 0;
        public string m_name        = string.Empty;
        public string m_location    = string.Empty;
        public string m_picturePath = string.Empty;
        public string m_description = string.Empty;

        public Place() { }

        public Place(int PlaceId)
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from places where " +
               " place_id = {0}", PlaceId.ToString()));

            MySqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            m_place_id = rd.GetInt32(0);
            m_name = rd.GetString(1);
            m_location = rd.GetString(2);
            m_picturePath = rd.GetString(3);
            m_description = rd.GetString(4);

            rd.Close();
        }

        public Place(int placeId, string name,  string location, 
            string picturePath, string description)
        {
            m_place_id = placeId;
            m_name = name;
            m_location = location;
            m_picturePath = picturePath;
            m_description = description;
        }

        public void UpLoad()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("update places set " +
                "name           = '{1}', " +
                "location       = '{2}', " +
                "picture_path   = '{3}', " +
                "description    = '{4}'  " +
                "where place_id =  {0}   ",
                m_place_id.ToString(),
                m_name, m_location, m_picturePath,
                m_description));

            cmd.ExecuteNonQuery();
        }

        public void Insert()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into places( " +
                " name, location, picture_path, description ) " +
                "values( " +
                " '{0}', " +
                " '{1}', " +
                " '{2}', " +
                " '{3}') ",
                m_name, m_location, m_picturePath,
                m_description));

            cmd.ExecuteNonQuery();
        }

        public static List<Place> DownLoadAll()
        {
            List<Place> places = new List<Place>();

            MySqlCommand cmd = DBConnection.Execute("select * from places");

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Place newPlace = new Place(rd.GetInt32(0),
                                          rd.GetString(1),
                                          rd.GetString(2),
                                          rd.GetString(3),
                                          rd.GetString(4));

                places.Add(newPlace);
            }
            rd.Close();

            return places;
        }
    }
}


