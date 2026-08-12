namespace TabSplit.Classes
{
    public class Item
    {
        string name {get; set;}
        float price { get; set; }
        int quantity { get; set; }

        public Item(string inName, float inPrice, int inQuantity)
        {
            name = inName;
            price = inPrice;
            quantity = inQuantity;
        }
    }
}
