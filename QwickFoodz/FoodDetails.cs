using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FoodDetails
    {
        // Field
        /// <summary>
        /// 
        /// </summary>
        private static int s_foodID = 2001;
        //Property
        public string FoodID { get; }
        public string FoodName { get; set; }
        public double PricePerQuantity { get; set; }
        public int QuantityAvailable { get; set; }

       // Constructor
       /// <summary>
       /// 
       /// </summary>
       /// <param name="foodName"></param>
       /// <param name="price"></param>
       /// <param name="quantity"></param>
        public FoodDetails(string foodName, double price, int quantity)
        {
            FoodID = "FID" + s_foodID;
            FoodName = foodName;
            PricePerQuantity = price;
            QuantityAvailable = quantity;
            s_foodID++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="food"></param> <summary>
        /// 
        /// </summary>
        /// <param name="food"></param>
        public FoodDetails(string food)
        {
            string[] values = food.Split(",");
            FoodID = values[0];
            FoodName = values[1];
            PricePerQuantity = double.Parse(values[2]);
            QuantityAvailable = int.Parse(values[3]);
            s_foodID++;
        }



    }
}