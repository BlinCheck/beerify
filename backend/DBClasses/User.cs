using System;
using System.Collections.Generic;
using System.Text;
using Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Beerify
{
    class User
    {
        public int      m_userId = 0;
        public string   m_email = string.Empty;
        public string   m_password = string.Empty;
        public string   m_name = string.Empty;
        public DateTime m_birdthDate = new DateTime(0);
        public string   m_picturePath = string.Empty;
        public int      m_telegramId = 0;
        public string   m_bio = string.Empty;

        public User() { }

        public User(int UserId)
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("select * from users where " +
                "user_id = {0}", UserId.ToString()));

            MySqlDataReader rd = cmd.ExecuteReader();
            rd.Read();

            m_userId = rd.GetInt32(0);
            m_email = rd.GetString(1);
            m_password = rd.GetString(2);
            m_name = rd.GetString(3);
            m_birdthDate = rd.GetDateTime(4);
            m_picturePath = rd.GetString(5);
            m_telegramId = rd.GetInt32(6);
            m_bio = rd.GetString(7);

            rd.Close();
        }

        public User(int userId, string email, string password, string name,
            DateTime birthDate, string picturePath, int telegramId, string bio)
        {
            m_userId = userId;
            m_email = email;
            m_password = password;
            m_name = name;
            m_birdthDate = birthDate;
            m_picturePath = picturePath;
            m_telegramId = telegramId;
            m_bio = bio;
        }

        public void UpLoad()
        {
            MySqlCommand cmd = DBConnection.Execute(string.Format("update users set " +
                "email         = '{1}', " +
                "password      = '{2}', " +
                "name          = '{3}', " +
                "birth_date    = '{4}', " +
                "picture_path  = '{5}', " +
                "telegram_id   =  {6},  " +
                "bio           = '{7}'  " +
                "where user_id =  {0}   ",
                m_userId.ToString(),
                m_email, m_password, m_name,
                m_birdthDate.ToString("dd.MM.yyyy"), m_picturePath,
                m_telegramId.ToString(), m_bio));

            cmd.ExecuteNonQuery();
        }

        public void Insert()
        {
            Console.WriteLine(string.Format("insert into users( " +
                "email, password, name, birth_date, picture_path, telegram_id, bio ) " +
                " values ( " +
                " '{0}', " +
                " '{1}', " +
                " '{2}', " +
                " '{3}', " +
                " '{4}', " +
                "  {5},  " +
                " '{6}') ",
                m_email, m_password, m_name,
                m_birdthDate.ToString("dd.MM.yyyy"), m_picturePath,
                m_telegramId.ToString(), m_bio));
            MySqlCommand cmd = DBConnection.Execute(string.Format("insert into users( " +
                "email, password, name, birth_date, picture_path, telegram_id, bio ) " +
                " values ( " +
                " '{0}', " +
                " '{1}', " +
                " '{2}', " +
                " '{3}', " +
                " '{4}', " +
                "  {5},  " +
                " '{6}') " ,
                m_email, m_password, m_name,
                m_birdthDate.ToString("dd.MM.yyyy"), m_picturePath,
                m_telegramId.ToString(), m_bio));

            cmd.ExecuteNonQuery();
        }

        public static List<User> DownLoadAll()
        {
            List<User> users = new List<User>();

            MySqlCommand cmd = DBConnection.Execute("select * from users");

            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                User newUser = new User(rd.GetInt32(0),
                                        rd.GetString(1),
                                        rd.GetString(2),
                                        rd.GetString(3),
                                        rd.GetDateTime(4),
                                        rd.GetString(5),
                                        rd.GetInt32(6),
                                        rd.GetString(7));

                users.Add(newUser);
            }
            rd.Close();

            return users;
        }
    }
}
