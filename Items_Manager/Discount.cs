using Items_Manager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items_Manager
{
    public class Discount
    {
        public double Percentage { get; set; }
        public DiscountBy Type { get; set; } //the property from the abtract type in which the discount is calculated by.
        public string ValueOfType { get; set; }//the value of the property in which the discount is calculated by.

        public Discount(double percentage, DiscountBy type, string valueOfType)
        {
            Percentage = percentage;
            Type = type;
            ValueOfType = valueOfType;
        }
    }
}