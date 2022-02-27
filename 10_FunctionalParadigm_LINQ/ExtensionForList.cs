using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_FunctionalParadigm_LINQ
{
    internal static class ExtensionForList
    {
        // EXTENSION METHOD
        public static void AddProductsToShoppingCart(this ShoppingItem shoppingItem, List<ShoppingItem> list)
        {
            list.Add(shoppingItem);
        }
    }
}
