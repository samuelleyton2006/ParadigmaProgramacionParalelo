using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

var limit = 100;
string url = "https://jsonplaceholder.typicode.com/todos/";
var httpClient = new HttpClient();
var requests = Enumerable.Range(1, limit).ToList();

var stopWatch = Stopwatch.StartNew();

var tasks = requests.Select(async r =>
{
    var response = await httpClient.GetAsync(url);
}).ToList();

await Task.WhenAll(tasks);

stopWatch.Stop();
Console.WriteLine(stopWatch.Elapsed);
