using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {
        // Field
        /// <summary>
        /// s_cardNumber is used to hold initial value and it is autoincrement
        /// </summary> <summary>
        private static int s_cardNumber = 1001;

        // Property

        /// <summary>
        /// CardNumber Property used to hold value of instance of <see cref="UserDeatails"/>
        /// </summary> <summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// Balance Property used to hold value of instance of <see cref="UserDeatails"/>
        /// </summary> <summary>
        public double Balance { get; set; }

        //Constructor

        /// <summary>
        /// Parameter constructor is used assign the value for property
        /// </summary>
        /// <param name="userName">used to store username value</param>
        /// <param name="phoneNumber">used to store phonenumber value</param>
        /// <param name="balance">used to store balance value</param>
        /// <returns></returns>
        public UserDetails(string userName, long phoneNumber, double balance) : base(userName, phoneNumber)
        {
            CardNumber = "CMRL" + s_cardNumber;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Balance = balance;
            s_cardNumber++;
        }

        /// <summary>
        /// Parameter constructor is used assign the value for property
        /// </summary>
        /// <param name="user">used to store full object of userDetails </param>
        public UserDetails(string user)
        {
            string[] values = user.Split(",");
            CardNumber = values[0];
            UserName = values[1];
            PhoneNumber = long.Parse(values[2]);
            Balance = double.Parse(values[3]);
            s_cardNumber++;

        }

        // Methods

        /// <summary>
        /// This method is used to get value as parameter and process and and return balance
        /// </summary>
        /// <param name="rechargeAmount">is used to get value as parameter </param>
        /// <returns>Balance</returns> <summary>

        public double WalletRecharge(double rechargeAmount)
        {
            Balance += rechargeAmount;
            return Balance;
        }
        /// <summary>
        /// This method is used to get value as parameter and process and and return balance
        /// </summary>
        /// <param name="deductAmount">is used to get value as parameter </param>
        /// <returns>Balance</returns> <summary>
        public double DeductBalance(double deductAmount)
        {
            Balance -= deductAmount;
            return Balance;
        }




    }
}