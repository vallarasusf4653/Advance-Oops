using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFairDetails
    {
        /// <summary>
        /// s_ticketID is used hold initial value and it's a autoincrement
        /// </summary>
        private static int s_ticketID=3001;
        //Property

        /// <summary>
        /// TicketID property is used store instance of <see cref="TicketFairDetails"/>
        /// </summary>
        public string TicketID { get; set; }
        /// <summary>
        /// FromLocation property is used store instance of <see cref="TicketFairDetails"/>
        /// </summary>
        public string FromLocation { get; set; }
        /// <summary>
        /// ToLocation property is used store instance of <see cref="TicketFairDetails"/>
        /// </summary>
        public string ToLocation { get; set; }
        /// <summary>
        /// TicketPrice property is used store instance of <see cref="TicketFairDetails"/>
        /// </summary>
        public double TicketPrice { get; set; }

        // Constructor
        /// <summary>
        /// parameter constructor is used to initialize the values of <see cref="TicketFairDetails"/> 
        /// </summary>
        /// <param name="fromLocation">used to hold the fromLocaton value</param>
        /// <param name="toLocation">used to hold the toLocaton value</param>
        /// <param name="ticketFair">used to hold the ticketFair value</param>
        public TicketFairDetails(string fromLocation,string toLocation,double ticketFair )
        {
             TicketID="MR"+s_ticketID;
             FromLocation=fromLocation;
             ToLocation=toLocation;
             TicketPrice=ticketFair;
             s_ticketID++;
        }   
        
        /// <summary>
        /// parameter constructor is used to initialize the values of <see cref="TicketFairDetails"/> 
        /// </summary>
        /// <param name="ticket">used to hold string value of entire details</param>
        public TicketFairDetails(string ticket )
        {
            string []values=ticket.Split(",");
             TicketID=values[0];
             FromLocation=values[1];
             ToLocation=values[2];
             TicketPrice=double.Parse(values[3]);
             s_ticketID++;
             
        }       
        
        
        
        
        
        
        
    }
}