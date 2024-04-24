using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum OrderStatus { Default, Initiated, Ordered, Cancelled }
    public class OrderDetails
    {
        //Field
        private static int s_orderID = 3001;

        //Property
        /// <summary>
        /// 
        /// </summary> <summary>
        public string OrderID { get; }
        public string CustomerID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfOrder { get; set; }
        public OrderStatus OrderStatus { get; set; }

         // Constructor
         /// <summary>
         /// 
         /// </summary>
         /// <param name="customerID"></param>
         /// <param name="totalPrice"></param>
         /// <param name="dateOfOrder"></param>
         /// <param name="orderStatus"></param> <summary>
     
        public OrderDetails(string customerID, double totalPrice, DateTime dateOfOrder, OrderStatus orderStatus)
        {
            OrderID = "OID" + s_orderID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfOrder = dateOfOrder;
            OrderStatus = orderStatus;
            s_orderID++;
        }
         // Constructor
         /// <summary>
         /// 
         /// </summary>
         /// <param name="order"></param> <summary>
         /// 
         /// </summary>
         /// <param name="order"></param>
        public OrderDetails(string order)
        {
            string[] values = order.Split(",");
            OrderID = values[0];
            CustomerID = values[1];
            TotalPrice = double.Parse(values[2]);
            DateOfOrder = DateTime.ParseExact(values[3], "dd/MM/yyyy", null);
            OrderStatus = Enum.Parse<OrderStatus>(values[4], true);
            s_orderID++;
        }





    }
}