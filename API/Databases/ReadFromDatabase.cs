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
    public class ReadFromDatabase : IReadSongs
    {
        public List<Song> GetAll()
        { // read in songs from songs table in database
            List<Song> songs = new List<Song>();
            ConnectionString myConnection = new ConnectionString(); //creates new connection string
            string cs = myConnection.cs; 

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM songs"; //inserts statement to select from songs table

            using var cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader(); //reads in song from database

            while(rdr.Read()) //reads song 
            {
                int id = rdr.GetInt32(0);
                string title = rdr.GetString(1);
                DateTime timeadded = rdr.GetDateTime(2);
                string deleted = rdr.GetString(3);
                string favorited = rdr.GetString(4);
                songs.Add(new Song(){SongID = id, SongTitle = title, SongTimestamp = timeadded, Deleted = deleted, Favorited = favorited}); //adds to the list
            }
            rdr.Close();

            foreach(Song song in songs)
            {
                Console.WriteLine(song);
            }
            return songs;
        }
        public Song GetOne(int id)
        {
            Song s = new Song();
            return s;
        }

        // public Song GetByName(string songTitle)
        // {
        //     Song s = new Song();
        //     return s;
        // }

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

        public void ChangeDatabase()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //deletes song table if it exists
            string drop = @"DROP TABLE if exists songs";

            using var cmd = new MySqlCommand(drop,con);
            cmd.ExecuteNonQuery();

            ReadFromDatabase.CreateSongTable();

            // Song a = new Song(){SongID = 123, SongTitle = "Hello", SongTimestamp = DateTime.Now, Deleted = "n", Favorited = "n"};
            // Song b = new Song(){SongID = 1234, SongTitle = "Thunderstruck", SongTimestamp = DateTime.Now, Deleted = "n", Favorited = "n"};

            WriteToDatabase w = new WriteToDatabase();
            // w.Create(a);
            // w.Create(b);
        }
    }
}