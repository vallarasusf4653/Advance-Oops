using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class FileHandling
    {
        // create
        public static void Create()
        {
            if (!Directory.Exists("QwickFoodz"))
            {
                Console.WriteLine("Creating QwickFoodz folder..");
                Directory.CreateDirectory("QwickFoodz");
            }
            if (!File.Exists("QwickFoodz/CustomerDetails.csv"))
            {
                File.Create("QwickFoodz/CustomerDetails.csv").Close();
            }
            if (!File.Exists("QwickFoodz/OrderDetails.csv"))
            {
                File.Create("QwickFoodz/OrderDetails.csv").Close();
            }
            if (!File.Exists("QwickFoodz/ItemDetails.csv"))
            {
                File.Create("QwickFoodz/ItemDetails.csv").Close();
            }
            if (!File.Exists("QwickFoodz/FoodDetails.csv"))
            {
                File.Create("QwickFoodz/FoodDetails.csv").Close();
            }
        }
        // WriteToCsv Method
        public static void WriteToCSV()
        {
            string[] customerContent = new string[Operations.customerList.Count];
            for (int i = 0; i < Operations.customerList.Count; i++)
            {
                customerContent[i] = $"{Operations.customerList[i].CustomerID},{Operations.customerList[i].WalletBalance},{Operations.customerList[i].Name},{Operations.customerList[i].FatherName},{Operations.customerList[i].Gender},{Operations.customerList[i].Mobile},{Operations.customerList[i].DOB.ToString("dd/MM/yyyy")},{Operations.customerList[i].MailID},{Operations.customerList[i].Location}";
            }
            File.WriteAllLines("QwickFoodz/CustomerDetails.csv", customerContent);

            string[] foodContent = new string[Operations.foodList.Count];
            for (int i = 0; i < Operations.foodList.Count; i++)
            {
                foodContent[i] = $"{Operations.foodList[i].FoodID},{Operations.foodList[i].FoodName},{Operations.foodList[i].PricePerQuantity},{Operations.foodList[i].QuantityAvailable}";
            }
            File.WriteAllLines("QwickFoodz/FoodDetails.csv", foodContent);

            string[] orderContent = new string[Operations.orderList.Count];
            for (int i = 0; i < Operations.orderList.Count; i++)
            {
                orderContent[i] = $"{Operations.orderList[i].OrderID},{Operations.orderList[i].CustomerID},{Operations.orderList[i].TotalPrice},{Operations.orderList[i].DateOfOrder.ToString("dd/MM/yyyy")},{Operations.orderList[i].OrderStatus}";

            }
            File.WriteAllLines("QwickFoodz/OrderDetails.csv", orderContent);

            string[] itemContent = new string[Operations.itemList.Count];
            for (int i = 0; i < Operations.itemList.Count; i++)
            {
                itemContent[i] = $"{Operations.itemList[i].ItemID},{Operations.itemList[i].OrderID},{Operations.itemList[i].FoodID},{Operations.itemList[i].PurchaseCount},{Operations.itemList[i].PriceOfOrder},";
            }
            File.WriteAllLines("QwickFoodz/ItemDetails.csv", itemContent);
        }

        // ReadFromCSV method
        public static void ReadFromCSV()
        {
            string[] customerContent = File.ReadAllLines("QwickFoodz/CustomerDetails.csv");
            foreach (string customer in customerContent)
            {
                CustomerDetails customer1 = new CustomerDetails(customer);
                Operations.customerList.Add(customer1);
            }

            string[] foodContent = File.ReadAllLines("QwickFoodz/FoodDetails.csv");
            foreach (string food in foodContent)
            {
                FoodDetails food1 = new FoodDetails(food);
                Operations.foodList.Add(food1);
            }

            string[] orderContent = File.ReadAllLines("QwickFoodz/OrderDetails.csv");
            foreach (string order in orderContent)
            {
                OrderDetails order1 = new OrderDetails(order);
                Operations.orderList.Add(order1);
            }

            string[] itemContent = File.ReadAllLines("QwickFoodz/ItemDetails.csv");
            foreach (string item in itemContent)
            {
                ItemDetails item1 = new ItemDetails(item);
                Operations.itemList.Add(item1);
            }
        }
    }
}