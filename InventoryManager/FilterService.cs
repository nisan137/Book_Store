using Items_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class FilterService
    {
        List<string> itemsByGenre = new List<string>();
        List<string> itemsByAuthor = new List<string>();
        List<string> itemsByName = new List<string>();
        List<string> itemsByPublisher = new List<string>();
        List<string> itemsByType = new List<string>();

        public List<string> FilterGenre
        {
            get { return itemsByGenre; }
        }
        public List<string> FilterAuthor
        {
            get { return itemsByAuthor; }
        }
        public List<string> FilterName
        {
            get { return itemsByName; }
        }
        public List<string> FilterPublisher
        {
            get { return itemsByPublisher; }
        }
        public List<string> FilterType
        {
            get { return itemsByType; }
        }

        public FilterService(List<Abstract_Item> inventoryStoreList)
        {
            inventoryStoreList = InventoryStoreManager.Instance.ItemList;

            foreach (var item in inventoryStoreList)
            {
                if (itemsByGenre.Contains(item.GenreEnum.ToString()) == false && item.GenreEnum.ToString() != null)
                {
                    itemsByGenre.Add(item.GenreEnum.ToString());
                }
                if (itemsByAuthor.Contains(item.AuthorName) == false && item.AuthorName != null)
                {
                    itemsByAuthor.Add(item.AuthorName);
                }
                if (itemsByName.Contains(item.ItemName) == false && item.ItemName != null)
                {
                    itemsByName.Add(item.ItemName);
                }
                if (itemsByPublisher.Contains(item.Publisher) == false && item.Publisher != null)
                {
                    itemsByPublisher.Add(item.Publisher);
                }
                if (itemsByType.Contains(item.ItemType) == false && item.ItemType != null)
                {
                    itemsByType.Add(item.ItemType);
                }
            }
        }
        // Get the types of a selected filter, for example: Author names or Genres
        public List<string> GetFilterResultsOfType(List<string> filterType)
        {
            List<string> filteredItems = new List<string>();

            foreach (string item in filterType)
            {
                if (item == null) continue;
                filteredItems.Add(item);
            }

            return filteredItems;
        }
        // Filter the list by the selected Sub-Filter, for example it will show only books by Author x
        public List<string> SubFilterResult(List<Abstract_Item> items, string filter)
        {
            List<string> filteredItems = new List<string>();

            foreach (Abstract_Item item in items)
            {
                if (string.IsNullOrEmpty(filter)) return null;
                else if (filter.ToString() == item.GenreEnum.ToString())
                    filteredItems.Add(item.ItemName);
                else if (filter.ToString() == item.AuthorName)
                    filteredItems.Add(item.ItemName);
                else if (filter.ToString() == item.Publisher)
                    filteredItems.Add(item.ItemName);
                else if (filter.ToString() == item.ItemType)
                    filteredItems.Add(item.ItemName);
            }
            return filteredItems;
        }
    }
}