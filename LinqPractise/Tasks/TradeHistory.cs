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
            //Implement body here
            return newList;
        }

        /// <summary>
        /// Vypište unikátní seznam měst.
        /// </summary>
        /// <returns></returns>
        public List<string> GetUniqueCitiesSortedAsc()
        {
            List<string> newList = new List<string>();
            //Implement body here
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
            //Implement body here
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
            //Implement body here
            return isSome;
        }

        /// <summary>
        /// Vraťte obchodníky zgrupovné podle města.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Trader>> GetTradersByTown()
        {
            Dictionary<string, List<Trader>> tradersByTown = new Dictionary<string, List<Trader>>();
            //Implement body here
            return tradersByTown;
        }

        /// <summary>
        /// Vraťte počty obchodníků zgrupovné podle města.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, long> GetTradersCountsByTown()
        {
            Dictionary<string, long> tradersByTown = new Dictionary<string, long>();
            //Implement body here
            return tradersByTown;
        }

        /// <summary>
        /// Rozdělte transakce na dvě skupiny - první, provedené vegetariány a druhá ostatní
        /// </summary>
        /// <returns></returns>
        public Dictionary<bool, List<Transaction>> PartitionTransactionsByTraderIsVegetarian()
        {
            Dictionary<bool, List<Transaction>> transactionsBy = new Dictionary<bool, List<Transaction>>();
            //Implement body here
            return transactionsBy;
        }
    }
}
