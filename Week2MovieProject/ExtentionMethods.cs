using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2MovieProject
{
    static class ExtentionMethods
    {
        // extension methods must be in a static class
        // - the extension methods should also be static

        // we must specify the type as a parameter that the extension
        // method applies to
        // - it must be preceded by the `this` keyword
        // - cannot override methods that already exist on the string class
        //public static void Write(this string s)
        //{
        //    Console.WriteLine(s);
        //}

        //public static void ReadById(this MovieRepository<Movie, int> s, int id)
        //{
        //    Console.WriteLine($"reading by id {id}");


        public static void Write(this string s)
        {
            Console.WriteLine(s);
        }

        public static bool IsEven(this int i)
        {
            return (i % 2 == 0);
        }
        public static bool IsOdd(this int i)
        {
            return (i % 2 == 1);
        }



    }
}

    

