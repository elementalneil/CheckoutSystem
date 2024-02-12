using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutSystem {
    public class OrdinaryPrices {
        public Dictionary<char, int> ItemToValueMap;

        public OrdinaryPrices() {
            ItemToValueMap = new Dictionary<char, int>();

        }

        public void AddItem(char item, int value) {
            ItemToValueMap[item] = value;
        }

        public int GetPrices(char item) {
            if (ItemToValueMap.ContainsKey(item))
                return ItemToValueMap[item];
            else
                throw new Exception("Item Does not Exist");
        }
    }
}
