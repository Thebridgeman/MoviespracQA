using System;


namespace Week2MovieProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("1. Movies \n2. Quit");
            string input = Console.ReadLine();

            switch (input.ToUpper())
            {
                case "Movies":
                    EnterMoviesSubMenu();
                    break;
                case "Quit":
                    // quit out of loop
                    break;
            }

        }

        public static void EnterMoviesSubMenu()
        {
            MovieController controller = new MovieController();

            Console.WriteLine("1. Create \n2. Read");
            string input = Console.ReadLine();

            switch (input.ToUpper())
            {
                case "Create":
                    controller.CreateMovie();
                    break;
                case "Read":
                    controller.ReadMovies();
                    break;

            }
    }
}
