using FluentAssertions;

namespace Challenges.Tests
{
    public class Tests
    {
        [Test]
        public void _1UserPropertyTest()
        {
            var testUser = new User("test", "test@northcoders.com");
            testUser.Username.Should().Be("test");
            testUser.Email.Should().Be("test@northcoders.com");
        }
        
        [Test]
        public void _2CheckBalanceTest()
        {
            var testUser = new User("test", "test@northcoders.com");
            int actual = testUser.CheckBalance();
            int expected = 0;
            actual.Should().Be(expected);
        }
        
        
        [Test]
        public void _3AccountsCreatedTest()
        {
            User.ResetAccountsCount();
            User.AccountsCreated.Should().Be(0);
            var testUser1 = new User("test1", "test1@northcoders.com");
            User.AccountsCreated.Should().Be(1);
            var testUser2 = new User("test2", "test2@northcoders.com");
            User.AccountsCreated.Should().Be(2);
        }
        
        
        [Test]
        public void _4AddBalanceTest()
        {
            var testUser = new User("test", "test@northcoders.com");
            testUser.AddBalance(50);
            testUser.CheckBalance().Should().Be(50);
            testUser.AddBalance(50);
            testUser.CheckBalance().Should().Be(100);
        }
        
        
        [Test]
        public void _5ItemPropertyTest()
        {
            var testItem = new Item("testUser", "test", 10, "testing it out");
            testItem.Owner.Should().Be("testUser");
            testItem.Name.Should().Be("test");
            testItem.Price.Should().Be(10);
            testItem.Description.Should().Be("testing it out");
        }
        
        
        [Test]
        public void _6ListItemTest()
        {
            var testUser = new User("testUser", "test@northcoders.com");
            string actual;
            string expected;
            actual = testUser.ListItem("testItemName1", 20, "test description1");
            expected = "testItemName1 has been listed for sale";
            actual.Should().Be(expected);
            testUser.ItemsForSale[0].Owner.Should().Be("testUser");
            testUser.ItemsForSale[0].Name.Should().Be("testItemName1");
            testUser.ItemsForSale[0].Price.Should().Be(20);
            testUser.ItemsForSale[0].Description.Should().Be("test description1");
            actual = testUser.ListItem("testItemName2", 20, "test description2");
            expected = "testItemName2 has been listed for sale";
            actual.Should().Be(expected);
            testUser.ItemsForSale[1].Owner.Should().Be("testUser");
            testUser.ItemsForSale[1].Name.Should().Be("testItemName2");
            testUser.ItemsForSale[1].Price.Should().Be(20);
            testUser.ItemsForSale[1].Description.Should().Be("test description2");
        }
        

        [Test]
        public void _7ReduceBalanceTest()
        {
            var testUser = new User("testUser", "test@northcoders.com");
            testUser.AddBalance(50);
            testUser.ReduceBalance(10);
            testUser.CheckBalance().Should().Be(40);
        }
        
        
        [Test]
        public void _8PurchaseItemTest()
        {
            var testUser1 = new User("testUser1", "test@northcoders.com");
            var testUser2 = new User("testUser2", "test@northcoders.com");
            testUser1.AddBalance(50);
            testUser2.ListItem("testItemName", 20, "test description");
            var testItem = testUser2.ItemsForSale[0];
            testUser1.PurchaseItem(testItem).Should().Be("Your purchase of testItemName has been confirmed!");
            testUser1.CheckBalance().Should().Be(30);
        }
        
        
        [Test]
        public void _9PurchaseItemValidationTest()
        {
            var testUser1 = new User("testUser1", "test1@northcoders.com");
            testUser1.ListItem("testItemName1", 20, "test description1");
            var testItem1 = testUser1.ItemsForSale[0];
            var testUser2 = new User("testUser2", "test2@northcoders.com");
            testUser2.ListItem("testItemName2", 20, "test description2");
            var testItem2 = testUser2.ItemsForSale[0];
            testUser1.PurchaseItem(testItem1).Should().Be("This item belongs to you already!");
            testUser1.PurchaseItem(testItem2).Should().Be("Insufficient funds");
            testUser1.CheckBalance().Should().Be(0);
            testUser1.AddBalance(50);
            testUser1.PurchaseItem(testItem2).Should().Be("Your purchase of testItemName2 has been confirmed!");
            testUser1.CheckBalance().Should().Be(30);
        }
        
    }
}