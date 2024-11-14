using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal class Appliance : Item
    {
        public Appliance(int owner, string name, int price, string description) : base(owner, name, price, description)
        {
            Enum EnumType = Enums.ItemType.APPLIANCE;
        }
    }
}
