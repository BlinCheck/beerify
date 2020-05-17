using System;
using System.Collections.Generic;
using System.Text;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Beerify
{
    class Drink
    {
        public int m_drink_id       = 0;
        public string m_name        = string.Empty;
        public string m_type        = string.Empty;
        public string m_picturePath = string.Empty;
        public string m_description = string.Empty;

        public Drink() { }

        public Drink(int PlaceId)
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from drinks where " +
               " drink_id = {0}", PlaceId.ToString()));

            MySqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            m_drink_id = rd.GetInt32(0);
            m_name = rd.GetString(1);
            m_type = rd.GetString(2);
            m_picturePath = rd.GetString(3);
            m_description = rd.GetString(4);

            rd.Close();
        }

        public Drink(int drinkId, string name, string type,
            string picturePath, string description)
        {
            m_drink_id = drinkId;
            m_name = name;
            m_type = type;
            m_picturePath = picturePath;
            m_description = description;
        }

        public void UpLoad()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("update drinks set " +
                "name           = '{1}', " +
                "type           = '{2}', " +
                "picture_path   = '{3}', " +
                "description    = '{4}'  " +
                "where drink_id =  {0}   ",
                m_drink_id.ToString(),
                m_name, m_type, m_picturePath,
                m_description));

            cmd.ExecuteNonQuery();
        }

        public void Insert()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into drinks( " +
                " name, type, picture_path, description ) " +
                "values( " +
                " '{0}', " +
                " '{1}', " +
                " '{2}', " +
                " '{3}') ",
                m_name, m_type, m_picturePath,
                m_description));

            cmd.ExecuteNonQuery();
        }

        public static List<Drink> DownLoadAll()
        {
            List<Drink> drinks = new List<Drink>();

            MySqlCommand cmd = DBConnection.Execute("select * from drinks");

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Drink newDrink = new Drink(rd.GetInt32(0),
                                           rd.GetString(1),
                                           rd.GetString(2),
                                           rd.GetString(3),
                                           rd.GetString(4));

                drinks.Add(newDrink);
            }
            rd.Close();

            return drinks;
        }
    }
}


