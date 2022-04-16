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
    public class UpdateToDatabase : IUpdateSongs
    {
        public void Update(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            string fav = "Yes";
            con.Open();

            using var cmd = new MySqlCommand(@"UPDATE songs set id = @id,timeadded = @timeadded, deleted = @deleted, favorited = @favorited WHERE title=@title");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@id",song.SongID);
            cmd.Parameters.AddWithValue("@title",song.SongTitle);
            cmd.Parameters.AddWithValue("@timeadded",song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted",song.Deleted);
            cmd.Parameters.AddWithValue("@favorited",fav);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}