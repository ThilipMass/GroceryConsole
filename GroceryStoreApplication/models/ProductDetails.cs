using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreApplication
{
    /// <summary>
    /// ProductDetils used to create a instance of Product 
    /// </summary>
    public class ProductDetails
    {
        // Field
        /// <summary>
        /// stati field s_productID used to AutoIncrementation of the ProductID
        /// </summary>
        private static int s_productID=2000;

        // property
        /// <summary>
        /// ProductID property used to Store the ProDuctID
        /// </summary>
        /// <value></value>
        public string ProductID { get;} // ReadOnly
        /// <summary>
        /// ProductName property used to Store the ProductName
        /// </summary>
        /// <value></value>
        public string ProductName { get; set; }
        /// <summary>
        /// QuantityAvailable property used to Store the QuantityAvailable
        /// </summary>
        /// <value></value>
        public int QuantityAvailable { get; set; }
        /// <summary>
        /// PricePerQuantity property used to Store the PricePerQuantity
        /// </summary>
        /// <value></value>
        public int PricePerQuantity { get; set; }
        // constructor
        /// <summary>
        /// ProductDetails Constructor used to Assign the Value to the Property.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="quantityAvailable"></param>
        /// <param name="pricePerQuantity"></param>
        public ProductDetails(string productName, int quantityAvailable, int pricePerQuantity)
        {
            // Auto increamentation
            s_productID++;
            // Assigning value to property
            ProductID="PID"+s_productID;
            ProductName = productName;
            QuantityAvailable = quantityAvailable;
            PricePerQuantity = pricePerQuantity;
        }
        /// <summary>
        ///  ProductDetails Constructor used to Assign the Value to the Property.
        /// </summary>
        /// <param name="product"></param>
        // public ProductDetails(string product)
        // {
        //     string[] value=product.Split(",");
        //     // Assigning value to property
        //     s_productID=int.Parse(value[0].Remove(0,3));
        //     ProductID=value[0];
        //     ProductName = value[1];
        //     QuantityAvailable = int.Parse(value[2]);
        //     PricePerQuantity = int.Parse(value[3]);
        // }
        // Method
        /// <summary>
        /// Show ProductDetils Method used to display the ShowProductDetails
        /// </summary>
        public static void ShowProductDetails()
        {
                
            Console.WriteLine($"********ProductDetails*******");
            Console.WriteLine($"------------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"ProductID",-12}|{"ProductName",-22}|{"QuantityAvailable",-18}|{"PricePerQuantity",-16}|");
            Console.WriteLine($"------------------------------------------------------------------------------------------");
            for(int i=0;i<Operations.productList.Count;i++)
            {
                Console.WriteLine($"|{Operations.productList[i].ProductID,-12}|{Operations.productList[i].ProductName,-22}|{Operations.productList[i].QuantityAvailable,-18}|{Operations.productList[i].PricePerQuantity,-16}|");
                Console.WriteLine($"------------------------------------------------------------------------------------------");
            }    
        }
        
    }
}