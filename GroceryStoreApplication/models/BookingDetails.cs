using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreApplication
{
    // enum
    /// <summary>
    /// BookingStatus DataType  used to store the BookingStatus
    /// </summary>
    public enum BookingStatus{
        Default,Initited,Booked,Cancelled
    }
    public class BookingDetails
    {
        // field
        /// <summary>
        /// static field s_bookID used to Auto Increament the value of UserID
        /// </summary>
        private static int s_bookID=3000;
        // Proeprty
        /// <summary>
        /// BookingId property used to store the BookingID
        /// </summary>
        /// <value></value>
        public string BookingID { get; }
        /// <summary>
        /// CustomerID property used to store the CustomerID
        /// </summary>
        /// <value></value>
        public string CustomerID { get; set; }
        /// <summary>
        /// TotalPrice property used to store the TotalPrice
        /// </summary>
        /// <value></value>
        public double TotalPrice { get; set; }
        /// <summary>
        /// DateOfBooking property used to store the DataOfBooking
        /// </summary>
        /// <value></value>
        public DateTime DateOfBooking { get; set; }
        /// <summary>
        /// BookingStatus property used to store the BookingStatus
        /// </summary>
        /// <value></value>
        public BookingStatus BookingStatus { get; set; }
        //constructor
        /// <summary>
        /// BookingStatus constructor is used to assign the Default value to the property
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="totalPrice"></param>
        /// <param name="dateOfBooking"></param>
        /// <param name="bookingStatus"></param>
        public BookingDetails(string customerID, double totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus)
        {
            // Auto  Increamentation
            s_bookID++;
            // Assigning value to property
            BookingID="BID"+s_bookID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfBooking = dateOfBooking;
            BookingStatus = bookingStatus;
        }
        /// <summary>
        ///  BookingStatus constructor is used to assign the Default value to the property
        /// </summary>
        /// <param name="booking"></param>
        //  public BookingDetails(string booking)
        // {
        //     string[] value=booking.Split(",");
        //     // Assigning value to property
        //     s_bookID=int.Parse(value[0].Remove(0,3));
        //     BookingID=value[0];
        //     CustomerID =value[1];
        //     TotalPrice = double.Parse(value[2]);
        //     DateOfBooking =DateTime.ParseExact(value[3],"dd/MM/yyyy",null);
        //     BookingStatus = Enum.Parse<BookingStatus>(value[4],true);
        // }            
    }
}