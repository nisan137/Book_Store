using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items_Manager
{
    abstract class Abstract_Item
    {
        private int _isbn;
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public double BuyingPrice { get; set; }
        public int ISBN
        {
            get { return _isbn; }
            protected set { _isbn = value; }
        }
        public string GenreId { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public int CopiesAmount { get; set; }
        public string Description { get; set; }
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
        Childrens
    };

}
