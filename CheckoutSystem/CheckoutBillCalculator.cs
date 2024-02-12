using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutSystem {
    public class CheckoutBillCalculator {
        private OrdinaryPrices OrdinaryPriceObj;
        private OfferPrices OfferPriceObj;

        public CheckoutBillCalculator() {
            // Load Data
            OrdinaryPriceObj = new OrdinaryPrices();
            OfferPriceObj = new OfferPrices();

            OrdinaryPriceObj.AddItem('A', 50);
            OrdinaryPriceObj.AddItem('B', 30);
            OrdinaryPriceObj.AddItem('C', 20);
            OrdinaryPriceObj.AddItem('D', 15);

            OfferPriceObj.AddItem('A', 3, 130);
            OfferPriceObj.AddItem('B', 2, 45);
        }

        public int Calculate(string SKUString) { 
            int totalBill = 0;
            Dictionary<char, int> ItemsCount = new Dictionary<char, int>();
            foreach (char ch in SKUString) {
                if (ItemsCount.ContainsKey(ch)) ItemsCount[ch]++;
                else ItemsCount[ch] = 1;
            }

            foreach (char ch in ItemsCount.Keys) {
                if (OfferPriceObj.ContainsOffer(ch)) {
                    OfferSummary summary = OfferPriceObj.GetOffer(ch);
                    totalBill += (ItemsCount[ch] / summary.itemsCount) * summary.aggregatePrice;
                    totalBill += (ItemsCount[ch] % summary.itemsCount) * OrdinaryPriceObj.GetPrices(ch);
                }
                else {
                    totalBill += (ItemsCount[ch] * OrdinaryPriceObj.GetPrices(ch));
                }
            }

            return totalBill;
        }
    }
}
