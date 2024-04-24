using System;
namespace QwickFoodz;
public class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();

        FileHandling.ReadFromCSV();

        //Operations.DefaultData();

        Operations.MainMenu();

        FileHandling.WriteToCSV();
    }
}