using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal class Food : Item, IEdible
    {
        public Food(int owner, string name, int price, string description) : base(owner, name, price, description)
        {
            Enum EnumType = Enums.ItemType.FOOD;
        }

        public void Eat(User buyer)
        {
            Console.WriteLine($"{buyer.Username} has eaten {Name}");
        }
    }
}
