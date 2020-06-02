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
        public int m_place_id = 0;
        public string m_name = string.Empty;
        public string m_picturePath = string.Empty;
        public string m_description = string.Empty;
        public double m_longitude = 0.0;
        public double m_latitude = 0.0;

        public Place() { }

        public Place(int PlaceId)
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from places where " +
               " place_id = {0}", PlaceId.ToString()));

            MySqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            m_place_id = rd.GetInt32(0);
            m_name = rd.GetString(1);
            m_picturePath = rd.GetString(2);
            m_description = rd.GetString(3);
            m_longitude = rd.GetDouble(4);
            m_latitude = rd.GetDouble(5);

            rd.Close();
        }

        public Place(int placeId, string name,
            string picturePath, string description, double longitude, double latitude)
        {
            m_place_id = placeId;
            m_name = name;
            m_picturePath = picturePath;
            m_description = description;
            m_longitude = longitude;
            m_latitude = latitude;
        }

        public void UpLoad()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("update places set " +
                "name           = '{1}', " +
                "picture_path   = '{2}', " +
                "description    = '{3}', " +
                "longitude      =  {4},  " +
                "latitude       =  {5}   " +
                "where place_id =  {0}   ",
                m_place_id.ToString(),
                m_name, m_picturePath,
                m_description, m_longitude, m_latitude));

            cmd.ExecuteNonQuery();
        }

        public void Insert()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into places( " +
                " name, picture_path, description, longitude, latitude ) " +
                "values( " +
                " '{0}', " +
                " '{1}', " +
                " '{2}', " +
                "  {3},  " +
                "  {4})  ",
                m_name, m_picturePath,
                m_description, m_longitude, m_latitude));

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
                                          rd.GetDouble(4),
                                          rd.GetDouble(5));

                places.Add(newPlace);
            }
            rd.Close();

            return places;
        }

        public static List<Place> DownLoadAllInRadius(double longitude, double latitude, double radius)
        {
            List<Place> places = new List<Place>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("SELECT *, (6371 * ACOS(" +
                                                    "COS(RADIANS({1})) *" +
                                                    "COS(RADIANS(latitude)) *" +
                                                    "COS(RADIANS(longitude) -" +
                                                    "RADIANS({0})) +" +
                                                    "SIN(RADIANS({1})) *" +
                                                    "SIN(RADIANS(latitude))))" +
                                                    "AS distance FROM places HAVING distance <= {2} ORDER BY distance ASC",
                                                    longitude, latitude, radius));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Place newPlace = new Place(rd.GetInt32(0),
                                          rd.GetString(1),
                                          rd.GetString(2),
                                          rd.GetString(3),
                                          rd.GetDouble(4),
                                          rd.GetDouble(5));

                places.Add(newPlace);
            }
            rd.Close();

            return places;
        }
    }
}


