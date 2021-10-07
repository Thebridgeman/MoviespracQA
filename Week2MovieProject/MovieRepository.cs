using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2MovieProject.Data;

namespace Week2MovieProject
{
    internal class MovieRepository
    {
        private readonly MySqlConnection connection;
        private IList<Movie> movies;
        private static int counter = 0;

        public MovieRepository(MySql.Data.MySqlClient.MySqlConnection mySqlConnection)
        {
            connection = mySqlConnection;
        }

        internal Movie Create(Movie toCreate)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO movies (name, description) VALUES('{toCreate.title}', '{toCreate.description}')";

            command.ExecuteNonQuery();
            connection.Close();

            Movie movie = new Movie();
            movie.ID = (int)command.LastInsertedId;
            movie.title = toCreate.title;

            return movie;
        }



        public IList<Movie> Read()
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM movies";

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            IList<Movie> movies = new List<Movie>();

            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("id");
                string name = reader.GetFieldValue<string>("name");

                Movie movie = new Movie() { ID = id, title = name };
                movies.Add(movie);
            }
            connection.Close();

            return movies;
        }

        public bool Exists(int u)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT COUNT(*) FROM movies WHERE id={u}";

            int result = Convert.ToInt32(command.ExecuteScalar());

            return result > 0;
        }




        public void Delete(int id)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM movies WHERE id={id}";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

    }
}