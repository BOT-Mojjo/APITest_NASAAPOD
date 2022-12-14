using System;
using RestSharp;
using System.Net;
using System.Text.Json;


string apiKey = "DEMO_KEY"; 

RestClient client = new RestClient("https://api.nasa.gov/planetary/");

while(true)
{
    Console.Clear();
    Console.WriteLine(@"   _  _____   _______     ___   ___  ____  ___    ___   ___  ____  ___                      ______        __    
  / |/ / _ | / __/ _ |   / _ | / _ \/ __ \/ _ \  / _ | / _ \/  _/ / _ |___________ ___ ___  /_  __/__ ___ / /_   
 /    / __ |_\ \/ __ |  / __ |/ ___/ /_/ / // / / __ |/ ___// /  / __ / __/ __/ -_|_-<(_-<   / / / -_|_-</ __/   
/_/|_/_/ |_/___/_/ |_| /_/ |_/_/   \____/____/ /_/ |_/_/  /___/ /_/ |_\__/\__/\__/___/___/  /_/  \__/___/\__/    
");

    Console.WriteLine("Current API Key: " + apiKey);
    Console.WriteLine("1: Todays Picture\n2: APOD of specified Date\n3: Random APODs\n4: All APODs during specefied time\n5: Change current API key\n6: Exit Application\n");
    int choice = 0;
    int.TryParse(Console.ReadLine().Trim(), out choice);
    switch(choice)
    {
        case 1:
        break;
        case 5:
        while(true)
        {
            Console.Write("New API Key: ");
            string tempKey = Console.ReadLine();
            Console.WriteLine("\nConfirm \"" + tempKey + "\" as new API Key. (y/n)");
            if(Console.ReadLine().Trim().ToLower() == "y")
            {
                apiKey = tempKey;
                break;
            }
        }
        
        break;
        default:
        Console.WriteLine("Try a number 1-6.");
        break;
    }


}
// RestClient api = new("https://api.nasa.gov/planetary/");

// APODRequest test = new APODRequest();



