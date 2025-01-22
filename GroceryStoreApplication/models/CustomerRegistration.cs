using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreApplication
{
    /// <summary>
    /// CustomerRegistration used to create a instance of customer
    /// </summary>
    public class CustomerRegistration : PersonalDetails,IBalance
    {
        //Field
        /// <summary>
        /// static field s_customerID used to AutoIncreamentation the cutomerID.
        /// </summary>
        private static int s_customerID=1000;
        //Property
        /// <summary>
        /// CustomerID used to store the CustomerID
        /// </summary>
        /// <value></value>
        public string CustomerID { get;  } // ReadOnly
        /// <summary>
        /// WalletBalance used to store the WalletBalance
        /// </summary>
        /// <value></value>
        public double WalletBalance { get; set; }
        // constructor
        /// <summary>
        /// CustomerRegistration constructor used to assign the default value to the Property
        /// </summary>
        /// <param name="walletBalance"></param>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="gender"></param>
        /// <param name="mobile"></param>
        /// <param name="dOB"></param>
        /// <param name="mailID"></param>
        /// <returns></returns>
        public CustomerRegistration(double walletBalance,string name, string mobile,string mailID) : base(name,mobile,mailID)
        {
            // Auto increamentation
            s_customerID++;
            //  Assinging value to property
            CustomerID = "CID"+s_customerID;
            WalletBalance = walletBalance;
        }
        /// <summary>
        /// CustomerRegistration constructor used to assign the default value to the Property
        /// </summary>
        /// <param name="customer"></param>
        // public CustomerRegistration(string customer)
        // {
        //     string[] value=customer.Split(",");
        //     //  Assinging value to property
        //     s_customerID=int.Parse(value[0].Remove(0,3));
        //     CustomerID = value[0];
        //     Name=value[1];
        //     FatherName=value[2];
        //     Gender=Enum.Parse<Gender>(value[3],true);
        //     DOB=DateTime.ParseExact(value[4],"dd/MM/yyyy",null);
        //     MailID=value[5];
        //     Mobile=value[6];
        //     WalletBalance =double.Parse(value[7]);
        // }
        // Method
        /// <summary>
        /// WalletRecharge used to Recharge the CustomerWalletBalance.
        /// </summary>
        /// <param name="amount"></param>
        public void WalletRecharge(double amount)
        {
            WalletBalance+=amount;
        }
    }
}