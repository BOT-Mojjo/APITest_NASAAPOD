using System.Text.Json.Serialization;

public class response
{
    public string title { get; set; }
    public string date { get; set; }
    public string url { get; set; }
    public string hdurl { get; set; }
    [JsonPropertyName ("media_type")]
    public string mediaType { get; set; }
    public string explanation { get; set; }
    public string copyright { get; set; }
}
