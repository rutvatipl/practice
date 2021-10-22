using System;
using System.Linq;
using System.Collections.Generic;

namespace ex_12
{
    class LinqExercise3
    {
        static void Main(string[] args)
        {
            // code from DevCurry.com
            var arr1 = new[] {1,2, 3, 9, 2, 8, 6, 5 ,4};

            Console.Write("\nLINQ : Find the number and its square of an array which is more than 20 : ");
          

            var sqNo = from int Number in arr1
                       let SqrNo = Number * Number
                       where SqrNo > 20
                       select new { Number, SqrNo };

            foreach (var a in sqNo)
                Console.WriteLine(a);

            Console.ReadLine();
        }
    }
}