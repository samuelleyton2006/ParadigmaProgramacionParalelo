using System.Diagnostics;

var limit = 100;
string url = "https://jsonplaceholder.typicode.com/todos/";
var httpClient = new HttpClient();

var stopWatch = Stopwatch.StartNew();

for (int i = 1; i <= limit; i++)
{
    var response = await httpClient.GetAsync(url);
}

stopWatch.Stop();

Console.WriteLine(stopWatch.Elapsed);
 
