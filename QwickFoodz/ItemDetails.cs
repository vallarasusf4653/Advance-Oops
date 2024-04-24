using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class ItemDetails
    {
        //Field
        private static int s_itemID = 4001;
        
        //Property
        /// <summary>
        /// 
        /// </summary>
     
        public string ItemID { get; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public int PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }

        //Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="foodID"></param>
        /// <param name="purchaseCount"></param>
        /// <param name="priceOfOrder"></param>
        public ItemDetails(string orderID, string foodID, int purchaseCount, double priceOfOrder)
        {
            ItemID = "ITID" + s_itemID;
            OrderID = orderID;
            FoodID = foodID;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
            s_itemID++;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public ItemDetails(string item)
        {
            string[] values = item.Split(",");
            ItemID = values[0];
            OrderID = values[1];
            FoodID = values[2];
            PurchaseCount = int.Parse(values[3]);
            PriceOfOrder = double.Parse(values[4]);
            s_itemID++;

        }




    }
}