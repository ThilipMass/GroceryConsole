using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using Serilog;

namespace GroceryStoreApplication
{
    // Static class
    public static class Operations
    {
        // Create a list
        public static List<CustomerRegistration> customerList = new List<CustomerRegistration>();
        public static List<ProductDetails> productList = new List<ProductDetails>();
        public static List<BookingDetails> bookingList = new List<BookingDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();

        //Current user Object
        static CustomerRegistration currentUser;
        // Main Menu
        public static void MainMenu()
        {
            
            Log.Information("Application Started");
            // Need to display Title
            Console.WriteLine($"*******Grocey Store***********");
            // Run until user choose exit
            bool flag = true;
            do
            {
                Console.WriteLine($"*******Main Menu******");
                Console.WriteLine($"1. Customer Registration\n2. Customer Login\n3. Exit");
                Console.WriteLine($"Enter the option : ");
                byte menuOption = byte.TryParse(Console.ReadKey(true).KeyChar.ToString(), out byte result) ? result : throw new InvalidOperationException("Invalid input. Only numeric keys are allowed.");
                switch (menuOption)
                {
                    case 1:
                        {
                            //Customer Registration
                            Console.WriteLine($"******Customer Registration*****");
                            UserRegistration();
                            Log.Information("User registered");
                            break;
                        }
                    case 2:
                        {
                            //CustomerLogin
                            Console.WriteLine($"******Customer Login*****");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            //Exit From the Application
                            Console.WriteLine($"******Exit from Applicatoion*****");
                              Log.Information("Appication closed");
                            flag = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Invalid Option");
                            break;
                        }
                }

            } while (flag);
        }
        // UserRegistration
        public static void UserRegistration()
        {
            //  ask the user to enter Details
            string name = string.Empty;
            name = Validate.ValidateName(ref name);
            bool valid = false;
            // Console.Write($"Enter MailID : ");
            // string mailID = Console.ReadLine();
            string validEmail = string.Empty;
             validEmail = Validate.ValidateMailID(ref validEmail);
            //Console.WriteLine(validationMessage);
            //Console.WriteLine(validationMessage); // Display validation message
            Console.Write($"Enter Mobile Number : ");
            string mobile = Console.ReadLine();
            Console.Write($"Enter Balance :");
            double balance = 0;
            //valid = false;
            while (!valid)
            {
                valid = double.TryParse(Console.ReadLine(), out balance);
                if (!valid)
                {
                    Console.WriteLine($"Invalid Format Enter Again : ");
                }
            }

            DbConnection.UpdatUserDetails(name,mobile,validEmail,balance);
            // create a object for customer Registration and added into list
            CustomerRegistration customerRegistration = new CustomerRegistration(balance,name, mobile, validEmail);
            customerList.Add(customerRegistration);
            // show  CustomerID
            //Console.WriteLine($"Registration Successfully.  Your CustomerId : {customerRegistration.CustomerID}");

        }
        // UserLogin
        public static void UserLogin()
        {
            int flag = 0;
            // Ask the user to enter CustomerID
            Console.WriteLine($"Enter your CustomerID :");
            string customerID = Console.ReadLine().ToUpper();
            // validate the CustomerID
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerID.Equals(customerList[i].CustomerID))
                {
                    // if valid then store the user Details into currentUser.
                    flag = 1;
                    currentUser = customerList[i];
                    Log.Information("User Loged in");
                    // Call submenu();
                    SubMenu();
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine($"Invalid CustomerID");
                Log.Error("Entered Invalid Customer ID");

            }
        }
        //SubMenu
        public static void SubMenu()
        {
            //Show Cuurent UserName
            Console.WriteLine($"Welcome {currentUser.Name}");
            System.Console.WriteLine();
            bool flag = true;
            //Runs until user choose Exit
            do
            {
                // Show SubMenu
                Console.WriteLine($"*********Sub Menu*********");
                Console.WriteLine($"1. Show Customer Details");
                Console.WriteLine($"2. Show Product Details");
                Console.WriteLine($"3. Wallet Recharge");
                Console.WriteLine($"4. Take Order");
                Console.WriteLine($"5. Modify Order Quantity");
                Console.WriteLine($"6. Cancel Order");
                Console.WriteLine($"7. Show Balance");
                Console.WriteLine($"8. Exit");
                //Ask the user to enter the Option
                Console.WriteLine($"Enter the option : ");
               // byte subOption = byte.Parse(Console.ReadKey(true));
               byte subOption = byte.TryParse(Console.ReadKey(true).KeyChar.ToString(), out byte result) ? result : throw new InvalidOperationException("Invalid input. Only numeric keys are allowed.");
                switch (subOption)
                {
                    case 1:
                        {
                            //Show Customer Dtails
                            Console.WriteLine($"*****Show Customer Details*****");
                            ShowCustomerDetails();
                            break;
                        }
                    case 2:
                        {
                            // Show ProductDetails
                            Console.WriteLine($"*****Show Product Details*****");
                            DbConnection.DisplayProduct();
                          //  ProductDetails.ShowProductDetails();
                            break;
                        }
                    case 3:
                        {
                            // Wallet Recharge
                            Console.WriteLine($"*****Wallet recharge*****");
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            //Take Order
                            Console.WriteLine($"*****Take order*****");
                            TakeOrder();
                            break;
                        }
                    case 5:
                        {
                            //Modify Order Quantity
                            Console.WriteLine($"*****Modify order Quantity*****");
                            ModifyOrderQuantity();
                            break;
                        }
                    case 6:
                        {
                            //Cancel Order
                            Console.WriteLine($"*****Cancel Order****");
                            CancelOrder();
                            break;
                        }
                    case 7:
                        {
                            // Show balance
                            Console.WriteLine($"*****Show Balance*****");
                            Console.WriteLine($"Balance : {currentUser.WalletBalance}");

                            break;
                        }
                    case 8:
                        {
                            // Exit
                            Console.WriteLine($"*****Exit*****");
                              Log.Information("Exited from Sub menu");
                            flag = false;
                            break;
                        }
                }
            } while (flag);

        }
        // Show CustomerDetails
        public static void ShowCustomerDetails()
        {
            Console.WriteLine(currentUser.CustomerID);
            DbConnection.DisplayCustomerDetails(currentUser.CustomerID);
            //Display customerDetails
            // Console.WriteLine($"******CustomerDetails******");
            // Console.WriteLine($"Name : {currentUser.Name}");
            // Console.WriteLine($"CustomerID : {currentUser.CustomerID}");
            // Console.WriteLine($"Father Name  : {currentUser.FatherName}");
            // Console.WriteLine($"Gender : {currentUser.Gender}");
            // Console.WriteLine($"Date of Birth : {currentUser.DOB}");
            // Console.WriteLine($"Mobile Number : {currentUser.Mobile}");
            // Console.WriteLine($"Mail ID :  {currentUser.MailID}");
            // Console.WriteLine($"Balance : {currentUser.WalletBalance}");

        }

        // Modify Order
        public static void ModifyOrderQuantity()
        {
            //Show the BookingList
            Console.WriteLine($"|{"Booking ID",-10}|{"CustomerID",-10}|{"TotalPrice",-10}|{"DateOfBooking",-15}|{"Booking Status",-15}|");
            for (int i = 0; i < bookingList.Count; i++)
            {
                if (bookingList[i].CustomerID.Equals(currentUser.CustomerID) && bookingList[i].BookingStatus == BookingStatus.Booked)
                {

                    Console.WriteLine($"|{bookingList[i].BookingID,-10}|{bookingList[i].CustomerID,-10}|{bookingList[i].TotalPrice,-10}|{bookingList[i].DateOfBooking.ToString("dd/MM/yyyy"),-15}|{bookingList[i].BookingStatus,-15}|");
                }
            }
            //Ask the user to Enter the BookingId
            Console.WriteLine($"Enter the Booking ID : ");
            string bookingID = Console.ReadLine().ToUpper();
            int valid = 0;
            for (int i = 0; i < bookingList.Count; i++)
            {
                if (bookingList[i].CustomerID.Equals(currentUser.CustomerID) && bookingList[i].BookingStatus == BookingStatus.Booked && bookingID.Equals(bookingList[i].BookingID))
                {
                    valid = 1;
                }
            }
            if (valid == 0)
            {
                Console.WriteLine($"Invalid BookingID");
                  Log.Error("Invalid booking");
            }
            else
            {
                //Show the OrderDetails
                for (int i = 0; i < bookingList.Count; i++)
                {
                    if (bookingID.Equals(bookingList[i].BookingID) && currentUser.CustomerID.Equals(bookingList[i].CustomerID) && bookingList[i].BookingStatus == BookingStatus.Booked)
                    {
                        valid = 1;
                        Console.WriteLine($"|{"OrderID",-8}|{"BookingID",-10}|{"ProductID",-10}|{"PurchaseCount",-14}|{"PriceOfOrder",-15}|");
                        Console.WriteLine($"-------------------------------------------------------------------------------");
                        for (int j = 0; j < orderList.Count; j++)
                        {
                            if (bookingList[i].BookingID.Equals(orderList[j].BookingID))
                            {
                                Console.WriteLine($"|{orderList[j].OrderID,-8}|{orderList[j].BookingID,-10}|{orderList[j].ProductID,-10}|{orderList[j].PurchaseCount,-14}|{orderList[j].PriceOfOrder,-15}|");
                                valid = 1;
                            }
                        }
                        if (valid == 0)
                        {
                            Console.WriteLine($"No Data dound");

                        }
                        else
                        {
                            // Ask the user to Enter the OrderID
                            Console.WriteLine($"Enter the OrderID :  ");
                            string orderID = Console.ReadLine().ToUpper();
                            int present = 0;
                            // validate the OrderId
                            for (int j = 0; j < orderList.Count; j++)
                            {
                                if (orderList[j].OrderID.Equals(orderID))
                                {
                                    //If valid Ask the user to enter new Quantiy
                                    present = 1;
                                    Console.WriteLine($"Enter the Quantity : ");
                                    int quantity = int.Parse(Console.ReadLine()); int available = 0;
                                    //Check if the quantity available or not.
                                    for (int k = 0; k < productList.Count; k++)
                                    {
                                        //if availble update the quantity and calculate price refund the amount to the user.
                                        productList[k].QuantityAvailable += orderList[j].PurchaseCount;
                                        if (productList[k].QuantityAvailable >= quantity && orderList[j].ProductID.Equals(productList[k].ProductID))
                                        {
                                            available = 1;

                                            double newAmount;
                                            double oneQuantity = (double)orderList[j].PriceOfOrder / orderList[j].PurchaseCount;
                                            newAmount = quantity * oneQuantity;
                                            double oldAmount = orderList[j].PriceOfOrder;

                                            if (oldAmount < newAmount)
                                            {
                                                if (currentUser.WalletBalance >= newAmount - oldAmount)
                                                {
                                                    productList[k].QuantityAvailable -= quantity;
                                                    currentUser.WalletBalance -= newAmount - oldAmount;
                                                    orderList[j].PriceOfOrder = newAmount;
                                                    bookingList[i].TotalPrice = newAmount;
                                                    orderList[j].PurchaseCount = quantity;

                                                }
                                                else
                                                {
                                                    productList[k].QuantityAvailable = orderList[j].PurchaseCount;
                                                    Console.WriteLine($"Insufficient Balance");
                                                    break;

                                                }
                                            }
                                            else if (newAmount < oldAmount)
                                            {
                                                currentUser.WalletBalance += oldAmount - newAmount;
                                            }
                                            //Show Order Modified Successfully.
                                            Console.WriteLine($"Order Moified Successfully");
                                              Log.Information("Order Moified Successfully");
                                        }
                                    }
                                    if (available == 0)
                                    {
                                        Console.WriteLine($"Quantity Not available.");

                                    }
                                }
                            }
                            if (present == 0)
                            {
                                Console.WriteLine($"Invalid OrderID");
                                Log.Error("Invalid OrderID");
                            }
                        }
                    }
                }

            }

        }

        //Cancel Order
        public static void CancelOrder()
        {
            // Show the Booking Details
            Console.WriteLine($"-----------------------------------------------------");
            Console.WriteLine($"|{"BookingID",-10}|{"TotalPrice",-10}|{"DateOfBooking",-12}|{"BookingStatus",-15}|");
            Console.WriteLine($"------------------------------------------------------");
            for (int i = 0; i < bookingList.Count; i++)
            {
                if (bookingList[i].CustomerID.Equals(currentUser.CustomerID) && bookingList[i].BookingStatus == BookingStatus.Booked)
                {
                    Console.WriteLine($"|{bookingList[i].BookingID,-10}|{bookingList[i].TotalPrice,-10}|{bookingList[i].DateOfBooking.ToString("dd/MM/yyyy"),-12}|{bookingList[i].BookingStatus,-15}|");
                }
            }
            // Ask the user to enter the BookingId
            Console.WriteLine($"Enter the BookingID : ");
            string bookingID = Console.ReadLine().ToUpper();
            // validate the userID.
            for (int i = 0; i < bookingList.Count; i++)
            {
                if (bookingList[i].CustomerID.Equals(currentUser.CustomerID) && bookingList[i].BookingStatus == BookingStatus.Booked && bookingList[i].BookingID.Equals(bookingID))
                {
                    //If valid BookingStatus changed to Cancelled.
                    bookingList[i].BookingStatus = BookingStatus.Cancelled;
                    double amount = bookingList[i].TotalPrice;
                    currentUser.WalletRecharge(amount);
                    // update the quantity refund the amount to the customer
                    for (int j = 0; j < orderList.Count; j++)
                    {
                        if (bookingID.Equals(orderList[j].BookingID))
                        {
                            string productID = orderList[j].ProductID;
                            int quantity = orderList[j].PurchaseCount;
                            //return the quantity to the productList
                            for (int k = 0; k < productList.Count; k++)
                            {
                                if (productID.Equals(productList[k].ProductID))
                                {
                                    productList[k].QuantityAvailable += quantity;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Cancel Order Successfully");
                      Log.Information("Order cancelled Sccessfully");
                }
            }
        }
        // Take Order
        public static void TakeOrder()
        {
            // Ask the user Want to purchase or not.

            bool take = true;
            while (take)
            {
                Console.WriteLine($"Do you Want to Purchase? Yes/No");
                string takeOrder = Console.ReadLine().ToUpper();
                if (takeOrder.Equals("YES"))
                {
                    // if yes means create a orderDetails,bookingDetails object and create a temporary orderDetails
                    OrderDetails orderDetails;
                    BookingDetails booking = new BookingDetails(currentUser.CustomerID, 0, DateTime.Now, BookingStatus.Initited);
                    List<OrderDetails> tempOrderList = new List<OrderDetails>();
                    bool flag = true;
                    //Run until user Choose to exit.
                    do
                    {
                        // Display productDetails
                        ProductDetails.ShowProductDetails();
                        //Ask the user to enter the productID.
                        Console.WriteLine($"Enter the Product ID : ");
                        string productID = Console.ReadLine().ToUpper();
                        int valid = 0;
                        // validate ProductID
                        for (int i = 0; i < productList.Count; i++)
                        {
                            // If valid Ask the user to enter the Quantity
                            if (productID.Equals(productList[i].ProductID))
                            {
                                valid = 1;
                                Console.WriteLine($"Enter the Quantity : ");
                                int quantity = int.Parse(Console.ReadLine());
                                // check th available quantity is greater Than or equal to quantity.
                                if (quantity <= productList[i].QuantityAvailable)
                                {
                                    //if valid change the totalPrice and create a object for orderDetails and added into orderList reduce the quantity
                                    double totalPrice = quantity * productList[i].PricePerQuantity;
                                    orderDetails = new OrderDetails(booking.BookingID, productID, quantity, totalPrice);
                                    tempOrderList.Add(orderDetails);
                                    productList[i].QuantityAvailable -= quantity;
                                    // Display Product Successfully added to  cart.
                                    Console.WriteLine($"Product Successfully added to  cart.");
                                    Log.Information("Product Successfully added to  cart");

                                }
                                else
                                {
                                    Console.WriteLine($"Requried Quantity is not available. ");
                                    Log.Error("Requried Quantity is not available.");
                                }
                            }
                        }
                        if (valid == 0)
                        {
                            Console.WriteLine($"Invalid Product Id");
                        }
                        // Ask the user to continue book another ptoduct or not
                        Console.WriteLine($"Do you want to Continue to book Another Product YES/NO : ");
                        string response = Console.ReadLine().ToUpper();
                        //If no means procced to next. if yes means repeat the process.
                        if (response.Equals("NO"))
                        {
                            flag = false;
                        }
                    } while (flag);
                    // Ask the user to confirm the order or not.
                    Console.WriteLine($"Do you Want to Confirm the Order YES/NO : ");
                    string confirm = Console.ReadLine().ToUpper();
                    //if yes means calculate totalprice and deduct money from user waller change the booking status into booked.
                    //if no means return the quantity to the produtDetails
                    if (confirm.Equals("YES"))
                    {
                        double totalPrice = 0;
                        for (int i = 0; i < tempOrderList.Count; i++)
                        {
                            totalPrice += tempOrderList[i].PriceOfOrder;
                        }
                        if (currentUser.WalletBalance >= totalPrice)
                        {
                            currentUser.WalletBalance -= totalPrice;
                            booking.BookingStatus = BookingStatus.Booked;
                            booking.TotalPrice = totalPrice;
                            // tempOrderList added into orderList and added booking into bookingList.
                            orderList.AddRange(tempOrderList);
                            bookingList.Add(booking);
                            // Show Booking Successfully
                            Console.WriteLine($"Booked Successfully.Your Booking ID : {booking.BookingID}");
                            Log.Information($"Booked Successfully. ID:{booking.BookingID}");

                        }
                        else
                        {
                            // show insufficient accountbalance with  totalprice
                            Console.WriteLine($"Insufficient account balance recharge with”+{totalPrice}");
                            // ask the user to  recharge or not
                            Console.WriteLine($"Do you Want to  Recharge ?");
                            string recharge = Console.ReadLine().ToUpper();
                            //if yes means ask the user to enter amount to recharge . if no means return the productQuantity to productDetils
                            if ("YES".Equals(recharge))
                            {
                                Console.WriteLine($"Enter the Amount to Rechagre : ");
                                double amount = double.Parse(Console.ReadLine());
                                currentUser.WalletRecharge(amount);
                                currentUser.WalletBalance -= totalPrice;
                                booking.BookingStatus = BookingStatus.Booked;
                                booking.TotalPrice = totalPrice;
                                orderList.AddRange(tempOrderList);
                                bookingList.Add(booking);
                                Console.WriteLine($"Booking Successfully.Your Booking ID : {booking.BookingID}");
                                Log.Information($"Booked Successfully. ID:{booking.BookingID}");
                            }
                            else if ("NO".Equals(recharge))
                            {
                                for (int i = 0; i < tempOrderList.Count; i++)
                                {
                                    for (int j = 0; j < productList.Count; j++)
                                    {
                                        if (tempOrderList[i].ProductID.Equals(productList[j].ProductID))
                                        {
                                            productList[j].QuantityAvailable += tempOrderList[i].PurchaseCount;
                                        }
                                    }
                                }
                                // show Cart Removed Successfully
                                Console.WriteLine($"Cart Removed Successfully");
                                Log.Information("Cart Removed Successfully");


                            }

                        }
                    }
                    else if (confirm.Equals("NO"))
                    {
                        for (int i = 0; i < tempOrderList.Count; i++)
                        {
                            for (int j = 0; j < productList.Count; j++)
                            {
                                if (tempOrderList[i].ProductID.Equals(productList[j].ProductID))
                                {
                                    productList[j].QuantityAvailable += tempOrderList[i].PurchaseCount;
                                }
                            }
                        }
                        // show Cart Removed Successfully
                        Console.WriteLine($"Cart Removed Successfully");
                        Log.Information("Cart Removed Successfully");

                    }
                }
                else if ("NO".Equals(takeOrder))
                {
                    take = false;

                }
                else
                {
                    Console.Write($"Invalid Response Enter Again : ");
                }

            }

        }
        // Wallet ReCharge
        public static void WalletRecharge()
        {
            // Ask the user to enter Amount
            Console.WriteLine($"Enter the amount to Recharge : ");
            double amount = double.Parse(Console.ReadLine());
            currentUser.WalletRecharge(amount);
            Log.Information("Amount added into wallet");
        }
        // Add Default Value
        public static void AddDefaultValue()
        {
            // Create a object for CustomerRegistration
            CustomerRegistration customer1 = new CustomerRegistration(10000, "Ravi", "974774646", "ravi@gmail.com");
            CustomerRegistration customer2 = new CustomerRegistration(15000, "Baskaran","847575775", "baskaran@gmail.com");
            // Store the customer Details  into CustomerList
            customerList.Add(customer1);
            customerList.Add(customer2);
            // create a object for productDetails
            ProductDetails product2 = new ProductDetails("Rice", 100, 50);
            ProductDetails product1 = new ProductDetails("Sugar", 20, 40);
            ProductDetails product3 = new ProductDetails("Milk", 10, 40);
            ProductDetails product4 = new ProductDetails("Coffee", 10, 10);
            ProductDetails product5 = new ProductDetails("Tea", 10, 10);
            ProductDetails product6 = new ProductDetails("Masala Powder", 10, 20);
            ProductDetails product7 = new ProductDetails("Salt", 10, 10);
            ProductDetails product8 = new ProductDetails("Turmeric Powder", 10, 25);
            ProductDetails product9 = new ProductDetails("Chilli Powder", 10, 20);
            ProductDetails product10 = new ProductDetails("Groundnut  Oil", 10, 140);
            // store the productDetails  into productList
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);
            productList.Add(product6);
            productList.Add(product7);
            productList.Add(product8);
            productList.Add(product9);
            productList.Add(product10);
            //create a object for BookingDetails
            BookingDetails booking1 = new BookingDetails("CID1001", 220, new DateTime(2022, 7, 26), BookingStatus.Booked);
            BookingDetails booking2 = new BookingDetails("CID1002", 400, new DateTime(2022, 7, 26), BookingStatus.Booked);
            BookingDetails booking3 = new BookingDetails("CID1001", 280, new DateTime(2022, 7, 26), BookingStatus.Cancelled);
            BookingDetails booking4 = new BookingDetails("CID1001", 0, new DateTime(2022, 7, 26), BookingStatus.Initited);
            //Store the bookingdetails into BokkingList
            bookingList.Add(booking1);
            bookingList.Add(booking2);
            bookingList.Add(booking3);
            bookingList.Add(booking4);
            // Create a object for OrderDetails
            OrderDetails order1 = new OrderDetails("BID3001", "PID2001", 2, 80);
            OrderDetails order2 = new OrderDetails("BID3001", "PID2002", 2, 100);
            OrderDetails order3 = new OrderDetails("BID3001", "PID2003", 1, 40);
            OrderDetails order4 = new OrderDetails("BID3002", "PID2001", 1, 40);
            OrderDetails order5 = new OrderDetails("BID3002", "PID2002", 4, 200);
            OrderDetails order6 = new OrderDetails("BID3002", "PID2010", 1, 140);
            OrderDetails order7 = new OrderDetails("BID3002", "PID2009", 1, 20);
            OrderDetails order8 = new OrderDetails("BID3003", "PID2002", 2, 100);
            OrderDetails order9 = new OrderDetails("BID3003", "PID2008", 4, 100);
            OrderDetails order10 = new OrderDetails("BID3003", "PID2001", 2, 80);
            // Store the OrderDetails into orderList
            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);
            orderList.Add(order4);
            orderList.Add(order5);
            orderList.Add(order6);
            orderList.Add(order7);
            orderList.Add(order8);
            orderList.Add(order9);
            orderList.Add(order10);
        }
    }
}