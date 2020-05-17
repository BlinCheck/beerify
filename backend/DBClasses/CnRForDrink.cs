using System;
using System.Collections.Generic;
using System.Text;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Beerify
{
    class CnRforDrink
    {
        public int m_user_id = 0;
        public int m_drink_id = 0;
        public int m_place_id = 0;
        public int m_rate = 0;
        public string m_comment = string.Empty;
        public bool m_is_hidden = true;
        public DateTime m_date_time = new DateTime(0);

        public CnRforDrink() { }

        public CnRforDrink(int UserId, int DrinkId, int PlaceId)
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from comments_and_rates_for_drinks_in_place where " +
               " user_id = {0} and drink_id = {1} and place_id = {2} ", 
               UserId.ToString(), DrinkId.ToString(), PlaceId.ToString()));

            MySqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            m_user_id = rd.GetInt32(0);
            m_drink_id = rd.GetInt32(1);
            m_place_id = rd.GetInt32(2);
            m_rate = rd.GetInt32(3);
            m_comment = rd.GetString(4);
            m_is_hidden = rd.GetBoolean(5);
            m_date_time = rd.GetDateTime(6);

            rd.Close();
        }

        public CnRforDrink(int userId, int drinkId, int placeId, int rate, string comment,
            bool is_hidden, DateTime dateTime)
        {
            m_user_id = userId;
            m_drink_id = drinkId;
            m_place_id = placeId;
            m_rate = rate;
            m_comment = comment;
            m_is_hidden = is_hidden;
            m_date_time = dateTime;
        }

        public void UpLoad()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("update comments_and_rates_for_drinks_in_place set " +
                "rate          =  {3},  " +
                "comment       = '{4}', " +
                "is_hidden     =  {5},  " +
                "date_time     = '{6}'  " +
                "where user_id =  {0}   " +
                "and drink_id  =  {1}   " +
                "and place_id  =  {2}   ",
                m_user_id, m_drink_id, m_place_id, m_rate,
                m_comment, m_is_hidden, m_date_time.ToString("dd.MM.yyyy")));

            cmd.ExecuteNonQuery();
        }

        public void Insert()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into comments_and_rates_for_drinks_in_place values( " +
                "  {0},  " +
                "  {1},  " +
                "  {2},  " +
                "  {3},  " +
                " '{4}', " +
                "  {5},  " +
                " '{6}')  ",
                m_user_id, m_drink_id, m_place_id, m_rate,
                m_comment, m_is_hidden, m_date_time.ToString("dd.MM.yyyy")));

            cmd.ExecuteNonQuery();
        }

        public static List<CnRforDrink> DownLoadAllForUser(int UserId)
        {
            List<CnRforDrink> CnRs = new List<CnRforDrink>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from comments_and_rates_for_drinks_in_place" +
                " where user_id = {0} ", UserId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                CnRforDrink newCnR = new CnRforDrink(rd.GetInt32(0),
                                                     rd.GetInt32(1),
                                                     rd.GetInt32(2),
                                                     rd.GetInt32(3),
                                                     rd.GetString(4),
                                                     rd.GetBoolean(5),
                                                     rd.GetDateTime(6));

                CnRs.Add(newCnR);
            }
            rd.Close();

            return CnRs;
        }

        public static List<CnRforDrink> DownLoadAllForDrink(int DrinkId)
        {
            List<CnRforDrink> CnRs = new List<CnRforDrink>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from comments_and_rates_for_drinks_in_place" +
                " where drink_id = {0} ", DrinkId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                CnRforDrink newCnR = new CnRforDrink(rd.GetInt32(0),
                                                     rd.GetInt32(1),
                                                     rd.GetInt32(2),
                                                     rd.GetInt32(3),
                                                     rd.GetString(4),
                                                     rd.GetBoolean(5),
                                                     rd.GetDateTime(6));

                CnRs.Add(newCnR);
            }
            rd.Close();

            return CnRs;
        }

        public static List<CnRforDrink> DownLoadAllForPlace(int PlaceId)
        {
            List<CnRforDrink> CnRs = new List<CnRforDrink>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from comments_and_rates_for_drinks_in_place" +
                " where place_id = {0} ", PlaceId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                CnRforDrink newCnR = new CnRforDrink(rd.GetInt32(0),
                                                     rd.GetInt32(1),
                                                     rd.GetInt32(2),
                                                     rd.GetInt32(3),
                                                     rd.GetString(4),
                                                     rd.GetBoolean(5),
                                                     rd.GetDateTime(6));

                CnRs.Add(newCnR);
            }
            rd.Close();

            return CnRs;
        }
    }
}


