using System.Security.Cryptography.X509Certificates;

namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //User buyer = new User("testUser2", "test2@northcoders.com");
            //Food food = new Food(1, "car 1", 200, "Check this out");

            //food.Eat(buyer);

            Console.WriteLine("Enter the following characters to perform each action:");
            Console.WriteLine("U: Create a user account");
            Console.WriteLine("L: List an item");
            Console.WriteLine("B: Browse items");
            Console.WriteLine("P: Purchase items");
            Console.WriteLine("S: Sell items");
            string action = Console.ReadLine();
            
            switch (action)
            {
                case "U":
                    //CreateUserAccount();
                    Console.WriteLine("Enter a username");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter an email");
                    string email = Console.ReadLine();
                    User testUser = new User(username, email);
                    Console.WriteLine("Account created successfully");
                    break;
                case "L":
                    //ListItems();
                    Console.WriteLine("Enter an item name");
                    string itemName = Console.ReadLine();
                    Console.WriteLine("Enter an item price");
                    string itemPrice = Console.ReadLine();
                    Console.WriteLine("Enter an item description");
                    string itemDescription = Console.ReadLine();

                    break;
                case "B":
                    //BrowseItems();
                    break;
                case "P":
                    //PurchaseItems();
                    break;
                case "S":
                    //SellItems();
                    break;
            }
        }
    }
}
