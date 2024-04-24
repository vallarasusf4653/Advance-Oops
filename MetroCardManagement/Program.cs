using System;
namespace MetroCardManagement;
public class Program 
{
    public static void Main(string[] args)
    {
        // Creating Folder and file
           FileHandling.Create();

        // Reading object from csv files
           FileHandling.ReadFromCSV();

        // Operations.DefaultData();

        // Calling MainMenu
           Operations.MainMenu();
           
        // Writing object into csv files   
           FileHandling.WriteToCSV();
    }
}