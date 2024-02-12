using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutSystem {
    public struct OfferSummary {
        public int itemsCount;
        public int aggregatePrice;
    }

    public class OfferPrices {
        private Dictionary<char, OfferSummary> ItemToOfferMap;

        public OfferPrices() {
            ItemToOfferMap = new Dictionary<char, OfferSummary>();
        }

        public void AddItem(char item, int count, int price) {
            OfferSummary offerSummary = new OfferSummary();
            offerSummary.itemsCount = count;
            offerSummary.aggregatePrice = price;

            ItemToOfferMap[item] = offerSummary;
        }

        public OfferSummary GetOffer(char item) {
            return ItemToOfferMap[item];
        }

        public bool ContainsOffer (char item) {
            return ItemToOfferMap.ContainsKey(item);
        }
    }
}
