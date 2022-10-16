using Microsoft.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.System;
using Items_Manager;

namespace InventoryManager
{
    public class InventoryStoreManager
    {
        List<Abstract_Item> ItemList = new List<Abstract_Item>();

        public InventoryStoreManager()
        {
            ItemList.Add(new Book("Paddington Bear", "Book", "Michael Bond", "BBC Audio, A Division Of Random House", Genre.Childrens, 2009, "/Assets/BearPaddington.png", 34.5, 9781408410059, 12, 0));
            ItemList.Add(new Book("The Cat in the Hat", "Book", "Dr. Seuss", "Random House USA Inc", Genre.Childrens, 2004, "/Assets/DrSeuss.png", 44.12, 9780394800011, 20, 0));
            ItemList.Add(new Book("Gone with the wind", "Book", "Margaret Mitchell", "Simon & Schuster", Genre.Novel, 1996, "/Assets/GoneWithTheWind.png", 92, 9780684830681, 5, 0));
            ItemList.Add(new Book("Harry Potter and the Philosopher's Stone", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, "/Assets/HarryPotter1.png", 45, 9781408855652, 14, 0));
            ItemList.Add(new Book("Harry Potter and the Chamber of Secrets", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, "/Assets/HarryPotter2.png", 47, 9781408855669, 10, 0));
            ItemList.Add(new Book("Harry Potter and the Prisoner of Azkaban", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, "/Assets/HarryPotter3.png", 40, 9781408855676, 16, 0));
            ItemList.Add(new Book("Harry Potter and the Goblet of Fire", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, "/Assets/HarryPotter4.png", 50, 9781408855683, 18, 0));
            ItemList.Add(new Book("Harry Potter and the Order of the Phoenix", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, "/Assets/HarryPotter5.png", 49, 9781408855690, 11, 0));
            ItemList.Add(new Book("Harry Potter and the Half-Blood Prince", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, "/Assets/HarryPotter6.png", 69, 9781408855706, 7, 0));
            ItemList.Add(new Book("Harry Potter and the Deathly Hallows", "Book", "J K Rolling", " Bloomsbury Publishing PLC", Genre.Fantasy, 2014, "/Assets/HarryPotter7.png", 69, 9781408855713, 12, 0));
            ItemList.Add(new Book("The Hobbit", "Book", "J. R. R. Tolkien", "HarperCollins Publishers Inc", Genre.Fantasy, 1991, "/Assets/Hobbit.png", 52, 9780261102217, 23, 0));
            ItemList.Add(new Book("James and the Giant Peach", "Book", "Roald Dahl", "Penguin Putnam Inc", Genre.Childrens, 2007, "/Assets/JamesAndTheGiantPeach.png", 38, 9780142410363, 20, 0));
            ItemList.Add(new Book("Little House on the Prairie", "Book", "Laura Ingalls Wilder", "HarperCollins Publishers Inc", Genre.Drama, 2007, "/Assets/LittleHouse.png", 22, 9780064400022, 19, 0));
            ItemList.Add(new Book("Love and War", "Book", "K J Wynne", "Austin Macauley Publishers LLC", Genre.Novel, 2020, "/Assets/LoveAndWar.png", 27, 9781643786223, 29, 0));
            ItemList.Add(new Book("Walt Disney's Peter Pan", "Book", "RH Disney", "Random House USA Inc", Genre.Childrens, 2007, "/Assets/PeterPan.png", 31, 9780736402385, 19, 0));
            ItemList.Add(new Book("What Do They Do With All That Poo?", "Book", "Jane Kurtz", "Simon & Schuster Ltd", Genre.Childrens, 2019, "/Assets/PooBook.png", 31.73, 9781471182549, 11, 0));
            ItemList.Add(new Book("Robinson Crusoe", "Book", "Daniel Defoe", "La Galera, SAU", Genre.Thriller, 2020, "/Assets/RobinsonCrusoe.png", 52.31, 9788424667740, 7, 0));
            ItemList.Add(new Book("Shadow and Bone: Shadow and Bone", "Book", "Leigh Bardugo", "Hachette Children's Group", Genre.ScienceFiction, 2018, "/Assets/ShadowAndBone.png", 35.47, 9781510105249, 14, 0));
            ItemList.Add(new Book("The Alchemist", "Book", "Paulo Coelho", "HarperCollins Publishers Inc", Genre.Novel, 2014, "/Assets/TheAlchemist.png", 46.27, 9780062315007, 4, 0));
            ItemList.Add(new Book("The Great Gatsby", "Book", "F. Scott Fitzgerald", "Simon & Schuster", Genre.Novel, 2004, "/Assets/TheGreatGatsby.png", 61.80, 9780743273565, 7, 0));
            ItemList.Add(new Book("We Are Giants", "Book", "Amber Lee Dodd", " Hachette Children's Group", Genre.Comedy, 2016, "/Assets/WeAreGiants.png", 31.82, 9781784294212, 13, 0));
            ItemList.Add(new Journal("Forbs Magazine", "Journal", 2089, "Integrated Whale Media Investments", Genre.Buisness, 2018, "/Assets/ForbsMagazine.png", 9.99, 3, 0));
            ItemList.Add(new Journal("GQ British UK Magazine", "Journal", 2089, "Condé Nast Inc", Genre.Entertainment, 2015, "/Assets/GqMagazine.png", 7.20, 5, 0));
            ItemList.Add(new Journal("Scientific American Magazine", "Journal", 1013, "Springer Nature", Genre.Science, 2014, "/Assets/ScientificAmericanMagazine.png", 6.35, 2, 0));
            ItemList.Add(new Journal("UK Vogue magazine", "Journal", 2154, "Condé Nast Inc", Genre.Entertainment, 2019, "/Assets/Vogue.png", 10.80, 4, 0));
        }
        public List<Abstract_Item> Items
        {
            get => ItemList;
            set => ItemList = value;
        }
    }
}
