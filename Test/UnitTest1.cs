using System;
using System.Collections.Generic;
using GoldBadgeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        public void MyAddItemTestMethod()
        {
            MenuItem item = new MenuItem();
            MenuRepo repository = new MenuRepo();
            bool addResult = repository.AddItemToMenu(item);

            Assert.IsTrue(addResult);
        }
        public void GetAllItems_ShouldReturnCollection()
        {
            MenuItem item = new MenuItem();
            MenuRepo repo = new MenuRepo();
            repo.AddItemToMenu(item);

            List<MenuItem> items = repo.GetAllItems();

            bool directoryHasContent = items.Contains(item);
            Assert.IsTrue(directoryHasContent);
        }
        //*WTF is this shit below*//
        private MenuRepo _repo;
        private MenuItem _item;
        [TestInitialize]
        public void Arrange()
        {
            List<string> mondayDailySlice = new List<string>() { "dough, parm, mozz, red sauce, red onion, mushroom" };
            _repo = new MenuRepo();
            _item = new MenuItem(1, "Monday Daily Slice", "Mushroom and onion slice",mondayDailySlice, 3.5);
            _repo.AddItemToMenu(_item);
        }
        //*WTF is this above shit*//
        public void MyGetByNameTestMethod()
        {
            MenuItem searhResult = _repo.GetItemByName("Monday Daily Slice");
            Assert.AreEqual(_repo, searhResult);
        }
        public void DeleteExistingItem()
        {
            bool removeResult = _repo.DeleteExistingItem("Monday Daily Slice");
            Assert.IsTrue(removeResult);
        }
    }
}
