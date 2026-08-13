using System.Runtime.CompilerServices;

namespace TabSplit.Classes
{
    public class CalculateTotalPrice
    {
        public float GetTotalPrice(List<Item> inventory, float tipPercent, float taxPercent)
        {
            float totalBasePrice = GetTotalBasePrice(inventory);
            float basePriceWithTip = 0.0f;
            float taxPrice = 0.0f;

            float tipDecimal = tipPercent / 100;
            float taxDecimal = taxPercent / 100;

            basePriceWithTip = (totalBasePrice * tipDecimal) + totalBasePrice;
            taxPrice = (totalBasePrice * taxDecimal);

            return basePriceWithTip + taxPrice;
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
