using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreApplication
{
    /// <summary>
    /// IBalance Interface
    /// </summary>
    public interface IBalance
    {
        //Property
        /// <summary>
        /// Wallet Valance used to store the CustomreWalletBalance
        /// </summary>
        /// <value></value>
        double WalletBalance { get; set;}
        ///Method
        /// <summary>
        /// WalletRecharge Method Declaration
        /// </summary>
        /// <param name="amount"></param>
        public void WalletRecharge(double amount);
        
    }
}