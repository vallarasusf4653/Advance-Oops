using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class Operations
    {



        public static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();
        public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static CustomList<ItemDetails> itemList = new CustomList<ItemDetails>();
        public static CustomerDetails CurrentLoggedUser;
        // static List<CustomerDetails> customerList = new List<CustomerDetails>();
        // static List<FoodDetails> foodList = new List<FoodDetails>();
        // static List<OrderDetails> orderList = new List<OrderDetails>();
        // static List<ItemDetails> itemList = new List<ItemDetails>();

        public static void MainMenu()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>> Welcome to Qwick Foodz <<<<<<<<<<<<<<<");
            string mainChoice = "yes";
            do
            {
                Console.WriteLine("Main Menu :\n\t\t1. Customer Registration\n\t\t2. Customer Login\n\t\t3. Exit");
                Console.Write("Select Your Option : ");
                int mainoption = int.Parse(Console.ReadLine());
                switch (mainoption)
                {
                    case 1:
                        {
                            Console.WriteLine("***********Customer Registration**********");
                            CustomerRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("***********Customer Login**********");
                            CustomerLogin();
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

        public static void CustomerRegistration()
        {
            Console.Write("Enter Your Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Your FatherName : ");
            string fatherName = Console.ReadLine();
            Console.Write("Select Your Gender in Specified Format (Male,Female,Transgender) : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter Your Mobiloe Number : ");
            string mobile = Console.ReadLine();
            Console.Write("Enter Your DOB : ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter Your MailID : ");
            string mailID = Console.ReadLine();
            Console.Write("Enter Your Location : ");
            string location = Console.ReadLine();
            Console.Write("Enter Your Balance  ");
            double balance = double.Parse(Console.ReadLine());

            CustomerDetails customer = new CustomerDetails(balance, name, fatherName, gender, mobile, dob, mailID, location);
            customerList.Add(customer);
            Console.WriteLine($"Customer Registration Successfully Your Customer ID : {customer.CustomerID}");
        }
        public static void CustomerLogin()
        {
            Console.Write("Enter Your Customer ID : ");
            string customerID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (CustomerDetails customer in customerList)
            {
                if (customer.CustomerID.Equals(customerID))
                {
                    flag = false;
                    CurrentLoggedUser = customer;
                    SubMenu();
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Customer ID");
            }
        }

        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                Console.WriteLine("Sub Menu : \n\t\t1. Show Profile\n\t\t2. Order Food\n\t\t3. Cancel Order\n\t\t4. Modify Order\n\t\t5. Order History\n\t\t6. Recharge Wallet\n\t\t7. Show Wallet Balance\n\t\t8. Exit");
                Console.Write("Select Your Option : ");
                int subOption = int.Parse(Console.ReadLine());
                switch (subOption)
                {
                    case 1:
                        {
                            Console.WriteLine("**********Show Profile**********");
                            Console.WriteLine("CustomerID\tWalletBalance\tName\tFatherName\tGender\tMobile\tDOB\tMailID\tLocation");
                            Console.WriteLine($"{CurrentLoggedUser.CustomerID}\t{CurrentLoggedUser.WalletBalance}\t{CurrentLoggedUser.Name}\t{CurrentLoggedUser.FatherName}\t{CurrentLoggedUser.Gender}\t{CurrentLoggedUser.DOB.ToString("dd/MM/yyyy")}\t{CurrentLoggedUser.MailID}\t{CurrentLoggedUser.Location}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("**********Order Food**********");
                            OrderFood();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("**********Cancel Food**********");
                            CancelFood();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("**********Modify Order**********");
                            ModifyOrder();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("**********Order History**********");
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("**********Recharge Wallet**********");
                            Console.Write("Enter The Amount to Recharge : ");
                            double rechargeAmount = double.Parse(Console.ReadLine());
                            Console.WriteLine($"Current Balance : {CurrentLoggedUser.WalletRecharge(rechargeAmount)}");
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("**********Show Wallet Balance**********");
                            Console.WriteLine($"Current Balance : {CurrentLoggedUser.WalletBalance}");
                            break;
                        }
                    case 8:
                        {
                            subChoice = "no";
                            break;
                        }
                }
            } while (subChoice.Equals("yes"));
        }

        public static void OrderFood()
        {
            // a.	Create OrderDetails object with CustomerID, TotalPrice = 0, DateOfOrder as today and OrderStatus = Initiated.
            OrderDetails order = new OrderDetails(CurrentLoggedUser.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
            // b.	Create localItemList for adding your wishlist.
            List<ItemDetails> wishList = new List<ItemDetails>();
            // c.	Show all the list of food items available in store for processing the order.
            bool flag = true;
            string choice = "yes";
            double totalOrderPrice = 0;
            do
            {
                Console.WriteLine("FoodID\tFoodName\tPricePerQuantity\tQuantityAvailable");
                foreach (FoodDetails food in foodList)
                {
                    Console.WriteLine($"{food.FoodID}\t{food.FoodName}\t{food.PricePerQuantity}\t{food.QuantityAvailable}");
                }
                // d.	Ask the FoodID, order quantity from user and check whether it is available. If not show FoodID Invalid or FoodQuantity unavailable based on the scenario. 
                Console.Write("Enter the Food ID :");
                string foodID = Console.ReadLine().ToUpper();

                foreach (FoodDetails food in foodList)
                {
                    if (food.FoodID.Equals(foodID))
                    {
                        flag = false;
                        Console.Write("Enter Order Quantity  : ");
                        int orderQuantity = int.Parse(Console.ReadLine());
                        if (food.QuantityAvailable >= orderQuantity)
                        {

                            // e.	If it is available then, create ItemDetails object with created OrderID, FoodID, Quantity and Price of this order,
                            // deduct the available quantity and store the ItemDetails object in localItemList.
                            food.QuantityAvailable -= orderQuantity;
                            // Calculate total price of this order by summing it with current item’s price.
                            double priceOfOrder = food.PricePerQuantity * orderQuantity;
                            totalOrderPrice += priceOfOrder;
                            ItemDetails item = new ItemDetails(order.OrderID, food.FoodID, orderQuantity, priceOfOrder);
                            wishList.Add(item);
                            // f.	Ask the user whether he want to order more. If “Yes” means again show food details and repeat from step “c” to create new ItemDetails object. Repeat this process until he says “No”.

                            Console.Write("Do you want order another item (yes/no) : ");
                            choice = Console.ReadLine().ToLower();
                            //break;
                        }
                        else
                        {
                            Console.WriteLine("Food Quantity unavailable");
                        }
                    }
                }
            } while (choice.Equals("yes"));

            if (choice.Equals("no"))
            {
                // g.	If user select “No” then show “Do you want to confirm purchase.” 
                Console.Write("Do you want to confirm purchase (yes/no) : ");
                string purchaseChoice = Console.ReadLine().ToLower();
                if (purchaseChoice.Equals("no"))
                {
                    //If he says “No” return the localItemList of items count back to FoodDetails list.
                    foreach (ItemDetails item in wishList)
                    {
                        foreach (FoodDetails food in foodList)
                        {
                            if (item.FoodID.Equals(food.FoodID))
                            {
                                food.QuantityAvailable += item.PurchaseCount;
                            }
                        }
                    }

                }
                else
                {
                    string isrechrage = "no";
                    do
                    {
                        // h.	If he says “Yes”. 
                        // i.	Check whether the customer wallet has sufficient balance.
                        if (CurrentLoggedUser.WalletBalance >= totalOrderPrice)
                        {
                            // j.	 If he has balance then, modify OrderDetails object which was created at beginning with TotalPrice and OrderStatus to “Ordered”. Deduct the total amount from user’s wallet balance. Add the localItemList to ItemList. 
                            order.OrderStatus = OrderStatus.Ordered;
                            order.TotalPrice = totalOrderPrice;
                            CurrentLoggedUser.DeductBalance(totalOrderPrice);
                            orderList.Add(order);
                            foreach (ItemDetails item in wishList)
                            {
                                itemList.Add(item);
                            }
                            // itemList.AddRange(wishList);

                            Console.WriteLine($"Order successfully Placed and your Order ID {order.OrderID}");
                        }
                        else
                        {
                            // k.	If the balance is insufficient, inform the customer that the wallet has insufficient balance and whether wish to recharge /not.
                            Console.WriteLine("the wallet has insufficient balance ");
                            Console.Write("Are you want to recharge : ");
                            Console.WriteLine();
                            isrechrage = Console.ReadLine().ToLower();
                            if (isrechrage.Equals("yes"))
                            {
                                double amountToRecharge = CurrentLoggedUser.WalletBalance - totalOrderPrice;
                                // m.	If “Yes” ask for the amount to be recharged. Show the balance after recharge and goto step “i” to proceed purchase again.
                                Console.Write($"You have to recharge {amountToRecharge} to  order : ");
                                double rechargeAmount = double.Parse(Console.ReadLine());
                                Console.WriteLine($"Current Balance : {CurrentLoggedUser.WalletRecharge(rechargeAmount)}");

                            }
                            else
                            {
                                // l.	If he says “No” return the localItemList item’s count to FoodList.
                                foreach (ItemDetails item in wishList)
                                {
                                    foreach (FoodDetails food in foodList)
                                    {
                                        if (item.FoodID.Equals(food.FoodID))
                                        {
                                            food.QuantityAvailable += item.PurchaseCount;
                                        }
                                    }
                                }

                            }

                        }
                    } while (isrechrage.Equals("yes"));
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid FoodID");
            }
        }

        public static void ModifyOrder()
        {
            // a.	Show the orders placed by current logged in user whose order status is booked.
            if (orderList.Count > 0)
            {
                Console.WriteLine("OrderID\tCustomerID\tTotalPrice\tDateOfOrder\tOrderStatus");
                bool flag = true;
                foreach (OrderDetails order in orderList)
                {

                    if (order.CustomerID.Equals(CurrentLoggedUser.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                        flag = false;
                        Console.WriteLine($"{order.OrderID}\t{order.CustomerID}\t{order.TotalPrice}\t{order.DateOfOrder.ToString("dd/MM/yyyy")}\t{order.OrderStatus}");
                    }
                }
                if (flag)
                {
                    Console.WriteLine("No Order History for Current Customer");

                }
            }
            else
            {
                Console.WriteLine("No Order History");
            }
            // b.	Ask OrderID to modify orders
            Console.Write("Enter Order ID to modify the Order : ");
            string orderID = Console.ReadLine().ToUpper();
            Console.WriteLine();


            // c.	Check OrderID is valid, and it is of current user’s and its status is Ordered. Then fetch the item details of corresponding order and show it.
            bool flag1 = true;
            bool flag3 = false;
            foreach (OrderDetails order in orderList)
            {

                if (order.CustomerID.Equals(CurrentLoggedUser.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered) && order.OrderID.Equals(orderID))
                {
                    flag1 = false;
                    Console.WriteLine("ItemID\tOrderID\tFoodID\tPurchaseCount\tPriceOfOrder");
                    foreach (ItemDetails item in itemList)
                    {
                        if (item.OrderID.Equals(order.OrderID))
                        {

                            Console.WriteLine($"{item.ItemID}\t{item.OrderID}\t{item.FoodID}\t{item.PurchaseCount}\t{item.PriceOfOrder}");

                        }
                    }

                    // d.	Ask ItemID and check ItemID is valid. Then ask user to provide new item quantity.
                    Console.Write("Enter ItemID to modify the Order : ");
                    string itemID = Console.ReadLine().ToUpper();
                    Console.WriteLine();
                    bool flag2 = true;
                    foreach (ItemDetails item in itemList)
                    {
                        if (item.OrderID.Equals(order.OrderID) && item.ItemID.Equals(itemID))
                        {
                            flag2 = false;
                            Console.Write("Enter New Quanitiy : ");
                            int newQuantity = int.Parse(Console.ReadLine());
                            // e.	Based on new item quantity the item object needs to be updated its price.
                            foreach (FoodDetails food in foodList)
                            {
                                if (item.FoodID.Equals(food.FoodID))
                                {

                                    food.QuantityAvailable += item.PurchaseCount;
                                    order.TotalPrice -= item.PriceOfOrder;
                                    CurrentLoggedUser.WalletRecharge(item.PriceOfOrder);


                                    double total = food.PricePerQuantity * newQuantity;


                                    if (CurrentLoggedUser.WalletBalance >= total)
                                    {
                                        flag3 = true;
                                        CurrentLoggedUser.DeductBalance(total);
                                        food.QuantityAvailable -= newQuantity;
                                        order.TotalPrice += total;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient Balance : Please Recharge :");

                                    }
                                }
                            }


                            // f.	If item quantity increased, then item amount will be collected from current user if he has enough balance.
                            // If he has no balance, ask him to recharge with that amount and proceed. 
                            //If the item quantity reduced, then balance amount should be returned to current user.   
                        }
                    }
                    if (flag3)
                    {
                        // g.	Update the total amount of order and show “Order ID + (OID3001) + modified successfully”.
                        Console.WriteLine($"Order ID  {order.OrderID}  modified successfully");
                    }

                    if (flag2)
                    {
                        Console.WriteLine("Invalid ItemID");
                    }
                }
            }
            if (flag1)
            {
                Console.WriteLine("Invalid Order ID .");
            }
        }

        public static void CancelFood()
        {
            // a.	Show the list of orders placed by current logged in user whose status is “Ordered”.
            if (orderList.Count > 0)
            {
                Console.WriteLine("OrderID\tCustomerID\tTotalPrice\tDateOfOrder\tOrderStatus");
                bool flag = true;
                foreach (OrderDetails order in orderList)
                {

                    if (order.CustomerID.Equals(CurrentLoggedUser.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                        flag = false;
                        Console.WriteLine($"{order.OrderID}\t{order.CustomerID}\t{order.TotalPrice}\t{order.DateOfOrder.ToString("dd/MM/yyyy")}\t{order.OrderStatus}");
                    }
                }
                if (flag)
                {
                    Console.WriteLine("No Order History for Current Customer");

                }
            }
            else
            {
                Console.WriteLine("No Order History");
            }
            // b.	Ask the user to pick an order to be cancelled by OrderID.
            Console.Write("Enter Order ID to Cancell the Order : ");
            string orderID = Console.ReadLine().ToUpper();
            bool flag1 = true;
            bool flag2 = false;
            foreach (OrderDetails order in orderList)
            {

                if (order.CustomerID.Equals(CurrentLoggedUser.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered) && order.OrderID.Equals(orderID))
                {
                    flag1 = false;
                    // c.	If OrderID is present, then change the order status to “Cancelled”.
                    order.OrderStatus = OrderStatus.Cancelled;
                    double refundAmount = order.TotalPrice;
                    // d.   Refund the total price amount of current order to user’s WalletBalance then 
                    CurrentLoggedUser.WalletRecharge(refundAmount);
                    foreach (ItemDetails item in itemList)
                    {
                        if (order.OrderID.Equals(item.OrderID))
                        {

                            foreach (FoodDetails food in foodList)
                            {
                                if (food.FoodID.Equals(item.FoodID))
                                {
                                    flag2 = true;
                                    //e. return the food items of the current order to FoodList.         
                                    food.QuantityAvailable += item.PurchaseCount;

                                }
                            }


                        }
                    }
                }

            }
            if (flag2)
            {
                Console.WriteLine($"Order Successfully Cancelled");
            }
            if (flag1)
            {
                Console.WriteLine("Invalid Order ID .");
            }
        }

        public static void OrderHistory()
        {
            if (orderList.Count > 0)
            {
                Console.WriteLine("OrderID\tCustomerID\tTotalPrice\tDateOfOrder\tOrderStatus");
                bool flag = true;
                foreach (OrderDetails order in orderList)
                {

                    if (order.CustomerID.Equals(CurrentLoggedUser.CustomerID))
                    {
                        flag = false;
                        Console.WriteLine($"{order.OrderID}\t{order.CustomerID}\t{order.TotalPrice}\t{order.DateOfOrder.ToString("dd/MM/yyyy")}\t{order.OrderStatus}");
                    }
                }
                if (flag)
                {
                    Console.WriteLine("No Order History for Current Customer");

                }
            }
            else
            {
                Console.WriteLine("No Order History");
            }
        }

        public static void DefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails(10000, "Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmial.com", "Chennai");
            CustomerDetails customer2 = new CustomerDetails(15000, "Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "baskaran@gmial.com", "Chennai");
            customerList.Add(customer1);
            customerList.Add(customer2);

            FoodDetails food1 = new FoodDetails("Chicken Briyani 1 Kg", 100, 12);
            FoodDetails food2 = new FoodDetails("Mutton Briyani 1 Kg", 150, 10);
            FoodDetails food3 = new FoodDetails("Veg Full Meals 1 Kg", 80, 30);
            FoodDetails food4 = new FoodDetails("Noodles", 100, 40);
            FoodDetails food5 = new FoodDetails("Dosa", 40, 40);
            FoodDetails food6 = new FoodDetails("Idly(2 Pieces)", 20, 50);
            FoodDetails food7 = new FoodDetails("Pongal", 40, 20);
            FoodDetails food8 = new FoodDetails("Vegetable Briyani", 80, 15);
            FoodDetails food9 = new FoodDetails("Lemon Rice", 50, 30);
            FoodDetails food10 = new FoodDetails("Veg Pulav", 120, 30);
            FoodDetails food11 = new FoodDetails("Chicken 65 (200 Grams)", 75, 30);
            foodList.Add(food1);
            foodList.Add(food2);
            foodList.Add(food3);
            foodList.Add(food4);
            foodList.Add(food5);
            foodList.Add(food6);
            foodList.Add(food7);
            foodList.Add(food8);
            foodList.Add(food9);
            foodList.Add(food10);
            foodList.Add(food11);

            OrderDetails order1 = new OrderDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order3 = new OrderDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled);

            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);

            ItemDetails item1 = new ItemDetails("OID3001", "FID2001", 2, 200);
            ItemDetails item2 = new ItemDetails("OID3001", "FID2002", 2, 300);
            ItemDetails item3 = new ItemDetails("OID3001", "FID2003", 1, 80);
            ItemDetails item4 = new ItemDetails("OID3002", "FID2001", 1, 100);
            ItemDetails item5 = new ItemDetails("OID3002", "FID2002", 4, 600);
            ItemDetails item6 = new ItemDetails("OID3002", "FID2010", 1, 120);
            ItemDetails item7 = new ItemDetails("OID3002", "FID2009", 1, 50);
            ItemDetails item8 = new ItemDetails("OID3003", "FID2002", 2, 300);
            ItemDetails item9 = new ItemDetails("OID3003", "FID2008", 4, 320);
            ItemDetails item10 = new ItemDetails("OID3003", "FID2001", 2, 200);
            itemList.Add(item1);
            itemList.Add(item2);
            itemList.Add(item3);
            itemList.Add(item4);
            itemList.Add(item5);
            itemList.Add(item6);
            itemList.Add(item7);
            itemList.Add(item8);
            itemList.Add(item9);
            itemList.Add(item10);


        }
    }
}