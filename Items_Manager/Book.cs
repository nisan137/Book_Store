using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items_Manager
{
    internal class Book : Abstract_Item
    {
        public string AuthorName { get; set; }
        public double RentPrice { get; set; }
        public bool IsRented { get; set; }
        public Book(string name, string type, string author, string publisher, Genre genre, int publishYear, string imagePath,
             double buyingPrice, int isbn, int copiesAmount, string description, double discount)
        {
            ItemName = name;
            ItemName = type;
            BuyingPrice = buyingPrice;
            ISBN = isbn;
            GenreEnum = genre;
            Publisher = publisher;
            PublishYear = publishYear;
            AuthorName = author;
            CopiesAmount = copiesAmount;
            Description = description;
            Discount = discount;
            ImagePath = imagePath;
        }
        public Book() : base()
        {

        }
        public override string ToString()
        {
            return $"{ItemName} is a {ItemType} by author {AuthorName}\nOriginally published on {PublishYear} by publisher {Publisher}\n" +
        $"Genre: {GenreEnum} \nBuying price: {BuyingPrice}";
        }
    }
}
