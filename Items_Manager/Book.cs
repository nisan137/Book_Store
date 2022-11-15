using Items_Manager.Enums;
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
             double buyingPrice, long isbn, int copiesAmount)
        {
            ItemName = name;
            ItemType = type;
            AuthorName = author;
            GenreEnum = genre;
            Publisher = publisher;
            PublishYear = publishYear;
            ISBN = isbn;
            BuyingPrice = buyingPrice;
            CopiesAmount = copiesAmount;
            ImagePath = imagePath;
        }
        public Book() : base()
        {

        }

    }
}