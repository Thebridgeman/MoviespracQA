using System;


namespace Week2MovieProject
{
    class Program
    {
        public enum CrudOptions
        {
            CREATE,
            READ,
            UPDATE,
            DELETE,
            QUIT
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("1. Movies \n2. Quit");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CrudMenu();
                    break;
                case "2":
                    // quit out of loop
                    break;
            }

        }
        public static void CrudMenu()
        {
            MovieController controller = new MovieController();

            bool inMenu = true;
            var values = Enum.GetValues(typeof(CrudOptions));
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
            while (inMenu)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                // TryParse(stringInputToParse, ignoreCaseBoolean, outputVariable)
                bool b = Enum.TryParse(input, true, out CrudOptions crudInput);
                if (!b)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                switch (crudInput)
                {
                    case CrudOptions.CREATE:
                        Console.WriteLine("Creating");
                        controller.CreateMovie();
                        break;
                    case CrudOptions.READ:
                        Console.WriteLine("Reading");
                        controller.ReadMovies();
                        break;
                    case CrudOptions.DELETE:
                        Console.WriteLine("Deleting");
                      //  controller.ReadMovies();
                        break;
                    case CrudOptions.QUIT:
                        inMenu = false;
                        break;
                }
            }
        }

    }
    }

