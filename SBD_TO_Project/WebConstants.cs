using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project
{
    public static class WebConstants
    {
        public static string ImageMoviePath = @"\images\movies\";

        public static string AdminRole = "Admin";
        public static string ManagerRole = "Manager";
        public static string EmployeeRole = "Employee";
        public static string CustomerRole = "Customer";

        public enum PaymentMethod { 
            Bank_Transfer,
            Credit_Card,
            Cash
        }

        public enum OrderStatus
        {
            Paid,
            Not_Paid
        }
    }
}
