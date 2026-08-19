using System.Runtime.CompilerServices;

namespace TabSplit.Classes
{
    public class CalculateTotalPrice
    {
        public float GetTotalPrice(List<Item> inventory, float tipPercent, float taxPercent, float serviceFeePercent)
        {
            float totalBasePrice = GetTotalBasePrice(inventory);
            float tipCost = 0.0f;
            float serviceFeeCost = 0.0f;
            float taxCost = 0.0f;

            float tipDecimal = tipPercent / 100;
            float taxDecimal = taxPercent / 100;
            float serviceFeeDecimal = serviceFeePercent / 100;

            tipCost = totalBasePrice * tipDecimal;
            serviceFeeCost = totalBasePrice * serviceFeeDecimal;
            taxCost = totalBasePrice * taxDecimal;

            return tipCost + serviceFeeCost + taxCost + totalBasePrice;
        }

        public float GetTotalBasePrice(List<Item> inventory)
        {
            float totalBasePrice = 0.0f;
            foreach (var item in inventory)
            {
                totalBasePrice += (item.price * item.quantity);
            }

            return totalBasePrice;
        }
    }
}
