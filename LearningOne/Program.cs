using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LearningOne
{
    // we need a way to create the id number of the item DONE (might need tweaking)
    // associate a price with said item (done)
    // we need a way to see if the id is still valid (ie: specific item is never sold before) done later when checkout happens
    // be able to process returns (later down the line) (last)
    // hold many items in the same "checkout" (in progress)
    // remove items that customer does not
    // process transaction and print reciept (depth reciept)
    // ability for processors to add items to inventory 
    class ItemGeneration
    {
        public static void Main(string[] args)
        {
            creatingAllItem();
        }
        public static void creatingAllItem() // should be basically where a "processor" adds items into inventory
        {
            bool keepAdding = true;
            // containing all the valid items in a list
            string[] validItemsWomens = {"women short sleeve shirt", "women long sleeve shirt", "women jeans", "women pants", "women capris",
            "women sweater/hoodie" , "women coat", "women boutique", "women shorts"};
    
            string[] validItemsMens = {"men short sleeve shirt", "men long sleeve shirt", "men jeans", "men pants", "men capris",
            "mens sweater/hoodie" , "mens coat", "mens boutique", "mens shorts"};

            string[] validMisc = {"wares", "shoes", "toys", "accessory"};

            while (keepAdding) // the while loop will keep running until the processor runs out of things to process
            {
                // initilaizing all neccessary info
                Console.Write("Item name: ");
                string name = Console.ReadLine();
                Console.Write("Item price: ");
                double price;

                while (!double.TryParse(Console.ReadLine(), out price)) // Tryparse will try to convert the string to a double and if it fails the body of loop is executed
                {                                           // out will set the value to price once its successfult parsed
                    Console.WriteLine("Invalid input Enter Valid Number: ");
                    Console.Write("Item price: ");
                }

                Console.WriteLine("Pess esc to stop adding items, anything else to continue");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape) //AAAAHHHHHHHH figure this shit out cuh
                {
                    keepAdding = false;
                }
                // if statements deal with checking inventory and such, probably a more efficient way to check this
                if (name.StartsWith("women") && isValid(name, validItemsWomens)) {
                    ItemInfo newItem = new ItemInfo(name, price);
                    inventory(newItem);
                } else if (name.StartsWith("men") && isValid(name, validItemsMens))
                {
                    ItemInfo newItem = new ItemInfo(name, price);
                    inventory(newItem);
                } else if (isValid(name, validMisc))
                {
                    ItemInfo newItem = new ItemInfo(name, price);
                    inventory(newItem);
                }else
                {
                    Console.WriteLine("Item is invalid try again: ");
                }
            }
        }
        public static bool isValid(string item, string[] list) // a basic linear search where we check if the item is inside the valid items list
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (item == list[i])
                {
                    return true;
                }
            }

            return false;
        }
        public static void inventory(ItemInfo item) // would it be techincally better to hold it in a file? so that said updated file can be fed to a seperate class where the check out happens
        {
            Dictionary<int, string> storage = new Dictionary<int, string>(); // creating the dictionary
            string itemToStore = item.getName(); // the name of the item to store is held here
            int itemID = item.generateId(); // we generate the id here
            
            if (storage.ContainsKey(itemID)) { // we checking to see if the key (id) is already in the dictionary
                itemID++; // if it is then we will increment said key by one to indicate the new item
            }
            
            storage.Add(itemID, itemToStore); // storing the id as the key and the name as the 

            Console.WriteLine("Item: " + itemToStore + " Price: " + item.getPrice() + " Id: " + itemID); // a basic to string to see if everything is working.
        }
    }
}