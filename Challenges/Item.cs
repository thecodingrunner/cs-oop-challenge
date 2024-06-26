namespace Challenges
{
    public class Item
    {
        public string Owner { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public Item(string owner, string name, int price, string description) 
        {
            Owner = owner;
            ItemName = name;
            Price = price;
            Description = description;
        }
    }
}
