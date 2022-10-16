using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items_Manager
{
    public class Book : Abstract_Item
    {
        
        public Book(string name, string type, string author, string publisher, Genre genre, int publishYear, string imagePath,
             double buyingPrice, long isbn, int copiesAmount, double discount)
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
            Discount = discount;
            ImagePath = imagePath;
        }
        public Book() : base()
        {

        }
      
    }
}
