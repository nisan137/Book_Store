using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items_Manager
{
    internal class Journal : Abstract_Item
    {
        public double Version { get; set; }
        public Journal(string name, string type, int version, string publisher, Genre genre, int publishYear, string imagePath,
         double buyingPrice, int isbn, int copiesAmount, string description, double discount)
        {
            ItemName = name;
            ItemType = type;
            BuyingPrice = buyingPrice;
            ISBN = isbn;
            GenreEnum = genre;
            Publisher = publisher;
            PublishYear = publishYear;
            Version = version;
            CopiesAmount = copiesAmount;
            Description = description;
            Discount = discount;
            ImagePath = imagePath;
        }
        public Journal() : base()
        {

        }
        public override string ToString()
        {
            return $"{ItemName} is a {ItemType}, version number {Version}\nOriginally published on {PublishYear} by publisher {Publisher}\n" +
        $"Genre: {GenreEnum} \nBuying price: {BuyingPrice}";
        }
    }
}
