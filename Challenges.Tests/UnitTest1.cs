namespace Challenges.Tests
{
    public class Tests
    {
        [Test]
        public void UserPropertyTest()
        {
            var testUser = new User("test", "test@northcoders.com");
            Assert.That(testUser.Username, Is.EqualTo("test"));
            Assert.That(testUser.UserEmail, Is.EqualTo("test@northcoders.com"));
        }
        [Test]
        public void CheckBalanceTest()
        {
            var testUser = new User("test", "test@northcoders.com");
            int actual = testUser.CheckBalance();
            int expected = 0;
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void AccountsCreatedTest()
        {
            Assert.That(User.AccountsCreated, Is.EqualTo(0));
            var testUser1 = new User("test1", "test1@northcoders.com");
            Assert.That(User.AccountsCreated, Is.EqualTo(1));
            var testUser2 = new User("test2", "test2@northcoders.com");
            Assert.That(User.AccountsCreated, Is.EqualTo(2));
        }
        [Test]
        public void AddBalanceTest()
        {
            var testUser = new User("test", "test@northcoders.com");
            testUser.AddBalance(50);
            Assert.That(testUser.CheckBalance(), Is.EqualTo(50));
            testUser.AddBalance(50);
            Assert.That(testUser.CheckBalance(), Is.EqualTo(100));
        }
        [Test]
        public void ItemPropertyTest()
        {
            var testItem = new Item("testUser", "test", 10, "testing it out");
            Assert.That(testItem.Owner, Is.EqualTo("testUser"));
            Assert.That(testItem.ItemName, Is.EqualTo("test"));
            Assert.That(testItem.Price, Is.EqualTo(10));
            Assert.That(testItem.Description, Is.EqualTo("testing it out"));
        }
        [Test]
        public void ListItemTest()
        {
            var testUser = new User("testUser", "test@northcoders.com");
            Item testItem = testUser.ListItem("testItemName", 20, "test description");
            Assert.That(testItem.Owner, Is.EqualTo("testUser"));
            Assert.That(testItem.ItemName, Is.EqualTo("testItemName"));
            Assert.That(testItem.Price, Is.EqualTo(20));
            Assert.That(testItem.Description, Is.EqualTo("test description"));
        }
        [Test]
        public void ReduceBalanceTest()
        {
            var testUser = new User("testUser", "test@northcoders.com");
            testUser.AddBalance(50);
            testUser.ReduceBalance(10);
            Assert.That(testUser.CheckBalance(), Is.EqualTo(40));
        }
        [Test]
        public void PurchaseItemTest()
        {
            var testUser1 = new User("testUser1", "test@northcoders.com");
            var testUser2 = new User("testUser2", "test@northcoders.com");
            testUser2.AddBalance(50);
            Item testItem = testUser1.ListItem("testItemName", 20, "test description");
            Assert.That(testUser2.PurchaseItem(testItem), Is.EqualTo("Your purchase of testItemName has been confirmed!"));
            Assert.That(testUser2.CheckBalance(), Is.EqualTo(30));
        }
        [Test]
        public void PurchaseItemValidationTest()
        {
            var testUser1 = new User("testUser1", "test1@northcoders.com");
            Item testItem1 = testUser1.ListItem("testItemName1", 20, "test description 1");
            var testUser2 = new User("testUser2", "test2@northcoders.com");
            Item testItem2 = testUser2.ListItem("testItemName2", 30, "test description 2");
            Assert.That(testUser1.PurchaseItem(testItem1), Is.EqualTo("This item belongs to you already!"));
            Assert.That(testUser1.PurchaseItem(testItem2), Is.EqualTo("Insufficient funds"));
            Assert.That(testUser1.CheckBalance(), Is.EqualTo(0));
            testUser1.AddBalance(50);
            Assert.That(testUser1.PurchaseItem(testItem2), Is.EqualTo("Your purchase of testItemName2 has been confirmed!"));
            Assert.That(testUser1.CheckBalance(), Is.EqualTo(20));
        }
    }
}