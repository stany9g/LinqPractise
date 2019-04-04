using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractise
{
    public class TradeHistory
    {
        private readonly List<Transaction> _transactions;

        public TradeHistory(List<Transaction> transactions)
        {
            _transactions = transactions;
        }

        /// <summary>
        /// Nalezněte všechny transakce provedené v roce 2011 a setřiďte je podle velikost.
        /// </summary>
        /// <returns></returns>
        public List<Transaction> FindAllTransactionsIn2011AndSortByValueAsc()
        {
            List<Transaction> newList = new List<Transaction>();
            newList = _transactions.FindAll(x => x.Year == 2011).OrderBy(x => x.Value).ToList();
            return newList;
        }

        /// <summary>
        /// Vypište unikátní seznam měst.
        /// </summary>
        /// <returns></returns>
        public List<string> GetUniqueCitiesSortedAsc()
        {
            List<string> newList = new List<string>();
            newList = _transactions.Select(x => x.Trader.City).Distinct().OrderBy(x => x).ToList();
            return newList;
        }

        /// <summary>
        /// Vypište řetězec, který vypisuje seznam obchodníků ve formátu “Traders: name1 name2 … ”- např. “Traders: Bob George”, ''.
        /// string shall start with "Traders:" and use space as separator. E.g.: "Traders: Bob George"
        /// </summary>
        /// <returns></returns>
        public string GetSinglestringFromUniqueTradersNamesSortByNameAsc()
        {
            string traderStr = "";
            var names = _transactions.Select(x => x.Trader.Name).Distinct().OrderBy(x => x).ToList();
            traderStr = $"Traders: {string.Join(" ", names)}";
            return traderStr;
        }

        /// <summary>
        /// Existuje pro zadané město nějaký obchodník?
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public bool IsSomeTraderFromCity(string cityName)
        {
            bool isSome = false;
            isSome = _transactions.Select(x => x.Trader).Where(x => x.City == cityName).Any();
            return isSome;
        }

        /// <summary>
        /// Vraťte obchodníky zgrupované podle města.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Trader>> GetTradersByTown()
        {
            Dictionary<string, List<Trader>> tradersByTown = new Dictionary<string, List<Trader>>();
            tradersByTown = _transactions.Select(x => x.Trader).Distinct().GroupBy(x => x.City).ToDictionary(x => x.Key, x => x.ToList());
            return tradersByTown;
        }

        /// <summary>
        /// Vraťte počty obchodníků zgrupovné podle města.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, long> GetTradersCountsByTown()
        {
            Dictionary<string, long> tradersByTown = new Dictionary<string, long>();
            tradersByTown = _transactions.Select(x => x.Trader).Distinct().GroupBy(x => x.City).ToDictionary(x => x.Key, x => (long)x.ToList().Count());
            return tradersByTown;
        }

    }
}
