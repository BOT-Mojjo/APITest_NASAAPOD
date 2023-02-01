using System;
using System.Net;
using System.Text.Json.Serialization;
using RestSharp;
public class APODRequest
{
    static public string apiKey = "";
    protected string endPoint = "apod?api_key=";// + apiKey
    // public APODRequest(string newApiKey = "DEMO_KEY")
    // {
    //     apiKey = newApiKey;
    //     Console.WriteLine();
    // }
    public virtual string req()
    {
        return endPoint+apiKey;
    }
}

public class RandomRequest : APODRequest
{
    int count = 0;
    // public RandomRequest(string newApiKey) : base(newApiKey){}
    public override string req()
    {
        Console.Write("Amount of Pictures: ");
        if(int.TryParse(Console.ReadLine(), out count) && count != 0)
        {
            endPoint = endPoint+apiKey+"&count="+count;
            return endPoint;
        }
        Console.WriteLine("Please input a number.");
        Console.ReadLine();
        return "fail";
    }
}

public class DateRequest : APODRequest
{
    protected string date = "";

    public override string req()
    {
        date = GetDate();
        endPoint = endPoint+apiKey+"?date="+date;
        return endPoint;
    }

    protected string GetDate()
    {
        string tempDate = String.Empty;
        Console.Write("Year: ");
        tempDate += Console.ReadLine();
        Console.Write("Month: ");
        tempDate += "-"+Console.ReadLine();
        Console.Write("Day: ");
        tempDate += "-"+Console.ReadLine();

        return new String(tempDate);
    }

}

public class RangeRequest : DateRequest
{
    string endDate = "";
    public override string req()
    {
        Console.Write("First date:\n");
        date = GetDate();
        Console.Write("\nLast date:\n");
        endDate = GetDate();


        return endPoint+apiKey+"&start_date=" + date + "&end_date=" + endDate;
    }
}

public class APODResponse{
    [JsonPropertyName("copyright")]
    public string Copyright { get; set; }
    [JsonPropertyName("date")]
    public string Date { get; set; }
    [JsonPropertyName("explanation")]
    public string Explanation { get; set; }
    [JsonPropertyName("hdurl")]
    public string HDUrl { get; set; }
    [JsonPropertyName("media_type")]
    public string MediaType { get; set; }
    [JsonPropertyName("service_version")]
    public string Version { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
