using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelHistoryDetails
    {

        //Field

        /// <summary>
        /// s_travelID is used hold initial value and it's a autoincrement
        /// </summary>
        private static int s_travelID = 2001;
        //Property

        /// <summary>
        /// TravelID property is used store instance of <see cref="TravelHistoryDetails"/>
        /// </summary>
        public string TravelID { get; }
        /// <summary>
        /// CardNumber property is used store instance of <see cref="TravelHistoryDetails"/>
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// FromLocation property is used store instance of <see cref="TravelHistoryDetails"/>
        /// </summary>
        public string FromLocation { get; set; }
        /// <summary>
        /// ToLocation property is used store instance of <see cref="TravelHistoryDetails"/>
        /// </summary>
        public string ToLocation { get; set; }
        /// <summary>
        /// Date property is used store instance of <see cref="TravelHistoryDetails"/>
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// TravelCost property is used store instance of <see cref="TravelHistoryDetails"/>
        /// </summary>
        public double TravelCost { get; set; }


        // Constructor

        /// <summary>
        /// parameter constructor is used to initialize the values of <see cref="TravelHistoryDetails"/> 
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="fromLocation"></param>
        /// <param name="toLocation"></param>
        /// <param name="date"></param>
        /// <param name="travelCost"></param>
        public TravelHistoryDetails(string cardNumber, string fromLocation, string toLocation, DateTime date, double travelCost)
        {
            TravelID = "TID" + s_travelID;
            CardNumber = cardNumber;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            Date = date;
            TravelCost = travelCost;
            s_travelID++;
        }

        /// <summary>
        /// parameter constructor is used to initialize the values of <see cref="TravelHistoryDetails"/> 
        /// </summary>
        /// <param name="travel">used to hold string value of entire details</param>
        public TravelHistoryDetails(string travel)
        {
            string[] values = travel.Split(",");
            TravelID = values[0];
            CardNumber = values[1];
            FromLocation = values[2];
            ToLocation = values[3];
            Date = DateTime.ParseExact(values[4], "dd/MM/yyyy", null);
            TravelCost = double.Parse(values[5]);
            s_travelID++;

        }












    }
}