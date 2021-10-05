using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2MovieProject.Data;

namespace Week2MovieProject
{
    class MovieController
    {
        private readonly IList<Movie> movies;

        private static int counter = 0;
        public MovieController() => movies = new List<Movie>();

        public void CreateMovie()
        {
            Console.WriteLine("What is the title");
            string title = Console.ReadLine();
            Console.WriteLine("What is the description");
            string description = Console.ReadLine();
            Console.WriteLine("What is the duration");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the age rating");
            string ageRating = Console.ReadLine();
            Console.WriteLine("What is the genre");
            string genre = Console.ReadLine();

            Movie newMovie = new Movie(title, duration, description, ageRating, genre);
            newMovie.ID = counter;
            counter++;
            movies.Add(newMovie);
            Console.WriteLine($"Created new movie {newMovie}");

        }

        public void ReadMovies()
        {
            foreach (var movie in movies)
            {
                Console.WriteLine(movies);
            }
        }

        public void DeleteMovie(int index)
        {
            movies.RemoveAt(index);
        }
    }
}
