using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items_Manager
{
    public class Journal : Abstract_Item
    {
       
        public Journal(string name, string type, int version, string publisher, Genre genre, int publishYear, string imagePath,
         double buyingPrice, int copiesAmount, double discount)
        {
            ItemName = name;
            ItemType = type;
            BuyingPrice = buyingPrice;
            GenreEnum = genre;
            Publisher = publisher;
            PublishYear = publishYear;
            Version = version;
            CopiesAmount = copiesAmount;
            Discount = discount;
            ImagePath = imagePath;
        }
        public Journal() : base()
        {

        }
   
    }
}
