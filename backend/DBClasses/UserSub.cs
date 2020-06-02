using System;
using System.Collections.Generic;
using System.Text;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Beerify
{
    class UserSub
    {
        public int m_user_id = 0;
        public int m_place_id = 0;

        public UserSub() { }

        public UserSub(int UserId, int placeId)
        {
            m_user_id = UserId;
            m_place_id = placeId;
        }

        public void Insert()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into user_subscriptions values( " +
                "  {0},  " +
                "  {1})  ",
                m_user_id, m_place_id));

            cmd.ExecuteNonQuery();
        }

        public static List<UserSub> DownLoadAllForUser(int UserId)
        {
            List<UserSub> UserSubs = new List<UserSub>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from user_subscriptions" +
                " where user_id = {0} ", UserId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                UserSub newSubHORDHORD = new UserSub(rd.GetInt32(0),
                                             rd.GetInt32(1));

                UserSubs.Add(newSubHORDHORD);
            }
            rd.Close();

            return UserSubs;
        }

        public static List<UserSub> DownLoadAllForPlace(int PlaceId)
        {
            List<UserSub> UserSubs = new List<UserSub>();

            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from user_subscriptions" +
                " where place_id = {0} ", PlaceId));

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                UserSub newSubHORDHORD = new UserSub(rd.GetInt32(0),
                                             rd.GetInt32(1));

                UserSubs.Add(newSubHORDHORD);
            }
            rd.Close();

            return UserSubs;
        }
    }
}


