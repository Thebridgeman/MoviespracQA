﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;


namespace Week2MovieProject
{
    class MySqlUtils
    {
        
        // "server=127.0.0.1:3304;uid=root;pwd=root;database=item"
        public static MySqlConnectionStringBuilder ConnectionString { get; set; } = new MySqlConnectionStringBuilder        {
            Server = "127.0.0.1", // server hosting the mysql server
            UserID = "root", //user id for mysql           
            Password = "root", // password for mysql
            Port = 3306, // port to connect on, 3306 is default for MySQL
            Database = "Movies", // name of db to connect to in rdbms
            AllowBatch = true, // allows batches of commands to be sent, defaults to true,
            AllowLoadLocalInfileInPath = "./", // only files in specified dir can be uploaded, AllowLoadLocalInfile will override if set to true
            AllowLoadLocalInfile = false, // allows file uploads from anywhere if set to true
            ConnectionTimeout = 30 // default is 15, amount of time until app throws a timeout error
         };
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString.ConnectionString);
        }
        public static void RunSchema(string path, MySqlConnection connection)
        {
            string schema = File.ReadAllText(path);
            MySqlCommand mySqlCommand = connection.CreateCommand();
            mySqlCommand.CommandText = schema;
            // .ExecuteNonQuery(); is used when we are not reading from the database, but manipulating it
            mySqlCommand.ExecuteNonQuery();
        }
    }

}


