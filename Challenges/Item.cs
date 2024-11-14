using moment.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal abstract class Item
    {
        public int Owner;
        public string Name;
        public int Price;
        public string Description;
        public DateTime DateListed;
        public int ItemId {  get; } = 0;
        public static int ItemsCreated { get; private set; } = 0;
        public Enum ItemType { get; set; }
        
        public Item(int owner, string name, int price, string description)
        {
            Owner = owner;
            Name = name;
            Price = price;
            Description = description;
            DateTime DateListed = DateTime.Now;
            ItemsCreated++;
            ItemId = ItemsCreated;
        }

        public string GetPrettyDateListed()
        {
            return DateListed.FromNow();
        }
    }
}
