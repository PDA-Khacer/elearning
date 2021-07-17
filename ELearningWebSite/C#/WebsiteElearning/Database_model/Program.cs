using Database_model.DB;
using System;

namespace Database_model
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BUS.Bus_Course.getAllCourse().Count);
            Console.ReadKey();
        }
    }
}
