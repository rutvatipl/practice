
//Write A Program To Sort One Dimensional Array In Descending Order Using Non Static Method
//Write a program in C# Sharp to find the sum of all elements of the array.

using System;
using System.Linq;

namespace Sort_Array_Des
{
    public class Program
    {
        private object num;

        public static void Main(string[] args)
        {
            int[] num = { 22, 50, 11, 2, 49 };
            Program p = new Program();
            p.SortArray(num);
        }

        public void SortArray(int[] numarray)
        {
            int swap = 0;
            for (int i = 0; i < numarray.Length; i++)
            {
                for (int j = i + 1; j < numarray.Length; j++)
                {
                    if (numarray[i] <= numarray[j])
                    {
                        swap = numarray[j];
                        numarray[j] = numarray[i];
                        numarray[i] = swap;
                    }
                }
                Console.Write(numarray[i] + " ");
            }
            int[] num = { 22, 50, 11, 2, 49 };
            int sum = num.Sum();
            Console.WriteLine("sum is : {0}", sum);
        }
    }
}



