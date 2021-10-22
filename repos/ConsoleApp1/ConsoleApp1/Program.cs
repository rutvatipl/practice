//using System;
//using System.Text;

//public class Program
//{
//	public static void Main()
//	{
//		StringBuilder sb = new StringBuilder();
//		sb.Append("Hello ");
//		sb.Append("World!");
//		sb.Append("Hello C#");

//		sb.AppendFormat("{0:C} ", 25);
//		sb.Insert(5, "asd");
//		sb.Remove(6, 7);
//		sb.Replace("Hello", "rutva");
//		Console.WriteLine(sb);
//	}
//}

/* Passing Value Type Variables*/

using System;
					
public class Program
{
	static void ChangeValue(int x)
	{
		x = 200;

		Console.WriteLine(x);
	}

	public static void Main()
	{
		int i = 100;

		Console.WriteLine(i);

		ChangeValue(i);

		Console.WriteLine(i);
	}
}
