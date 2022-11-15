using Items_Manager;
using Items_Manager.Enums;
using JSON_Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class DiscountManager
    {
        public static DiscountManager Instance { get; } = new DiscountManager();
        public List<Discount> DiscountList { get; set; } = new List<Discount>();

        public DbService DbServiceForUsage { get; } = new DbService("DiscountDB.json");
        private DiscountManager()
        {
            List<Discount> tempListDB = DbServiceForUsage.GetData<Discount>();
            if (tempListDB != null)
            {
                DiscountList = tempListDB;
            }
        }
        public void Save()
        {
            DbServiceForUsage.SaveData(DiscountList);
        }
        public void AddNewDiscount(double percentage, DiscountBy type, string ValueOfType)
        {
            DiscountList.Add(new Discount(percentage, type, ValueOfType));
            Save();
        }

        public void RemoveDiscount(Discount discount)
        {
            if (DiscountList.Remove(discount))
            {
                Save();
            }
        }
        public void SetDiscount(List<Discount> DiscountsListAll)
        {
            {
               
            }
        }

    }
}