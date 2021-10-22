using System;
using System.Collections;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("employee name display:");
		var arlist = new ArrayList()
				{
					"rutu",
					"Bill",
					"rushi",
					"rushita",
					"rutva",
					"ritu",
					"rutvi",
					"riya",
					"vidhi",
					"namu"
				};
		foreach (var i in arlist)
			Console.WriteLine(i + " ");

		Console.WriteLine("employee name count:");
		Console.WriteLine("employee name: " + arlist.Count);

		Console.WriteLine("remove 4 to 7 employee and sort :");

		for (int j = 4; j < 7; j++)
		{
			arlist.RemoveAt(j);
		}
		foreach (var i in arlist)
			Console.WriteLine(i + " ");

		arlist.Sort();
		Console.WriteLine("\n" + "List After" + "\n");
		foreach (string num in arlist)

		{

			Console.WriteLine(num);


		}
        Console.WriteLine("insert data:");

		arlist.Insert(2, "rahil");
		arlist.RemoveAt(5);

		if(arlist.Contains("rutu"))
        {
			arlist.Insert(5, "rahil");
		}
		foreach (var i in arlist)
			Console.WriteLine(i + " ");

		Console.WriteLine("reverse data:");
		arlist.Reverse();
		Console.WriteLine("\n" + "List After" + "\n");
		foreach (string num in arlist)

		{

			Console.WriteLine(num);


		}

	}
}