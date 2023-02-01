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
    Console.WriteLine("1: Todays Picture\n2: APOD of specified Date\n3: Random APODs\n4: All APODs during specefied time\n5: Change current API key\n6: View currently cached anwsers\n7: Exit Application\n");
    int choice = 0;
    int.TryParse(Console.ReadLine().Trim(), out choice);
    switch(choice)
    {
        case 1:
        APODRequester(new APODRequest(), client, CachedAnswers);
        break;
        case 2:
        APODRequester(new DateRequest(), client, CachedAnswers);
        break;
        case 3:
        APODRequester(new RandomRequest(), client, CachedAnswers);
        break;
        case 4:
        APODRequester(new RangeRequest(), client, CachedAnswers);
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
        case 6:
        new Viewer(CachedAnswers);
        
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
    try
    {
        listCache.Add(JsonSerializer.Deserialize<APODResponse>(localResponse.Content));
    } catch
    {
        List<APODResponse> tempList = JsonSerializer.Deserialize<List<APODResponse>>(localResponse.Content);
        foreach(APODResponse tmpContent in tempList)
        {
            listCache.Add(tmpContent);
        }
    }
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




