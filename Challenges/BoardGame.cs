using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal class BoardGame : Item
    {
        public BoardGame(int owner, string name, int price, string description) : base(owner, name, price, description)
        {
            Enum EnumType = Enums.ItemType.BOARDGAME;
        }

        public void Eat(User buyer)
        {
            Console.WriteLine($"{buyer.Username} has eaten {Name}");
        }
    }
}
