using System;
public class Exercise14
{
    public static void Main()
    {
        int i, j;
        int[,] arr1 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 },{ 7, 8, 9 } };


        Console.Write("\nThe matrix is : \n");
        for (i = 0; i < 3; i++)
        {
            Console.Write("\n");
            for (j = 0; j < 3; j++)
                Console.Write("{0}\t", arr1[i, j]);
        }
        Console.Write("\n\n");
    }
}