using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using mis321tmtromblypa4.API;
using mis321tmtromblypa4.Models;
using mis321tmtromblypa4.API.Models.Interfaces;
using Repository.mis321tmtromblypa4.API.Databases;

namespace Repository.mis321tmtromblypa4.API.Databases
{
    public class DeleteFromDatabase : IDeleteSongs
    {
        public void Delete(Song s)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand("DELETE FROM songs WHERE title = '" + s.SongTitle+"'",con);


            cmd.ExecuteNonQuery();
        }
    }
}