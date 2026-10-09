using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TabSplit.Classes
{
    internal class CollectionSorter
    {
        public CollectionSorter()
        {

        }

        public void sortAscending<T, TKey>(ObservableCollection<T> collection, Func<T, TKey> nameSelector) 
        {
            var sorted = collection.ToList().OrderBy(element => nameSelector(element));
            RebuildObservableCollection(sorted, collection);
        }

        public void sortDescending<T, TKey>(ObservableCollection<T> collection, Func<T, TKey> nameSelector)
        {
            var sorted = collection.ToList().OrderByDescending(element => nameSelector(element));
            RebuildObservableCollection(sorted, collection);
        }

        private void RebuildObservableCollection<T>(IOrderedEnumerable<T> sortedList, ObservableCollection<T> originalList)
        {
            originalList.Clear();

            foreach (var element in sortedList)
            {
                originalList.Add(element);
            }
        }
    }
}
