using MySql.Data.MySqlClient;
using System;


namespace Week2MovieProject
{

    class Menu : IDrawable
    {
        public void Draw()
        {
            Console.WriteLine("=== Menu ===");
            Console.WriteLine("1. Movies");
            Console.WriteLine("2. Quit");
            Console.WriteLine("=== ==== ===");

            //        try
            //        {
            //            Console.WriteLine("Hello"); // do something that could throw an exception
            //            DoSomething();
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine("App continues executing");
            //        }


            //    }

            //    public static void DoSomething()
            //    {
            //        Console.WriteLine("In do something");
            //        DoSomethingElse();
            //    }

            //    public static void DoSomethingElse()
            //    {
            //        Console.WriteLine("In do something else");
            //        throw new Exception("thrown an exception");
            //    }

        }

    }

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
            Menu m = new Menu();
            m.Draw();

            

            string input = Console.ReadLine();

            MySqlConnection connection = MySqlUtils.GetConnection();



            //opens the conection with the DB
            connection.Open();

            bool connectionOpen = connection.Ping();

            //var schema = connection.GetSchema("Movies");
            
            MySqlUtils.RunSchema(Environment.CurrentDirectory + @"\Resources\Schema.sql", connection);

            Console.WriteLine(@$"Connection status: {connection.State}
             Ping successfull: {connectionOpen}
             DB Version: {connection.ServerVersion}");

            //closes the connection with the db
             connection.Dispose();


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
            MovieController controller = new 
                MovieController(
                new MovieService(
                    new MovieRepository(MySqlUtils.GetConnection())));

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

                //string s = "Hello world";
                //s.Write(); // this extension method is only scope when the namespace is imported
                //MovieRepository<Item, int> repo = new MovieRepository(MySqlUtils.GetConnection());
                //repo.ReadById(32);

                int i = 32;
                Console.WriteLine(i.IsEven());
                Console.WriteLine(i.IsOdd());


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

