namespace Challenges
{
    public class User
    {
        public string Username { get; set; }
        public string UserEmail { get; set; }

        public List<Item> ListedItems { get; set; } = new List<Item>();

        public User(string username, string email) 
        {
            Username = username;
            UserEmail = email;
        }
        public string ListItem(string itemName, int price, string description)
        {
            var newItem = new Item(Username, itemName, price, description);
            ListedItems.Add(newItem);
            return $"{itemName} has been listed for sale";
        }
    }
}
