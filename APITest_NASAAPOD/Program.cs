using System;
using RestSharp;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;


string apiKey = "DEMO_KEY"; 

RestClient client = new RestClient("https://api.nasa.gov/planetary/");
List<APODResponse> CachedAnswers = new List<APODResponse>();

while(true)
{
    APODRequest.apiKey = apiKey;
    Console.Clear();
    Console.WriteLine(@"   _  _____   _______     ___   ___  ____  ___    ___   ___  ____  ___                       ______        __    
  / |/ / _ | / __/ _ |   / _ | / _ \/ __ \/ _ \  / _ | / _ \/  _/ / _ |___________ ___ ___  /_  __/__ ___ / /_   
 /    / __ |_\ \/ __ |  / __ |/ ___/ /_/ / // / / __ |/ ___// /  / __ / __/ __/ -_|_-<(_-<   / / / -_|_-</ __/   
/_/|_/_/ |_/___/_/ |_| /_/ |_/_/   \____/____/ /_/ |_/_/  /___/ /_/ |_\__/\__/\__/___/___/  /_/  \__/___/\__/    
");

    Console.WriteLine("Current API Key: " + apiKey);
    if(CachedAnswers.Count > 0){
        Console.WriteLine("Currently cached anwsers: " + CachedAnswers.Count);
    }
    Console.WriteLine("1: Todays Picture\n2: APOD of specified Date\n3: Random APODs\n4: All APODs during specefied time\n5: Change current API key\n6: Exit Application\n");
    int choice = 0;
    int.TryParse(Console.ReadLine().Trim(), out choice);
    APODRequest APODReq = null;
    switch(choice)
    {
        case 1:
        APODReq = new APODRequest();
        APODRequester(APODReq, client, CachedAnswers);
        break;
        case 2:
        APODReq = new DateRequest();
        APODRequester(APODReq, client, CachedAnswers);
        break;
        case 3:
        APODReq = new RandomRequest();
        APODRequester(APODReq, client, CachedAnswers);
        break;
        case 4:
        APODReq = new RangeRequest();
        APODRequester(APODReq, client, CachedAnswers);
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
        Console.WriteLine("what");
        break;
    }


}


//Repetative code made context generic. Handels making requests
void APODRequester(APODRequest tempRequest, RestClient localClient, List<APODResponse> listCache){
    RestResponse localResponse;
    RestRequest localRequest = new(tempRequest.req());
    localResponse = client.GetAsync(localRequest).Result;
    if(APIReturnCheck(localResponse)) return;
    listCache.Add(JsonSerializer.Deserialize<APODResponse>(localResponse.Content));
}

//To check if the returned conten exists to avoid Json deserialiser exception
bool APIReturnCheck(RestResponse tempResponse){
    if(tempResponse.StatusCode != HttpStatusCode.OK){
        Console.Clear();
        Console.WriteLine("Error, API request unsuccsessful:");
        Console.WriteLine(tempResponse.ResponseStatus);
        Console.WriteLine((int) tempResponse.StatusCode);
        return true;
    }
    return false;
}
// RestClient api = new("https://api.nasa.gov/planetary/");

// APODRequest test = new APODRequest();




