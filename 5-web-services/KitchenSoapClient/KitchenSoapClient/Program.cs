using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenSoapClient.KitchenService;

namespace KitchenSoapClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your smart kitchen");

            using (var client = new KitchenServiceClient())
            {
                Console.WriteLine("opening fridge:");
                var items = client.LookInsideFridge();

                foreach (FridgeItem item in items)
                {
                    Console.WriteLine($"{item.Name}, expires {item.Expiration.ToShortDateString()}");
                }

                var result = client.CleanFridge();

                Console.WriteLine($"fridge needed cleaning: {result}");


                var items2 = client.LookInsideFridge();

                Console.WriteLine("opening fridge:");
                foreach (FridgeItem item in items2)
                {
                    Console.WriteLine($"{item.Name}, expires {item.Expiration.ToShortDateString()}");
                }
            }

            Console.ReadKey();
        }
    }
}
