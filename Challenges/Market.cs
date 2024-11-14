using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal class Market
    {
        public List<Item> ItemsForSale = new List<Item>();

        public Item ListItem(string name, int price, string description, User seller)
        {
            Item item = new Item(seller.UserId, name, price, description);
            ItemsForSale.Add(item);
            return item;
        }

        public Enum PurchaseItem(int ItemId, User seller, User buyer)
        {
            Item item = GetItemById(ItemId);
            if (ItemsForSale.Where(item => item.Owner == buyer.UserId).ToList().Count != 0)
            {
                return Enums.PurchaseResult.ALREADY_OWNED;
            }
            if (buyer.Balance < item.Price)
            {
                return Enums.PurchaseResult.INSUFFICIENT_FUNDS;
            }

            buyer.Balance -= item.Price;
            UnlistItem(item);
            return Enums.PurchaseResult.SUCCESS;
        }

        public Enum PurchaseItem(Item item, User seller, User buyer)
        {
            if (ItemsForSale.Where(item => item.Owner == buyer.UserId).ToList().Count != 0)
            {
                return Enums.PurchaseResult.ALREADY_OWNED;
            }
            if (buyer.Balance < item.Price)
            {
                return Enums.PurchaseResult.INSUFFICIENT_FUNDS;
            }

            buyer.Balance -= item.Price;
            UnlistItem(item);
            return Enums.PurchaseResult.SUCCESS;
        }

        public List<Item> UnlistItem(Item item)
        {
            ItemsForSale.Remove(item);
            return ItemsForSale;
        }

        public Item GetItemById(int ItemId)
        {
            return ItemsForSale.Where(item => item.ItemId == ItemId).ToList()[0];
        } 
    }
}
