using System;
using System;

public class request
{
    string date = "";
    int count;
    string startDate = "";
    string endDate = "";
    string apiKey = "DEMO_KEY";

    public request()
    {
        req();
    }

    public void req()
    {
        string endpoint = "apod?api_key="+apiKey;
        Console.Write("Get todays APOD? y/n ");
        if(Console.ReadLine().ToLower() != "y")
        {
            
        }
    }
}
