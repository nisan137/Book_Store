using Items_Manager;
using Items_Manager.Enums;
using JSON_Logic.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using Windows.Graphics.Printing3D;
using Windows.Storage;
using Formatting = Newtonsoft.Json.Formatting;

namespace InventoryManager
{
    public class InventoryStoreManager
    {
        public static InventoryStoreManager Instance { get; } = new InventoryStoreManager();
        private DbService _dbService;
        public DbService DbServiceForUsage
        {
            get { return _dbService; }
        }

        public List<Abstract_Item> ItemList;

        private InventoryStoreManager()
        {
            ItemList = new List<Abstract_Item>();
            _dbService = new DbService("InventoryDB.json");
            List<Abstract_Item> tempListDB = _dbService.GetData<Abstract_Item>();
            if (tempListDB != null)
            {
                ItemList = tempListDB;

            }
            //ItemList.Add(new Book("Paddington Bear", "Book", "Michael Bond", "BBC Audio, A Division Of Random House", Genre.Childrens, 2009, @"ms-appx:///Assets/BearPaddington.png", 34.5, 9781408410059, 12));
            //ItemList.Add(new Book("The Cat in the Hat", "Book", "Dr. Seuss", "Random House USA Inc", Genre.Childrens, 2004, @"ms-appx:///Assets/DrSeuss.png", 44.12, 9780394800011, 20));
            //ItemList.Add(new Book("Gone with the wind", "Book", "Margaret Mitchell", "Simon & Schuster", Genre.Novel, 1996, @"ms-appx:///Assets/GoneWithTheWind.png", 92, 9780684830681, 5));
            //ItemList.Add(new Book("Harry Potter and the Philosopher's Stone", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, @"ms-appx:///Assets/HarryPotter1.png", 45, 9781408855652, 14));
            //ItemList.Add(new Book("Harry Potter and the Chamber of Secrets", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, @"ms-appx:///Assets/HarryPotter2.png", 47, 9781408855669, 10));
            //ItemList.Add(new Book("Harry Potter and the Prisoner of Azkaban", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, @"ms-appx:///Assets/HarryPotter3.png", 40, 9781408855676, 16));
            //ItemList.Add(new Book("Harry Potter and the Goblet of Fire", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, @"ms-appx:///Assets/HarryPotter4.png", 50, 9781408855683, 18));
            //ItemList.Add(new Book("Harry Potter and the Order of the Phoenix", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, @"ms-appx:///Assets/HarryPotter5.png", 49, 9781408855690, 11));
            //ItemList.Add(new Book("Harry Potter and the Half-Blood Prince", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, @"ms-appx:///Assets/HarryPotter6.png", 69, 9781408855706, 7));
            //ItemList.Add(new Book("Harry Potter and the Deathly Hallows", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, @"ms-appx:///Assets/HarryPotter7.png", 69, 9781408855713, 12));
            //ItemList.Add(new Book("The Hobbit", "Book", "J. R. R. Tolkien", "HarperCollins Publishers Inc", Genre.Fantasy, 1991, @"ms-appx:///Assets/Hobbit.png", 52, 9780261102217, 23));
            //ItemList.Add(new Book("James and the Giant Peach", "Book", "Roald Dahl", "Penguin Putnam Inc", Genre.Childrens, 2007, @"ms-appx:///Assets/JamesAndTheGiantPeach.png", 38, 9780142410363, 20));
            //ItemList.Add(new Book("Little House on the Prairie", "Book", "Laura Ingalls Wilder", "HarperCollins Publishers Inc", Genre.Drama, 2007, @"ms-appx:///Assets/LittleHouse.png", 22, 9780064400022, 19));
            //ItemList.Add(new Book("Love and War", "Book", "K J Wynne", "Austin Macauley Publishers LLC", Genre.Novel, 2020, @"ms-appx:///Assets/LoveAndWar.png", 27, 9781643786223, 29));
            //ItemList.Add(new Book("Walt Disney's Peter Pan", "Book", "RH Disney", "Random House USA Inc", Genre.Childrens, 2007, @"ms-appx:///Assets/PeterPan.png", 31, 9780736402385, 19));
            //ItemList.Add(new Book("What Do They Do With All That Poo?", "Book", "Jane Kurtz", "Simon & Schuster Ltd", Genre.Childrens, 2019, @"ms-appx:///Assets/PooBook.png", 31.73, 9781471182549, 11));
            //ItemList.Add(new Book("Robinson Crusoe", "Book", "Daniel Defoe", "La Galera, SAU", Genre.Thriller, 2020, @"ms-appx:///Assets/RobinsonCrusoe.png", 52.31, 9788424667740, 7));
            //ItemList.Add(new Book("Shadow and Bone: Shadow and Bone", "Book", "Leigh Bardugo", "Hachette Children's Group", Genre.ScienceFiction, 2018, @"ms-appx:///Assets/ShadowAndBone.png", 35.47, 9781510105249, 14));
            //ItemList.Add(new Book("The Alchemist", "Book", "Paulo Coelho", "HarperCollins Publishers Inc", Genre.Novel, 2014, @"ms-appx:///Assets/TheAlchemist.png", 46.27, 9780062315007, 4));
            //ItemList.Add(new Book("The Great Gatsby", "Book", "F. Scott Fitzgerald", "Simon & Schuster", Genre.Novel, 2004, @"ms-appx:///Assets/TheGreatGatsby.png", 61.80, 9780743273565, 7));
            //ItemList.Add(new Book("We Are Giants", "Book", "Amber Lee Dodd", " Hachette Children's Group", Genre.Comedy, 2016, @"ms-appx:///Assets/WeAreGiants.png", 31.82, 9781784294212, 13));
            //ItemList.Add(new Journal("Forbs Magazine", "Journal", 2089, "Integrated Whale Media Investments", Genre.Buisness, 2018, @"ms-appx:///Assets/ForbsMagazine.png", 9.99, 3));
            //ItemList.Add(new Journal("GQ British UK Magazine", "Journal", 2089, "Condé Nast Inc", Genre.Entertainment, 2015, @"ms-appx:///Assets/GqMagazine.png", 7.20, 5));
            //ItemList.Add(new Journal("Scientific American Magazine", "Journal", 1013, "Springer Nature", Genre.Science, 2014, @"ms-appx:///Assets/ScientificAmericanMagazine.png", 6.35, 2));
            //ItemList.Add(new Journal("UK Vogue magazine", "Journal", 2154, "Condé Nast Inc", Genre.Entertainment, 2019, @"ms-appx:///Assets/Vogue.png", 10.80, 4));

            //_dbService.SaveData(ItemList);
            //_dbService.GetData<Abstract_Item>();
        }
        public List<Abstract_Item> Items
        {
            get => ItemList;
            set => ItemList = value;
        }
        //public void AddDiscount(List<Abstract_Item> ItemList, Discount dis, DiscountBy disEnum)
        //{

        //    bool discountByTypeOf = disEnum.Equals(dis.ValueOfType);
        //    if (discountByTypeOf)
        //    {
        //        string TypeOfDiscount = disEnum.ToString();
        //        DiscountList.Add(dis);
        //        foreach (var item in ItemList)
        //        {
        //            if ((item.ItemType != TypeOfDiscount) || (item.ItemName != TypeOfDiscount) || (item.AuthorName != TypeOfDiscount) || (item.Publisher != TypeOfDiscount) || (item.GenreEnum.ToString() != TypeOfDiscount))
        //            {
        //                item.CurrentDiscount = 0;
        //            }
        //            else
        //                item.CurrentDiscount = dis.Percentage;
        //        }
        //    }
        //    //Save();
        //    // dis = new Discount(10, DiscountBy.AuthorName, "J K Rolling");
        //}

        public void Save()
        {
            _dbService.SaveData(ItemList);
        }
        public void AddItem
            (string name, string type, string author, string publisher,
            Genre genre, int publishYear, string imagePath, double buyingPrice,
            long isbn, int copiesAmount, int version)
        {
            if (type == null)
            {
                throw new NullReferenceException("Item type string can not be null");
            }
            if (type == "0")
            {
                type = "Book";
                ItemList.Add(new Book(name, type, author, publisher, genre, publishYear, imagePath, buyingPrice, isbn, copiesAmount));
            }
            else if (type == "1")
            {
                type = "Journal";
                ItemList.Add(new Journal(name, type, version, publisher, genre, publishYear, imagePath, buyingPrice, copiesAmount));
            }
            else
            {
                throw new MissingFieldException("Error in parameters, null item, item wasn't saved.");
            }
            Save();
        }
        public void RemoveItem(Abstract_Item item)
        {
            if (ItemList.Remove(item))
            {
                Save();
            }
        }
        public ObservableCollection<Abstract_Item> GetObservableItemCollection()
        {
            return new ObservableCollection<Abstract_Item>(ItemList);
        }
        public Abstract_Item SelectedAbstractItem(List<Abstract_Item> items, string selectedItem)
        {
            if (selectedItem == null || items == null) return null;

            Abstract_Item selectedBook = PrivateSelectedAbstractItem(items, selectedItem);
            return selectedBook;
        }
        private Abstract_Item PrivateSelectedAbstractItem(List<Abstract_Item> items, string selectedItem)
        {
            if (selectedItem == null || items == null) return null;

            Abstract_Item temp = null;
            foreach (var item in items)
            {
                if (selectedItem == item.ItemName)
                    temp = item;
            }
            if (temp == null)
            {
                throw new ArgumentNullException("No Item was selected.");
            }
            return temp;
        }
    }
}