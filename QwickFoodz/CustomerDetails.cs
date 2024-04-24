using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails : PersonalDetails, IBalance
    {
        //Field

        /// <summary>
        /// this field is used hold value of WalletBalance property
        /// </summary>

        private double _balance;
        /// <summary>
        /// this field is used hold value of CustomerID property
        /// </summary>
        private static int s_customerID = 1001;

        // Property

        /// <summary>
        /// CustomerID property is used hold the instance of <see cref="CustomerDetails"/>
        /// </summary>
        public string CustomerID { get; }
        /// <summary>
        /// CustomerID property is used hold the instance of <see cref="CustomerDetails"/>
        /// </summary>
        public double WalletBalance { get { return _balance; } }


        // Constructor

        /// <summary>
        /// Parameter constructor is used assign value for <see cref="CustomerDetails"/>
        /// </summary>
        /// <param name="walletBalance">use to hold walletbalance</param>
        /// <param name="name">used to store value of name</param>
        /// <param name="fatherName">used to store value of fathername</param>
        /// <param name="gender">used to store value of gender</param>
        /// <param name="mobile">used to store value of mobile number</param>
        /// <param name="dob">used to store value of date of birth</param>
        /// <param name="mailID">used to store value of mail id</param>
        /// <param name="location">used to store value of location</param>
        /// <returns></returns>
        public CustomerDetails(double walletBalance, string name, string fatherName, Gender gender, string mobile, DateTime dob, string mailID, string location) : base(name, fatherName, gender, mobile, dob, mailID, location)
        {
            CustomerID = "CID" + s_customerID;
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            DOB = dob;
            MailID = mailID;
            Location = location;
            _balance = walletBalance;
            s_customerID++;
        }
        /// <summary>
        /// Parameter constructor is used assign value for <see cref="CustomerDetails"/>
        /// </summary>
        /// <param name="customer"></param>
        public CustomerDetails(string customer)
        {
            string[] values = customer.Split(",");
            CustomerID = values[0];
            Name = values[2];
            FatherName = values[3];
            Gender = Enum.Parse<Gender>(values[4], true);
            Mobile = values[5];
            DOB = DateTime.ParseExact(values[6], "dd/MM/yyyy", null);
            MailID = values[7];
            Location = values[8];
            _balance = int.Parse(values[1]);
            s_customerID++;
        }


        /// <summary>
        /// this method is used to calculate walletrecharge return current balance
        /// </summary>
        /// <param name="rechargeAmount"></param>
        /// <returns>current balance of <see cref="CustomerDetails"/></returns>

        public double WalletRecharge(double rechargeAmount)
        {
            _balance += rechargeAmount;
            return _balance;
        }

        /// <summary>
        /// this method is used to calculate walletrecharge return current balance
        /// </summary>
        /// <param name="deductAmount"></param>
        /// <returns>current balance of <see cref="CustomerDetails"/></returns>
        public double DeductBalance(double deductAmount)
        {
            _balance -= deductAmount;
            return _balance;
        }
    }
}