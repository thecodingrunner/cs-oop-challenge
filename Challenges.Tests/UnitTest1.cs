using FluentAssertions;

namespace Challenges.Tests
{
    public class Tests
    {
        [Test]
        public void _1UserPropertyTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.Username.Should().Be("test");
            testUser.Email.Should().Be("test@northcoders.com");
        }

        [Test]
        public void _2BalanceTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.Balance.Should().Be(0);
        }


        [Test]
        public void _3UpdateBalanceTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.UpdateBalance(55);
            testUser.Balance.Should().Be(55);
            testUser.UpdateBalance(-5);
            testUser.Balance.Should().Be(50);
        }


        [Test]
        public void _4AccountsCreatedTest()
        {
            User.ResetAccountsCount();
            User.AccountsCreated.Should().Be(0);
            new User("test1", "test1@northcoders.com");
            User.AccountsCreated.Should().Be(1);
            new User("test2", "test2@northcoders.com");
            User.AccountsCreated.Should().Be(2);
        }


        [Test]
        public void _5ItemPropertyTest()
        {
            Item testItem = new Car(1, "test", 10, "testing it out");
            testItem.Owner.Should().Be(1);
            testItem.Name.Should().Be("test");
            testItem.Price.Should().Be(10);
            testItem.Description.Should().Be("testing it out");

            testItem.Owner = 2;
            testItem.Owner.Should().Be(2);

            testItem.Name = "new name";
            testItem.Name.Should().Be("new name");

            testItem.Price = 20;
            testItem.Price.Should().Be(20);

            testItem.Description = "new description";
            testItem.Description.Should().Be("new description");
        }


        [Test]
        public void _6ListItemTest()
        {
            User testUser = new User("testUser", "test@northcoders.com");

            Market market = new Market();

            Item firstItem = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName1", 20, "test description1", testUser);
            Item firstItemForSale = market.ItemsForSale[0];
            firstItemForSale.Should().Be(firstItem);

            Item secondItem = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName2", 20, "test description2", testUser);
            Item secondItemForSale = market.ItemsForSale[1];
            secondItemForSale.Should().Be(secondItem);
        }


        [Test]
        public void _7PurchaseItemTest()
        {
            Market market = new Market();
            User buyer = new User("testUser1", "test@northcoders.com");
            User seller = new User("testUser2", "test@northcoders.com");
            buyer.UpdateBalance(50);
            market.ListItem(Enums.ItemType.APPLIANCE, "testItemName", 20, "test description", seller);
            Item testItem = market.ItemsForSale[0];
            market.PurchaseItem(testItem, seller, buyer).Should().Be(Enums.PurchaseResult.SUCCESS);
            buyer.Balance.Should().Be(30);
        }


        [Test]
        public void _9PurchaseItemWithoutFundsTest()
        {
            Market market = new Market();
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName1", 20, "test description1", seller);

            User buyer = new User("testUser2", "test2@northcoders.com");

            market.PurchaseItem(item, seller, buyer).Should().Be(Enums.PurchaseResult.INSUFFICIENT_FUNDS);

            buyer.UpdateBalance(50);

            market.PurchaseItem(item, seller, buyer).Should().Be(Enums.PurchaseResult.SUCCESS);
        }


        [Test]
        public void _9PurchaseOwnItemTest()
        {
            Market market = new Market();
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName1", 20, "test description1", seller);

            market.PurchaseItem(item, seller, seller).Should().Be(Enums.PurchaseResult.ALREADY_OWNED);
        }

        [Test]
        public void _10ItemUnlisted()
        {
            Market market = new Market();
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName1", 0, "test description1", seller);
            User buyer = new User("testUser2", "test2@northcoders.com");

            market.PurchaseItem(item, seller, buyer);

            market.ItemsForSale.Should().BeEmpty();
        }

        [Test]
        public void _11ThrowUsernameException()
        {
            Assert.Throws<ArgumentException>(() => new User("", "test1@northcoders.com"));
        }

        [Test]
        public void _12ThrowEmailException()
        {
            Assert.Throws<ArgumentException>(() => new User("username", "test1@northcoderscom"));
        }

        [Test]
        public void _13GetPrettyDate()
        {
            Market market = new Market();
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName1", 0, "test description1", seller);
            Assert.That(item.GetPrettyDateListed(), Is.TypeOf<string>());
        }

        [Test]
        public void _14CheckItemIDs()
        {
            Market market = new Market();
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item1 = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName1", 0, "test description1", seller);
            Item item2 = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName2", 0, "test description2", seller);
            Item item3 = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName3", 0, "test description3", seller);
            item3.ItemId.Should().Be(Item.ItemsCreated);
        }

        [Test]
        public void _15CheckUserIDs()
        {
            var one = new User("testUser1", "test1@northcoders.com"); // ItemId is automatically set to 1
            var two = new User("testUser2", "test2@northcoders.com"); // ItemId is automatically set to 2
            var three = new User("testUser3", "test3@northcoders.com"); // ItemId is automatically set to 3
            three.UserId.Should().Be(User.AccountsCreated);
        }

        [Test]
        public void _16FilterCategories()
        {
            Market market = new Market();
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item1 = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName1", 0, "test description1", seller);
            Item item2 = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName2", 0, "test description2", seller);

            Assert.That(market.FilterByCategory(Enums.ItemType.APPLIANCE), Is.TypeOf<List<Item>>());
        }

        [Test]
        public void _17BrowseItems()
        {
            Market market = new Market();
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item1 = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName1", 0, "test description1", seller);
            Item item2 = market.ListItem(Enums.ItemType.APPLIANCE, "testItemName2", 0, "test description2", seller);

            Assert.That(market.BrowseItems(1), Is.TypeOf<List<Item>>());
        }
    }
}
