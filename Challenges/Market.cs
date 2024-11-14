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

        public Item ListItem(Enum itemType, string name, int price, string description, User seller)
        {
            Item item;
            switch (itemType)
            {
                case Enums.ItemType.CAR:
                    item = new Car(seller.UserId, name, price, description);
                    break;
                case Enums.ItemType.FOOD:
                    item = new Food(seller.UserId, name, price, description);
                    break;
                case Enums.ItemType.BOARDGAME:
                    item = new BoardGame(seller.UserId, name, price, description);
                    break;
                case Enums.ItemType.APPLIANCE:
                    item = new Appliance(seller.UserId, name, price, description);
                    break;
                default:
                    item = new Appliance(seller.UserId, name, price, description);
                    break;
            }

            if (item != null) ItemsForSale.Add(item);
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

        public List<Item> FilterByCategory(Enum category)
        {
            return ItemsForSale.Where(item => item.ItemType == category).ToList();
        }

        public List<Item> BrowseItems(int userId)
        {
            return ItemsForSale.Where(item => item.Owner == userId).ToList();
        }
    }
}
