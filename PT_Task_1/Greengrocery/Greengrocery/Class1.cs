using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold grocery items
            List<string> groceryList = new List<string>();

            // Add some items to the grocery list
            groceryList.Add("Apples");
            groceryList.Add("Bananas");
            groceryList.Add("Tomatoes");
            groceryList.Add("Onions");
            groceryList.Add("Potatoes");

            // Display the grocery list
            Console.WriteLine("My Grocery List:");
            foreach (string item in groceryList)
            {
                Console.WriteLine("- " + item);
            }

            Console.ReadLine(); // Wait for user input before closing the console window
        }
    }
}
