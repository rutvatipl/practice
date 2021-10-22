using System;

public class Program
{
	enum WeekDays
	{
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
	}

	public static void Main()
	{
		foreach (string i in Enum.GetNames(typeof(WeekDays)))
		{
			Console.WriteLine(i);
		}
	
	}
}