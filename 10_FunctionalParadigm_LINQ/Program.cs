// See https://aka.ms/new-console-template for more information
using _10_FunctionalParadigm_LINQ;
using System.Collections;

// Print the title of the book.
static void PrintProduct(ShoppingItem b)
{
    Console.WriteLine($" ProducId: {b.Id}, ProductName: {b.ProductName}, ProductCategory: {b.ProductCategory}, " +
        $"ProducPrice: {b.Price}");
}


ShoppingCartDB itemDB = new ShoppingCartDB();

// Initialize the database with some items:
AddShoppingItems(itemDB);

// Print all the items of paperbacks:
Console.WriteLine("Printing all Products from the cart: ");

// Create a new delegate object associated with the static
// method Test.PrintTitle:
itemDB.ProcessShoppingItems(PrintProduct);

// Get the average price of all shopping items by using
// a ProductsManager object:
ProductsManager totaller = new ProductsManager();

// Create a new delegate object associated with the nonstatic
// method AddItemToTotal on the object totaller:
itemDB.ProcessShoppingItems(totaller.AddItemToTotal);

Console.WriteLine("Average Items Price is: ${0:#.##}",
        totaller.AveragePrice());

Console.WriteLine("----------Printing value from the list before sorting------------");
itemDB.ProcessShoppingItems(PrintProduct);

// using anonymous function lambda expression
Console.WriteLine("----------Sorting list with products by price-----------");
itemDB.SortShoppingItems((a, b) => ((ShoppingItem)a).Price > ((ShoppingItem)b).Price);
Console.WriteLine("----------Print list with products afer sorting by price-----------");
itemDB.ProcessShoppingItems(PrintProduct);

// using anonymous function 
Console.WriteLine("Sorting product list by id");
itemDB.SortShoppingItems(delegate (object a, object b)
{
    return ((ShoppingItem)a).Id > ((ShoppingItem)b).Id;
});
Console.WriteLine("----------Print list with products afer sorting by id-----------");
itemDB.ProcessShoppingItems(PrintProduct);

// PRACTICE EXTENSIONS
ShoppingItem ShoppingItem = new ShoppingItem(14, "Laptop", "IT", 2500, true);

ExtensionForList.AddProductsToShoppingCart(ShoppingItem, itemDB.ShoppingCardItems);
ShoppingItem.AddProductsToShoppingCart(itemDB.ShoppingCardItems);

Console.WriteLine("----------Print list with products afer add some elements with extension method-----------");
itemDB.ProcessShoppingItems(PrintProduct);

// LINQ EXAMPLES
var filteredProducts = itemDB.ShoppingCardItems
    .Where(p => p.Price >= 100)
    .OrderBy(p => p.Id)
    .Select(p => p.ProductCategory + "- - -" + p.ProductName + "- - -" + p.Price);

Console.WriteLine("LINQ USE");
foreach (var product in filteredProducts)
{
    Console.WriteLine(product);
}

Console.WriteLine("-------------------------");

var filerProd = from p in itemDB.ShoppingCardItems
            where  p.Price >= 50
            orderby p.Id ascending
            select p.ProductCategory + "- - -" + p.ProductName + "- - -" + p.Price;

foreach (var product in filerProd)
{
    Console.WriteLine(product);
}

// Practice anonymous types
Console.WriteLine("------Anonymous Types--------------");
var filteredProds = itemDB.ShoppingCardItems
    .Where(p => p.Price >= 100)
    .OrderBy(p => p.Id)
    .Select(p => new { Category = p.ProductCategory,
                       ProdName = p.ProductName, 
                       Price =p.Price});
foreach(var product in filteredProds)
{
    Console.WriteLine(product.Category + " " + product.Price);
}

// Practice ofType
Console.WriteLine("--------------  Practice OfType -----------------");
ArrayList arrList = new ArrayList();
arrList.Add("Laptop");
arrList.Add(new ShoppingItem(15, "Map", "School", 340, true));
arrList.Add(new ShoppingItem(16, "Pen", "School", 15, true));
arrList.Add(new ShoppingItem(15, "Water", "Drinks", 12, true));
arrList.Add(new ShoppingItem(15, "Bread", "Food", 7, true));


var query = from p in arrList.OfType<ShoppingItem>()
            where p.ProductCategory == "School"
            select p;

foreach(var item in query)
{
    Console.WriteLine($"{ item.ProductName} -- {item.ProductCategory} --- {item.Price}");
}

Console.WriteLine("___________");
var laptops = arrList.OfType<string>();

// Initialize the book database with some test books:
static void AddShoppingItems(ShoppingCartDB shoppingDB)
{
    shoppingDB.AddShoppingItem(2, "The C Programming Language", "Books", 19.95m, true);
    shoppingDB.AddShoppingItem(1, "C# in Nutshell ", "Books", 39.95m, true);
    shoppingDB.AddShoppingItem(3, "C++ Programming Language", "Books", 129.95m, true);
    shoppingDB.AddShoppingItem(5, "The book of Wisdom", "Books", 112.00m, true);
    shoppingDB.AddShoppingItem(4, "Apples", "Food", 4.00m, true);
    shoppingDB.AddShoppingItem(8, "Oranges", "Food", 6.00m, true);
    shoppingDB.AddShoppingItem(6, "Bananas", "Food", 5.00m, true);
    shoppingDB.AddShoppingItem(7, "Bread", "Food", 8.00m, true);
    shoppingDB.AddShoppingItem(11, "Subaru Forester", "Cars", 42000m, false);
    shoppingDB.AddShoppingItem(9, "Tent", "Travel", 120.00m, true);
    shoppingDB.AddShoppingItem(10, "Sleep Bag", "Travel", 55.00m, false);
    shoppingDB.AddShoppingItem(8, "Gloves", "Clothes", 125.00m, true);
    shoppingDB.AddShoppingItem(12, "Trousers", "Clothes", 140.00m, true);
}