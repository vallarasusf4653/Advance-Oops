using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static class Operations
    {
       // static List<UserDetails> userList = new List<UserDetails>();
       // static List<TravelHistoryDetails> travelList = new List<TravelHistoryDetails>();
       // static List<TicketFairDetails> ticketList = new List<TicketFairDetails>();


        // Custom List for UserDetails
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
         // Custom List for TravelHistoryDetails
        public static CustomList<TravelHistoryDetails> travelList = new CustomList<TravelHistoryDetails>();
         // Custom List for TicketFairDetails
        public static CustomList<TicketFairDetails> ticketList = new CustomList<TicketFairDetails>();

        // used to current user object
        static UserDetails CurrentLoggedUser;

        // Main Menu
        public static void MainMenu()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>Welcome to Metro Card Management<<<<<<<<<<<<<<<<");
            string mainChoice = "yes";
            do
            {
                Console.WriteLine(" Main Menu : \n\t\t1. New User Registartion\n\t\t2. Login User\n\t\t3. Exit");
                Console.Write("Select the Option : ");
                int mainOption = int.Parse(Console.ReadLine());
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("**********New User Registration**********");
                            NewUserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("**********Login User**********");
                            LoginUser();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Application Exit Successfully");
                            mainChoice = "no";
                            break;
                        }
                }
            } while (mainChoice.Equals("yes"));

        }

        public static void NewUserRegistration()
        {
            Console.Write("Enter Your Name : ");
            string userName = Console.ReadLine();
            Console.Write("Enter Your Phone Number : ");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter Your Balance : ");
            double balance = double.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(userName, phoneNumber, balance);
            userList.Add(user);
            Console.WriteLine($"Your Card number is {user.CardNumber}");
        }

        public static void LoginUser()
        {
            Console.Write("Enter Your Card Number : ");
            string loginNumber = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (UserDetails user in userList)
            {
                if (user.CardNumber.Equals(loginNumber))
                {
                    Console.WriteLine($"Welcome {user.UserName}");
                    flag = false;
                    CurrentLoggedUser = user;
                    SubMenu();


                }
            }
            if (flag)
            {
                Console.WriteLine("The Card number you entered is not a valid one");
            }
        }


        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                Console.WriteLine("Sub Menu : \n\t\ta. Balance Check\n\t\tb. Recharge\n\t\tc. View Travel History\n\t\td. Travel\n\t\te. Exit");
                Console.Write("Please Mention Your Option : ");
                char subOption = char.Parse(Console.ReadLine().ToLower());
                switch (subOption)
                {
                    case 'a':
                        {
                            Console.WriteLine("**********Balance Check**********");
                            BalanceCheck();
                            break;
                        }
                    case 'b':
                        {
                            Console.WriteLine("**********Recharge**********");
                            Recharge();
                            break;
                        }
                    case 'c':
                        {
                            Console.WriteLine("**********View Travel History**********");
                            ViewTravelHostory();
                            break;
                        }
                    case 'd':
                        {
                            Console.WriteLine("**********Travel**********");
                            Travel();
                            break;
                        }
                    case 'e':
                        {
                            subChoice = "no";
                            break;
                        }
                }
            } while (subChoice.Equals("yes"));
        }

        public static void BalanceCheck()
        {
            Console.WriteLine($"Current Balance : {CurrentLoggedUser.Balance}");
        }
        public static void Recharge()
        {
            Console.Write("Enter the amount to Recharge :");
            double rechargeAmount = double.Parse(Console.ReadLine());
            double currentBalance = CurrentLoggedUser.WalletRecharge(rechargeAmount);
            Console.WriteLine($"Current Balance : {CurrentLoggedUser.Balance}");

        }
        public static void ViewTravelHostory()
        {
            if (travelList.Count > 0)
            {
                Console.WriteLine("|TravelID|\t|CardNumber|\t|FromLocation|\t|ToLocation|\t|  Date  |\t|TravelCost|");
                Console.WriteLine();
                bool flag=true;
                foreach (TravelHistoryDetails travel in travelList)
                {
                    if (CurrentLoggedUser.CardNumber.Equals(travel.CardNumber))
                    {
                        flag=false;
                        Console.WriteLine($"{travel.TravelID}\t      {travel.CardNumber}\t      {travel.FromLocation}\t\t{travel.ToLocation}\t\t{travel.Date.ToString("dd/MM/yyyy")}\t{travel.TravelCost}");
                    }
                }
                if(flag)
                {
                      Console.WriteLine("No Travel History");
                }
            }
            else
            {
                Console.WriteLine("No Travel History");
            }
        }
        public static void Travel()
        {

            //1.	Show the Ticket fair details where the user wishes to travel by getting TicketID.
            Console.WriteLine("TicketID      FromLocation      ToLocation    Fair");
            foreach (TicketFairDetails ticket in ticketList)
            {
                Console.WriteLine($"{ticket.TicketID}\t     {ticket.FromLocation  }\t{ticket.ToLocation}\t   {ticket.TicketPrice}");
            }
            Console.Write("Enter TicketID :");
            string ticketID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (TicketFairDetails ticket in ticketList)
            {
                // 2.	Check the ticketID is valid. Else show “Invalid user id”.
                if (ticket.TicketID.Equals(ticketID))
                {
                    flag = false;
                    // 3.	IF ticket is valid then, Check the balance from the user object whether it has sufficient balance to travel.
                    if (CurrentLoggedUser.Balance >= ticket.TicketPrice)
                    {

                        // 4.	If “Yes” deduct the respective amount from the balance and 
                        //add the travel details like Card number, From and ToLocation, Travel Date, Travel cost, Travel ID (auto generation) in his travel history.
                        CurrentLoggedUser.DeductBalance(ticket.TicketPrice);
                        TravelHistoryDetails travel= new TravelHistoryDetails(CurrentLoggedUser.CardNumber,ticket.FromLocation,ticket.ToLocation,DateTime.Now,ticket.TicketPrice);
                        travelList.Add(travel);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Ticket ID");
            }


            // 5.	If “No” ask him to recharge and go to the “Existing User Service” menu.

        }
        // DefaultData
        public static void DefaultData()
        {

            UserDetails user1 = new UserDetails("Ravi", 9848812345, 1000);
            UserDetails user2 = new UserDetails("Baskaran", 9948854321, 1000);

            userList.Add(user1);
            userList.Add(user2);

            TravelHistoryDetails travel1 = new TravelHistoryDetails("CMRL1001", "Airport", "Egmore", new DateTime(2023, 10, 10), 55);
            TravelHistoryDetails travel2 = new TravelHistoryDetails("CMRL1001", "Egmore", "Koyambedu", new DateTime(2023, 10, 10), 32);
            TravelHistoryDetails travel3 = new TravelHistoryDetails("CMRL1001", "Alandur", "Koyambedu", new DateTime(2023, 11, 10), 25);
            TravelHistoryDetails travel4 = new TravelHistoryDetails("CMRL1001", "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 25);
            travelList.Add(travel1);
            travelList.Add(travel2);
            travelList.Add(travel3);
            travelList.Add(travel4);

            TicketFairDetails ticket1 = new TicketFairDetails("Airport", "Egmore", 55);
            TicketFairDetails ticket2 = new TicketFairDetails("Airport", "Koyambedu", 25);
            TicketFairDetails ticket3 = new TicketFairDetails("Alandur", "Koyambedu", 25);
            TicketFairDetails ticket4 = new TicketFairDetails("Koyambedu", "Egmore", 32);
            TicketFairDetails ticket5 = new TicketFairDetails("Vadapalani", "Egmore", 45);
            TicketFairDetails ticket6 = new TicketFairDetails("Arumbakkam", "Egmore", 25);
            TicketFairDetails ticket7 = new TicketFairDetails("Vadapalani", "Koyambedu", 25);
            TicketFairDetails ticket8 = new TicketFairDetails("Arumbakkam", "Koyambedu", 16);

            ticketList.Add(ticket1);
            ticketList.Add(ticket2);
            ticketList.Add(ticket3);
            ticketList.Add(ticket4);
            ticketList.Add(ticket5);
            ticketList.Add(ticket6);
            ticketList.Add(ticket7);
            ticketList.Add(ticket8);


            // // forEach
            // foreach (UserDetails user in userList)
            // {
            //     Console.WriteLine($"{user.CardNumber}\t{user.UserName}\t{user.PhoneNumber}\t{user.Balance}");
            // }



            // foreach (TicketFairDetails ticket in ticketList)
            // {
            //     Console.WriteLine($"{ticket.TicketID}\t{ticket.FromLocation}\t{ticket.ToLocation}\t{ticket.TicketPrice}");
            // }

        }

    }
}