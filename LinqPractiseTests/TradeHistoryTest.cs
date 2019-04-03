using System;
using System.Collections.Generic;
using System.Linq;
using LinqPractise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqPractiseTests
{
    [TestClass]
    public class TradeHistoryTest
    {
        private TradeHistory tradeHistory;

        [TestInitialize]
        public void Init()
        {
            Trader raoul = new Trader("Raoul", "Cambridge", false);
            Trader mario = new Trader("Mario", "Milano", true);
            Trader alan = new Trader("Alan", "Cambridge", false);
            Trader brian = new Trader("Brian", "Cambridge", false);
            Trader bohous = new Trader("Bohous", "Kladno", false);
            Trader jarous = new Trader("Jarous", "Kladno", true);

            List<Transaction> transactions = new List<Transaction> {
                    new Transaction(brian, 2011, 300),
                    new Transaction(raoul, 2012, 1000),
                    new Transaction(raoul, 2011, 400),
                    new Transaction(mario, 2012, 20),
                    new Transaction(mario, 2012, 10),
                    new Transaction(alan, 2012, 950),
                    new Transaction(bohous, 2012, 1000),
                    new Transaction(bohous, 2011, 1100),
                    new Transaction(bohous, 2012, 800),
                    new Transaction(jarous, 2011, 10),
                    new Transaction(jarous, 2011, 30)};

            tradeHistory = new TradeHistory(transactions);
        }

        [TestMethod]
        public void FindAllTransactionsIn2011AndSortByValueAscTest()
        {
            // Act
            List<Transaction> actual = tradeHistory.FindAllTransactionsIn2011AndSortByValueAsc();

            // Assert
            Assert.AreEqual(actual[0], 10);
            Assert.AreEqual(actual[0], 10);
        }

        [TestMethod]
        public void GetUniqueCitiesSortedAscTest()
        {
            //Arrange
            string[] expected = new string[] { "Cambridge", "Kladno", "Milano" };

            //Act
            List<string> actual = tradeHistory.GetUniqueCitiesSortedAsc();

            //Assert
            CollectionAssert.AreEqual(expected,actual.ToArray());
        }

        [TestMethod]
        public void GetSinglestringFromUniqueTradersNamesSortByNameAscTest()
        {
            //Arrange
            string expected = "Traders: Alan Bohous Brian Jarous Mario Raoul";

            //Act
            string actual = tradeHistory.GetSinglestringFromUniqueTradersNamesSortByNameAsc();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsSomeTraderFromCityTest()
        {
            //Arrange
            string test1 = "Kladno";
            string test2 = "Brno";

            //act & assert
            Assert.IsTrue(tradeHistory.IsSomeTraderFromCity(test1));
            Assert.IsFalse(tradeHistory.IsSomeTraderFromCity(test2));
        }

        [TestMethod]
        public void GetTraderNamesByTownTest()
        {
            //arrange
            string[] kladnoTradersLabel = new string[] { "Bohous", "Jarous" };
            string[] cambridgeTradersLabel = new string[] { "Alan", "Brian", "Raoul" };
            string[] milanoTradersLabel = new string[] { "Mario" };

            //act
            Dictionary<string, List<Trader>> traders = tradeHistory.GetTradersByTown();


            List<string> kladnoTradersTest = traders["Kladno"].Select(x => x.Name).ToList();
            List<string> cambridgeTradersTest = traders["Cambridge"].Select(x => x.Name).ToList();
            List<string> milanoTradersTest = traders["Milano"].Select(x => x.Name).ToList();

            //assert
            CollectionAssert.AreEqual(kladnoTradersLabel, kladnoTradersTest.ToArray());
            CollectionAssert.AreEqual(cambridgeTradersLabel, cambridgeTradersTest.ToArray());
            CollectionAssert.AreEqual(milanoTradersLabel, milanoTradersTest.ToArray());
        }

        [TestMethod]
        public void GetTradersCountsByTownTest()
        {
            //act
            Dictionary<string, long> traders = tradeHistory.GetTradersCountsByTown();

            //assert
            Assert.AreEqual(2, traders["Kladno"]);
            Assert.AreEqual(3, traders["Cambridge"]);
            Assert.AreEqual(1, traders["Milano"]);
        }

        [TestMethod]
        public void PartitionTransactionsByTraderIsVegetarian()
        {
            //act
            Dictionary<bool, List<Transaction>> traders = tradeHistory.PartitionTransactionsByTraderIsVegetarian();

            //assert - simplified test checking only size of both groups
            Assert.AreEqual(traders[true].Count, 4);
            Assert.AreEqual(traders[false].Count, 7);
        }
    }
}
