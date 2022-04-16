using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using mis321tmtromblypa4.API;
using mis321tmtromblypa4.Models;
using mis321tmtromblypa4.API.Models.Interfaces;

namespace Repository.mis321tmtromblypa4.API.Databases
{
    public class WriteToDatabase : ICreateSongs
    {
        public static void CreateSongTable()
        {
            ConnectionString myConnection = new ConnectionString(); //connection string
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, timeadded DATETIME, deleted TEXT, favorited TEXT)"; //statement that creates the table for songs

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void Create(Song song) //insert data method into database
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(title, timeadded, deleted, favorited) VALUES(@title, @timeadded, @deleted, @favorited)"; //statement to populate values into table

            using var cmd = new MySqlCommand(stm, con);

            
            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@timeadded", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@favorited", song.Favorited);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
        public static void WriteAllToDatabase(List<Song> Playlist) //writes all info to database
        {
            ConnectionString myConnection = new ConnectionString(); //connection string
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string dr = @"DROP TABLE if exists songs"; //drops the table to recreate table to update database

            using var cmd = new MySqlCommand(dr, con);

            cmd.ExecuteNonQuery();

            WriteToDatabase.CreateSongTable();

            string stm = @"INSERT INTO songs(id, title, timeadded, deleted) VALUES(@id,@title,@timeadded,@deleted,@favorited)"; //statement to populate values into table

            foreach(Song song in Playlist)
            {
                using var cmd2 = new MySqlCommand(stm, con);
                string deleted = "n"; //inserts n to if deleted column
                string favorited = "n";

                cmd2.Parameters.AddWithValue("@id",song.SongID);
                cmd2.Parameters.AddWithValue("@title",song.SongTitle);
                cmd2.Parameters.AddWithValue("@timeadded",song.SongTimestamp);
                cmd2.Parameters.AddWithValue("@deleted", deleted);
                cmd2.Parameters.AddWithValue("@favorited", favorited);

                cmd2.Prepare();

                cmd2.ExecuteNonQuery();
            }
        }
    }
}