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
        /*
        [Test]
        public void _2CheckBalanceTest()
        {
            var testUser = new User("test", "test@northcoders.com");
            int actual = testUser.CheckBalance();
            int expected = 0;
            Assert.That(actual, Is.EqualTo(expected));
        }
        /*
        [Test]
        public void _3AccountsCreatedTest()
        {
            User.ResetAccountsCount();
            Assert.That(User.AccountsCreated, Is.EqualTo(0));
            var testUser1 = new User("test1", "test1@northcoders.com");
            Assert.That(User.AccountsCreated, Is.EqualTo(1));
            var testUser2 = new User("test2", "test2@northcoders.com");
            Assert.That(User.AccountsCreated, Is.EqualTo(2));
        }
        */
        /*
        [Test]
        public void _4AddBalanceTest()
        {
            var testUser = new User("test", "test@northcoders.com");
            testUser.AddBalance(50);
            Assert.That(testUser.CheckBalance(), Is.EqualTo(50));
            testUser.AddBalance(50);
            Assert.That(testUser.CheckBalance(), Is.EqualTo(100));
        }
        */
        /*
        [Test]
        public void _5ItemPropertyTest()
        {
            var testItem = new Item("testUser", "test", 10, "testing it out");
            Assert.That(testItem.Owner, Is.EqualTo("testUser"));
            Assert.That(testItem.Name, Is.EqualTo("test"));
            Assert.That(testItem.Price, Is.EqualTo(10));
            Assert.That(testItem.Description, Is.EqualTo("testing it out"));
        }
        */
        /*
        [Test]
        public void _6ListItemTest()
        {
            var testUser = new User("testUser", "test@northcoders.com");
            string actual;
            string expected;
            actual = testUser.ListItem("testItemName1", 20, "test description1");
            expected = "testItemName1 has been listed for sale";
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(testUser.ItemsForSale[0].Owner, Is.EqualTo("testUser"));
            Assert.That(testUser.ItemsForSale[0].Name, Is.EqualTo("testItemName1"));
            Assert.That(testUser.ItemsForSale[0].Price, Is.EqualTo(20));
            Assert.That(testUser.ItemsForSale[0].Description, Is.EqualTo("test description1"));
            actual = testUser.ListItem("testItemName2", 20, "test description2");
            expected = "testItemName2 has been listed for sale";
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(testUser.ItemsForSale[1].Owner, Is.EqualTo("testUser"));
            Assert.That(testUser.ItemsForSale[1].Name, Is.EqualTo("testItemName2"));
            Assert.That(testUser.ItemsForSale[1].Price, Is.EqualTo(20));
            Assert.That(testUser.ItemsForSale[1].Description, Is.EqualTo("test description2"));
        }
        */
        /*
        [Test]
        public void _7ReduceBalanceTest()
        {
            var testUser = new User("testUser", "test@northcoders.com");
            testUser.AddBalance(50);
            testUser.ReduceBalance(10);
            Assert.That(testUser.CheckBalance(), Is.EqualTo(40));
        }
        */
        /*
        [Test]
        public void _8PurchaseItemTest()
        {
            var testUser1 = new User("testUser1", "test@northcoders.com");
            var testUser2 = new User("testUser2", "test@northcoders.com");
            testUser2.AddBalance(50);
            testUser2.ListItem("testItemName2", 20, "test description2");
            var testItem = testUser2.ItemsForSale[0];
            Assert.That(testUser2.PurchaseItem(testItem), Is.EqualTo("Your purchase of testItemName has been confirmed!"));
            Assert.That(testUser2.CheckBalance(), Is.EqualTo(30));
        }
        */
        /*
        [Test]
        public void _9PurchaseItemValidationTest()
        {
            var testUser1 = new User("testUser1", "test1@northcoders.com");
            testUser1.ListItem("testItemName1", 20, "test description1");
            var testItem1 = testUser1.ItemsForSale[0];
            var testUser2 = new User("testUser2", "test2@northcoders.com");
            testUser2.ListItem("testItemName2", 20, "test description2");
            var testItem2 = testUser2.ItemsForSale[0];
            Assert.That(testUser1.PurchaseItem(testItem1), Is.EqualTo("This item belongs to you already!"));
            Assert.That(testUser1.PurchaseItem(testItem2), Is.EqualTo("Insufficient funds"));
            Assert.That(testUser1.CheckBalance(), Is.EqualTo(0));
            testUser1.AddBalance(50);
            Assert.That(testUser1.PurchaseItem(testItem2), Is.EqualTo("Your purchase of testItemName2 has been confirmed!"));
            Assert.That(testUser1.CheckBalance(), Is.EqualTo(20));
        }
        */
    }
}