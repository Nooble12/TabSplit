namespace TabSplit.Classes
{
    public class Person
    {
        string name {get; set;}
        Dictionary<Item, int> inventory = new Dictionary<Item, int>();

        public Person(string inName)
        {
            name = inName;
        }
    }
}
