using System;
using Raylib_cs;
public class Viewer
{
    public Viewer(List<APODResponse> listCache){
        int current = 0;
        while(true){
            APODResponse currentResponse = listCache[current];
            Console.Clear();
            Console.WriteLine(currentResponse.Title);
            Console.WriteLine(currentResponse.Copyright);
            Console.WriteLine(currentResponse.Date);
            Console.WriteLine(currentResponse.Explanation);
            Console.WriteLine(currentResponse.MediaType);
            if(currentResponse.HDUrl == null)
            {
                Console.WriteLine(currentResponse.Url);
            } else {
                Console.WriteLine(currentResponse.HDUrl);
            }
            if(Console.ReadLine() == "next")
            {
                current++;
                if(current > listCache.Count) current = listCache.Count;
            } else if(Console.ReadLine() == "previous")
            {
                current--;
                if(current < 0) current = 0;
            } else if(Console.ReadLine() == "exit"){
                break;
            }
        }
    }
}
