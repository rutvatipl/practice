using System;
using System.Collections.Generic;
using System.Linq;

namespace ex11
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp = new Dictionary<int, string>(){
             {1, "Rushita"},
             {2, "Rutva"},
             {3, "Vishwa"},
             {4, "Milan"},
             {5, "Vidhi"},
             {6, "Rahil"},
             {7, "Dhruv"},
};
            Console.WriteLine("Employee Of TIPL ");
            Console.WriteLine("----------------------------");
            foreach (var kvp in emp)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            Console.WriteLine("----------------------------");
            Console.WriteLine("No. Of Employee : " + emp.Count);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Key of Employee");
            Console.WriteLine("----------------------------");
            foreach (var kvp in emp)
                Console.WriteLine("Key: {0}", kvp.Key);
            Console.WriteLine("----------------------------");

            if (!emp.ContainsKey(5))
            {
                emp[5] = "ABC";
            }
            if (!emp.ContainsKey(50))
            {
                emp[50] = "XYZ";
            }
            foreach (var kvp in emp)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            Console.WriteLine("----------------------------");

        }
    }
}