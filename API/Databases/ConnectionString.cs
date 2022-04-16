using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using mis321tmtromblypa4.API;
using mis321tmtromblypa4.Models;

namespace Repository.mis321tmtromblypa4.API.Databases
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString() //used to connect to the database
        {
            string server = "frwahxxknm9kwy6c.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "qlx32ogst4pll505";
            string port = "3306";
            string username = "vir4ho6i09y4ds5d";
            string password = "qm712v3l24a493bw";
            cs = $@"server = {server};user={username};database={database};port={port};password={password};";
        }
    }
}