using InventoryManager;
using Items_Manager.Enums;
using System.Collections.Generic;

namespace Items_Manager
{
    public abstract class Abstract_Item
    {
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public double BuyingPrice { get; set; }
        public long ISBN { get; set; }
        private Genre genre { get; set; }
        public Genre GenreEnum
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public int CopiesAmount { get; set; }
        public string AuthorName { get; set; }
        public double Version { get; set; }
        public string Description
        {
            get
            {   // Description to show in a TextBlock about the item.
                if (GetType().Name == "Book")
                {
                    return $"{ItemName} is a {ItemType} by author {AuthorName}\nOriginally published on {PublishYear} by publisher {Publisher}\n" +
                    $"Genre: {GenreEnum} \nBuying price: {BuyingPrice:c}\n Price after discount: {PriceAfterDiscount:c}";
                }
                else
                {
                    return $"{ItemName} is a {ItemType}, version number {Version}\nOriginally published on {PublishYear} by publisher {Publisher}\n" +
                    $"Genre: {GenreEnum} \nBuying price: {BuyingPrice:c}\nPrice after discount: {PriceAfterDiscount:c}";
                }
            }
        }

        public double PriceAfterDiscount
        {
            get
            {
                var temp = CurrentDiscount;
                if (temp != 0)
                {
                    return BuyingPrice - (BuyingPrice * temp / 100);
                }
                else
                    return BuyingPrice;
            }
        }
        public double CurrentDiscount //ההנחה הרלוונטית-הכי גבוהה
        {
            get
            {
                double maxPercentage = 0;
                this.DiscountsListPerItem.ForEach(discount =>
                {
                    if (discount.Percentage > maxPercentage)
                    {
                        maxPercentage = discount.Percentage;
                    }
                });
                return maxPercentage;
            }
        }
        private List<Discount> DiscountsListPerItem
        {
            get
            {
                var list = DiscountManager.Instance.DiscountList;
                List<Discount> _discountsListPerItem = new List<Discount>();
                foreach (Discount discount in list)
                {
                    if (this is Book)
                    {
                        switch (discount.Type)
                        {
                            case DiscountBy.ItemType:
                                if (this.GetType().Name.Equals(discount.ValueOfType))
                                    _discountsListPerItem.Add(discount);
                                break;
                            case DiscountBy.Publisher:
                                if (this.Publisher.Equals(discount.ValueOfType))
                                    _discountsListPerItem.Add(discount);
                                break;
                            case DiscountBy.AuthorName:
                                if (this.AuthorName.Equals(discount.ValueOfType))
                                    _discountsListPerItem.Add(discount);
                                break;
                            case DiscountBy.Genre:
                                if (this.GenreEnum.ToString().Equals(discount.ValueOfType))
                                    _discountsListPerItem.Add(discount);
                                break;
                        }
                    }
                    else if (this is Journal)
                    {
                        switch (discount.Type)
                        {
                            case DiscountBy.ItemType:
                                if (this.GetType().Name.Equals(discount.ValueOfType))
                                    _discountsListPerItem.Add(discount);
                                break;
                            case DiscountBy.Publisher:
                                if (this.Publisher.Equals(discount.ValueOfType))
                                    _discountsListPerItem.Add(discount);
                                break;
                            case DiscountBy.Genre:
                                if (this.GenreEnum.ToString().Equals(discount.ValueOfType))
                                    _discountsListPerItem.Add(discount);
                                break;
                        }
                    }
                }
                return _discountsListPerItem;
            }
        }

        public string ImagePath { get; set; }
        public override string ToString()
        {
            return ItemName;
        }
    }
}