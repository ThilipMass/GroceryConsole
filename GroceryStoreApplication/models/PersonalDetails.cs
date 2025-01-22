using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreApplication
{
     // Enum
     /// <summary>
     /// enum Gender DataType  used to  store the Gender
     /// </summary>
    // public enum Gender{
    //     M,F,T
    // }
    /// <summary>
    /// PersonalDetails is used to Stroe the PersonalDetils of Customer
    /// </summary>
    public class PersonalDetails
    { 
        // property
        /// <summary>
        /// Name property used to Store the Name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// FatherName property used to Store the FatherName
        /// </summary>
        /// <value></value>
        public string Mobile { get; set; }
        /// <summary>
        /// DOB property used to Store the DOB
        /// </summary>
        /// <value></value>
        public string MailID { get; set; }  
        // constructor
        /// <summary>
        /// PersonalDetails used to assign the Default value to the property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="mailID"></param>
        public PersonalDetails(string name,string mobile,string mailID)
        {
            //Assign value to the property
            Name = name;
            Mobile = mobile;
            MailID = mailID;
        }
        public PersonalDetails(){}
    }
}