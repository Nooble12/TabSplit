using System.Collections.ObjectModel;
using System.Text;

namespace TabSplit.Classes
{
    public class GenerateReport
    {
        private ObservableCollection<Person> personList = new ObservableCollection<Person>();
        private float taxPerent;
        private float tipPerecnt;
        public GenerateReport(ObservableCollection<Person> inList, float inTaxPercent, float inTipPercent)
        {
            personList = inList;
            taxPerent = inTaxPercent;
            tipPerecnt = inTipPercent;
        }

        public string CreateReport()
        {
            float totalCost = 0.0f;
            float totalTax = 0.0f;
            float totalTip = 0.0f;

            StringBuilder builder = new StringBuilder("Summary \n");
            builder.AppendLine("Tax and Tip are calculated separately on the item base value.");
            builder.AppendLine($"Tip: {tipPerecnt}%");
            builder.AppendLine($"Sales Tax: {taxPerent}%");
            builder.AppendLine();
            builder.AppendLine("<-------------------------------------->\n");
            foreach (Person person in personList)
            {

                float individualTaxCost = 0.0f;
                float individualTipCost = 0.0f;

                totalCost += person.totalPrice;

                builder.AppendLine(person.name);
                builder.AppendLine(person.contactInfo + "\n");
                
                foreach (Item item in person.inventory)
                {
                    builder.AppendLine($"{item.name}: ${item.price} ({item.quantity}) = ${(item.price * item.quantity):F2}");
                    individualTaxCost += item.price * (taxPerent / 100);
                    individualTipCost += item.price * (tipPerecnt / 100);
                }

                totalTax += individualTaxCost;
                totalTip += individualTipCost;

                builder.AppendLine();
                builder.AppendLine($"Tip: ${individualTipCost:F2}");
                builder.AppendLine($"Tax: ${individualTaxCost:F2}");
                builder.AppendLine($"Total: ${person.totalPrice:F2} <----- {person.name} pays");
                builder.AppendLine();

                builder.AppendLine("<-------------------------------------->\n");
            }

            builder.AppendLine($"Tip: ${totalTip:F2}");
            builder.AppendLine($"Tax: ${totalTax:F2}");
            builder.AppendLine($"Total: ${totalCost:F2}");

            builder.AppendLine("Report Generated With: " + "https://github.com/Nooble12/TabSplit");
            return builder.ToString();
        }
    }
}
