using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Items_Manager
{
    public abstract class Abstract_Item
    {
        private int _isbn;
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public double BuyingPrice { get; set; }
        public long ISBN
        {
            get { return _isbn; }
            protected set { _isbn = (int)value; }
        }
        public string GenreId { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public int CopiesAmount { get; set; }
        public string AuthorName { get; set; }
        public double Version { get; set; }
        public string Description
        {
            get
            {   // Description to show in a TextBlock about the book both in Librarian or User page.
                if (ItemTypeFigure == "Book")
                {
                    return $"{ItemName} is a {ItemType} by author {AuthorName}\nOriginally published on {PublishYear} by publisher {Publisher}\n" +
                    $"Genre: {GenreEnum} \nBuying price: {BuyingPrice}";

                }
                else
                {
                    return $"{ItemName} is a {ItemType}, version number {Version}\nOriginally published on {PublishYear} by publisher {Publisher}\n" +
                    $"Genre: {GenreEnum} \nBuying price: {BuyingPrice}";
                }
            }
        }
        private string ItemTypeFigure
        {
            get { return GetType().Name; }
        }

        public override string ToString()
        {
            return ItemName;
        }
        public double Discount { get; set; }

        public string ImagePath { get; set; }

        public Genre GenreEnum
        {
            get
            {
                Genre value;
                if (!Enum.TryParse(GenreId, out value))
                    value = Genre.GeneralGenre; // default value, instead of Exception throwing

                return value;
            }

            protected set { }
        }

    }
    public enum Genre
    {
        GeneralGenre,
        Comedy,
        Fantasy,
        Drama,
        Novel,
        ScienceFiction,
        Documantry,
        Thriller,
        Childrens,
        Buisness,
        Entertainment,
        Science
    };

}
