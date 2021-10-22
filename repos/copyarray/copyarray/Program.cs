using System;
using System.Collections;

namespace CotyTo
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();

            // Adding elements to ArrayList 
            myList.Add("1");
            myList.Add("2");
            myList.Add("3");
            myList.Add("4");
            myList.Add("5");
            myList.Add("6");
            myList.Add("7");
            myList.Add("8");
            myList.Add("9");


            String[] arr = new String[18];

            arr[0] = "C";
            arr[1] = "C++";
            arr[2] = "Java";
            arr[3] = "Python";
            arr[4] = "C#";
            arr[5] = "HTML";
            arr[6] = "CSS";
            arr[7] = "PHP";
            arr[8] = "DBMS";




            myList.CopyTo(arr, 9);
            // myList.CopyTo(arr,0);

            foreach (var item in arr)
                Console.Write(item + ", ");
            Console.WriteLine();
            foreach (var item in myList)
                Console.Write(item + ", ");


        }

    }
}