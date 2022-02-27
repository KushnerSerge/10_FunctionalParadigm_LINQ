using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_FunctionalParadigm_LINQ
{
    public struct ShoppingItem
    {
        public int Id;
        public string ProductName;
        public string ProductCategory;
        public decimal Price;
        public bool Paid;

        public ShoppingItem(int id, string productName, string productCategory, decimal price, bool paid)
        {
            Id = id;
            ProductName = productName;
            ProductCategory = productCategory;
            Price = price;
            Paid = paid;
        }
    }

    // Declare a delegate type for processing a book:
    public delegate void ProcessShoppingItemCallback(ShoppingItem product_item);
    public class ShoppingCartDB
    {
        // List of all books in the database:
        public List<ShoppingItem> ShoppingCardItems = new List<ShoppingItem>();

   

        // Add a book to the database:
        public void AddShoppingItem(int id, string productName, string productCategory, decimal price, bool paid)
        {
            ShoppingCardItems.Add(new ShoppingItem(id, productName, productCategory, price, paid));
        }

        // Call a passed-in delegate on each paperback book to process it:
        public void ProcessShoppingItems(ProcessShoppingItemCallback processShoppingItem)
        {
            foreach (ShoppingItem b in ShoppingCardItems)
            {
                if (b.Paid)
                    // Calling the delegate:
                    processShoppingItem(b);
            }
        }

        // a new way to pass a delegate into a function
        public void SortShoppingItems(Func<object, object, bool> isAGreaterThanB)
        {
            bool swapped;
            do
            {
                swapped = false;

                for (int i = 0; i <= ShoppingCardItems.Count - 2; i++)
                {
                    if (isAGreaterThanB(ShoppingCardItems[i], ShoppingCardItems[i + 1]))
                    {
                        ShoppingItem temp = ShoppingCardItems[i];
                        ShoppingCardItems[i] = ShoppingCardItems[i + 1];
                        ShoppingCardItems[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

    }
}
