using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreApplication
{
    /// <summary>
    /// OrderDetails used to create a instance of customerOrder
    /// </summary>
    public class OrderDetails
    {
        // Field
        /// <summary>
        /// Static field s_orderId used to Auto increamentation of the OrderID
        /// </summary>
        private static int s_orderID=4000;
        // Property
        /// <summary>
        /// OrderID property used to Store the OrderID
        /// </summary>
        public string OrderID { get; } // ReadOnly
        /// <summary>
        /// BookingID property used to Store the BookingID
        /// </summary>
        /// <value></value>
        public string BookingID { get; set; }
        /// <summary>
        /// ProductID property used to store the ProductID
        /// </summary>
        /// <value></value>
        public string ProductID { get; set; }
        /// <summary>
        /// PurchaseCount property used to Store the PurchaseCount
        /// </summary>
        /// <value></value>
        public int PurchaseCount { get; set; }
        /// <summary>
        /// PriceOfOrder property used to Store the PriceOfOrder
        /// </summary>
        /// <value></value>
        public double PriceOfOrder { get; set; }
        // Constructor
        /// <summary>
        /// OrderDetailsconstructor used to assign the default value to the property
        /// </summary>
        /// <param name="bookingID"></param>
        /// <param name="productID"></param>
        /// <param name="purchaseCount"></param>
        /// <param name="priceOfOrder"></param>
        public OrderDetails(string bookingID, string productID, int purchaseCount, double priceOfOrder)
        {
            // Auto increament
            s_orderID++;
            //Assigning value to property
            OrderID ="OID"+s_orderID;
            BookingID = bookingID;
            ProductID = productID;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }
        /// <summary>
        ///  OrderDetailsconstructor used to assign the default value to the property
        /// </summary>
        /// <param name="order"></param>
        // public OrderDetails(string order)
        // {
        //     string[] value=order.Split(",");
        //     //Assigning value to property
        //     s_orderID=int.Parse(value[0].Remove(0,3));
        //     OrderID =value[0];
        //     BookingID = value[1];
        //     ProductID = value[2];
        //     PurchaseCount = int.Parse(value[3]);
        //     PriceOfOrder = double.Parse(value[4]);
        // }
    }
}