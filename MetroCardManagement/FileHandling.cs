using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static  class FileHandling
    {

        // Create Method
        public static void Create()
        {
            if(!Directory.Exists("MetroCardManagement"))
            {
               Console.WriteLine("Creating folder MetroCardManagement");
               Directory.CreateDirectory("MetroCardManagement");
            }
            if(!File.Exists("MetroCardManagement/UserDetails.csv"))
            {
                 Console.WriteLine("Creating  UserDetails file in MetroCardManagement Folder");
                 File.Create("MetroCardManagement/UserDetails.csv").Close();
            }
            if(!File.Exists("MetroCardManagement/TicketFairDetails.csv"))
            {
                 Console.WriteLine("Creating TicketFairDetails file in MetroCardManagement Folder");
                 File.Create("MetroCardManagement/TicketFairDetails.csv").Close();
            }
            if(!File.Exists("MetroCardManagement/TravelHistoryDetails.csv"))
            {
                 Console.WriteLine("Creating  TravelHistoryDetails file in MetroCardManagement Folder");
                 File.Create("MetroCardManagement/TravelHistoryDetails.csv").Close();
            }
        }

        // WriteToCSV Method
        public static void WriteToCSV()
        {
            string []userContent = new string[Operations.userList.Count];
            for(int i=0;i<Operations.userList.Count;i++)
            {
                userContent[i]=$"{Operations.userList[i].CardNumber},{Operations.userList[i].UserName},{Operations.userList[i].PhoneNumber},{Operations.userList[i].Balance}";
            }
            File.WriteAllLines("MetroCardManagement/UserDetails.csv",userContent);

            string []ticketContent=new string[Operations.ticketList.Count];
            for(int i=0;i<Operations.ticketList.Count;i++)
            {
                ticketContent[i]=$"{Operations.ticketList[i].TicketID},{Operations.ticketList[i].FromLocation},{Operations.ticketList[i].ToLocation},{Operations.ticketList[i].TicketPrice}";
            }
            File.WriteAllLines("MetroCardManagement/TicketFairDetails.csv",ticketContent);

            string []travelContent=new string[Operations.travelList.Count];
            for(int i=0;i<Operations.travelList.Count;i++)
            {
                travelContent[i]=$"{Operations.travelList[i].TravelID},{Operations.travelList[i].CardNumber},{Operations.travelList[i].FromLocation},{Operations.travelList[i].ToLocation},{Operations.travelList[i].Date.ToString("dd/MM/yyyy")},{Operations.travelList[i].TravelCost}";
            }
            File.WriteAllLines("MetroCardManagement/TravelHistoryDetails.csv",travelContent);
        }

        // ReadFromCSV Method      
        public static void ReadFromCSV()
        {
           
            string []userContent = File.ReadAllLines("MetroCardManagement/UserDetails.csv");
            foreach (string oneuser in userContent)
            {
                
                UserDetails user = new UserDetails(oneuser);
                Operations.userList.Add(user);
            }


            string []ticketContent = File.ReadAllLines("MetroCardManagement/TicketFairDetails.csv");
            foreach (string oneticket in ticketContent)
            {
                TicketFairDetails ticket = new TicketFairDetails(oneticket);
                Operations.ticketList.Add(ticket);
            }


            string []travelContent = File.ReadAllLines("MetroCardManagement/TravelHistoryDetails.csv");
            foreach (string onetravel in travelContent)
            {
                TravelHistoryDetails travel = new TravelHistoryDetails(onetravel);
                Operations.travelList.Add(travel);
            }
        }
    
    }
}