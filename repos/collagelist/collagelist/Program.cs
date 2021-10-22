using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		var clg = new List<string>();
		clg.Add("Nirma");
		clg.Add("LD");
		clg.Add("LJ");
		clg.Add("SAAL");
		clg.Add("alpha");
		clg.Add("pdpu");
		clg.Add("IIT");
		clg.Add("IIM");
		clg.Add("GEC");
		clg.Add("GIT");

		Console.WriteLine("search clg:"); 

		var result = clg.Where(c => c.Contains("LD"));

			foreach (var i in result)
			Console.WriteLine(i +" ");

		Console.WriteLine("remove 5th clg:");

		clg.RemoveAt(5);

		foreach (var i in clg)
			Console.WriteLine(i + " ");

		Console.WriteLine("remove 3 to 6 clg and sort :");

		for (int j=3;j<6;j++)
        {
            clg.RemoveAt(j);
        }
		foreach (var i in clg)
			Console.WriteLine(i + " ");

		clg.Sort();
        Console.WriteLine("\n" + "List After" + "\n");
      foreach (string num in clg)

		{

			Console.WriteLine(num);
			

		}



		Console.ReadLine();
	}
}
	