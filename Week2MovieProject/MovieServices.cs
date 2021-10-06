using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2MovieProject.Data;

namespace Week2MovieProject
{
    class MovieService
    {
        private IList<Movie> movies;
        private static int counter = 0;

       private readonly MovieRepository movieRepository;

        public MovieService(MovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        internal Movie Create(Movie toCreate)
        {
            Movie newMovie = movieRepository.Create(toCreate);
            return newMovie;
        }

        internal IEnumerable<Movie> Read()
        {
            return movieRepository.Read();
        }

        internal void Delete(int id)
        {
            movieRepository.Delete(id);
        }

    }
}
