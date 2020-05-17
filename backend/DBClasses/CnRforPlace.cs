using System;
using System.Collections.Generic;
using System.Text;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Beerify
{
    class CnRforPlace
    {                              
        public int m_user_id        = 0;
        public int m_place_id       = 0;
        public int m_rate           = 0;
        public string m_comment     = string.Empty;
        public bool m_is_hidden     = true;
        public DateTime m_date_time = new DateTime(0);

        public CnRforPlace() { }

        public CnRforPlace(int UserId, int PlaceId)
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from comments_and_rates_for_places where " +
               " user_id = {0} and place_id = {1} ", UserId.ToString(), PlaceId.ToString()));

            MySqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            m_user_id = rd.GetInt32(0);
            m_place_id = rd.GetInt32(1);
            m_rate = rd.GetInt32(2);
            m_comment = rd.GetString(3);
            m_is_hidden = rd.GetBoolean(4);
            m_date_time = rd.GetDateTime(5);

            rd.Close();
        }

        public CnRforPlace(int userId, int placeId, int rate, string comment,
            bool is_hidden, DateTime dateTime)
        {
            m_user_id = userId;
            m_place_id = placeId;
            m_rate = rate;
            m_comment = comment;
            m_is_hidden = is_hidden;
            m_date_time = dateTime;
        }

        public void UpLoad()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("update comments_and_rates_for_places set " +
                "rate          =  {2},  " +
                "comment       = '{3}', " +
                "is_hidden     =  {4},  " +
                "date_time     = '{5}'  " +
                "where user_id =  {0}   " +
                "and place_id  =  {1}   ",
                m_user_id, m_place_id, m_rate,
                m_comment, m_is_hidden, m_date_time.ToString("dd.MM.yyyy")));

            cmd.ExecuteNonQuery();
        }

        public void Insert()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into comments_and_rates_for_places values( " +
                "  {0},  " +
                "  {1},  " +
                "  {2},  " +
                " '{3}', " +
                "  {4},  " +
                " '{5}')  " ,
                m_user_id, m_place_id, m_rate,
                m_comment, m_is_hidden, m_date_time.ToString("dd.MM.yyyy")));

            cmd.ExecuteNonQuery();
        }

        public static List<CnRforPlace> DownLoadAllForUser(int UserId)
        {
            List<CnRforPlace> CnRs = new List<CnRforPlace>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from comments_and_rates_for_places" +
                " where user_id = {0} ", UserId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                CnRforPlace newCnR = new CnRforPlace(rd.GetInt32(0),
                                                       rd.GetInt32(1),
                                                       rd.GetInt32(2),
                                                       rd.GetString(3),
                                                       rd.GetBoolean(4),
                                                       rd.GetDateTime(5));

                CnRs.Add(newCnR);
            }
            rd.Close();

            return CnRs;
        }

        public static List<CnRforPlace> DownLoadAllForPlace(int PlaceId)
        {
            List<CnRforPlace> CnRs = new List<CnRforPlace>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from comments_and_rates_for_places" +
                " where place_id = {0} ", PlaceId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                CnRforPlace newCnR = new CnRforPlace(rd.GetInt32(0),
                                                       rd.GetInt32(1),
                                                       rd.GetInt32(2),
                                                       rd.GetString(3),
                                                       rd.GetBoolean(4),
                                                       rd.GetDateTime(5));

                CnRs.Add(newCnR);
            }
            rd.Close();

            return CnRs;
        }
    }
}


