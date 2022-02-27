using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_FunctionalParadigm_LINQ
{
    public class ProductsManager
    {

        decimal TotalItemsCosts = 0;
        int countItems = 0;


        internal void AddItemToTotal(ShoppingItem item)
        {
            countItems += 1;
            TotalItemsCosts += item.Price;
        }

        internal decimal AveragePrice()
        {
            return TotalItemsCosts / countItems;
        }
/*
        public static void SortShoppingItems(object[] items, Func<object, object, bool> isAGreaterThanB)
        {
            bool swapped;
            do
            {
                swapped = false;

                for (int i = 0; i <= items.Length - 2; i++)
                {
                    if (isAGreaterThanB(items[i], items[i + 1]))
                    {
                        object temp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

*/
    }
}
