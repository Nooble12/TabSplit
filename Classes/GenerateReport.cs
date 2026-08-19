using System.Collections.ObjectModel;
using System.Text;

namespace TabSplit.Classes
{
    public class GenerateReport
    {
        private ObservableCollection<Person> personList = new ObservableCollection<Person>();
        private float taxPerent;
        private float tipPerecnt;
        private float serviceFeePercent;
        public GenerateReport(ObservableCollection<Person> inList, float inTaxPercent, float inTipPercent, float serviceFeePercent)
        {
            personList = inList;
            taxPerent = inTaxPercent;
            tipPerecnt = inTipPercent;
            this.serviceFeePercent = serviceFeePercent;
        }

        public string CreateReport()
        {
            float totalCost = 0.0f;
            float totalTax = 0.0f;
            float totalTip = 0.0f;
            float totalServiceFee = 0.0f;

            StringBuilder builder = new StringBuilder("Summary \n");
            builder.AppendLine("Tax, Service Fee, and Tip are calculated separately on the item base value.\n");
            builder.AppendLine($"Tip: {tipPerecnt}%");
            builder.AppendLine($"Service Fee: {serviceFeePercent}%");
            builder.AppendLine($"Sales Tax: {taxPerent}%");
            builder.AppendLine();
            builder.AppendLine("<-------------------------------------->\n");
            foreach (Person person in personList)
            {

                float individualTaxCost = 0.0f;
                float individualTipCost = 0.0f;
                float individualServiceFeeCost = 0.0f;

                totalCost += person.totalPrice;

                builder.AppendLine(person.name);
                builder.AppendLine(person.contactInfo + "\n");
                
                foreach (Item item in person.inventory)
                {
                    builder.AppendLine($"{item.name}: ${item.price} ({item.quantity}) = ${(item.price * item.quantity):F2}");
                    individualTaxCost += (item.price * item.quantity) * (taxPerent / 100);
                    individualTipCost += (item.price * item.quantity) * (tipPerecnt / 100);
                    individualServiceFeeCost += (item.price * item.quantity) * (serviceFeePercent / 100);
                }

                totalTax += individualTaxCost;
                totalTip += individualTipCost;
                totalServiceFee += individualServiceFeeCost;

                builder.AppendLine();
                builder.AppendLine($"Tip: ${individualTipCost:F2}");
                builder.AppendLine($"Service Fee: ${individualTipCost:F2}");
                builder.AppendLine($"Tax: ${individualTaxCost:F2}");
                builder.AppendLine($"Total: ${person.totalPrice:F2} <----- {person.name} pays");
                builder.AppendLine();

                builder.AppendLine("<-------------------------------------->\n");
            }

            builder.AppendLine($"Tip: ${totalTip:F2}");
            builder.AppendLine($"Service Fee: ${totalTip:F2}");
            builder.AppendLine($"Tax: ${totalTax:F2}");
            builder.AppendLine($"Total: ${totalCost:F2}");

            builder.AppendLine("\nReport Generated With: " + "https://github.com/Nooble12/TabSplit");
            return builder.ToString();
        }
    }
}
