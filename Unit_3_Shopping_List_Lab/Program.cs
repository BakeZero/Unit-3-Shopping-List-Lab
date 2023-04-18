using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        Dictionary<string, decimal> menu = new Dictionary<string, decimal>
        {
            ["apple"] = 0.99m,
            ["banana"] = 0.59m,
            ["cauliflower"] = 1.59m,
            ["dragonfruit"] = 2.19m,
            ["elderberry"] = 1.79m,
            ["figs"] = 2.09m,
            ["grapefruit"] = 1.99m,
            ["honeydew"] = 3.49m
        };
        List<string> shoppingList = new List<string>();
        Console.WriteLine("Welcome to Chirpus Market!");
        string prompt = "y";
        do
        {
            Console.WriteLine();
            DisplayMenu(menu);
            Console.Write("What item would you like to add to your order? ");
            string item = Console.ReadLine();
            if (menu.ContainsKey(item.ToLower()))
            {
                Console.WriteLine($"Adding {item} to cart at ${menu[item]}");
                shoppingList.Add(item);
            }
            else
            {
                Console.WriteLine("Sorry, we don't have those. Please try again.");
                continue;
            }
            Console.Write("Would you like to order anything else (y/n)? ");
            prompt = Console.ReadLine();
        } while (prompt == "y");
        DisplayOrder(menu, shoppingList);
    }
    static void DisplayMenu(Dictionary<string, decimal> menu)
    {
        Console.WriteLine("Item\t\t\tPrice");
        Console.WriteLine("==============================");
        foreach (var e in menu)
        {
            //Console.WriteLine($"{e.Key}\t\t${e.Value}");
            Console.WriteLine(string.Format("{0}\t\t${1}",e.Key.ToString().PadRight(10),e.Value));
        }
        Console.WriteLine();
    }

    static void DisplayOrder(Dictionary<string, decimal> menu, List<string> cart)
    {
        decimal cost = 0.0m;
        Dictionary<string, decimal> tempDict = new Dictionary<string, decimal>();
        Console.WriteLine("\nThanks for your order!\nHere's what you got:");

        /* Sorting the cart by cost, ascending order */
        foreach (string item in cart)
        {
            tempDict.Add(item, menu[item]);
        }
        var sortedByCost = from entry in tempDict orderby entry.Value ascending select entry;
        foreach (var item in sortedByCost)
        {
            Console.WriteLine(string.Format("{0}\t\t${1}", item.Key.ToString().PadRight(10), item.Value));
            cost += item.Value;
        }

        /*
        foreach (string item in cart)
        {
            Console.WriteLine(string.Format("{0}\t\t${1}", item.ToString().PadRight(10), menu[item]));
            cost += menu[item];
        }*/
        Console.WriteLine($"Average price per item in order was ${cost / cart.Count}");
    }
}