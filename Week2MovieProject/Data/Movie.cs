using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2MovieProject.Data
{
    class Movie
    {
        // atribute getters and setters
        public int ID
        {
            get; set;
        }
        private string movieTitle;

        public string title
        {
            get
            {
                return movieTitle;
            }
            set
            {
                movieTitle = value;
            }
        }

        private int movieDuration;

        public int duration
        {
            get
            {
                return movieDuration;
            }
            set
            {
                movieDuration = value;
            }
        }

        private string movieDescription;

        public string description
        {
            get
            {
                return movieDescription;
            }
            set
            {
                movieDescription = value;
            }
        }

        private string movieAgeRating;

        public string ageRating
        {
            get
            {
                return movieAgeRating;
            }
            set
            {
                movieAgeRating = value;
            }
        }

        private string movieGenre;

        public string genre
        {
            get
            {
                return movieGenre;
            }
            set
            {
                movieGenre = value;
            }
        }
        
        // constructor
            public Movie(string movieTitle, int movieDuration, string movieDescription, string movieAgeRating, string movieGenre)
        {
            this.title = movieTitle;
            this.movieDuration = movieDuration;
            this.description = movieDescription;
            this.ageRating = movieAgeRating;
            this.genre = movieGenre;

        }

        public Movie()
        {
        }

        public override string ToString()
        {
            return $"Movie[id={ID}, Title={title}], Genre={genre} ";
        }
    }


}
