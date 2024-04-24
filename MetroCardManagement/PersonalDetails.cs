using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails
    {
        //Property


        /// <summary>
        /// UserName property is used store instance of <see cref="PersonalDetails"/>
        /// </summary>   
        public string UserName { get; set; }
        //Property
        /// <summary>
        /// PhoneNumber property is used store instance of <see cref="PersonalDetails"/>
        /// </summary>  
        public long PhoneNumber { get; set; }
        

        //Constructor

        /// <summary>
        /// Parameter constructor is used assign the value for property
        /// </summary>
        /// <param name="userName">used to store username value</param>
        /// <param name="phoneNumber">used to store phoneNumber value</param>
        public PersonalDetails(string userName,long phoneNumber)
        {
            UserName=userName;
            PhoneNumber=phoneNumber;
        }

       /// <summary>
       /// Default constructor
       /// </summary>
        public PersonalDetails()
        {

        }
        
        
    }
}