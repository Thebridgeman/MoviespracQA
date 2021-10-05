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

            Console.WriteLine("1. Movies \n2. Quit");
            string input = Console.ReadLine();

            // if statement based on input
            // if movies
            // start loop
            // call crud movies
            // ask if they want to continue
            // yes -> continue
            // no -> quit
            // else quit

            bool loop = true;

            if (input == "1")
            {
                while (loop)
                {

                    CrudMenu();

                    Console.WriteLine("Do you want to continue? Y/N");
                    string choice = Console.ReadLine();

                    if (choice.ToUpper() == "N")
                    {
                        loop = false;

                    }
                    else
                    {
                        continue;
                    }
                }
            }


        }
        public static void CrudMenu()
        {
            MovieController controller = new MovieController();

            bool inMenu = true;


            while (inMenu)
            {
                PrintMenu();
                Console.Write("> ");
                string input = Console.ReadLine();
                // TryParse(stringInputToParse, ignoreCaseBoolean, outputVariable)
                bool b = Enum.TryParse(input, true, out CrudOptions crudInput);
                if (!b)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }

                //TRIED IF STATEMENT TO CONTINUE HERE BUT DIDNT WORK
          

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
                        int index = int.Parse(Console.ReadLine());
                        controller.DeleteMovie(index);
                        break;
                    case CrudOptions.QUIT:
                        inMenu = false;
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        public static void PrintMenu()
        {
            Console.Clear();
            var values = Enum.GetValues(typeof(CrudOptions));
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }

    }
    }

