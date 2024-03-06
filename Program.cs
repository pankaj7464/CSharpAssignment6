using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{

    /// <summary>
    /// This program asynchronously fetches content from a URL provided by the user
    /// And writes it to a file named "A.txt".
    /// </summary>
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter the URL:");
        string url = Console.ReadLine();

        string content = await FetchContentFromUrl(url);

        await WriteToFileAsync(content);

        Console.WriteLine("Content has been written to A.txt");
    }

    /// <summary>
    /// Asynchronously fetches content from the specified URL using HttpClient.
    /// </summary>
    /// <param name="url"></param>
    static async Task<string> FetchContentFromUrl(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    /// <summary>
    /// Asynchronously writes the given content to a file named "A.txt".
    /// </summary>
    /// <param name="content"></param>
    static async Task WriteToFileAsync(string content)
    {
        using (StreamWriter writer = new StreamWriter("A.txt"))
        {
            await writer.WriteAsync(content);
        }
    }
}
